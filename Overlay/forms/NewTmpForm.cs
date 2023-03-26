using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
namespace Overlay
{
    public partial class NewTmpForm : Form // 임시오버레이폼
    {

        #region 라이브러리
        private IKeyboardMouseEvents globalHook;
        [DllImport("user32.dll")]
        static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        public delegate bool EnumWindowCallback(int hwnd, int iParam);
        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowCallback callback, int y);
        [DllImport("user32.dll")]
        public static extern int GetParent(int hWnd);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(int hWnd, int nIndex);

        const int GCL_HICON = -14;
        const int GCL_HMODULE = -16;       


        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool EnableWindow(IntPtr hwnd, bool bEnable);
        #endregion

        #region 작업프로그램불러오기
        const int LWA_ALPHA = 0x00000002;
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERERD = 0X80000;
        uint pid = 0;
        Process ps = null;
        Process p = null;
        ImageList imgList;
        List<IntPtr> handleList = new List<IntPtr>();
        private void callTasks()
        {
            imgList = new ImageList();
            imgList.ImageSize = new Size(12, 12);

            EnumWindowCallback callback = new EnumWindowCallback(EnumWindowsProc);
            EnumWindows(callback, 0);
 
        }
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
            UInt32 style = (UInt32)GetWindowLong(hwnd, GCL_HMODULE);
            //if ((style & 0x10000000L) == 0x10000000L && (style & 0x00C00000L) == 0x00C00000L)
            if ((style & 0x00040000L) == 0x00040000L && (style & 0x10000000L) == 0x10000000L) // 윈도우 속성 visible, sizable
            {
                if (GetParent(hwnd) == 0)
                {
                    StringBuilder Buf = new StringBuilder(256);
                    if (GetWindowText(hwnd, Buf, 256) > 0)
                    {
                        try
                        {
                            pid = 0;
                            Icon icon = null;
                            IntPtr hWnd = FindWindow(null, Buf.ToString()); //핸들 얻어옴
                            GetWindowThreadProcessId(hWnd, out pid); // 핸들로 프로세스아이디 얻어옴
                            if (pid == 0)
                            {
                                icon = ProcessCheck((IntPtr)hwnd);
                            }
                            else
                            {
                                ps = Process.GetProcessById((int)pid);
                                icon = GetProcessIcon(ps);
                            }
                            imgList.Images.Add(icon);
                            handleList.Add((IntPtr)hwnd);
                            taskListComboBox.Items.Add(Buf.ToString());
                        }
                        catch (Exception)
                        {
                            imgList.Images.Add(this.Icon);
                        }
                    }
                }
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
        #endregion
        public NewTmpForm()
        {
            InitializeComponent();                  
            initData();
            callTasks();
        }
        TaskInfo thisForm;
        IconForm iconForm;
        private void initData()
        {
            this.taskListComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.taskListComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            globalHook = Hook.GlobalEvents();
            globalHook.MouseDown += GlobalHook_MouseDown;
            globalHook.MouseUp += GlobalHook_MouseUp;
            globalHook.MouseMove += GlobalHook_MouseMove;

            this.TopMost = true;
            winInfo.TaskHandle = GetDesktopWindow();
            winInfo.GetWindowPosition(winInfo.TaskHandle, ref point, ref size);

            thisForm = new TaskInfo();
            thisForm.TaskHandle = this.Handle;
            this.FormClosing += NewTmpForm_FormClosing;
            this.FormClosed += NewTmpForm_FormClosed;
            this.ResizeRedraw = true;
            this.SizeChanged += NewTmpForm_SizeChanged;
            tmpFormMainPanel.MouseDown += NewTmpForm_MouseDown;
            iconForm = new IconForm(this.point);
            iconForm.sideMenuVisible += new IconForm.DataPassSideShow(sidePanelShow);
            iconForm.Owner = this;

            tbOpacity.Text = opacity + "";
        }

        private void NewTmpForm_SizeChanged(object sender, EventArgs e)
        {
            if(selectTask != null)
            {
                thisForm.GetWindowPosition(thisForm.TaskHandle, ref point, ref size);
                selectTask.FormResize(thisForm.TaskSize);
            }
        }

        private void NewTmpForm_MouseDown(object sender, MouseEventArgs e)
        {
            SetForegroundWindow(tmpFormMainPanel.Handle);
        }

        private void sidePanelShow(bool sideMenuShow)
        {
            if (sideMenuShow)
                tmpFormSidePanel.Visible = true;
            iconForm.Hide();
        }

        private void NewTmpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ChangeDisplay();
            formDie = true;
        }

        private void NewTmpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChangeDisplay();
            formDie = true;
        }
        private void btRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSideClose_Click(object sender, EventArgs e)
        {
            tmpFormSidePanel.Visible = false;

            iconForm.Show();
            iconForm.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
        }
        private void DropDown(object sender, EventArgs e)
        {
            //refresh();
            comboDrop = true;
        }

        private void DropClosed(object sender, EventArgs e)
        {
            comboDrop = false;
        }

        bool mouseDown;
        Point lastLocation;
        int startX;
        int startY;
        IntPtr tmphwnd;
        bool isDoResize = false;
        bool formDie = false;
        bool comboDrop = false;

        #region 화면이동관련
        private void GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            tmphwnd = GetForegroundWindow();
            if (mouseDown && focusedTask(tmphwnd))
            {

                this.Location = new Point(
                    startX + e.X, startY + e.Y);
                this.Update();
                iconForm.Location = new Point(this.Location.X + 10, this.Location.Y + 10);
            }
        }
        private void GlobalHook_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseDown = false;
            }
            this.Refresh();
        }
        

        private void GlobalHook_MouseDown(object sender, MouseEventArgs e)
        {
            
                      
            if ((e.Location.X >= this.Location.X &&
                e.Location.X <= this.Location.X + this.Width &&
                e.Location.Y >= this.Location.Y &&
                e.Location.Y <= this.Location.Y + this.Height))
;           {
                mouseDown = true;
                lastLocation = e.Location;
                startX = (this.Location.X - lastLocation.X);
                startY = (this.Location.Y - lastLocation.Y);
            }
            if (isDoResize | comboDrop)
                mouseDown = false;

        }

        private bool focusedTask(IntPtr tmphwnd)
        {
            if (formDie)
                return false;
            else if (selectTask == null)
                return tmphwnd == this.Handle;
            else
                return tmphwnd == this.Handle || tmphwnd == selectTask.TaskHandle;
        }


        #endregion

        TaskInfo selectTask = null;
        TaskInfo winInfo = new TaskInfo();
        Point point;
        Size size;
        public void openWindow(IntPtr hWnd)
        { 
            if (selectTask != null)
            {
                ChangeDisplay();
            }
            selectTask = new TaskInfo();
            selectTask.TaskHandle = hWnd;
            selectTask.GetWindowPosition(selectTask.TaskHandle, ref point, ref size);
            selectTask.TaskEnter(tmpFormMainPanel.Handle);           
            SetForegroundWindow(this.Handle);
            Size = new Size(selectTask.TaskSize.Width, selectTask.TaskSize.Height);
            opacityChange();
            TopMost = true;
        }      
        private void ChangeDisplay()
        {
            if(selectTask != null)
            {
                selectTask.TaskExit(winInfo.TaskHandle);
                selectTask = null;
                tmphwnd = IntPtr.Zero;
                GC.Collect();
                TopMost = true;
            }
        }

        private void taskListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectTitle = taskListComboBox.Text;
            //IntPtr hWnd = FindWindow(null, selectTitle);
            IntPtr hWnd = handleList[taskListComboBox.SelectedIndex];
            if (!hWnd.Equals(IntPtr.Zero))
            {

                ShowWindowAsync(hWnd, SW_SHOWNORMAL);

                SetForegroundWindow(hWnd);
                openWindow(hWnd);
                SetForegroundWindow(tmpFormSidePanel.Handle);
                refresh();
            }
            
        }
        private void refresh()
        {
            taskListComboBox.Items.Clear();
            handleList.Clear();
            callTasks();
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            this.Width += 30;
            this.Height += 20;
            if(selectTask != null)
                selectTask.TaskResize('+');
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            if (this.Width > 300 && this.Height>300)
            {
                this.Width -= 30;
                this.Height -= 20;
            }
            if (selectTask != null)
                selectTask.TaskResize('-');
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            ChangeDisplay();
            refresh();
            Size = new Size(500, 500);
        }
        int opacity = 100;
    
        private void opacityChange()
        {
            if (opacity >= 20)
            {
                byte formOpacity = Convert.ToByte((255 * opacity) / 100);
                if(selectTask != null)
                    selectTask.OpacityChange(formOpacity);
                //var formStyle = GetWindowLong(thisForm.TaskHandle, -20);
                SetLayeredWindowAttributes(thisForm.TaskHandle, 0, formOpacity, LWA_ALPHA);
            }
        }

        
        private void taskListComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle Bounds = new Rectangle(0, e.Bounds.Y, 12, 12);

            if (e.Index < 0)
            { 
                return;
            }
            e.DrawBackground();
            e.Graphics.DrawImage(imgList.Images[e.Index], Bounds);
            using (Font fnt = new Font(this.taskListComboBox.Font.FontFamily, 8))
            {
                e.Graphics.DrawString(this.taskListComboBox.Items[e.Index].ToString(), fnt, Brushes.Black, e.Bounds.X + 10, e.Bounds.Y);
            }
            e.DrawFocusRectangle();

        }
       
        private void cbSetSize_CheckedChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = cbSizeSetting.Checked ? FormBorderStyle.Sizable : FormBorderStyle.None;
            isDoResize = cbSizeSetting.Checked;
        }

        private void cbBan_CheckedChanged(object sender, EventArgs e)
        {
            if(selectTask != null)
            {
                    selectTask.TaskClickBan(cbBan.Checked);
            }
            tmpFormMainPanel.Enabled = !cbBan.Checked;

        }

        private void tbOpacity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string opacityText = "";
                opacityText = tbOpacity.Text;                
                bool isNum = int.TryParse(opacityText, out opacity);
                if (isNum && opacity > 20)
                {
                    opacityChange();
                }
                else
                {
                    tbOpacity.Text = opacity + "";
                }
            }
        }

      
    }
}