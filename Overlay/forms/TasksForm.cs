using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;


namespace Overlay
{
    public partial class TasksForm : Form
    {
        public delegate bool EnumWindowCallback(int hwnd, int iParam);
        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowCallback callback, int y);
        [DllImport("user32.dll")]
        public static extern int GetParent(int hWnd);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(int hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);



        public delegate void DataPassHwnd(IntPtr data);

        public event DataPassHwnd tmpFormSendHwnd;

        public delegate void DataPassRefresh(IntPtr data);

        public event DataPassRefresh tmpFormRefresh;

        public delegate void DataPassOpacity(int data);

        public event DataPassOpacity tmpFormOpacity;

        public delegate void DataPassView(bool data);

        public event DataPassView tmpFormView;
        public delegate void DataPassPlus(int sWidth, int sHeight);

        public event DataPassPlus tmpFormPlus;

        public delegate void DataPassMinus(int sWidth, int sHeight);

        public event DataPassMinus tmpFormMinus;

        public delegate void DataPassBan(bool TaskBan);

        public event DataPassBan tmpFormTaskBan;

        public delegate void DataPassBordorLess(bool TaskBorder);

        public event DataPassBordorLess tmpFormBorderLess;

        public TasksForm()
        {
            InitializeComponent();
            callTasks();
            taskListView.Focus();
            trackBar.Value = 10;
        }
        uint pid = 0;
        Process ps = null;
        ImageList imgList;
        List<IntPtr> handleList = new List<IntPtr>();
        private void callTasks()
        {
            imgList = new ImageList();
            imgList.ImageSize = new Size(32, 32);
            taskListView.SmallImageList = imgList;
            taskListView.View = View.List;
            EnumWindowCallback callback = new EnumWindowCallback(EnumWindowsProc);
            EnumWindows(callback, 0);
        }
        List<IntPtr> tmpHwnd = new List<IntPtr>();
        private Icon ProcessCheck(IntPtr handle)
        {
            Process[] pro = Process.GetProcesses();
            Icon icon = this.Icon;
            for (int i = 0; i < pro.Length; i++)
            {
                if (pro[i].MainWindowHandle != IntPtr.Zero)
                {
                    if (pro[i].MainWindowTitle == "")
                        continue;

                    IntPtr hWnd = pro[i].MainWindowHandle;
                    if (hWnd == handle)
                    {

                        icon = GetProcessIcon(pro[i]);
                        return icon;
                    }
                }
            }

            return icon;
        }


        public bool EnumWindowsProc(int hwnd, int iParam)
        {
            UInt32 style = (UInt32)GetWindowLong(hwnd, -16);//GCL_HMODULE = -16
            if((style & 0x00040000L) == 0x00040000L && (style & 0x10000000L) == 0x10000000L) // 윈도우 속성 visible, sizable
            {
                string taskName = "";
                StringBuilder Buf = new StringBuilder(256);
                if (GetWindowText(hwnd, Buf, 256) > 0)
                {
                    try
                    {
                        pid = 0;
                        taskName = Buf.ToString();
                        IntPtr hWnd = FindWindow(null, taskName); 
                        Icon icon = null;
                        GetWindowThreadProcessId(hWnd, out pid);
                        if (pid == 0)
                        {

                            SetForegroundWindow((IntPtr)hwnd);
                            icon = ProcessCheck((IntPtr)hwnd);
                        }
                        else
                        {
                            ps = Process.GetProcessById((int)pid);
                            icon = GetProcessIcon(ps);
                        }
                        imgList.Images.Add(icon);                      
                    }
                    catch (Exception)
                    {

                        imgList.Images.Add(this.Icon);
                    }

                }
                    handleList.Add((IntPtr)hwnd);
                    taskListView.Items.Add(new ListViewItem(taskName, taskListView.Items.Count));
            }
            return true;
        }
        private Icon GetProcessIcon(Process p)
        {
            try
            {
                return Icon.ExtractAssociatedIcon(p.MainModule.FileName);
            }
            catch (Exception e)
            {
                if (e is ArgumentException || e is Win32Exception) //인수 또는 윈도우문제
                {
                    return SystemIcons.Application;
                }
                else
                {
                    return SystemIcons.Error;
                }
            }
        }


        private void taskListView_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selectTitle = taskListView.Items[taskListView.FocusedItem.Index].SubItems[0].Text.ToString();

            IntPtr hWnd = handleList[taskListView.FocusedItem.Index];

            StringBuilder buf = new StringBuilder();
            if (GetWindowText(hWnd, buf, 256) != 0)
            {
                // 윈도우가 최소화 되어 있다면 활성화
                ShowWindowAsync(hWnd, SW_SHOWNORMAL);

                SetForegroundWindow(hWnd);// 윈도우에 포커스

                tmpFormSendHwnd(hWnd);//오버레이 폼에 핸들값 

                cbOverlayView.Checked = true;
                checkedChange();
            }
            refresh();


        }


        private void refresh()
        {
            taskListView.Items.Clear();
            handleList.Clear();
            callTasks();
        }


        private void bt_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bt_init_Click(object sender, EventArgs e)
        {

            tmpFormRefresh(new IntPtr()); //오버레이 폼 프로그램 꺼내기
            refresh();
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            int opacity = trackBar.Value * 10;
            if (opacity >= 20)
                tmpFormOpacity(opacity);
        }

        private void cbOverlayView_CheckedChanged(object sender, EventArgs e)
        {
            checkedChange();
        }

        private void checkedChange()
        {
            if (cbOverlayView.Checked)
                tmpFormView(true);
            else
                tmpFormView(false);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            tmpFormPlus(btnPlus.Width, btnPlus.Height);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            tmpFormMinus(btnPlus.Width, btnPlus.Height);
        }

        private void btDevide_Click(object sender, EventArgs e)
        {
            NewTmpForm newTmpForm = new NewTmpForm();
            newTmpForm.Show();
        }

        private void cbTaskBan_CheckedChanged(object sender, EventArgs e)
        {
            tmpFormTaskBan(cbTaskBan.Checked);
        }

        private void cbBorderLess_CheckedChanged(object sender, EventArgs e)
        {
            tmpFormBorderLess(cbBorderLess.Checked);
        }
    }
}
