
namespace Overlay
{
    partial class MainForm
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
            this.top_panel = new System.Windows.Forms.Panel();
            this.top_text = new System.Windows.Forms.PictureBox();
            this.minimize_top = new System.Windows.Forms.PictureBox();
            this.close_top = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu_mococo = new System.Windows.Forms.Button();
            this.version_state = new System.Windows.Forms.Label();
            this.menu_panel_2 = new System.Windows.Forms.Panel();
            this.menu_panel_1 = new System.Windows.Forms.Panel();
            this.menu_boss = new System.Windows.Forms.Button();
            this.menu_panel_3 = new System.Windows.Forms.Panel();
            this.menu_tasks = new System.Windows.Forms.Button();
            this.panel_tasks = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.panel_contents = new System.Windows.Forms.Panel();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top_text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_tasks.SuspendLayout();
            this.panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.top_panel.Controls.Add(this.top_text);
            this.top_panel.Controls.Add(this.minimize_top);
            this.top_panel.Controls.Add(this.close_top);
            this.top_panel.Controls.Add(this.pictureBox1);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(800, 27);
            this.top_panel.TabIndex = 19;
            // 
            // top_text
            // 
            this.top_text.Image = global::Overlay.Properties.Resources.caption;
            this.top_text.Location = new System.Drawing.Point(29, 4);
            this.top_text.Name = "top_text";
            this.top_text.Size = new System.Drawing.Size(70, 20);
            this.top_text.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.top_text.TabIndex = 21;
            this.top_text.TabStop = false;
            // 
            // minimize_top
            // 
            this.minimize_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.minimize_top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimize_top.Image = global::Overlay.Properties.Resources.minimize_icon;
            this.minimize_top.Location = new System.Drawing.Point(756, 3);
            this.minimize_top.Name = "minimize_top";
            this.minimize_top.Size = new System.Drawing.Size(22, 22);
            this.minimize_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.minimize_top.TabIndex = 19;
            this.minimize_top.TabStop = false;
            this.minimize_top.Click += new System.EventHandler(this.minimize_top_Click);
            // 
            // close_top
            // 
            this.close_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.close_top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_top.Image = global::Overlay.Properties.Resources.close_icon;
            this.close_top.Location = new System.Drawing.Point(778, 3);
            this.close_top.Name = "close_top";
            this.close_top.Size = new System.Drawing.Size(22, 22);
            this.close_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_top.TabIndex = 20;
            this.close_top.TabStop = false;
            this.close_top.Click += new System.EventHandler(this.close_top_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Overlay.Properties.Resources.caption_icon;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menu_mococo
            // 
            this.menu_mococo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_mococo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_mococo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.menu_mococo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menu_mococo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_mococo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menu_mococo.ForeColor = System.Drawing.Color.White;
            this.menu_mococo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_mococo.Location = new System.Drawing.Point(3, 48);
            this.menu_mococo.Name = "menu_mococo";
            this.menu_mococo.Size = new System.Drawing.Size(196, 50);
            this.menu_mococo.TabIndex = 21;
            this.menu_mococo.Text = "웹 페이지";
            this.menu_mococo.UseVisualStyleBackColor = true;
            this.menu_mococo.Click += new System.EventHandler(this.menu_mococo_Click);
            // 
            // version_state
            // 
            this.version_state.AutoSize = true;
            this.version_state.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.version_state.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(81)))), ((int)(((byte)(36)))));
            this.version_state.Location = new System.Drawing.Point(26, 22);
            this.version_state.Name = "version_state";
            this.version_state.Size = new System.Drawing.Size(113, 15);
            this.version_state.TabIndex = 22;
            this.version_state.Text = "※ 전체 창모드 필수";
            // 
            // menu_panel_2
            // 
            this.menu_panel_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_panel_2.Location = new System.Drawing.Point(3, 95);
            this.menu_panel_2.Name = "menu_panel_2";
            this.menu_panel_2.Size = new System.Drawing.Size(5, 50);
            this.menu_panel_2.TabIndex = 23;
            // 
            // menu_panel_1
            // 
            this.menu_panel_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_panel_1.Location = new System.Drawing.Point(3, 48);
            this.menu_panel_1.Name = "menu_panel_1";
            this.menu_panel_1.Size = new System.Drawing.Size(5, 50);
            this.menu_panel_1.TabIndex = 22;
            // 
            // menu_boss
            // 
            this.menu_boss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_boss.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_boss.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.menu_boss.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menu_boss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_boss.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menu_boss.ForeColor = System.Drawing.Color.White;
            this.menu_boss.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_boss.Location = new System.Drawing.Point(3, 95);
            this.menu_boss.Name = "menu_boss";
            this.menu_boss.Size = new System.Drawing.Size(196, 50);
            this.menu_boss.TabIndex = 26;
            this.menu_boss.Text = "이미지";
            this.menu_boss.UseVisualStyleBackColor = true;
            this.menu_boss.Click += new System.EventHandler(this.menu_boss_Click);
            // 
            // menu_panel_3
            // 
            this.menu_panel_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_panel_3.Location = new System.Drawing.Point(3, 146);
            this.menu_panel_3.Name = "menu_panel_3";
            this.menu_panel_3.Size = new System.Drawing.Size(5, 50);
            this.menu_panel_3.TabIndex = 24;
            // 
            // menu_tasks
            // 
            this.menu_tasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menu_tasks.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.menu_tasks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.menu_tasks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menu_tasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menu_tasks.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menu_tasks.ForeColor = System.Drawing.Color.White;
            this.menu_tasks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu_tasks.Location = new System.Drawing.Point(3, 146);
            this.menu_tasks.Name = "menu_tasks";
            this.menu_tasks.Size = new System.Drawing.Size(196, 50);
            this.menu_tasks.TabIndex = 27;
            this.menu_tasks.Text = "작업프로그램";
            this.menu_tasks.UseVisualStyleBackColor = true;
            this.menu_tasks.Click += new System.EventHandler(this.menu_tasks_Click);
            // 
            // panel_tasks
            // 
            this.panel_tasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel_tasks.Controls.Add(this.panel1);
            this.panel_tasks.Controls.Add(this.button7);
            this.panel_tasks.Location = new System.Drawing.Point(201, 32);
            this.panel_tasks.Name = "panel_tasks";
            this.panel_tasks.Size = new System.Drawing.Size(599, 684);
            this.panel_tasks.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(25, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 602);
            this.panel1.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(512, 14);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panel_menu
            // 
            this.panel_menu.Controls.Add(this.menu_panel_3);
            this.panel_menu.Controls.Add(this.menu_panel_2);
            this.panel_menu.Controls.Add(this.menu_panel_1);
            this.panel_menu.Controls.Add(this.menu_tasks);
            this.panel_menu.Controls.Add(this.menu_boss);
            this.panel_menu.Controls.Add(this.menu_mococo);
            this.panel_menu.Controls.Add(this.version_state);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 27);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(200, 691);
            this.panel_menu.TabIndex = 47;
            // 
            // panel_contents
            // 
            this.panel_contents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contents.Location = new System.Drawing.Point(200, 27);
            this.panel_contents.Name = "panel_contents";
            this.panel_contents.Size = new System.Drawing.Size(600, 691);
            this.panel_contents.TabIndex = 48;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(800, 718);
            this.ControlBox = false;
            this.Controls.Add(this.panel_contents);
            this.Controls.Add(this.panel_tasks);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.top_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OverLay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.top_text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_tasks.ResumeLayout(false);
            this.panel_menu.ResumeLayout(false);
            this.panel_menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.PictureBox top_text;
        private System.Windows.Forms.PictureBox minimize_top;
        private System.Windows.Forms.PictureBox close_top;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button menu_mococo;
        private System.Windows.Forms.Label version_state;
        private System.Windows.Forms.Panel menu_panel_2;
        private System.Windows.Forms.Panel menu_panel_1;
        private System.Windows.Forms.Button menu_boss;
        private System.Windows.Forms.Panel menu_panel_3;
        private System.Windows.Forms.Button menu_tasks;
        private System.Windows.Forms.Panel panel_tasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_contents;
    }
}

