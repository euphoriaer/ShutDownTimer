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
            SuspendLayout();
            // 
            // shutDownTimeH
            // 
            shutDownTimeH.Location = new Point(84, 78);
            shutDownTimeH.Name = "shutDownTimeH";
            shutDownTimeH.Size = new Size(54, 23);
            shutDownTimeH.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 84);
            label1.Name = "label1";
            label1.Size = new Size(20, 17);
            label1.TabIndex = 1;
            label1.Text = "时";
            // 
            // shutDownBtn
            // 
            shutDownBtn.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            shutDownBtn.Location = new Point(86, 130);
            shutDownBtn.Name = "shutDownBtn";
            shutDownBtn.Size = new Size(250, 64);
            shutDownBtn.TabIndex = 2;
            shutDownBtn.Text = "关机";
            shutDownBtn.UseVisualStyleBackColor = true;
            shutDownBtn.Click += shutDownBtn_Click;
            // 
            // remainTime
            // 
            remainTime.AutoSize = true;
            remainTime.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            remainTime.Location = new Point(47, 24);
            remainTime.Name = "remainTime";
            remainTime.Size = new Size(312, 27);
            remainTime.TabIndex = 3;
            remainTime.Text = "距离关机还剩：1小时45分钟45秒";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 84);
            label2.Name = "label2";
            label2.Size = new Size(20, 17);
            label2.TabIndex = 6;
            label2.Text = "分";
            // 
            // shutDownTimeM
            // 
            shutDownTimeM.Location = new Point(170, 78);
            shutDownTimeM.Name = "shutDownTimeM";
            shutDownTimeM.Size = new Size(54, 23);
            shutDownTimeM.TabIndex = 7;
            // 
            // shutDownTimeS
            // 
            shutDownTimeS.Location = new Point(256, 78);
            shutDownTimeS.Name = "shutDownTimeS";
            shutDownTimeS.Size = new Size(54, 23);
            shutDownTimeS.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(316, 84);
            label3.Name = "label3";
            label3.Size = new Size(20, 17);
            label3.TabIndex = 9;
            label3.Text = "秒";
            // 
            // 定时关机
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 223);
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
    }
}
