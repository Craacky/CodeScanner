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
			StartButton = new System.Windows.Forms.Button();
			StatusBar = new System.Windows.Forms.TextBox();
			AllCodesBox = new System.Windows.Forms.TextBox();
			AllCodeCounter = new System.Windows.Forms.TextBox();
			ReadCodeCounter = new System.Windows.Forms.TextBox();
			ReadCodeBox = new System.Windows.Forms.TextBox();
			NoReadCodeBox = new System.Windows.Forms.TextBox();
			NoReadCodeCounter = new System.Windows.Forms.TextBox();
			UploadDB = new System.Windows.Forms.Button();
			resetStat = new System.Windows.Forms.Button();
			lotNumBox = new System.Windows.Forms.TextBox();
			lotMunText = new System.Windows.Forms.TextBox();
			lotDate = new System.Windows.Forms.DateTimePicker();
			permissionBox = new System.Windows.Forms.CheckBox();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			statisticsBox = new System.Windows.Forms.GroupBox();
			statusBox = new System.Windows.Forms.GroupBox();
			datetimeBox = new System.Windows.Forms.GroupBox();
			inputsBox = new System.Windows.Forms.GroupBox();
			gtinStatus = new System.Windows.Forms.TextBox();
			controlBox = new System.Windows.Forms.GroupBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			statisticsBox.SuspendLayout();
			statusBox.SuspendLayout();
			datetimeBox.SuspendLayout();
			inputsBox.SuspendLayout();
			controlBox.SuspendLayout();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// StartButton
			// 
			StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			StartButton.Location = new System.Drawing.Point(36, 19);
			StartButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			StartButton.Name = "StartButton";
			StartButton.Size = new System.Drawing.Size(170, 20);
			StartButton.TabIndex = 1;
			StartButton.Text = "1.Старт";
			StartButton.UseVisualStyleBackColor = true;
			StartButton.Click += StartButton_Click;
			// 
			// StatusBar
			// 
			StatusBar.Location = new System.Drawing.Point(31, 20);
			StatusBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			StatusBar.Name = "StatusBar";
			StatusBar.ReadOnly = true;
			StatusBar.Size = new System.Drawing.Size(451, 20);
			StatusBar.TabIndex = 2;
			StatusBar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// AllCodesBox
			// 
			AllCodesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			AllCodesBox.Location = new System.Drawing.Point(6, 33);
			AllCodesBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			AllCodesBox.Name = "AllCodesBox";
			AllCodesBox.ReadOnly = true;
			AllCodesBox.Size = new System.Drawing.Size(110, 13);
			AllCodesBox.TabIndex = 4;
			AllCodesBox.Text = "Всего кодов";
			// 
			// AllCodeCounter
			// 
			AllCodeCounter.Location = new System.Drawing.Point(165, 33);
			AllCodeCounter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			AllCodeCounter.Name = "AllCodeCounter";
			AllCodeCounter.ReadOnly = true;
			AllCodeCounter.Size = new System.Drawing.Size(317, 20);
			AllCodeCounter.TabIndex = 5;
			AllCodeCounter.Text = " ";
			// 
			// ReadCodeCounter
			// 
			ReadCodeCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			ReadCodeCounter.Location = new System.Drawing.Point(6, 70);
			ReadCodeCounter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			ReadCodeCounter.Name = "ReadCodeCounter";
			ReadCodeCounter.ReadOnly = true;
			ReadCodeCounter.Size = new System.Drawing.Size(119, 13);
			ReadCodeCounter.TabIndex = 6;
			ReadCodeCounter.Text = "Прочитано кодов";
			// 
			// ReadCodeBox
			// 
			ReadCodeBox.Location = new System.Drawing.Point(165, 70);
			ReadCodeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			ReadCodeBox.Name = "ReadCodeBox";
			ReadCodeBox.ReadOnly = true;
			ReadCodeBox.Size = new System.Drawing.Size(317, 20);
			ReadCodeBox.TabIndex = 7;
			// 
			// NoReadCodeBox
			// 
			NoReadCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			NoReadCodeBox.Location = new System.Drawing.Point(6, 110);
			NoReadCodeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			NoReadCodeBox.Name = "NoReadCodeBox";
			NoReadCodeBox.ReadOnly = true;
			NoReadCodeBox.Size = new System.Drawing.Size(144, 13);
			NoReadCodeBox.TabIndex = 8;
			NoReadCodeBox.Text = "Не прочитано кодов";
			// 
			// NoReadCodeCounter
			// 
			NoReadCodeCounter.Location = new System.Drawing.Point(165, 107);
			NoReadCodeCounter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			NoReadCodeCounter.Name = "NoReadCodeCounter";
			NoReadCodeCounter.ReadOnly = true;
			NoReadCodeCounter.Size = new System.Drawing.Size(317, 20);
			NoReadCodeCounter.TabIndex = 9;
			// 
			// UploadDB
			// 
			UploadDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			UploadDB.Location = new System.Drawing.Point(31, 20);
			UploadDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			UploadDB.Name = "UploadDB";
			UploadDB.Size = new System.Drawing.Size(119, 24);
			UploadDB.TabIndex = 10;
			UploadDB.Text = "4. Записать файл";
			UploadDB.UseVisualStyleBackColor = true;
			UploadDB.Click += UploadDB_Click;
			// 
			// resetStat
			// 
			resetStat.Location = new System.Drawing.Point(354, 20);
			resetStat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			resetStat.Name = "resetStat";
			resetStat.Size = new System.Drawing.Size(128, 24);
			resetStat.TabIndex = 14;
			resetStat.Text = "5.Сброс статистики";
			resetStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			resetStat.UseVisualStyleBackColor = true;
			resetStat.Click += ResetStat_Click;
			// 
			// lotNumBox
			// 
			lotNumBox.BackColor = System.Drawing.SystemColors.MenuBar;
			lotNumBox.Location = new System.Drawing.Point(122, 16);
			lotNumBox.MaxLength = 4;
			lotNumBox.Name = "lotNumBox";
			lotNumBox.Size = new System.Drawing.Size(194, 20);
			lotNumBox.TabIndex = 15;
			lotNumBox.TextChanged += LotNumBox_TextChanged;
			lotNumBox.KeyPress += LotNumBox_KeyPress;
			// 
			// lotMunText
			// 
			lotMunText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			lotMunText.Location = new System.Drawing.Point(6, 20);
			lotMunText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			lotMunText.Name = "lotMunText";
			lotMunText.ReadOnly = true;
			lotMunText.Size = new System.Drawing.Size(110, 13);
			lotMunText.TabIndex = 16;
			lotMunText.Text = "2. Номер партии";
			// 
			// lotDate
			// 
			lotDate.Location = new System.Drawing.Point(23, 19);
			lotDate.Name = "lotDate";
			lotDate.Size = new System.Drawing.Size(200, 20);
			lotDate.TabIndex = 17;
			// 
			// permissionBox
			// 
			permissionBox.AutoSize = true;
			permissionBox.Location = new System.Drawing.Point(332, 18);
			permissionBox.Name = "permissionBox";
			permissionBox.Size = new System.Drawing.Size(140, 17);
			permissionBox.TabIndex = 18;
			permissionBox.Text = "Блокировка измнений";
			permissionBox.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
			textBox1.Location = new System.Drawing.Point(122, 53);
			textBox1.MaxLength = 20;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(194, 20);
			textBox1.TabIndex = 20;
			// 
			// textBox2
			// 
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox2.Location = new System.Drawing.Point(6, 56);
			textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new System.Drawing.Size(110, 13);
			textBox2.TabIndex = 21;
			textBox2.Text = "3. GTIN";
			// 
			// statisticsBox
			// 
			statisticsBox.Controls.Add(AllCodesBox);
			statisticsBox.Controls.Add(NoReadCodeCounter);
			statisticsBox.Controls.Add(AllCodeCounter);
			statisticsBox.Controls.Add(NoReadCodeBox);
			statisticsBox.Controls.Add(ReadCodeBox);
			statisticsBox.Controls.Add(ReadCodeCounter);
			statisticsBox.Location = new System.Drawing.Point(12, 238);
			statisticsBox.Name = "statisticsBox";
			statisticsBox.Size = new System.Drawing.Size(512, 152);
			statisticsBox.TabIndex = 22;
			statisticsBox.TabStop = false;
			statisticsBox.Text = "Статистика";
			// 
			// statusBox
			// 
			statusBox.Controls.Add(StatusBar);
			statusBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			statusBox.Location = new System.Drawing.Point(12, 68);
			statusBox.Name = "statusBox";
			statusBox.Size = new System.Drawing.Size(514, 54);
			statusBox.TabIndex = 23;
			statusBox.TabStop = false;
			statusBox.Text = "Статус";
			// 
			// datetimeBox
			// 
			datetimeBox.Controls.Add(lotDate);
			datetimeBox.Location = new System.Drawing.Point(271, 8);
			datetimeBox.Name = "datetimeBox";
			datetimeBox.Size = new System.Drawing.Size(253, 54);
			datetimeBox.TabIndex = 24;
			datetimeBox.TabStop = false;
			datetimeBox.Text = "Дата";
			// 
			// inputsBox
			// 
			inputsBox.Controls.Add(gtinStatus);
			inputsBox.Controls.Add(textBox2);
			inputsBox.Controls.Add(textBox1);
			inputsBox.Controls.Add(permissionBox);
			inputsBox.Controls.Add(lotMunText);
			inputsBox.Controls.Add(lotNumBox);
			inputsBox.Location = new System.Drawing.Point(12, 128);
			inputsBox.Name = "inputsBox";
			inputsBox.Size = new System.Drawing.Size(514, 87);
			inputsBox.TabIndex = 25;
			inputsBox.TabStop = false;
			inputsBox.Text = "Исходные данные";
			// 
			// gtinStatus
			// 
			gtinStatus.Location = new System.Drawing.Point(332, 53);
			gtinStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			gtinStatus.Name = "gtinStatus";
			gtinStatus.ReadOnly = true;
			gtinStatus.Size = new System.Drawing.Size(163, 20);
			gtinStatus.TabIndex = 3;
			gtinStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// controlBox
			// 
			controlBox.Controls.Add(resetStat);
			controlBox.Controls.Add(UploadDB);
			controlBox.Location = new System.Drawing.Point(12, 412);
			controlBox.Name = "controlBox";
			controlBox.Size = new System.Drawing.Size(512, 58);
			controlBox.TabIndex = 26;
			controlBox.TabStop = false;
			controlBox.Text = "Управление";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(StartButton);
			groupBox1.Location = new System.Drawing.Point(12, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(253, 54);
			groupBox1.TabIndex = 27;
			groupBox1.TabStop = false;
			groupBox1.Text = "Начало";
			// 
			// UI
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			ClientSize = new System.Drawing.Size(536, 488);
			Controls.Add(groupBox1);
			Controls.Add(controlBox);
			Controls.Add(inputsBox);
			Controls.Add(datetimeBox);
			Controls.Add(statusBox);
			Controls.Add(statisticsBox);
			Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			Name = "UI";
			Text = "Code Scanner";
			FormClosing += Form1_FormClosing;
			Load += UI_Load;
			statisticsBox.ResumeLayout(false);
			statisticsBox.PerformLayout();
			statusBox.ResumeLayout(false);
			statusBox.PerformLayout();
			datetimeBox.ResumeLayout(false);
			inputsBox.ResumeLayout(false);
			inputsBox.PerformLayout();
			controlBox.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
		}

		private System.Windows.Forms.Button resetStat;

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox StatusBar;
        //private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.TextBox AllCodesBox;
        private System.Windows.Forms.TextBox ReadCodeCounter;  
        private System.Windows.Forms.TextBox NoReadCodeBox;
        public System.Windows.Forms.TextBox AllCodeCounter;
        public System.Windows.Forms.TextBox ReadCodeBox;
        public System.Windows.Forms.TextBox NoReadCodeCounter;
        private System.Windows.Forms.Button UploadDB;
        private System.Windows.Forms.TextBox lotNumBox;
        private System.Windows.Forms.TextBox lotMunText;
        private System.Windows.Forms.DateTimePicker lotDate;
        private System.Windows.Forms.CheckBox permissionBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox statisticsBox;
        private System.Windows.Forms.GroupBox statusBox;
        private System.Windows.Forms.GroupBox datetimeBox;
        private System.Windows.Forms.GroupBox inputsBox;
        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.TextBox gtinStatus;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}