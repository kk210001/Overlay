using Overlay.forms;
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

namespace Overlay
{
    public partial class MainForm : Form
    {
		private POINT tempPoint;
		private bool form_dragging;
		private int form_left;
		private MainForm.POINT firstPoint;
		private int form_top;
		private overlayform_mococo _overlayform_mococo;
		private bool dragging;
		private int bar_value;
		private IntPtr appHwnd;
		private RECT rect;
		private int app_left;



		[DllImport("user32")]
		public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

		public MainForm()
        {
            InitializeComponent();
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            this.top_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
            this.top_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseUp);
			//this.KeyPreview = true;
			//this.Load += new EventHandler(this.menu_mococo_Load);
			//this.pbscrollBarPoint.MouseDown += new MouseEventHandler(this.scrollBar_point_MouseDown);
			//this.pbscrollBarPoint.MouseMove += new MouseEventHandler(this.scrollBar_point_MouseMove);
			//this.pbscrollBarPoint.MouseUp += new MouseEventHandler(this.scrollBar_point_MouseUp);
			//this.pbscrollBarBack.MouseDown += new MouseEventHandler(this.scrollBar_back_MouseDown);
			//this.pbscrollBarBack.MouseMove += new MouseEventHandler(this.scrollBar_back_MouseMove);
			//this.pbscrollBarBack.MouseUp += new MouseEventHandler(this.scrollBar_back_MouseUp);
		}

        

        TasksForm taskForm = null;
		public MainForm(TasksForm tasksForm) : this()
        {
            taskForm = tasksForm;

		}
		[DllImport("user32", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern int GetCursorPos(out MainForm.POINT pt);
		private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.FromHandle(Properties.Resources.taskbar_icon.GetHicon());
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

		private void top_panel_MouseUp(object sender, MouseEventArgs e)
		{
			this.form_dragging = false;
		}
		public struct POINT
		{
			public int x;

			public int y;
		}

        private void close_top_Click(object sender, EventArgs e)
        {
			Environment.Exit(0); // 창 닫기
		}

        private void minimize_top_Click(object sender, EventArgs e)
        {
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized; //창 최소화
		}

        private void menu_mococo_Click(object sender, EventArgs e)
        {
			if(menu_panel_1.BackColor.R != 255)
            {
				menu_panel_1.BackColor = Color.FromArgb(255, 81, 36);
				menu_panel_2.BackColor = Color.FromArgb(17, 17, 17);
				menu_panel_3.BackColor = Color.FromArgb(17, 17, 17);
				mococoForm _mococoForm = new mococoForm();
				_mococoForm.TopLevel = false;
				panel_contents.Controls.Clear();
				panel_contents.BringToFront();
				panel_contents.Controls.Add(_mococoForm);
				_mococoForm.Show();
				GC.Collect();
				GC.WaitForFullGCComplete();
			}
        }

        private void menu_boss_Click(object sender, EventArgs e)
        {
			if (this.menu_panel_2.BackColor.R != 255)
			{
				this.menu_panel_2.BackColor = Color.FromArgb(255, 81, 36);
				this.menu_panel_1.BackColor = Color.FromArgb(17, 17, 17);
				this.menu_panel_3.BackColor = Color.FromArgb(17, 17, 17);

				imageForm _imageForm = new imageForm();
				_imageForm.TopLevel = false;
				panel_contents.Controls.Clear();
				panel_contents.BringToFront();
				panel_contents.Controls.Add(_imageForm);
				_imageForm.Show();
				GC.Collect();
				GC.WaitForFullGCComplete();
            }
		}

        private void menu_tasks_Click(object sender, EventArgs e)
        {
			if (this.menu_panel_3.BackColor.R != 255)
			{
				this.menu_panel_3.BackColor = Color.FromArgb(255, 81, 36);
				this.menu_panel_1.BackColor = Color.FromArgb(17, 17, 17);
				this.menu_panel_2.BackColor = Color.FromArgb(17, 17, 17);
				taskForm.TopLevel= false;
				panel_contents.Controls.Clear();
				panel_contents.BringToFront();
				panel_contents.Controls.Add(taskForm);
				taskForm.Dock = DockStyle.Fill;
				taskForm.Show();
				GC.Collect();
				GC.WaitForFullGCComplete();
			}
		}


		//private void menu_mococo_Load(object sender, EventArgs e)
		//{
		//	// 스크롤바 로직 
		//	Image imgBack = Properties.Resources.scrollbar_back;
		//	Image imgPoint = Properties.Resources.scrollbar_point;
		//	pbscrollBarBack.Image = imgBack;
		//	pbscrollBarPoint.Image = imgPoint;
		//	this.bar_value = 75;
		//	this.pbscrollBarPoint.Left = (int)((double)(this.bar_value - 8) / (100.0 / (double)this.pbscrollBarBack.Width) + (double)this.pbscrollBarBack.Left);
		//	this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
		//}

		//private void scrollBar_point_MouseDown(object sender, MouseEventArgs e)
		//{
		//	if (this.dragging)
		//		return;
		//	this.dragging = true;
		//	GetWindowRect(this.appHwnd, ref this.rect);
		//	this.app_left = this.rect.left;
		//}

		//private void scrollBar_point_MouseMove(object sender, MouseEventArgs e)
		//{
		//	if (!this.dragging)
		//		return;
		//	GetCursorPos(out this.tempPoint);
		//	if (this.tempPoint.x <= this.app_left + 201 + this.pbscrollBarBack.Left || this.tempPoint.x >= this.app_left + 201 + this.pbscrollBarBack.Right)
		//		return;
		//	this.pbscrollBarPoint.Left = this.tempPoint.x - (this.app_left + 201) - 15;
		//	this.bar_value = (int)((double)(this.pbscrollBarPoint.Left - this.pbscrollBarBack.Left) * (100.0 / (double)this.pbscrollBarBack.Width)) + 8;
		//	if (this.bar_value > 95)
		//		this.bar_value = 100;
		//	else if (this.bar_value < 10)
		//		this.bar_value = 10;
		//	this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
		//	if (!this._overlayform_mococo.IsHandleCreated)
		//		return;
		//	this._overlayform_mococo.Opacity = (double)this.bar_value / 100.0;
		//}

		//private void scrollBar_point_MouseUp(object sender, MouseEventArgs e) => this.dragging = false;

		//private void scrollBar_back_MouseDown(object sender, MouseEventArgs e)
		//{
		//	if (this.dragging)
		//		return;
		//	this.dragging = true;
		//	GetWindowRect(this.appHwnd, ref this.rect);
		//	this.app_left = this.rect.left;
		//}

		//private void scrollBar_back_MouseMove(object sender, MouseEventArgs e)
		//{
		//	if (!this.dragging)
		//		return;
		//	GetCursorPos(out this.tempPoint);
		//	if (this.tempPoint.x <= this.app_left + 201 + this.pbscrollBarBack.Left || this.tempPoint.x >= this.app_left + 201 + this.pbscrollBarBack.Right)
		//		return;
		//	this.pbscrollBarPoint.Left = this.tempPoint.x - (this.app_left + 201) - 15;
		//	this.bar_value = (int)((double)(this.pbscrollBarPoint.Left - this.pbscrollBarBack.Left) * (100.0 / (double)this.pbscrollBarBack.Width)) + 8;
		//	if (this.bar_value > 95)
		//		this.bar_value = 100;
		//	else if (this.bar_value < 10)
		//		this.bar_value = 10;
		//	this.lbTransParent.Text = "불투명도 (" + this.bar_value.ToString() + "%)";
		//	if (!this._overlayform_mococo.IsHandleCreated)
		//		return;
		//	this._overlayform_mococo.Opacity = (double)this.bar_value / 100.0;
		//}

		//private void scrollBar_back_MouseUp(object sender, MouseEventArgs e) => this.dragging = false;

		////public void isChecked(bool check)
		////      {	
		////	if (check)
		////          {
		////		this._overlayform_mococo = new overlayform_mococo();
		////		this._overlayform_mococo.Show();
		////          }
		////          else
		////          {
		////		this._overlayform_mococo.Close();
		////	}
		////      }


		//private void checkBox1_CheckedChanged(object sender, EventArgs e)
		//      {

		//	isChecked(checkBox1.Checked);
		//}

		//      private void checkBox2_Click(object sender, EventArgs e)
		//      {
		//	this._overlayform_mococo.clicknotuse(checkBox2.Checked);
		//}

		//      private void button1_Click(object sender, EventArgs e)
		//      {
		//	_overlayform_mococo.webURL = lb.Text; 
		//	//_overlayform_mococo.navigateBrowser();
		//	//System.Diagnostics.Process.Start(txt);

		//}
		//public string getUrlAddress()
		//      {
		//	return textBox1.Text;
		//}
		//public void setUrlAddress(string setAddress)
		//{
		//	textBox1.Text = setAddress;
		//}



		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
	}
}
