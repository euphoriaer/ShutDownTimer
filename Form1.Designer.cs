namespace ShutDown
{
    partial class 定时关机
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(定时关机));
            shutDownTimeH = new TextBox();
            label1 = new Label();
            shutDownBtn = new Button();
            remainTime = new Label();
            label2 = new Label();
            shutDownTimeM = new TextBox();
            shutDownTimeS = new TextBox();
            label3 = new Label();
            closeAppBtn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // shutDownTimeH
            // 
            shutDownTimeH.Location = new Point(75, 63);
            shutDownTimeH.Name = "shutDownTimeH";
            shutDownTimeH.Size = new Size(54, 23);
            shutDownTimeH.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 69);
            label1.Name = "label1";
            label1.Size = new Size(20, 17);
            label1.TabIndex = 1;
            label1.Text = "时";
            // 
            // shutDownBtn
            // 
            shutDownBtn.Font = new Font("Microsoft YaHei UI", 15F);
            shutDownBtn.Location = new Point(127, 92);
            shutDownBtn.Name = "shutDownBtn";
            shutDownBtn.Size = new Size(145, 33);
            shutDownBtn.TabIndex = 2;
            shutDownBtn.Text = "关机";
            shutDownBtn.UseVisualStyleBackColor = true;
            shutDownBtn.Click += shutDownBtn_Click;
            // 
            // remainTime
            // 
            remainTime.AutoSize = true;
            remainTime.Font = new Font("Microsoft YaHei UI", 15F);
            remainTime.Location = new Point(47, 24);
            remainTime.Name = "remainTime";
            remainTime.Size = new Size(272, 27);
            remainTime.TabIndex = 3;
            remainTime.Text = "计时还剩：1小时45分钟45秒";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(221, 69);
            label2.Name = "label2";
            label2.Size = new Size(20, 17);
            label2.TabIndex = 6;
            label2.Text = "分";
            // 
            // shutDownTimeM
            // 
            shutDownTimeM.Location = new Point(161, 63);
            shutDownTimeM.Name = "shutDownTimeM";
            shutDownTimeM.Size = new Size(54, 23);
            shutDownTimeM.TabIndex = 7;
            // 
            // shutDownTimeS
            // 
            shutDownTimeS.Location = new Point(247, 63);
            shutDownTimeS.Name = "shutDownTimeS";
            shutDownTimeS.Size = new Size(54, 23);
            shutDownTimeS.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(307, 69);
            label3.Name = "label3";
            label3.Size = new Size(20, 17);
            label3.TabIndex = 9;
            label3.Text = "秒";
            // 
            // closeAppBtn
            // 
            closeAppBtn.Font = new Font("Microsoft YaHei UI", 15F);
            closeAppBtn.Location = new Point(127, 131);
            closeAppBtn.Name = "closeAppBtn";
            closeAppBtn.Size = new Size(145, 37);
            closeAppBtn.TabIndex = 10;
            closeAppBtn.Text = "定时关软件";
            closeAppBtn.UseVisualStyleBackColor = true;
            closeAppBtn.Click += 定时关软件_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 15F);
            button1.Location = new Point(127, 174);
            button1.Name = "button1";
            button1.Size = new Size(145, 37);
            button1.TabIndex = 11;
            button1.Text = "定时重启";
            button1.UseVisualStyleBackColor = true;
            button1.Click += 定时重启_click;
            // 
            // 定时关机
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 223);
            Controls.Add(button1);
            Controls.Add(closeAppBtn);
            Controls.Add(label3);
            Controls.Add(shutDownTimeS);
            Controls.Add(shutDownTimeM);
            Controls.Add(label2);
            Controls.Add(remainTime);
            Controls.Add(shutDownBtn);
            Controls.Add(label1);
            Controls.Add(shutDownTimeH);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "定时关机";
            Text = "定时关机";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox shutDownTimeH;
        private Label label1;
        private Button shutDownBtn;
        private Label remainTime;
        private Label label2;
        private TextBox shutDownTimeM;
        private TextBox shutDownTimeS;
        private Label label3;
        private Button closeAppBtn;
        private Button button1;
    }
}
