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
using CefSharp;
using CefSharp.WinForms;
using Overlay.forms;

namespace Overlay.addlayers
{
	public partial class overlayform_mococo : Form
	{
		private bool form_dragging;
		private int form_left;
		private int form_top;
		private MainForm.POINT firstPoint;
		MainForm main = new MainForm();
		mococoForm MococoForm; 
		ChromiumWebBrowser chrome;

		const int WM_NCHITTEST = 0x0084;
		const int HTCLIENT = 1;
		const int HTCAPTION = 2;
		public overlayform_mococo()
		{
			InitializeComponent();
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
			this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseMove);
			this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseUp);
			InitializeChromeBrowser();
			//webBrowser1.Navigate(webURL);
			//webBrowser1.Navigate(main.getUrlAddress());
		}
		[DllImport("user32", CharSet = CharSet.None, ExactSpelling = false)]
		public static extern int GetCursorPos(out MainForm.POINT pt);

		public string webURL { get; set; }

		//public void navigateBrowser() => this.webBrowser1.Navigate(this.webURL);
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
		public void clicknotuse(bool check)
        {
			if(check == true)
            {
				Enabled = false;
			}
            else
            {
				Enabled = true;
			}
        }
		private void InitializeChromeBrowser()
		{
			//CefSettings cefSettings = new CefSettings();
			//MococoForm = new mococoForm();
			//chrome = new ChromiumWebBrowser(MococoForm.tbLink.Text);
			//chrome = new ChromiumWebBrowser("https://www.naver.com");
			//panel2.Dock = DockStyle.Fill;// Form창에 ChrominumWebCrowser 가득 채우기
										 //Cef.Initialize(cefSettings);
			//panel2.Controls.Clear();
			//panel2.Controls.Add(chrome);
		}

        private void overlayform_mococo_Load(object sender, EventArgs e)
        {
			/*
			CefSettings cefSettings = new CefSettings();
			MococoForm = new mococoForm();
			chrome = new ChromiumWebBrowser(MococoForm.tbLink.Text);
			//chrome = new ChromiumWebBrowser("https://www.naver.com");
			panel2.Dock = DockStyle.Fill;// Form창에 ChrominumWebCrowser 가득 채우기
										 //Cef.Initialize(cefSettings);
			panel2.Controls.Clear();
			panel2.Controls.Add(chrome);
			*/
			webView.Source = new System.Uri(webURL);
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

        private void webView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
			webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
		}
		private void CoreWebView2_NewWindowRequested(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
		{
			e.NewWindow = webView.CoreWebView2;
		}
	}
}
