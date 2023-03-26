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
    public partial class SearchForm : Form
    {
        public delegate void DataPassEventHandler(IntPtr data);       
        public event DataPassEventHandler DataPassEvent;

        int formWidth = 0;
        int formHeight = 0;
        public SearchForm(int width, int height)
        {
            InitializeComponent();          
            SettingComboBoxUrl();

            formWidth = width;
            formHeight = height;
            initData();
        }
        public SearchForm()
        {
            InitializeComponent();
            SettingComboBoxUrl();

        }

        private void initData()
        {

            this.TopMost = true;

            this.Paint += SearchForm_Paint;
            this.StartPosition = FormStartPosition.Manual;
            this.Location= new Point(formWidth, formHeight);
            comboBox1.Text = "네이버";
            
        }

        private void SearchForm_Paint(object sender, PaintEventArgs e)
        {
            webSearchText.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.Black);
            p.Width = 5;
            Graphics g = e.Graphics;
            g.DrawRectangle(p, new Rectangle(webSearchText.Location.X - 3,
                                            webSearchText.Location.Y - 3
                                            , webSearchText.Width + 3,
                                           webSearchText.Height + 3));
        }

        private void SettingComboBoxUrl()
        {
            comboBox1.Items.Add("유튜브");
            comboBox1.Items.Add("네이버");
            comboBox1.Items.Add("구글");
        }



        Process newWeb;
        private void btnWebSearch_Click(object sender, EventArgs e)
        {
            newWeb = null;
            String web = "";
            try
            {
                if (comboBox1.SelectedItem.ToString() == "유튜브")
                {
                    web = "https://www.youtube.com/results?search_query=";
                }
                else if (comboBox1.SelectedItem.ToString() == "구글")
                {
                    web = "https://www.google.com/search?q=";
                }
                else if (comboBox1.SelectedItem.ToString() == "네이버")
                {
                    web = "https://search.naver.com/search.naver?where=nexearch&sm=top_hty&fbm=0&ie=utf8&query=";
                }
                else
                {
                    //검색사이트 추가
                }

            }
            catch(Win32Exception)
            {
                MessageBox.Show("알 수 없는 오류");
            }
            web += webSearchText.Text;
            web = web.Replace("&", "^&");


            newWeb = new Process();
            newWeb.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            newWeb.StartInfo.Arguments = web + " --new-window";
            newWeb.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            newWeb.Start();



            Thread.Sleep(2000);

            Process[] tmpProcess = Process.GetProcessesByName("chrome");
            for (int i = 0; i < tmpProcess.Length; i++)
            {
                if (tmpProcess[i].MainWindowTitle.Contains(webSearchText.Text))
                    newWeb = tmpProcess[i];
            }
            if(newWeb != null)
                DataPassEvent(newWeb.MainWindowHandle);
            this.Refresh();

            webSearchText.Text = "";

        }
        Color color = Color.Green;

        private void pTasks_Paint(object sender, PaintEventArgs e)
        {
            webSearchText.BorderStyle = BorderStyle.None;
            Pen p = new Pen(color);
            p.Width = 3;
            Graphics g = e.Graphics;
            g.DrawRectangle(p, new Rectangle(comboBox1.Location.X ,
                                            comboBox1.Location.Y
                                            , comboBox1.Width + webSearchText.Width + btnWebSearch.Width,
                                           webSearchText.Height));
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "유튜브")
            {
                color = Color.Red;
            }
            else if (comboBox1.SelectedItem.ToString() == "구글")
            {
                color = Color.Blue;
            }
            else if (comboBox1.SelectedItem.ToString() == "네이버")
            {
                color = Color.Green;
            }
            else
            {

            }
            this.Refresh();
        }
    }
}
