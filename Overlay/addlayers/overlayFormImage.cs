using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Overlay.addlayers
{
    public partial class overlayFormImage : Form
    {
        private bool form_dragging;
        private int form_left;
        private int form_top;
        private MainForm.POINT firstPoint;
        CommonOpenFileDialog dialog;
        List<string> imgpath;
        int ncount = 0;
        private double ratio = 1.0F;
        private Point imgPoint;
        private Rectangle imgRect;
        private Point clickPoint;
        private Point LastPoint;

        const int WM_NCHITTEST = 0x0084;
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        public overlayFormImage()
        {
            InitializeComponent();
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseUp);
            pictureBox1.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);
            btnNext.Click += BtnNext_Click;
            btnPrev.Click += BtnPrev_Click;
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                e.Graphics.DrawImage(pictureBox1.Image, imgRect);
                pictureBox1.Focus();
            }
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            PictureBox pb = (PictureBox)sender;

            if (lines > 0)
            {
                ratio *= 1.1F;
                if (ratio > 100.0) ratio = 100.0f;

                imgRect.Width = (int)Math.Round(pictureBox1.Width * ratio);
                imgRect.Height = (int)Math.Round(pictureBox1.Height * ratio);
                imgRect.X = -(int)Math.Round(1.1F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(1.1F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }
            else if (lines < 0)
            {
                ratio *= 0.9F;
                if (ratio < 1) ratio = 1;

                imgRect.Width = (int)Math.Round(pictureBox1.Width * ratio);
                imgRect.Height = (int)Math.Round(pictureBox1.Height * ratio);
                imgRect.X = -(int)Math.Round(0.9F * (imgPoint.X - imgRect.X) - imgPoint.X);
                imgRect.Y = -(int)Math.Round(0.9F * (imgPoint.Y - imgRect.Y) - imgPoint.Y);
            }

            if (imgRect.X > 0) imgRect.X = 0;
            if (imgRect.Y > 0) imgRect.Y = 0;
            if (imgRect.X + imgRect.Width < pictureBox1.Width) imgRect.X = pictureBox1.Width - imgRect.Width;
            if (imgRect.Y + imgRect.Height < pictureBox1.Height) imgRect.Y = pictureBox1.Height - imgRect.Height;
            pictureBox1.Invalidate();
        }


        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (imgpath == null) return;
            else if (ncount == 0) ncount = imgpath.Count - 1;
            else
                ncount--;
            imgpath = GetImageFiles(dialog.FileName);
            pictureBox1.Image = Bitmap.FromFile(imgpath[ncount]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Invalidate();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (imgpath == null) return;
            else if (ncount == imgpath.Count - 1) ncount = 0;
            else
                ncount++;
            imgpath = GetImageFiles(dialog.FileName);
            pictureBox1.Image = Bitmap.FromFile(imgpath[ncount]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.Invalidate();
        }

        public overlayFormImage(CommonOpenFileDialog setdialog) : this()
        {
            dialog = setdialog;
            try
            {
                if(dialog != null) {
                    imgpath = GetImageFiles(dialog.FileName);
                    pictureBox1.Image = Bitmap.FromFile(imgpath[0]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    imgPoint = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
                    imgRect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
                    ratio = 1.0;
                    clickPoint = imgPoint;
                    pictureBox1.Invalidate();
                }
                else
                {
                    MessageBox.Show("경로를 입력하지 않았습니다.");
                    this.Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("이미지를 찾을 수 없습니다.");
                this.Close();
            }
            
        }

        private void top_panel_MouseUp(object sender, MouseEventArgs e)
        {
            this.form_dragging = false;
        }

        private void top_panel_MouseMove(object sender, MouseEventArgs e)
        {
            MainForm.POINT pOINT;
            if (this.form_dragging)
            {
                MainForm.GetCursorPos(out pOINT);
                base.Left = this.form_left + pOINT.x - this.firstPoint.x;
                base.Top = this.form_top + pOINT.y - this.firstPoint.y;
            }
        }

        private void top_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!this.form_dragging)
            {
                this.form_dragging = true;
                this.form_left = base.Left;
                this.form_top = base.Top;
                MainForm.GetCursorPos(out this.firstPoint);
            }
        }
        public void clicknotuse(bool check)
        {
            if (check == true)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }
        public static List<string> GetImageFiles(string directoryPath)
        {
            List<string> imageFileList = new List<string>();

            foreach (string fileName in Directory.GetFiles(directoryPath))
            {
                if (Regex.IsMatch(fileName, @".jpg|.png|.bmp|.JPG|.PNG|.BMP|.JPEG|.jpeg$"))
                {
                    imageFileList.Add(fileName);
                }
            }
            return imageFileList;

        }
        protected override void WndProc(ref Message m)

        {

            base.WndProc(ref m);

            switch (m.Msg)

            {

                case WM_NCHITTEST:

                    if (m.Result == (IntPtr)HTCLIENT)

                    {

                        m.Result = (IntPtr)HTCAPTION;
                    }

                    break;

            }

        }



        protected override CreateParams CreateParams

        {

            get

            {

                CreateParams cp = base.CreateParams;

                cp.Style |= 0x40000;
                return cp;

            }

        }


    }
   
}
