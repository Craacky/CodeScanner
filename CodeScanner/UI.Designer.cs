using System.Windows.Forms;

namespace WindowsFormsApp1
{
	partial class UI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UI));
			groupBox1 = new GroupBox();
			StartButton = new Button();
			controlBox = new GroupBox();
			resetStat = new Button();
			UploadDB = new Button();
			inputsBox = new GroupBox();
			gtinStatus = new TextBox();
			textBox2 = new TextBox();
			textBox1 = new TextBox();
			permissionBox = new CheckBox();
			lotMunText = new TextBox();
			lotNumBox = new TextBox();
			datetimeBox = new GroupBox();
			lotDate = new DateTimePicker();
			statusBox = new GroupBox();
			StatusBar = new TextBox();
			statisticsBox = new GroupBox();
			textBox4 = new TextBox();
			AllCodeCounter = new TextBox();
			textBox3 = new TextBox();
			NoReadCodeCounter = new TextBox();
			NoReadCodeBox = new TextBox();
			ReadCodeBox = new TextBox();
			groupBox1.SuspendLayout();
			controlBox.SuspendLayout();
			inputsBox.SuspendLayout();
			datetimeBox.SuspendLayout();
			statusBox.SuspendLayout();
			statisticsBox.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(StartButton);
			groupBox1.Location = new System.Drawing.Point(43, 26);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(271, 68);
			groupBox1.TabIndex = 33;
			groupBox1.TabStop = false;
			groupBox1.Text = "Начало";
			// 
			// StartButton
			// 
			StartButton.Cursor = Cursors.Hand;
			StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			StartButton.Location = new System.Drawing.Point(39, 28);
			StartButton.Margin = new Padding(3, 4, 3, 4);
			StartButton.Name = "StartButton";
			StartButton.Size = new System.Drawing.Size(170, 20);
			StartButton.TabIndex = 1;
			StartButton.Text = "1.Старт";
			StartButton.UseVisualStyleBackColor = true;
			StartButton.Click += StartButton_Click_1;
			// 
			// controlBox
			// 
			controlBox.Controls.Add(resetStat);
			controlBox.Controls.Add(UploadDB);
			controlBox.Location = new System.Drawing.Point(43, 459);
			controlBox.Name = "controlBox";
			controlBox.Size = new System.Drawing.Size(530, 58);
			controlBox.TabIndex = 32;
			controlBox.TabStop = false;
			controlBox.Text = "Управление";
			// 
			// resetStat
			// 
			resetStat.Cursor = Cursors.Hand;
			resetStat.Location = new System.Drawing.Point(332, 20);
			resetStat.Margin = new Padding(3, 4, 3, 4);
			resetStat.Name = "resetStat";
			resetStat.Size = new System.Drawing.Size(150, 24);
			resetStat.TabIndex = 14;
			resetStat.Text = "5.Сброс статистики";
			resetStat.UseVisualStyleBackColor = true;
			// 
			// UploadDB
			// 
			UploadDB.Cursor = Cursors.Hand;
			UploadDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			UploadDB.Location = new System.Drawing.Point(31, 20);
			UploadDB.Margin = new Padding(3, 4, 3, 4);
			UploadDB.Name = "UploadDB";
			UploadDB.Size = new System.Drawing.Size(154, 24);
			UploadDB.TabIndex = 10;
			UploadDB.Text = "4. Записать файл";
			UploadDB.UseVisualStyleBackColor = true;
			// 
			// inputsBox
			// 
			inputsBox.BackColor = System.Drawing.SystemColors.ButtonFace;
			inputsBox.Controls.Add(gtinStatus);
			inputsBox.Controls.Add(textBox2);
			inputsBox.Controls.Add(textBox1);
			inputsBox.Controls.Add(permissionBox);
			inputsBox.Controls.Add(lotMunText);
			inputsBox.Controls.Add(lotNumBox);
			inputsBox.Location = new System.Drawing.Point(43, 176);
			inputsBox.Name = "inputsBox";
			inputsBox.Size = new System.Drawing.Size(532, 87);
			inputsBox.TabIndex = 31;
			inputsBox.TabStop = false;
			inputsBox.Text = "Исходные данные";
			// 
			// gtinStatus
			// 
			gtinStatus.BorderStyle = BorderStyle.FixedSingle;
			gtinStatus.Cursor = Cursors.No;
			gtinStatus.Location = new System.Drawing.Point(343, 54);
			gtinStatus.Margin = new Padding(3, 4, 3, 4);
			gtinStatus.Name = "gtinStatus";
			gtinStatus.ReadOnly = true;
			gtinStatus.Size = new System.Drawing.Size(163, 20);
			gtinStatus.TabIndex = 3;
			gtinStatus.TextAlign = HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			textBox2.AccessibleRole = AccessibleRole.TitleBar;
			textBox2.BorderStyle = BorderStyle.None;
			textBox2.Cursor = Cursors.No;
			textBox2.Location = new System.Drawing.Point(6, 56);
			textBox2.Margin = new Padding(3, 4, 3, 4);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new System.Drawing.Size(110, 13);
			textBox2.TabIndex = 21;
			textBox2.Text = "3. GTIN";
			// 
			// textBox1
			// 
			textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
			textBox1.Cursor = Cursors.IBeam;
			textBox1.Location = new System.Drawing.Point(122, 53);
			textBox1.MaxLength = 14;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(194, 20);
			textBox1.TabIndex = 20;
			// 
			// permissionBox
			// 
			permissionBox.AutoSize = true;
			permissionBox.Cursor = Cursors.Hand;
			permissionBox.Location = new System.Drawing.Point(343, 18);
			permissionBox.Name = "permissionBox";
			permissionBox.Size = new System.Drawing.Size(140, 17);
			permissionBox.TabIndex = 18;
			permissionBox.Text = "Блокировка измнений";
			permissionBox.UseVisualStyleBackColor = true;
			// 
			// lotMunText
			// 
			lotMunText.AccessibleRole = AccessibleRole.TitleBar;
			lotMunText.BorderStyle = BorderStyle.None;
			lotMunText.Cursor = Cursors.No;
			lotMunText.Location = new System.Drawing.Point(6, 20);
			lotMunText.Margin = new Padding(3, 4, 3, 4);
			lotMunText.Name = "lotMunText";
			lotMunText.ReadOnly = true;
			lotMunText.Size = new System.Drawing.Size(110, 13);
			lotMunText.TabIndex = 16;
			lotMunText.Text = "2. Номер партии";
			// 
			// lotNumBox
			// 
			lotNumBox.BackColor = System.Drawing.SystemColors.MenuBar;
			lotNumBox.Cursor = Cursors.IBeam;
			lotNumBox.Location = new System.Drawing.Point(122, 16);
			lotNumBox.MaxLength = 4;
			lotNumBox.Name = "lotNumBox";
			lotNumBox.Size = new System.Drawing.Size(194, 20);
			lotNumBox.TabIndex = 15;
			// 
			// datetimeBox
			// 
			datetimeBox.Controls.Add(lotDate);
			datetimeBox.FlatStyle = FlatStyle.Flat;
			datetimeBox.Location = new System.Drawing.Point(320, 26);
			datetimeBox.Name = "datetimeBox";
			datetimeBox.Size = new System.Drawing.Size(253, 68);
			datetimeBox.TabIndex = 30;
			datetimeBox.TabStop = false;
			datetimeBox.Text = "Дата";
			// 
			// lotDate
			// 
			lotDate.Cursor = Cursors.Hand;
			lotDate.Location = new System.Drawing.Point(29, 28);
			lotDate.Name = "lotDate";
			lotDate.Size = new System.Drawing.Size(200, 20);
			lotDate.TabIndex = 17;
			// 
			// statusBox
			// 
			statusBox.Controls.Add(StatusBar);
			statusBox.FlatStyle = FlatStyle.Flat;
			statusBox.Location = new System.Drawing.Point(43, 100);
			statusBox.Name = "statusBox";
			statusBox.Size = new System.Drawing.Size(532, 54);
			statusBox.TabIndex = 29;
			statusBox.TabStop = false;
			statusBox.Text = "Статус";
			// 
			// StatusBar
			// 
			StatusBar.BorderStyle = BorderStyle.FixedSingle;
			StatusBar.Cursor = Cursors.No;
			StatusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			StatusBar.Location = new System.Drawing.Point(39, 20);
			StatusBar.Margin = new Padding(3, 4, 3, 4);
			StatusBar.Name = "StatusBar";
			StatusBar.ReadOnly = true;
			StatusBar.Size = new System.Drawing.Size(451, 20);
			StatusBar.TabIndex = 2;
			StatusBar.TextAlign = HorizontalAlignment.Center;
			// 
			// statisticsBox
			// 
			statisticsBox.BackgroundImageLayout = ImageLayout.Center;
			statisticsBox.Controls.Add(textBox4);
			statisticsBox.Controls.Add(AllCodeCounter);
			statisticsBox.Controls.Add(textBox3);
			statisticsBox.Controls.Add(NoReadCodeCounter);
			statisticsBox.Controls.Add(NoReadCodeBox);
			statisticsBox.Controls.Add(ReadCodeBox);
			statisticsBox.Location = new System.Drawing.Point(43, 285);
			statisticsBox.Name = "statisticsBox";
			statisticsBox.Size = new System.Drawing.Size(530, 153);
			statisticsBox.TabIndex = 28;
			statisticsBox.TabStop = false;
			statisticsBox.Text = "Статистика";
			// 
			// textBox4
			// 
			textBox4.AccessibleRole = AccessibleRole.TitleBar;
			textBox4.BorderStyle = BorderStyle.None;
			textBox4.Cursor = Cursors.No;
			textBox4.Location = new System.Drawing.Point(6, 72);
			textBox4.Margin = new Padding(3, 4, 3, 4);
			textBox4.Name = "textBox4";
			textBox4.ReadOnly = true;
			textBox4.Size = new System.Drawing.Size(110, 13);
			textBox4.TabIndex = 24;
			textBox4.Text = "Прочитано кодов";
			// 
			// AllCodeCounter
			// 
			AllCodeCounter.BorderStyle = BorderStyle.FixedSingle;
			AllCodeCounter.Cursor = Cursors.No;
			AllCodeCounter.Location = new System.Drawing.Point(165, 33);
			AllCodeCounter.Margin = new Padding(3, 4, 3, 4);
			AllCodeCounter.Name = "AllCodeCounter";
			AllCodeCounter.ReadOnly = true;
			AllCodeCounter.Size = new System.Drawing.Size(317, 20);
			AllCodeCounter.TabIndex = 23;
			// 
			// textBox3
			// 
			textBox3.AccessibleRole = AccessibleRole.TitleBar;
			textBox3.BorderStyle = BorderStyle.None;
			textBox3.Cursor = Cursors.No;
			textBox3.Location = new System.Drawing.Point(6, 35);
			textBox3.Margin = new Padding(3, 4, 3, 4);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(110, 13);
			textBox3.TabIndex = 22;
			textBox3.Text = "Всего кодов";
			// 
			// NoReadCodeCounter
			// 
			NoReadCodeCounter.BorderStyle = BorderStyle.FixedSingle;
			NoReadCodeCounter.Cursor = Cursors.No;
			NoReadCodeCounter.Location = new System.Drawing.Point(165, 107);
			NoReadCodeCounter.Margin = new Padding(3, 4, 3, 4);
			NoReadCodeCounter.Name = "NoReadCodeCounter";
			NoReadCodeCounter.ReadOnly = true;
			NoReadCodeCounter.Size = new System.Drawing.Size(317, 20);
			NoReadCodeCounter.TabIndex = 9;
			// 
			// NoReadCodeBox
			// 
			NoReadCodeBox.BorderStyle = BorderStyle.None;
			NoReadCodeBox.Cursor = Cursors.No;
			NoReadCodeBox.Location = new System.Drawing.Point(6, 110);
			NoReadCodeBox.Margin = new Padding(3, 4, 3, 4);
			NoReadCodeBox.Name = "NoReadCodeBox";
			NoReadCodeBox.ReadOnly = true;
			NoReadCodeBox.Size = new System.Drawing.Size(144, 13);
			NoReadCodeBox.TabIndex = 8;
			NoReadCodeBox.Text = "Не прочитано кодов";
			// 
			// ReadCodeBox
			// 
			ReadCodeBox.BorderStyle = BorderStyle.FixedSingle;
			ReadCodeBox.Cursor = Cursors.No;
			ReadCodeBox.Location = new System.Drawing.Point(165, 70);
			ReadCodeBox.Margin = new Padding(3, 4, 3, 4);
			ReadCodeBox.Name = "ReadCodeBox";
			ReadCodeBox.ReadOnly = true;
			ReadCodeBox.Size = new System.Drawing.Size(317, 20);
			ReadCodeBox.TabIndex = 7;
			// 
			// UI
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.ButtonFace;
			ClientSize = new System.Drawing.Size(616, 547);
			Controls.Add(groupBox1);
			Controls.Add(controlBox);
			Controls.Add(inputsBox);
			Controls.Add(datetimeBox);
			Controls.Add(statusBox);
			Controls.Add(statisticsBox);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(3, 4, 3, 4);
			Name = "UI";
			Text = "Code Scanner";
			FormClosing += Form1_FormClosing;
			Load += UI_Load;
			groupBox1.ResumeLayout(false);
			controlBox.ResumeLayout(false);
			inputsBox.ResumeLayout(false);
			inputsBox.PerformLayout();
			datetimeBox.ResumeLayout(false);
			statusBox.ResumeLayout(false);
			statusBox.PerformLayout();
			statisticsBox.ResumeLayout(false);
			statisticsBox.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private Button StartButton;
		private GroupBox controlBox;
		private Button resetStat;
		private Button UploadDB;
		private GroupBox inputsBox;
		private TextBox gtinStatus;
		private TextBox textBox2;
		private TextBox textBox1;
		private CheckBox permissionBox;
		private TextBox lotMunText;
		private TextBox lotNumBox;
		private GroupBox datetimeBox;
		private DateTimePicker lotDate;
		private GroupBox statusBox;
		private TextBox StatusBar;
		private GroupBox statisticsBox;
		private TextBox textBox4;
		public TextBox AllCodeCounter;
		private TextBox textBox3;
		public TextBox NoReadCodeCounter;
		private TextBox NoReadCodeBox;
		public TextBox ReadCodeBox;
	}
}