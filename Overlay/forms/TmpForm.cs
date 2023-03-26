using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
namespace Overlay
{
    public partial class TmpForm : Form // 임시오버레이폼
    {
        private IKeyboardMouseEvents globalHook;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr windowHandle);

        const int LWA_ALPHA = 0x00000002;
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERERD = 0X80000;

        MainForm mainForm = null;
        public TmpForm()
        {
            InitializeComponent();                  
            initData();
            this.Hide();
        }
        TaskInfo thisForm;
        SearchForm searchForm;
        private void initData()
        {
            globalHook = Hook.GlobalEvents();
            globalHook.MouseDown += GlobalHook_MouseDown;
            globalHook.MouseUp += GlobalHook_MouseUp;
            globalHook.MouseMove += GlobalHook_MouseMove;

            this.TopMost = true;
            this.FormClosed += TmpForm_Closing;
            this.Shown += TmpForm_Shown;
            this.SizeChanged += TmpForm_SizeChanged;
            winInfo.TaskHandle = GetDesktopWindow();
            winInfo.GetWindowPosition(winInfo.TaskHandle, ref point, ref size);

            thisForm = new TaskInfo();
            thisForm.TaskHandle = this.Handle;

            searchForm = new SearchForm(this.Location.X + (this.Width / 4), this.Location.Y - 50 );
            searchForm.DataPassEvent += new SearchForm.DataPassEventHandler(ReceivedHwndEvent);
            searchForm.Owner = this;

            

            TasksForm taskForm = new TasksForm();
            taskForm.tmpFormSendHwnd += new TasksForm.DataPassHwnd(ReceivedHwndEvent);
            taskForm.tmpFormRefresh += new TasksForm.DataPassRefresh(RefreshEvent);
            taskForm.tmpFormOpacity += new TasksForm.DataPassOpacity(OpacityEvent);
            taskForm.tmpFormView += new TasksForm.DataPassView(ViewEvent);
            taskForm.tmpFormPlus += new TasksForm.DataPassPlus(PlusEvent);
            taskForm.tmpFormMinus += new TasksForm.DataPassMinus(MinusEvent);
            taskForm.tmpFormTaskBan += new TasksForm.DataPassBan(TaskBanEvent);
            taskForm.tmpFormBorderLess += new TasksForm.DataPassBordorLess(BorderEvent);
            mainForm = new MainForm(taskForm);

            mainForm.Show();
            

        }

        private void TmpForm_SizeChanged(object sender, EventArgs e)
        {
            if (selectTask != null)
            {
                thisForm.GetWindowPosition(thisForm.TaskHandle, ref point, ref size);
                selectTask.FormResize(thisForm.TaskSize);
            }
        }

        bool BanResize = false;
        private void BorderEvent(bool makeBorder)
        {
            this.FormBorderStyle = makeBorder ? FormBorderStyle.Sizable : FormBorderStyle.None;
            BanResize = makeBorder;
        }

        private void TmpForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ViewEvent(bool data)
        {
            if (data)
            {
                this.Show();
                searchForm.Show();
            }
            else
            {
                this.Hide();
                searchForm.Hide();
            }               
        }

        #region 화면이동
        bool mouseDown;
        Point lastLocation;
        int startX;
        int startY;
        private void GlobalHook_MouseMove(object sender, MouseEventArgs e)
        {
            IntPtr tmphwnd = GetForegroundWindow();
            if (mouseDown && focusedTask(tmphwnd))
            {

                this.Location = new Point(
                    startX + e.X, startY + e.Y);
                searcherPointChange();
                this.Update();
            }
        }
        private bool focusedTask(IntPtr tmphwnd)
        {
            if (selectTask == null)
                return tmphwnd == this.Handle;
            else
                return tmphwnd == this.Handle || tmphwnd == selectTask.TaskHandle;
        }
        private void searcherPointChange()
        {
            int searchX = this.Location.X + (this.Width / 2) - (searchForm.Width / 2);
            searchForm.Location = new Point(searchX, this.Location.Y - 50);
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
            {
                mouseDown = true;
                lastLocation = e.Location;
                startX = (this.Location.X - lastLocation.X);
                startY = (this.Location.Y - lastLocation.Y);
            }
            if (BanResize)
                mouseDown = false;

        }
        #endregion

        private void TmpForm_Closing1(object sender, FormClosingEventArgs e)
        {
            if (selectTask != null)
            {
                ChangeDisplay();
            }
        }
        private void TmpForm_Closing(object sender, FormClosedEventArgs e)
        {
            if (selectTask != null)
            {
                ChangeDisplay();
            }
        }
        #region 다른 폼에서 영향
        private void TaskBanEvent(bool taskBan)
        {
            if(selectTask != null)
            {
                selectTask.TaskClickBan(taskBan);
            }
            Enabled = !taskBan;
        }
        private void ReceivedHwndEvent(IntPtr data)
        {
            openWindow(data);
            Size = new Size(selectTask.TaskSize.Width, selectTask.TaskSize.Height);
            searcherPointChange();

        }
        private void RefreshEvent(IntPtr data)
        {
            if (selectTask != null)
                ChangeDisplay();
            Size = new Size(500,500);
            searcherPointChange();
        }
        int opacity = 100;
        private void OpacityEvent(int data)
        {
            opacity = data;
            if (selectTask != null)
            {
                byte formOpacity = Convert.ToByte((255 * data) / 100);
                selectTask.OpacityChange(formOpacity);

                var formStyle = GetWindowLong(thisForm.TaskHandle, -20);
               // SetWindowLong(selectTask.TaskHandle, GWL_EXSTYLE, formStyle | WS_EX_LAYERERD);
                SetLayeredWindowAttributes(thisForm.TaskHandle, 0, formOpacity, LWA_ALPHA);
            }
        }

        private void PlusEvent(int sWidth, int sHeight)
        {
            this.Width += 30;
            this.Height += 20;
            selectTask.TaskResize('+');
        }

        private void MinusEvent(int sWidth, int sHeight)
        {
            this.Width -= 30;
            this.Height -= 20;
            selectTask.TaskResize('-');
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
            selectTask.TaskEnter(panel1.Handle);           
            SetForegroundWindow(this.Handle);
            OpacityEvent(opacity);
            TopMost = true;
        }      
        private void ChangeDisplay()
        {
            if (selectTask != null)
            {
                selectTask.TaskExit(winInfo.TaskHandle);
                selectTask = null;
                GC.Collect();
                TopMost = true;
            }                        
        }     
    }
}
