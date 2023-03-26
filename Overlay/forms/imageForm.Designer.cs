
namespace Overlay
{
    partial class imageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbscrollBarPoint = new System.Windows.Forms.PictureBox();
            this.pbscrollBarBack = new System.Windows.Forms.PictureBox();
            this.btnSearchImage = new System.Windows.Forms.Button();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.lbTransParent = new System.Windows.Forms.Label();
            this.cbVisible = new System.Windows.Forms.CheckBox();
            this.cbNotClickable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbscrollBarPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbscrollBarBack)).BeginInit();
            this.SuspendLayout();
            // 
            // pbscrollBarPoint
            // 
            this.pbscrollBarPoint.Location = new System.Drawing.Point(453, 154);
            this.pbscrollBarPoint.Name = "pbscrollBarPoint";
            this.pbscrollBarPoint.Size = new System.Drawing.Size(29, 34);
            this.pbscrollBarPoint.TabIndex = 62;
            this.pbscrollBarPoint.TabStop = false;
            // 
            // pbscrollBarBack
            // 
            this.pbscrollBarBack.Location = new System.Drawing.Point(319, 154);
            this.pbscrollBarBack.Name = "pbscrollBarBack";
            this.pbscrollBarBack.Size = new System.Drawing.Size(227, 20);
            this.pbscrollBarBack.TabIndex = 61;
            this.pbscrollBarBack.TabStop = false;
            // 
            // btnSearchImage
            // 
            this.btnSearchImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnSearchImage.FlatAppearance.BorderSize = 0;
            this.btnSearchImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearchImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchImage.ForeColor = System.Drawing.Color.White;
            this.btnSearchImage.Location = new System.Drawing.Point(471, 377);
            this.btnSearchImage.Name = "btnSearchImage";
            this.btnSearchImage.Size = new System.Drawing.Size(75, 23);
            this.btnSearchImage.TabIndex = 59;
            this.btnSearchImage.Text = "찾아오기";
            this.btnSearchImage.UseVisualStyleBackColor = false;
            // 
            // tbImage
            // 
            this.tbImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.tbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbImage.ForeColor = System.Drawing.Color.White;
            this.tbImage.Location = new System.Drawing.Point(266, 315);
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(280, 21);
            this.tbImage.TabIndex = 58;
            // 
            // lbTransParent
            // 
            this.lbTransParent.AutoSize = true;
            this.lbTransParent.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTransParent.ForeColor = System.Drawing.Color.White;
            this.lbTransParent.Location = new System.Drawing.Point(36, 154);
            this.lbTransParent.Name = "lbTransParent";
            this.lbTransParent.Size = new System.Drawing.Size(55, 15);
            this.lbTransParent.TabIndex = 56;
            this.lbTransParent.Text = "불투명도";
            // 
            // cbVisible
            // 
            this.cbVisible.AutoSize = true;
            this.cbVisible.Location = new System.Drawing.Point(520, 38);
            this.cbVisible.Name = "cbVisible";
            this.cbVisible.Size = new System.Drawing.Size(15, 14);
            this.cbVisible.TabIndex = 53;
            this.cbVisible.UseVisualStyleBackColor = true;
            // 
            // cbNotClickable
            // 
            this.cbNotClickable.AutoSize = true;
            this.cbNotClickable.Location = new System.Drawing.Point(520, 87);
            this.cbNotClickable.Name = "cbNotClickable";
            this.cbNotClickable.Size = new System.Drawing.Size(15, 14);
            this.cbNotClickable.TabIndex = 55;
            this.cbNotClickable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "표시";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 54;
            this.label2.Text = "클릭 불가";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(36, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "이미지경로";
            // 
            // imageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(599, 684);
            this.Controls.Add(this.pbscrollBarPoint);
            this.Controls.Add(this.pbscrollBarBack);
            this.Controls.Add(this.btnSearchImage);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.lbTransParent);
            this.Controls.Add(this.cbVisible);
            this.Controls.Add(this.cbNotClickable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "imageForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbscrollBarPoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbscrollBarBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbscrollBarPoint;
        private System.Windows.Forms.PictureBox pbscrollBarBack;
        private System.Windows.Forms.Button btnSearchImage;
        public System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.Label lbTransParent;
        private System.Windows.Forms.CheckBox cbVisible;
        private System.Windows.Forms.CheckBox cbNotClickable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}