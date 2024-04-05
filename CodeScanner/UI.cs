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
        static readonly string appFolderPath = Path.Combine(appDataFolderPath, "App_Code_Scanner");
        readonly string configFilePath = Path.Combine(appFolderPath, "config.txt");

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
            if (!Directory.Exists(appFolderPath))
            {
                Directory.CreateDirectory(appFolderPath);
            }
            if (!File.Exists(configFilePath))
            {
                File.Create(configFilePath);
            }
            string Port_line;
            using (StreamReader reader = new(configFilePath))
            {
                Camera_ip = reader.ReadLine();
                Port_line = reader.ReadLine();
                Camera_port = int.Parse(Port_line);
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
                var model = new DatabaseTemplate { MarkingCode = message };
                db_buffer.Buffer.Add(model);
                db_buffer.SaveChanges();

                db_archive.Archive.Add(model);
                db_archive.SaveChanges();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Ошибка программы. Проверьте конфигурационный файл");
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
                                    _form.StartButton_Click(new object(), new EventArgs());
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
                        else if (message.Contains("fail") && isEmpty)
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
            var gtin = firstCode.Substring(5, 22);
            gtin = gtin[2..];

            string folder_path = Path.Combine(appFolderPath, "scanned_codes");
            if (!Directory.Exists(folder_path))
            {
                Directory.CreateDirectory(folder_path);
            }

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

            String filename =
                folder_path
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
                    writer.WriteLine(vals.Substring(7, 20));
            }
            writer.Close();

            StatusBar.BackColor = Color.LightGreen;
            StatusBar.Text = "База данных выгружена в файл";

            DialogResult choice = MessageBox.Show(
                "Вы уверенны что хотите очистить буферную базу данных ?",
                "Yes OR No",
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
            StatusBar.Text = "Статистика сброшена. Начните с начала.";
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
            Application.Exit();
        }
    }
}
