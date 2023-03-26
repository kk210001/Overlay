
using System;
using System.Windows.Forms;

namespace Overlay
{
    partial class NewTmpForm
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
            this.tmpFormMainPanel = new System.Windows.Forms.Panel();
            this.taskListComboBox = new System.Windows.Forms.ComboBox();
            this.tmpFormSidePanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbOpacity = new System.Windows.Forms.TextBox();
            this.cbBan = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.cbSizeSetting = new System.Windows.Forms.CheckBox();
            this.btPlus = new System.Windows.Forms.Button();
            this.btMinus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btFormClose = new System.Windows.Forms.Button();
            this.btSideClose = new System.Windows.Forms.Button();
            this.tmpFormSidePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmpFormMainPanel
            // 
            this.tmpFormMainPanel.BackColor = System.Drawing.Color.White;
            this.tmpFormMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmpFormMainPanel.Location = new System.Drawing.Point(0, 0);
            this.tmpFormMainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tmpFormMainPanel.Name = "tmpFormMainPanel";
            this.tmpFormMainPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tmpFormMainPanel.Size = new System.Drawing.Size(800, 360);
            this.tmpFormMainPanel.TabIndex = 0;
            // 
            // taskListComboBox
            // 
            this.taskListComboBox.FormattingEnabled = true;
            this.taskListComboBox.Location = new System.Drawing.Point(3, 12);
            this.taskListComboBox.Name = "taskListComboBox";
            this.taskListComboBox.Size = new System.Drawing.Size(114, 20);
            this.taskListComboBox.TabIndex = 0;
            this.taskListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.taskListComboBox_DrawItem);
            this.taskListComboBox.DropDown += new System.EventHandler(this.DropDown);
            this.taskListComboBox.SelectedIndexChanged += new System.EventHandler(this.taskListComboBox_SelectedIndexChanged);
            this.taskListComboBox.DropDownClosed += new System.EventHandler(this.DropClosed);
            // 
            // tmpFormSidePanel
            // 
            this.tmpFormSidePanel.BackColor = System.Drawing.Color.Gray;
            this.tmpFormSidePanel.Controls.Add(this.panel3);
            this.tmpFormSidePanel.Controls.Add(this.panel1);
            this.tmpFormSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tmpFormSidePanel.Location = new System.Drawing.Point(0, 0);
            this.tmpFormSidePanel.Name = "tmpFormSidePanel";
            this.tmpFormSidePanel.Size = new System.Drawing.Size(120, 360);
            this.tmpFormSidePanel.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.tbOpacity);
            this.panel3.Controls.Add(this.cbBan);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.cbSizeSetting);
            this.panel3.Controls.Add(this.btPlus);
            this.panel3.Controls.Add(this.btMinus);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 294);
            this.panel3.TabIndex = 0;
            // 
            // tbOpacity
            // 
            this.tbOpacity.Location = new System.Drawing.Point(57, 181);
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(34, 21);
            this.tbOpacity.TabIndex = 0;
            this.tbOpacity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbOpacity_KeyUp);
            // 
            // cbBan
            // 
            this.cbBan.AutoSize = true;
            this.cbBan.Location = new System.Drawing.Point(0, 246);
            this.cbBan.Name = "cbBan";
            this.cbBan.Size = new System.Drawing.Size(76, 16);
            this.cbBan.TabIndex = 4;
            this.cbBan.Text = "화면 잠금";
            this.cbBan.UseVisualStyleBackColor = true;
            this.cbBan.CheckedChanged += new System.EventHandler(this.cbBan_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.taskListComboBox);
            this.panel2.Controls.Add(this.btRefresh);
            this.panel2.Controls.Add(this.btExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 106);
            this.panel2.TabIndex = 0;
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(12, 45);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 26);
            this.btRefresh.TabIndex = 1;
            this.btRefresh.Text = "새로고침";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(12, 80);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "화면초기화";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // cbSizeSetting
            // 
            this.cbSizeSetting.AutoSize = true;
            this.cbSizeSetting.Location = new System.Drawing.Point(0, 224);
            this.cbSizeSetting.Name = "cbSizeSetting";
            this.cbSizeSetting.Size = new System.Drawing.Size(124, 16);
            this.cbSizeSetting.TabIndex = 0;
            this.cbSizeSetting.Text = "사이즈 사용자설정";
            this.cbSizeSetting.UseVisualStyleBackColor = true;
            this.cbSizeSetting.CheckedChanged += new System.EventHandler(this.cbSetSize_CheckedChanged);
            // 
            // btPlus
            // 
            this.btPlus.Location = new System.Drawing.Point(11, 109);
            this.btPlus.Name = "btPlus";
            this.btPlus.Size = new System.Drawing.Size(40, 40);
            this.btPlus.TabIndex = 2;
            this.btPlus.Text = "+";
            this.btPlus.UseVisualStyleBackColor = true;
            this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
            // 
            // btMinus
            // 
            this.btMinus.Location = new System.Drawing.Point(51, 109);
            this.btMinus.Name = "btMinus";
            this.btMinus.Size = new System.Drawing.Size(40, 40);
            this.btMinus.TabIndex = 3;
            this.btMinus.Text = "-";
            this.btMinus.UseVisualStyleBackColor = true;
            this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "투명도";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.btFormClose);
            this.panel1.Controls.Add(this.btSideClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 294);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 66);
            this.panel1.TabIndex = 0;
            // 
            // btFormClose
            // 
            this.btFormClose.Location = new System.Drawing.Point(16, 40);
            this.btFormClose.Name = "btFormClose";
            this.btFormClose.Size = new System.Drawing.Size(75, 23);
            this.btFormClose.TabIndex = 5;
            this.btFormClose.Text = "폼 닫기";
            this.btFormClose.UseVisualStyleBackColor = true;
            this.btFormClose.Click += new System.EventHandler(this.btFormClose_Click);
            // 
            // btSideClose
            // 
            this.btSideClose.Location = new System.Drawing.Point(16, 11);
            this.btSideClose.Name = "btSideClose";
            this.btSideClose.Size = new System.Drawing.Size(75, 23);
            this.btSideClose.TabIndex = 6;
            this.btSideClose.Text = "메뉴 닫기";
            this.btSideClose.UseVisualStyleBackColor = true;
            this.btSideClose.Click += new System.EventHandler(this.btSideClose_Click);
            // 
            // NewTmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.tmpFormSidePanel);
            this.Controls.Add(this.tmpFormMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NewTmpForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.tmpFormSidePanel.ResumeLayout(false);
            this.tmpFormSidePanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tmpFormMainPanel;
        private Panel tmpFormSidePanel;
        private Label label1;
        private Button btMinus;
        private Button btPlus;
        private Button btRefresh;
        private ComboBox taskListComboBox;
        private Button btExit;
        private Button btFormClose;
        private Button btSideClose;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private CheckBox cbBan;
        private CheckBox cbSizeSetting;
        private TextBox tbOpacity;
    }
}

