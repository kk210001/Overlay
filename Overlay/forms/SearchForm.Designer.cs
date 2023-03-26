
namespace Overlay
{
    partial class SearchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.pTasks = new System.Windows.Forms.Panel();
            this.webSearchText = new System.Windows.Forms.TextBox();
            this.btnWebSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pTasks
            // 
            this.pTasks.BackColor = System.Drawing.Color.Silver;
            this.pTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTasks.Location = new System.Drawing.Point(0, 0);
            this.pTasks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pTasks.Name = "pTasks";
            this.pTasks.Size = new System.Drawing.Size(450, 73);
            this.pTasks.TabIndex = 4;
            this.pTasks.Paint += new System.Windows.Forms.PaintEventHandler(this.pTasks_Paint);
            // 
            // webSearchText
            // 
            this.webSearchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.webSearchText.Location = new System.Drawing.Point(96, 26);
            this.webSearchText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.webSearchText.Multiline = true;
            this.webSearchText.Name = "webSearchText";
            this.webSearchText.Size = new System.Drawing.Size(211, 18);
            this.webSearchText.TabIndex = 5;
            // 
            // btnWebSearch
            // 
            this.btnWebSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnWebSearch.Image")));
            this.btnWebSearch.Location = new System.Drawing.Point(307, 26);
            this.btnWebSearch.Margin = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.btnWebSearch.Name = "btnWebSearch";
            this.btnWebSearch.Size = new System.Drawing.Size(35, 20);
            this.btnWebSearch.TabIndex = 6;
            this.btnWebSearch.UseVisualStyleBackColor = true;
            this.btnWebSearch.Click += new System.EventHandler(this.btnWebSearch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(37, 26);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10, 8, 100, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 20);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(450, 73);
            this.Controls.Add(this.webSearchText);
            this.Controls.Add(this.btnWebSearch);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pTasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SearchForm";
            this.ShowInTaskbar = false;
            this.Text = "작업프로그램";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pTasks;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox webSearchText;
        private System.Windows.Forms.Button btnWebSearch;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

