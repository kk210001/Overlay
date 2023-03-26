
using System;

namespace Overlay
{
    partial class TasksForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_tasks = new System.Windows.Forms.Panel();
            this.cbTaskBan = new System.Windows.Forms.CheckBox();
            this.btDevide = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.cbOverlayView = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.bt_init = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.panel_contents = new System.Windows.Forms.Panel();
            this.taskListView = new System.Windows.Forms.ListView();
            this.cbBorderLess = new System.Windows.Forms.CheckBox();
            this.panel_tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.panel_contents.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_tasks
            // 
            this.panel_tasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel_tasks.Controls.Add(this.cbBorderLess);
            this.panel_tasks.Controls.Add(this.cbTaskBan);
            this.panel_tasks.Controls.Add(this.btDevide);
            this.panel_tasks.Controls.Add(this.btnPlus);
            this.panel_tasks.Controls.Add(this.btnMinus);
            this.panel_tasks.Controls.Add(this.cbOverlayView);
            this.panel_tasks.Controls.Add(this.label1);
            this.panel_tasks.Controls.Add(this.trackBar);
            this.panel_tasks.Controls.Add(this.bt_init);
            this.panel_tasks.Controls.Add(this.bt_refresh);
            this.panel_tasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tasks.Location = new System.Drawing.Point(0, 0);
            this.panel_tasks.Name = "panel_tasks";
            this.panel_tasks.Size = new System.Drawing.Size(800, 684);
            this.panel_tasks.TabIndex = 26;
            // 
            // cbTaskBan
            // 
            this.cbTaskBan.AutoSize = true;
            this.cbTaskBan.ForeColor = System.Drawing.SystemColors.Control;
            this.cbTaskBan.Location = new System.Drawing.Point(372, 106);
            this.cbTaskBan.Name = "cbTaskBan";
            this.cbTaskBan.Size = new System.Drawing.Size(76, 16);
            this.cbTaskBan.TabIndex = 8;
            this.cbTaskBan.Text = "화면 잠금";
            this.cbTaskBan.UseVisualStyleBackColor = true;
            this.cbTaskBan.CheckedChanged += new System.EventHandler(this.cbTaskBan_CheckedChanged);
            // 
            // btDevide
            // 
            this.btDevide.Location = new System.Drawing.Point(491, 129);
            this.btDevide.Name = "btDevide";
            this.btDevide.Size = new System.Drawing.Size(75, 23);
            this.btDevide.TabIndex = 7;
            this.btDevide.Text = "화면분할";
            this.btDevide.UseVisualStyleBackColor = true;
            this.btDevide.Click += new System.EventHandler(this.btDevide_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(121, 119);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(40, 40);
            this.btnPlus.TabIndex = 6;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(177, 119);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(40, 40);
            this.btnMinus.TabIndex = 5;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // cbOverlayView
            // 
            this.cbOverlayView.AutoSize = true;
            this.cbOverlayView.ForeColor = System.Drawing.SystemColors.Control;
            this.cbOverlayView.Location = new System.Drawing.Point(372, 84);
            this.cbOverlayView.Name = "cbOverlayView";
            this.cbOverlayView.Size = new System.Drawing.Size(96, 16);
            this.cbOverlayView.TabIndex = 4;
            this.cbOverlayView.Text = "오버레이표시";
            this.cbOverlayView.UseVisualStyleBackColor = true;
            this.cbOverlayView.CheckedChanged += new System.EventHandler(this.cbOverlayView_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(284, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "투명도 조절";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(372, 129);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(113, 45);
            this.trackBar.TabIndex = 2;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // bt_init
            // 
            this.bt_init.Location = new System.Drawing.Point(491, 84);
            this.bt_init.Name = "bt_init";
            this.bt_init.Size = new System.Drawing.Size(75, 23);
            this.bt_init.TabIndex = 1;
            this.bt_init.Text = "화면초기화";
            this.bt_init.UseVisualStyleBackColor = true;
            this.bt_init.Click += new System.EventHandler(this.bt_init_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(278, 84);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(75, 23);
            this.bt_refresh.TabIndex = 0;
            this.bt_refresh.Text = "새로고침";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // panel_contents
            // 
            this.panel_contents.Controls.Add(this.taskListView);
            this.panel_contents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_contents.Location = new System.Drawing.Point(0, 184);
            this.panel_contents.Name = "panel_contents";
            this.panel_contents.Size = new System.Drawing.Size(800, 534);
            this.panel_contents.TabIndex = 48;
            // 
            // taskListView
            // 
            this.taskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListView.HideSelection = false;
            this.taskListView.Location = new System.Drawing.Point(0, 0);
            this.taskListView.Name = "taskListView";
            this.taskListView.Size = new System.Drawing.Size(800, 534);
            this.taskListView.TabIndex = 0;
            this.taskListView.UseCompatibleStateImageBehavior = false;
            this.taskListView.SelectedIndexChanged += new System.EventHandler(this.taskListView_SelectedIndexChanged);
            // 
            // cbBorderLess
            // 
            this.cbBorderLess.AutoSize = true;
            this.cbBorderLess.ForeColor = System.Drawing.Color.White;
            this.cbBorderLess.Location = new System.Drawing.Point(121, 88);
            this.cbBorderLess.Name = "cbBorderLess";
            this.cbBorderLess.Size = new System.Drawing.Size(116, 16);
            this.cbBorderLess.TabIndex = 9;
            this.cbBorderLess.Text = "사용자 설정 크기";
            this.cbBorderLess.UseVisualStyleBackColor = true;
            this.cbBorderLess.CheckedChanged += new System.EventHandler(this.cbBorderLess_CheckedChanged);
            // 
            // TasksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.ControlBox = false;
            this.Controls.Add(this.panel_contents);
            this.Controls.Add(this.panel_tasks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "TasksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverLay";
            this.panel_tasks.ResumeLayout(false);
            this.panel_tasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.panel_contents.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Panel panel_tasks;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.Panel panel_contents;
        private System.Windows.Forms.Button bt_init;
        private System.Windows.Forms.ListView taskListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.CheckBox cbOverlayView;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btDevide;
        private System.Windows.Forms.CheckBox cbTaskBan;
        private System.Windows.Forms.CheckBox cbBorderLess;
    }
}

