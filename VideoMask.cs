using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System;

namespace VideoMasking
{
    public partial class VideoMask : Form
    {
        Thread kodiWatcher;
        Thread mpcWatcher;
        Thread madVRWatcher;
        int left, right, top, bottom = 0;

        public VideoMask(bool forceForeground)
        {
            try
            {
                string maskNums = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "videomask.txt"));
                string[] masks = maskNums.Split(',');
                left = Convert.ToInt32(masks[0]);
                right = Convert.ToInt32(masks[1]);
                top = Convert.ToInt32(masks[2]);
                bottom = Convert.ToInt32(masks[3]);

            }
            catch { }

            InitializeComponent();

            BackColor = Color.White;
            TransparencyKey = Color.White;

            FormBorderStyle = FormBorderStyle.None;
            Bounds = Screen.PrimaryScreen.Bounds;
            TopMost = true;

            kodiWatcher = new Thread(WatchKodi);
            kodiWatcher.Start();

            mpcWatcher = new Thread(WatchMPC);
            mpcWatcher.Start();

            madVRWatcher = new Thread(WatchMadVR);
            madVRWatcher.Start();

            if (forceForeground)
            {
                System.Threading.Timer foregroundTimer = new System.Threading.Timer(ForegroundTimerTick, null, 1000, 1000);
            }
        }

        private void ForegroundTimerTick(object o)
        {
            Invoke((MethodInvoker)delegate
            {
                Activate();
            });
        }

        private void VideoMask_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "videomask.txt"), left + "," + right + "," + top + "," + bottom);
            }
            catch { }

            Environment.Exit(0);
        }

        private void WatchKodi()
        {
            try
            {
                Thread.Sleep(5000);
                Process.GetProcessesByName("kodi")[0].WaitForExit();

                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }
            catch { }
        }

        private void WatchMPC()
        {
            try
            {
                Thread.Sleep(5000);
                Process.GetProcessesByName("mpc-hc64")[0].WaitForExit();

                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }
            catch { }
        }

        private void WatchMadVR()
        {
            try
            {
                Thread.Sleep(5000);
                Process.GetProcessesByName("madHcCtrl")[0].WaitForExit();

                Invoke((MethodInvoker)delegate
                {
                    Close();
                });
            }
            catch { }
        }

        private void VideoMask_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Black);

            e.Graphics.FillRectangle(myBrush, 0, 0, Bounds.Width, top);
            e.Graphics.FillRectangle(myBrush, 0, 0, left, Bounds.Height);
            e.Graphics.FillRectangle(myBrush, Bounds.Width - right, 0, Bounds.Width, Bounds.Height);
            e.Graphics.FillRectangle(myBrush, 0, Bounds.Height - bottom, Bounds.Width, Bounds.Height);
        }

        private void VideoMask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        left--;
                        break;
                    case Keys.D2:
                        right--;
                        break;
                    case Keys.D3:
                        top--;
                        break;
                    case Keys.D4:
                        bottom--;
                        break;
                    default:
                        break;
                }
            }
            else if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        left++;
                        break;
                    case Keys.D2:
                        right++;
                        break;
                    case Keys.D3:
                        top++;
                        break;
                    case Keys.D4:
                        bottom++;
                        break;
                    default:
                        break;
                }
            }

            if (left < 0)
            {
                left = 0;
            }
            if (right < 0)
            {
                right = 0;
            }
            if (top < 0)
            {
                top = 0;
            }
            if (bottom < 0)
            {
                bottom = 0;
            }

            Invalidate();
        }
    }
}