using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Overlay
{
    class TaskInfo
    {
        [DllImport("user32.dll")]
        internal static extern bool GetWindowPlacement(IntPtr handle, ref WINDOWPLACEMENT placement);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
        [DllImport("user32.dll")]
        static extern long SetWindowLongPtr(IntPtr hwnd, int nIndex, long dwNewLong);
        [DllImport("user32.dll")]
        static extern bool EnableWindow(IntPtr hwnd, bool bEnable);

        public TaskInfo() { }
        public TaskInfo(TaskInfo newTask)
        {
            newTask.point = this.point;
            newTask.size = this.size;
            newTask.TaskHandle = this.TaskHandle;

        }

        const int LWA_ALPHA = 0x00000002;
        const int GWL_EXSTYLE = -20;
        const int WS_EX_LAYERERD = 0X80000;
        internal enum SHOW_WINDOW_COMMANDS : int
        {
            HIDE = 0,
            NORMAL = 1,
            MINIMIZED = 2,
            MAXIMIZED = 3,

        }
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public SHOW_WINDOW_COMMANDS showc_cmd;
            public Point min_position;
            public Point max_position;
            public Rectangle normal_position;


        }
        private IntPtr taskHandle;
        private Point taskPoint;
        private Size taskSize;

        public IntPtr TaskHandle { get => taskHandle; set => taskHandle = value; }
        public Point TaskPoint { get => taskPoint; set => taskPoint = value; }
        public Size TaskSize { get => taskSize; set => taskSize = value; }

        Point point = new Point();
        Size size = new Size();
        Size currentSize = new Size();

        public void GetWindowPosition(IntPtr hWnd, ref Point point, ref Size size)
        {

            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hWnd, ref placement);

            taskSize = new Size(placement.normal_position.Right - (placement.normal_position.Left * 2),
                placement.normal_position.Bottom - (placement.normal_position.Top * 2));

            taskPoint = new Point(placement.normal_position.Left, placement.normal_position.Top);
        }
        public void OpacityChange(byte opacity)
        {
            var style = GetWindowLong(this.TaskHandle, -20);
            SetWindowLong(this.TaskHandle, GWL_EXSTYLE, style | WS_EX_LAYERERD);
            SetLayeredWindowAttributes(this.TaskHandle, 0, opacity, LWA_ALPHA);
        }
        public void TaskExit(IntPtr winHandle)
        {
            var style = GetWindowLong(this.TaskHandle, -20);
            SetWindowLong(this.TaskHandle, GWL_EXSTYLE, style & ~WS_EX_LAYERERD);
            EnableWindow(this.TaskHandle, true);
            SetParent(this.TaskHandle, winHandle);
            MoveWindow(this.TaskHandle,
                this.TaskPoint.X,
                this.TaskPoint.Y,
                this.TaskSize.Width,
                this.TaskSize.Height,
                true);
            currentSize = new Size(0, 0);
        }
        public void TaskEnter(IntPtr pannelHandle)
        {
            SetParent(this.TaskHandle, pannelHandle);
            MoveWindow(this.TaskHandle, 0, 0, this.TaskSize.Width,
                this.TaskSize.Height, true);
            currentSize = new Size(this.TaskSize.Width, this.TaskSize.Height);
        }
        public void FormResize(Size formSize)
        {
            MoveWindow(this.TaskHandle, 0, 0, formSize.Width,
                formSize.Height, true);
            currentSize = new Size(formSize.Width, formSize.Height);
        }
        public void TaskResize(char oper)
        {
            
            
            if (oper == '+')
            {
                MoveWindow(this.TaskHandle, 0, 0, currentSize.Width + 30,
                                currentSize.Height + 20, true);
                currentSize = new Size(currentSize.Width + 30, currentSize.Height + 20);
            }
            else if(oper == '-')
            {
                MoveWindow(this.TaskHandle, 0, 0, currentSize.Width - 30,
                                currentSize.Height - 20, true);
                currentSize = new Size(currentSize.Width - 30, currentSize.Height - 20);
            }
            
        }
        public void TaskClickBan(bool isBan)
        {
                EnableWindow(this.TaskHandle, !isBan);
        }

    }
}
