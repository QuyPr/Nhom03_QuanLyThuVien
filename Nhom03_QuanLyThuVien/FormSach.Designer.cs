
namespace Nhom03_QuanLyThuVien
{
    partial class FormSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtTriGia = new System.Windows.Forms.TextBox();
            this.txtNhaXB = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDSSach = new System.Windows.Forms.DataGridView();
            this.colMaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNhaXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTriGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptbThoat = new System.Windows.Forms.PictureBox();
            this.ptbXoa = new System.Windows.Forms.PictureBox();
            this.ptbSua = new System.Windows.Forms.PictureBox();
            this.ptbThem = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThoat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(395, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý Thông Tin Sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Sách";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayNhap);
            this.groupBox1.Controls.Add(this.txtNamXB);
            this.groupBox1.Controls.Add(this.txtTacGia);
            this.groupBox1.Controls.Add(this.txtTriGia);
            this.groupBox1.Controls.Add(this.txtNhaXB);
            this.groupBox1.Controls.Add(this.txtTenSach);
            this.groupBox1.Controls.Add(this.txtMaSach);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(363, 342);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Sách";
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(125, 287);
            this.dtpNgayNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(178, 26);
            this.dtpNgayNhap.TabIndex = 3;
            // 
            // txtNamXB
            // 
            this.txtNamXB.Location = new System.Drawing.Point(125, 163);
            this.txtNamXB.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(192, 26);
            this.txtNamXB.TabIndex = 2;
            this.txtNamXB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamXB_KeyPress);
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(125, 123);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(192, 26);
            this.txtTacGia.TabIndex = 1;
            // 
            // txtTriGia
            // 
            this.txtTriGia.Location = new System.Drawing.Point(124, 246);
            this.txtTriGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtTriGia.Name = "txtTriGia";
            this.txtTriGia.Size = new System.Drawing.Size(192, 26);
            this.txtTriGia.TabIndex = 1;
            this.txtTriGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTriGia_KeyPress);
            // 
            // txtNhaXB
            // 
            this.txtNhaXB.Location = new System.Drawing.Point(125, 202);
            this.txtNhaXB.Margin = new System.Windows.Forms.Padding(4);
            this.txtNhaXB.Name = "txtNhaXB";
            this.txtNhaXB.Size = new System.Drawing.Size(192, 26);
            this.txtNhaXB.TabIndex = 1;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(125, 83);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(192, 26);
            this.txtTenSach.TabIndex = 1;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(125, 42);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(192, 26);
            this.txtMaSach.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tác Giã";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên Sách";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 291);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ngày Nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 246);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Trị Giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Năm XB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhà XB";
            // 
            // dgvDSSach
            // 
            this.dgvDSSach.AllowUserToAddRows = false;
            this.dgvDSSach.AllowUserToDeleteRows = false;
            this.dgvDSSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSach,
            this.colTenSach,
            this.ColTacGia,
            this.colNXB,
            this.ColNhaXB,
            this.ColTriGia,
            this.ColNgayNhap});
            this.dgvDSSach.Location = new System.Drawing.Point(380, 124);
            this.dgvDSSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSSach.Name = "dgvDSSach";
            this.dgvDSSach.ReadOnly = true;
            this.dgvDSSach.RowHeadersWidth = 62;
            this.dgvDSSach.Size = new System.Drawing.Size(697, 346);
            this.dgvDSSach.TabIndex = 9;
            this.dgvDSSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSSach_CellClick);
            // 
            // colMaSach
            // 
            this.colMaSach.FillWeight = 80F;
            this.colMaSach.HeaderText = "Mã Sách";
            this.colMaSach.MinimumWidth = 8;
            this.colMaSach.Name = "colMaSach";
            this.colMaSach.ReadOnly = true;
            // 
            // colTenSach
            // 
            this.colTenSach.FillWeight = 140F;
            this.colTenSach.HeaderText = "Tên Sách";
            this.colTenSach.MinimumWidth = 8;
            this.colTenSach.Name = "colTenSach";
            this.colTenSach.ReadOnly = true;
            // 
            // ColTacGia
            // 
            this.ColTacGia.HeaderText = "Tác Giả";
            this.ColTacGia.MinimumWidth = 8;
            this.ColTacGia.Name = "ColTacGia";
            this.ColTacGia.ReadOnly = true;
            // 
            // colNXB
            // 
            this.colNXB.FillWeight = 80F;
            this.colNXB.HeaderText = "Năm XB";
            this.colNXB.MinimumWidth = 8;
            this.colNXB.Name = "colNXB";
            this.colNXB.ReadOnly = true;
            // 
            // ColNhaXB
            // 
            this.ColNhaXB.HeaderText = "Nhà XB";
            this.ColNhaXB.MinimumWidth = 8;
            this.ColNhaXB.Name = "ColNhaXB";
            this.ColNhaXB.ReadOnly = true;
            // 
            // ColTriGia
            // 
            this.ColTriGia.HeaderText = "Trị Giá";
            this.ColTriGia.MinimumWidth = 8;
            this.ColTriGia.Name = "ColTriGia";
            this.ColTriGia.ReadOnly = true;
            // 
            // ColNgayNhap
            // 
            this.ColNgayNhap.HeaderText = "Ngày Nhập";
            this.ColNgayNhap.MinimumWidth = 8;
            this.ColNgayNhap.Name = "ColNgayNhap";
            this.ColNgayNhap.ReadOnly = true;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(807, 86);
            this.txtFind.Margin = new System.Windows.Forms.Padding(4);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(242, 22);
            this.txtFind.TabIndex = 8;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::Nhom03_QuanLyThuVien.Properties.Resources.pngtree_vector_search_icon_png_image_848679;
            this.pictureBox1.Location = new System.Drawing.Point(723, 74);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // ptbThoat
            // 
            this.ptbThoat.BackColor = System.Drawing.Color.White;
            this.ptbThoat.Image = global::Nhom03_QuanLyThuVien.Properties.Resources.pngtree_exit_direction_line_icon_vector_png_image_5195526;
            this.ptbThoat.Location = new System.Drawing.Point(151, 474);
            this.ptbThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbThoat.Name = "ptbThoat";
            this.ptbThoat.Size = new System.Drawing.Size(91, 67);
            this.ptbThoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbThoat.TabIndex = 12;
            this.ptbThoat.TabStop = false;
            this.ptbThoat.Click += new System.EventHandler(this.ptbThoat_Click);
            // 
            // ptbXoa
            // 
            this.ptbXoa.BackColor = System.Drawing.Color.White;
            this.ptbXoa.Image = global::Nhom03_QuanLyThuVien.Properties.Resources._3221845;
            this.ptbXoa.Location = new System.Drawing.Point(268, 389);
            this.ptbXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbXoa.Name = "ptbXoa";
            this.ptbXoa.Size = new System.Drawing.Size(93, 67);
            this.ptbXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbXoa.TabIndex = 11;
            this.ptbXoa.TabStop = false;
            this.ptbXoa.Click += new System.EventHandler(this.ptbXoa_Click);
            // 
            // ptbSua
            // 
            this.ptbSua.BackColor = System.Drawing.Color.White;
            this.ptbSua.Image = global::Nhom03_QuanLyThuVien.Properties.Resources.kisspng_customer_service_computer_icons_car_automobile_rep_served_svg_png_icon_free_download_27465_onli_5b8e1bbe7fda14_3508031215360398705237;
            this.ptbSua.Location = new System.Drawing.Point(151, 389);
            this.ptbSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbSua.Name = "ptbSua";
            this.ptbSua.Size = new System.Drawing.Size(95, 67);
            this.ptbSua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSua.TabIndex = 11;
            this.ptbSua.TabStop = false;
            this.ptbSua.Click += new System.EventHandler(this.ptbSua_Click);
            // 
            // ptbThem
            // 
            this.ptbThem.BackColor = System.Drawing.Color.White;
            this.ptbThem.ErrorImage = null;
            this.ptbThem.Image = global::Nhom03_QuanLyThuVien.Properties.Resources.pngtree_add_vector_icon_png_image_470700;
            this.ptbThem.InitialImage = null;
            this.ptbThem.Location = new System.Drawing.Point(25, 389);
            this.ptbThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbThem.Name = "ptbThem";
            this.ptbThem.Size = new System.Drawing.Size(95, 67);
            this.ptbThem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbThem.TabIndex = 11;
            this.ptbThem.TabStop = false;
            this.ptbThem.Click += new System.EventHandler(this.ptbThem_Click);
            // 
            // FormSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1067, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ptbThoat);
            this.Controls.Add(this.ptbXoa);
            this.Controls.Add(this.ptbSua);
            this.Controls.Add(this.ptbThem);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.dgvDSSach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormSach";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThoat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.DataGridView dgvDSSach;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhaXB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtTriGia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNhaXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTriGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNgayNhap;
        private System.Windows.Forms.PictureBox ptbThem;
        private System.Windows.Forms.PictureBox ptbSua;
        private System.Windows.Forms.PictureBox ptbXoa;
        private System.Windows.Forms.PictureBox ptbThoat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

