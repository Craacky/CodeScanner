using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1
{
    public partial class UI : Form
    {
        private readonly Camera _camera;
        readonly OpenFileDialog openFileDialog = new();
        private static string _camera_ip;
        private static int _camera_port;
        private bool _subscribedNotify;
        static readonly string appDataFolderPath = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData
        );
        static readonly string appFolderPath = Path.Combine(appDataFolderPath, "Code Scanner");
        static readonly string configFilePath = Path.Combine(appFolderPath, "config.json");
        static readonly string scannedCodeFolderPath = Path.Combine(appFolderPath, "Scanned Codes");
        static readonly string scannedCodeArchiveFolderPath = Path.Combine(
            appFolderPath,
            "Total Scanned Codes"
        );

        public static string Camera_ip
        {
            get => _camera_ip;
            set => _camera_ip = value;
        }
        public static int Camera_port
        {
            get => _camera_port;
            set => _camera_port = value;
        }

        public UI()
        {
            string fileContent = File.ReadAllText(configFilePath);
            dynamic settings = JsonConvert.DeserializeObject(fileContent);
            Camera_port = settings.cameraPort;
            Camera_ip = settings.cameraIp;
            if (Camera_ip.Equals("0.0.0.0") && Camera_port.Equals(0))
            {
                DialogResult choice = MessageBox.Show(
                    "Конфиругационный фалй пустой! Заполните его!",
                    "Если всё понятно, нажмите OK",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                if (choice == DialogResult.OK)
                {
                    Environment.Exit(0);
                    System.Windows.Forms.Application.Exit();
                }
            }

            InitializeComponent();
            _camera = new Camera(Camera_ip, Camera_port, this);

            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Camera_Notify(string message)
        {
            using ApplicationContextBuffer db_buffer = new();
            using ApplicationContextArchive db_archive = new();
            if (message != "fail")
            {
                db_buffer.Buffer.Add(new DatabaseTemplate { MarkingCode = message });
                db_buffer.SaveChanges();

                db_archive.Archive.Add(new DatabaseTemplate { MarkingCode = message });
                db_archive.SaveChanges();
            }
        }

        private void StartButton_Click_1(object sender, EventArgs e)
        {
            StatusBar.ReadOnly = true;
            StatusBar.BackColor = Color.LightGreen;
            _camera.Connect();
            StatusBar.Text = "Работа начата";
            if (!_subscribedNotify)
            {
                _camera.Notify += Camera_Notify;
                _subscribedNotify = true;
            }
        }

        class Camera
        {
            private readonly string _ip;
            private readonly int _port = Camera_port;
            private TcpClient _client;
            private NetworkStream _stream;

            public delegate void NewMessage(string message);

            public event NewMessage Notify;

            public float AllCode = 0;
            public float codeRead = 0;
            public float codeNoRead = 0;
            public float percentRead = 0;
            public float percentNoRead = 0;
            private readonly UI _form;

            public Camera(string ip, int port, UI form)
            {
                _form = form;
                _ip = ip;
                _port = port;
            }

            public void Connect()
            {
                try
                {
                    _client = new TcpClient();
                    _client.Connect(_ip, _port);
                    _stream = _client.GetStream();
                    Thread receivethread = new(new ThreadStart(ReceiveMessage));
                    receivethread.Start();
                }
                catch (Exception)
                {
                    _form.StatusBar.BackColor = Color.Red;
                    _form.StatusBar.Text = "Ошибка программы";
                    MessageBox.Show("Проверьте конфигурационный файл!", "Ошибка программы");
                    Environment.Exit(0);
                }
            }

            private static bool Pinger(string ip)
            {
                Ping ping = null;
                bool result = false;
                try
                {
                    ping = new Ping();
                    PingReply reply = ping.Send(ip);
                    result = reply.Status == IPStatus.Success;
                }
                catch (Exception) { }
                finally
                {
                    ping?.Dispose();
                }

                return result;
            }

            public void ReceiveMessage()
            {
                while (true)
                {
                    try
                    {
                        while (_client.Connected == false)
                        {
                            Camera camera = new(Camera_ip, Camera_port, _form);
                            camera.Disconnect();

                            DialogResult diagnostic_message = MessageBox.Show(
                                "Потеря соединения с камерой. \n 1. Проверьте соединение сетевого кабеля с компьютером"
                                    + "\n 2. Проверьте соединение сетевого кабеля в камере \n 3. Проверьте соединение сетевого кабеля в комутаторе \n\n"
                                    + "После выполнения всех пунктов нажмите кнопку ОК",
                                "Yes OR No",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );

                            if (diagnostic_message == DialogResult.OK)
                            {
                                if (Pinger(Camera_ip))
                                {
                                    _form.StartButton_Click_1(new object(), new EventArgs());
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                    try
                    {
                        byte[] data = new byte[128]; // буфер для получаемых данных

                        StringBuilder builder = new();
                        int bytes = 0;
                        do
                        {
                            bytes = _stream.Read(data, 0, data.Length);
                            builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                        } while (_stream.DataAvailable);

                        var message = builder.ToString();
                        var isEmpty = string.IsNullOrEmpty(message);

                        if (!message.Contains("fail") && !isEmpty)
                        {
                            AllCode += 1;
                            codeRead += 1;
                        }
                        if (isEmpty || message.Contains("fail"))
                        {
                            AllCode += 1;
                            codeNoRead += 1;
                        }

                        percentRead = (codeRead / AllCode) * 100;
                        percentNoRead = (codeNoRead / AllCode) * 100;

                        _form.AllCodeCounter.BeginInvoke(
                            (MethodInvoker)(
                                () => _form.AllCodeCounter.Text = "Всего " + AllCode + " кодов"
                            )
                        );
                        _form.ReadCodeBox.BeginInvoke(
                            (MethodInvoker)(
                                () =>
                                    _form.ReadCodeBox.Text =
                                        "Всего прочитано - "
                                        + codeRead
                                        + " кодов - "
                                        + percentRead.ToString("F2")
                                        + "%"
                            )
                        );
                        _form.NoReadCodeCounter.BeginInvoke(
                            (MethodInvoker)(
                                () =>
                                    _form.NoReadCodeCounter.Text =
                                        "Всего не прочитано - "
                                        + codeNoRead
                                        + " кодов - "
                                        + percentNoRead.ToString("F2")
                                        + "%"
                            )
                        );
                        Notify(message);
                    }
                    catch
                    {
                        Disconnect();
                    }
                }
            }

            public void Disconnect()
            {
                _stream?.Close(); //отключение потока
                _client?.Close(); //отключение клиента
            }
        }

        public static bool CheckString(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                if (char.IsLetter(str[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static string ExtractBetweenTags(string text, string startTag, string endTag)
        {
            int startIndex = text.IndexOf(startTag) + startTag.Length;
            int endIndex = text.IndexOf(endTag);

            if (startIndex < 0 || endIndex < 0)
            {
                return string.Empty; // Not found
            }

            return text.Substring(startIndex, endIndex - startIndex);
        }

        private void UploadDB_Click(object sender, EventArgs e)
        {
            StatusBar.Clear();
            StatusBar.BackColor = Color.White;
            string lotNumber;
            string inputGTIN;
            lotNumber = lotNumBox.Text.ToString();
            inputGTIN = textBox1.Text.ToString();

            if (lotNumber.Equals(""))
            {
                MessageBox.Show("Введите номер партии");
                return;
            }

            ApplicationContextBuffer db = new();
            if (!db.Buffer.Select(m => m.MarkingCode).Any())
            {
                MessageBox.Show("Ошибка в создании отчета. База данных пуста");
                return;
            }

            var firstCode = db.Buffer.Select(m => m.MarkingCode).First();
            var gtin = ExtractBetweenTags(firstCode, "<start>", "<end>");

            if (CheckString(gtin))
            {
                MessageBox.Show("Считанный код содержит буквы.");
            }
            if (inputGTIN.Equals(gtin))
            {
                gtinStatus.BackColor = Color.LightGreen;
                gtinStatus.Text = "GTIN коды совпали";
            }
            else
            {
                gtinStatus.BackColor = Color.Red;
                gtinStatus.Text = "GTIN коды не совпали";
            }

            String archiveFilename =
                scannedCodeArchiveFolderPath
                + "\\"
                + gtin
                + '_'
                + lotDate.Value.ToString("MM")
                + '.'
                + lotDate.Value.ToString("dd")
                + '.'
                + lotDate.Value.ToString("yy")
                + '_'
                + lotNumber
                + ".txt";
            FileStream fileArchive = new(scannedCodeArchiveFolderPath, FileMode.OpenOrCreate);
            StreamWriter writerArchive = new(fileArchive, Encoding.UTF8);

            var listDBArchive = db.Buffer.Select(m => m.MarkingCode).ToList();
            var counter = 0;
            foreach (var vals in listDBArchive)
            {
                if (!vals.Contains("fail"))
                {
                    writerArchive.WriteLine(ExtractBetweenTags(vals, "<start>", "<end>"));
                    counter++;
                }
            }
            writerArchive.Close();

            String filename =
                scannedCodeFolderPath
                + "\\"
                + gtin
                + '_'
                + lotDate.Value.ToString("MM")
                + '.'
                + lotDate.Value.ToString("dd")
                + '.'
                + lotDate.Value.ToString("yy")
                + '_'
                + lotNumber
                + ".txt";

            FileStream file = new(filename, FileMode.OpenOrCreate);
            StreamWriter writer = new(file, Encoding.UTF8);

            var listDB = db.Buffer.Select(m => m.MarkingCode).Distinct().ToList();
            foreach (var vals in listDB)
            {
                if (!vals.Contains("fail"))
                {
                    writer.WriteLine(
                        ExtractBetweenTags(vals, "<start>", "<end>") + "\tКоличество:" + counter
                    );
                }
            }
            writer.Close();

            StatusBar.BackColor = Color.LightGreen;
            StatusBar.Text = "База данных выгружена в файл";

            DialogResult choice = MessageBox.Show(
                "Вы уверенны что хотите очистить буферную базу данных ?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            StatusBar.Clear();
            StatusBar.BackColor = Color.White;

            if (choice == DialogResult.Yes)
            {
                db.Database.ExecuteSqlRaw("TRUNCATE TABLE [buffer]");
                StatusBar.BackColor = Color.LightGreen;
                StatusBar.Text = "Буферная база данных очищена";
            }
            else if (choice == DialogResult.No)
            {
                StatusBar.BackColor = Color.LightGreen;
                StatusBar.Text = "Буферная база данных не очищена";
                return;
            }
        }

        private void ResetStat_Click(object sender, EventArgs e)
        {
            if (_subscribedNotify)
            {
                _camera.Notify -= Camera_Notify;
                _subscribedNotify = false;
            }
            StatusBar.Clear();
            StatusBar.BackColor = Color.White;
            AllCodeCounter.Clear();
            ReadCodeBox.Clear();
            NoReadCodeCounter.Clear();
            _camera.AllCode = 0;
            _camera.codeRead = 0;
            _camera.codeNoRead = 0;
            StatusBar.BackColor = Color.LightGreen;
            StatusBar.Text = "Статистика сброшена. Камера готова к работе";
        }

        private void LotNumBox_TextChanged(object sender, EventArgs e)
        {
            StatusBar.Clear();
            StatusBar.BackColor = Color.White;
        }

        private void LotNumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
            if (permissionBox.Checked)
            {
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
            System.Windows.Forms.Application.Exit();
        }

        private void UI_Load(object sender, EventArgs e)
        {
            StartButton.BeginInvoke(new MethodInvoker(() => StartButton.Select()));
        }
    }
}
