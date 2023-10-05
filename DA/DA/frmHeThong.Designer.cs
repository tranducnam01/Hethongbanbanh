namespace DA
{
    partial class frmHeThong
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
            this.panel_Left = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQLK = new System.Windows.Forms.Button();
            this.btnQLHH = new System.Windows.Forms.Button();
            this.btnQLHD = new System.Windows.Forms.Button();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.Purple;
            this.panel_Left.Controls.Add(this.pictureBox1);
            this.panel_Left.Controls.Add(this.btnDangXuat);
            this.panel_Left.Controls.Add(this.btnQLK);
            this.panel_Left.Controls.Add(this.btnQLHH);
            this.panel_Left.Controls.Add(this.btnQLHD);
            this.panel_Left.Controls.Add(this.btnQLNV);
            this.panel_Left.Controls.Add(this.btnTrangChu);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(182, 730);
            this.panel_Left.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::DA.Properties.Resources._11;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 616);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(182, 77);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // btnQLK
            // 
            this.btnQLK.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnQLK.Location = new System.Drawing.Point(0, 533);
            this.btnQLK.Name = "btnQLK";
            this.btnQLK.Size = new System.Drawing.Size(182, 77);
            this.btnQLK.TabIndex = 1;
            this.btnQLK.Text = "Quản Lý Kho";
            this.btnQLK.UseVisualStyleBackColor = false;
            this.btnQLK.Click += new System.EventHandler(this.btnQLK_Click);
            // 
            // btnQLHH
            // 
            this.btnQLHH.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnQLHH.Location = new System.Drawing.Point(0, 450);
            this.btnQLHH.Name = "btnQLHH";
            this.btnQLHH.Size = new System.Drawing.Size(182, 77);
            this.btnQLHH.TabIndex = 1;
            this.btnQLHH.Text = "Quản Lý Hàng Hóa";
            this.btnQLHH.UseVisualStyleBackColor = false;
            this.btnQLHH.Click += new System.EventHandler(this.btnQLHH_Click);
            // 
            // btnQLHD
            // 
            this.btnQLHD.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnQLHD.Location = new System.Drawing.Point(0, 367);
            this.btnQLHD.Name = "btnQLHD";
            this.btnQLHD.Size = new System.Drawing.Size(182, 77);
            this.btnQLHD.TabIndex = 1;
            this.btnQLHD.Text = "Quản Lý Hóa Đơn";
            this.btnQLHD.UseVisualStyleBackColor = false;
            this.btnQLHD.Click += new System.EventHandler(this.btnQLHD_Click);
            // 
            // btnQLNV
            // 
            this.btnQLNV.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnQLNV.Location = new System.Drawing.Point(0, 284);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(182, 77);
            this.btnQLNV.TabIndex = 1;
            this.btnQLNV.Text = "Quản Lý Nhân Viên";
            this.btnQLNV.UseVisualStyleBackColor = false;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnTrangChu.Location = new System.Drawing.Point(0, 201);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(182, 77);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang Chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panel_Body
            // 
            this.panel_Body.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Body.BackColor = System.Drawing.Color.Thistle;
            this.panel_Body.Controls.Add(this.pictureBox2);
            this.panel_Body.Location = new System.Drawing.Point(182, 85);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(950, 730);
            this.panel_Body.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::DA.Properties.Resources._1;
            this.pictureBox2.Location = new System.Drawing.Point(399, 324);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 154);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Purple;
            this.panel_Top.Controls.Add(this.label1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(182, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(950, 84);
            this.panel_Top.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home";
            // 
            // frmHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 730);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel_Left);
            this.Name = "frmHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống";
            this.panel_Left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Button btnQLK;
        private System.Windows.Forms.Button btnQLHH;
        private System.Windows.Forms.Button btnQLHD;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Panel panel_Body;
    }
}