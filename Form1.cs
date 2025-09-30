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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
                shutDownBtn.Text = "取消";
                closeAppBtn.Text = "取消";
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


                timer = new Timer(CloseWindowsCallback, null, countdownTimeSpan, TimeSpan.FromSeconds(1));
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
                    closeAppBtn.Text = "定时关软件";
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
                remainTime.Text = $"计时还剩：{countdownTimeSpan.Hours}小时{countdownTimeSpan.Minutes}分钟{countdownTimeSpan.Seconds}秒";

            }, countdownTimeSpan);

        }
        private void CloseWindowsCallback(Object state)
        {
            Console.WriteLine($"计时器触发时间: {DateTime.Now}");
            shutDownBtn_Click(null, null);
            ShutdownComputer();
            MessageBox.Show("倒计时结束！正在关闭计算机...");
        }
        private void CloseExeCallback(Object state)
        {
            Console.WriteLine($"计时器触发时间: {DateTime.Now}");
            shutDownBtn_Click(null, null);
            try
            {
                if (processHandle != null) //可能已经被关闭了
                {
                    processHandle.Kill();
                    processHandle = null;
                }

            }
            catch (Exception)
            {
                processHandle = null;
            }
            MessageBox.Show("倒计时结束！正在关闭软件...");
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

        public static Process OpenExe()
        {
            // 创建 OpenFileDialog 实例
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置对话框属性
                openFileDialog.Title = "选择要启动的可执行文件 (.exe)";
                openFileDialog.Filter = "可执行文件 (*.exe)|*.exe|所有文件 (*.*)|*.*"; // 过滤器，优先显示 .exe
                openFileDialog.FilterIndex = 1; // 默认选择第一个过滤器
                openFileDialog.RestoreDirectory = true; // 恢复到上次打开的目录
                openFileDialog.CheckFileExists = true; // 确保用户选择的文件必须存在

                // 显示对话框并检查用户是否点击了“确定”
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        // 获取用户选择的文件路径
                        string filePath = openFileDialog.FileName;

                        // 使用 Process.Start 启动选定的 .exe 文件
                        // Process.Start 返回一个 Process 对象，代表新启动的进程
                        Process process = Process.Start(filePath);

                        // 确保进程对象不为 null
                        if (process != null)
                        {
                            // 等待进程进入空闲状态（确保主窗口已创建）
                            // 这可以提高获取正确 MainWindowHandle 的可靠性
                            process.WaitForInputIdle();

                            // 返回进程的主窗口句柄
                            // MainWindowHandle 是 IntPtr 类型，符合您的要求
                            return process;
                        }
                    }
                    catch (Exception ex)
                    {
                        // 处理可能的异常，例如文件无法启动、权限不足等
                        MessageBox.Show($"启动程序时发生错误：{ex.Message}", "启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // 返回 null 表示失败
                        return null;
                    }
                }

                // 用户点击了“取消”或对话框被关闭
                return null;
            } // using 语句确保 OpenFileDialog 被正确释放
        }
        Process processHandle;
        private void 定时关软件_Click(object sender, EventArgs e)
        {
            IsShutDown = !isShutDown;
            if (IsShutDown)
            {
                //尝试启动软件
                if (processHandle != null)
                {
                    processHandle.Kill();
                    processHandle = null;
                }
                processHandle = OpenExe();
                if (processHandle == null)
                {
                    Console.WriteLine("用户取消了选择或启动失败。");
                    IsShutDown = !isShutDown;
                    return;
                }

                shutDownBtn.Text = "取消";
                closeAppBtn.Text = "取消";
                int hour = 0;
                int min = 0;
                int second = 0;
                //定时关
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


                timer = new Timer(CloseExeCallback, null, countdownTimeSpan, TimeSpan.FromSeconds(1));
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
                    closeAppBtn.Text = "定时关软件";
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
    }
}



