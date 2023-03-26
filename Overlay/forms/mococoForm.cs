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
using Overlay.addlayers;

namespace Overlay.forms
{
    public partial class mococoForm : Form
    {
        overlayform_mococo _overlayform_mococo = new overlayform_mococo();
        Boolean movemouse = false;
        Point positionCurseurImage = new Point(0, 0);
        //private mococoForm.POINT tempPoint;
        private IntPtr appHwnd;
        private int app_left;
        private int bar_value;
        private bool dragging;
        private Point start_p;
        private Point end_p;
        private bool mouse_move = false;
        //private mococoForm.RECT rect;

        //[DllImport("user32")]
        //public static extern int GetWindowRect(IntPtr hwnd, ref mococoForm.RECT lpRect);

        //[DllImport("user32")]
        //public static extern int GetCursorPos(out mococoForm.POINT pt);

        public mococoForm()
        {
            InitializeComponent();
            InitializeEvent();
            InitializeProp();
            pbscrollBarBack.Image = Properties.Resources.scrollbar_back;
            pbscrollBarPoint.Image = Properties.Resources.scrollbar_point;
            bar_value = 75;
            this.pbscrollBarPoint.Left = (int)((double)(this.bar_value - 8) / (100.0 / (double)this.pbscrollBarBack.Width) + (double)this.pbscrollBarBack.Left);
            this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
        }

        private void InitializeProp()
        {
            tbLink.Text = "https://lostark.inven.co.kr/dataninfo/world/?code=10201";
        }

        private void InitializeEvent()
        {
            cbVisible.Click += cbVisible_CheckedChanged;
            cbNotClickable.CheckedChanged += cbNotClickable_CheckedChanged;
            btnApp.Click += btnApp_Click;
            btnInit.Click += btnInit_Click;
            pbscrollBarPoint.MouseDown += pbscrollBarPoint_MouseDown;
            pbscrollBarPoint.MouseMove += pbscrollBarPoint_MouseMove;
            pbscrollBarPoint.MouseUp += PbscrollBarPoint_MouseUp;
            //this.KeyDown += new KeyEventHandler(MococoForm_KeyDown);
        }


        //private void mococoform_keydown(object sender, keyeventargs e)
        //{
            
        //}


        // private void PbscrollBarPoint_MouseUp(object sender, MouseEventArgs e) => this.dragging = false;
        private void PbscrollBarPoint_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_move = false;
            //movemouse = false;
        }

        private void pbscrollBarPoint_MouseMove(object sender, MouseEventArgs e)
        {

            Point th;
            if (mouse_move == true)
            {

                th = this.Location;
                end_p = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                Point tmp = new Point((pbscrollBarPoint.Location.X + (end_p.X - start_p.X)), pbscrollBarBack.Location.Y);
                start_p = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                if (tmp.X + 20 > pbscrollBarBack.Right)
                    return;
                if (tmp.X < pbscrollBarBack.Left)
                    return;

                pbscrollBarPoint.Location = tmp;

                this.bar_value = (int)((double)(this.pbscrollBarPoint.Left - this.pbscrollBarBack.Left) * (100.0 / (double)this.pbscrollBarBack.Width)) + 8;
                if (this.bar_value > 95)
                    this.bar_value = 100;
                else if (this.bar_value < 10)
                    this.bar_value = 10;
                this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
                if (!this._overlayform_mococo.IsHandleCreated)
                    return;
                this._overlayform_mococo.Opacity = (double)this.bar_value / 100.0;
            }

            /*
            if (e.Button == MouseButtons.Left)
            {
                if (pbscrollBarPoint.Left > (pbscrollBarBack.Left + pbscrollBarBack.Right) || pbscrollBarPoint.Left < (pbscrollBarBack.Left + pbscrollBarBack.Right))
                    return;
                this.pbscrollBarPoint.Left += e.X - this.positionCurseurImage.X;
                //else if ()
                //    this.pbscrollBarPoint.Left = pbscrollBarBack.Left - this.positionCurseurImage.X;
                this.bar_value = (int)((double)(this.pbscrollBarPoint.Left - this.pbscrollBarBack.Left) * (100.0 / (double)this.pbscrollBarBack.Width)) + 8;
                if (this.bar_value > 95)
                    this.bar_value = 100;
                else if (this.bar_value < 10)
                    this.bar_value = 10;
                this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
                if (!this._overlayform_mococo.IsHandleCreated)
                    return;
                this._overlayform_mococo.Opacity = (double)this.bar_value / 100.0;
            }
            */
        }

        private void pbscrollBarPoint_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move = true;
            start_p = ((Control)sender).PointToScreen(new Point(e.X, e.Y));

            /*
           
            if (!isPositionCurseurImageSet)
            {

                this.positionCurseurImage = this.pbscrollBarPoint.PointToClient(Cursor.Position);
                pbscrollBarPoint.Left = e.X - this.positionCurseurImage.X;
            }
            movemouse = true;
            */
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            InitializeProp();
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            //lbTransParent.Text = tbLink.Text;
            //throw new NotImplementedException();
        }

        private void cbNotClickable_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNotClickable.Checked)
                _overlayform_mococo.clicknotuse(true);
            else
                _overlayform_mococo.clicknotuse(false);

        }

        private void cbVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVisible.Checked)
            {
                //예외처리
                if(_overlayform_mococo.IsDisposed == true)
                    _overlayform_mococo = new overlayform_mococo();
                _overlayform_mococo.webURL = tbLink.Text;
                //_overlayform_mococo.navigateBrowser();
                _overlayform_mococo.Show();
            }
            else
            {
                _overlayform_mococo.Close();
            }
        }

   
        //public struct RECT
        //{
        //    public int left;
        //    public int top;
        //    public int right;
        //    public int bottom;
        //}
        //public struct POINT
        //{
        //    public int x;
        //    public int y;
        //}
    }
}
