using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlay
{
    public partial class IconForm : Form
    {
        public delegate void DataPassSideShow(bool sideMenuShow);
        public event DataPassSideShow sideMenuVisible;
        public IconForm()
        {
            InitializeComponent();
            pictureBox1.Image = ImageOpacity(Properties.Resources.menuIcon, 0.15f);
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave;
            pictureBox1.Click += PictureBox1_Click;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            sideMenuVisible(true);
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = ImageOpacity(Properties.Resources.menuIcon, 0.15f);
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = ImageOpacity(Properties.Resources.menuIcon, 0.9f);
        }

        private Image ImageOpacity(Bitmap imgData, float imgOpacity)
        {
            Bitmap bmpTmp = new Bitmap(imgData.Width, imgData.Height); 
            Graphics gp = Graphics.FromImage(bmpTmp);
            ColorMatrix clrMatrix = new ColorMatrix();
            clrMatrix.Matrix33 = imgOpacity;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            gp.DrawImage(imgData, new Rectangle(0, 0, bmpTmp.Width, bmpTmp.Height), 0, 0, imgData.Width, imgData.Height, GraphicsUnit.Pixel, imgAttribute);
            gp.Dispose(); 
            return bmpTmp;
        }

        public IconForm(Point point) : this()
        {
            this.Location = new Point(point.X, point.Y);
            this.TopMost = true;

        }

    }
}
