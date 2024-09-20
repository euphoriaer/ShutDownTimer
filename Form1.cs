using System;
using System.Diagnostics;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Timer = System.Threading.Timer;

namespace ShutDown
{
    public partial class 定时关机 : Form
    {
        private Timer timer;
        private Timer labShowTimer;
        private bool isShutDown = false;
        private DateTime closeTime;
        SynchronizationContext cur;

        private bool isCountdownRunning = false;
        private TimeSpan countdownTimeSpan;
        private TimeSpan remainingTime;
        public 定时关机()
        {
            InitializeComponent();
            cur = SynchronizationContext.Current;
            remainTime.Visible = false;
        }

        public bool IsShutDown
        {
            get => isShutDown;
            set
            {
                isShutDown = value;

                cur.Send((o) =>
                {
                    remainTime.Visible = isShutDown;
                }, countdownTimeSpan);

            }

        }

        private void shutDownBtn_Click(object sender, EventArgs e)
        {
            IsShutDown = !isShutDown;
            if (IsShutDown)
            {
                shutDownBtn.Text = "取消关机";
                int hour = 0;
                int min = 0;
                int second = 0;
                //定时关机
                if (!string.IsNullOrEmpty(shutDownTimeH.Text))
                {
                    hour = int.Parse(shutDownTimeH.Text);
                }
                if (!string.IsNullOrEmpty(shutDownTimeM.Text))
                {
                    min = int.Parse(shutDownTimeM.Text);
                }
                if (!string.IsNullOrEmpty(shutDownTimeS.Text))
                {
                    second = int.Parse(shutDownTimeS.Text);
                }

                countdownTimeSpan = new TimeSpan(0, (int)hour, (int)min, (int)second);

                remainingTime = countdownTimeSpan;
                isCountdownRunning = true;


                timer = new Timer(TimerCallback, null, countdownTimeSpan, TimeSpan.FromSeconds(1));
                labShowTimer = new Timer(TimerShow, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
                closeTime = DateTime.Now;
                TimerShow(null);
            }
            else
            {
                //取消定时关机

                cur.Send((o) =>
                {
                    shutDownBtn.Text = "关机";
                }, countdownTimeSpan);


                if (timer != null)
                {
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                    timer.Dispose();
                    timer = null;
                }
                if (labShowTimer != null)
                {
                    labShowTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    labShowTimer.Dispose();
                    labShowTimer = null;
                }
            }

        }
        private void TimerShow(Object state)
        {
            countdownTimeSpan = countdownTimeSpan - TimeSpan.FromSeconds(1);
            cur.Send((o) =>
            {
                remainTime.Text = $"距离关机还剩：{countdownTimeSpan.Hours}小时{countdownTimeSpan.Minutes}分钟{countdownTimeSpan.Seconds}秒";

            }, countdownTimeSpan);

        }
        private void TimerCallback(Object state)
        {
            Console.WriteLine($"计时器触发时间: {DateTime.Now}");
            shutDownBtn_Click(null, null);
            ShutdownComputer();
            MessageBox.Show("倒计时结束！正在关闭计算机...");
        }
        private void ShutdownComputer()
        {
            try
            {
                using (Process process = new Process())
                {
                    var command = "shutdown -s -t 1";
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WorkingDirectory = "C:\\";
                    process.StartInfo.RedirectStandardInput = true;
                    //process.StartInfo.RedirectStandardOutput = true;
                    //process.StartInfo.UseShellExecute = false;
                    //process.StartInfo.CreateNoWindow = true;

                    process.Start();

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(process.StandardInput.BaseStream))
                    {
                        sw.WriteLine(command);
                        sw.WriteLine("exit");
                    }
                    // 获取cmd的输出
                    // 打印输出结果
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"关闭计算机失败：{ex.Message}");
            }
        }
    }
}
