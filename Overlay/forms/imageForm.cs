using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Overlay.addlayers;

namespace Overlay
{
    public partial class imageForm : Form
    {
        overlayFormImage _overlayForm_Image;
        private int bar_value;
        private Point start_p;
        private Point end_p;
        private bool mouse_move = false;
        CommonOpenFileDialog dialog;
        
        public imageForm()
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
            //throw new NotImplementedException();
        }

        private void InitializeEvent()
        {
            cbVisible.Click += cbVisible_Click;
            cbNotClickable.CheckedChanged += cbNotClickable_CheckedChanged;
            btnSearchImage.Click += btnApp_Click;
            pbscrollBarPoint.MouseDown += pbscrollBarPoint_MouseDown;
            pbscrollBarPoint.MouseMove += pbscrollBarPoint_MouseMove;
            pbscrollBarPoint.MouseUp += PbscrollBarPoint_MouseUp;
            btnSearchImage.Click += BtnSearchImage_Click;
        }

        private void BtnSearchImage_Click(object sender, EventArgs e)
        {
            string image_file = string.Empty;
            dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                try
                {
                    tbImage.Text = dialog.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("폴더를 찾을 수 없습니다.");
                }

            }
        }

        private void btnApp_Click(object sender, EventArgs e)
        {
            //lbTransParent.Text = tbLink.Text;
            //throw new NotImplementedException();
        }

        private void cbNotClickable_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNotClickable.Checked)
                _overlayForm_Image.clicknotuse(true);
            else
                _overlayForm_Image.clicknotuse(false);
        }

        private void cbVisible_Click(object sender, EventArgs e)
        {
            if (cbVisible.Checked)
            {
                //예외처리
                //if (_overlayForm_Image.IsDisposed == true)
                _overlayForm_Image = new overlayFormImage(dialog);
                if(_overlayForm_Image.IsDisposed == false)
                    _overlayForm_Image.Show();
            }
            else
            {
                _overlayForm_Image.Close();
            }
        }
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
                if (!this._overlayForm_Image.IsHandleCreated)
                    return;
                this._overlayForm_Image.Opacity = (double)this.bar_value / 100.0;
            }
        }
        private void pbscrollBarPoint_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_move = true;
            start_p = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
        }

    }
}
