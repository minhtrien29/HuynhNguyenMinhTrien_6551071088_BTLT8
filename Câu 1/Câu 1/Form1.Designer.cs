namespace Câu_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle cellStyleGia = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleTon = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleNgay = new System.Windows.Forms.DataGridViewCellStyle();

            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.lblLoaiHang = new System.Windows.Forms.Label();
            this.cboLoaiHang = new System.Windows.Forms.ComboBox();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.cboDonVi = new System.Windows.Forms.ComboBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.numGiaBan = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.numSoLuongTon = new System.Windows.Forms.NumericUpDown();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.chkConKinhDoanh = new System.Windows.Forms.CheckBox();

            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocLoaiHang = new System.Windows.Forms.ComboBox();
            this.chkChiHienConKinhDoanh = new System.Windows.Forms.CheckBox();

            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.colMaHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConKinhDoanh = new System.Windows.Forms.DataGridViewCheckBoxColumn();

            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemBangGia = new System.Windows.Forms.Button();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnXuatExcelLuoi = new System.Windows.Forms.Button();
            this.btnXuatExcelTonKho = new System.Windows.Forms.Button();

            this.lblTrangThai = new System.Windows.Forms.Label();
            this.tmrTimKiem = new System.Windows.Forms.Timer(this.components);

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.chkConKinhDoanh);
            this.grpThongTin.Controls.Add(this.dtpNgayNhap);
            this.grpThongTin.Controls.Add(this.lblNgayNhap);
            this.grpThongTin.Controls.Add(this.numSoLuongTon);
            this.grpThongTin.Controls.Add(this.lblSoLuongTon);
            this.grpThongTin.Controls.Add(this.numGiaBan);
            this.grpThongTin.Controls.Add(this.lblGiaBan);
            this.grpThongTin.Controls.Add(this.cboDonVi);
            this.grpThongTin.Controls.Add(this.lblDonVi);
            this.grpThongTin.Controls.Add(this.cboLoaiHang);
            this.grpThongTin.Controls.Add(this.lblLoaiHang);
            this.grpThongTin.Controls.Add(this.txtTenHang);
            this.grpThongTin.Controls.Add(this.lblTenHang);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(580, 145);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin hàng hóa";

            // lblTenHang
            this.lblTenHang.Location = new System.Drawing.Point(10, 24);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(65, 23);
            this.lblTenHang.Text = "Tên hàng:";

            // txtTenHang
            this.txtTenHang.Location = new System.Drawing.Point(80, 21);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(485, 23);

            // lblLoaiHang
            this.lblLoaiHang.Location = new System.Drawing.Point(10, 54);
            this.lblLoaiHang.Name = "lblLoaiHang";
            this.lblLoaiHang.Size = new System.Drawing.Size(65, 23);
            this.lblLoaiHang.Text = "Loại hàng:";

            // cboLoaiHang
            this.cboLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiHang.Location = new System.Drawing.Point(80, 51);
            this.cboLoaiHang.Name = "cboLoaiHang";
            this.cboLoaiHang.Size = new System.Drawing.Size(180, 23);

            // lblDonVi
            this.lblDonVi.Location = new System.Drawing.Point(10, 84);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(65, 23);
            this.lblDonVi.Text = "Đơn vị:";

            // cboDonVi
            this.cboDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonVi.Location = new System.Drawing.Point(80, 81);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(180, 23);

            // lblGiaBan
            this.lblGiaBan.Location = new System.Drawing.Point(10, 114);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(65, 23);
            this.lblGiaBan.Text = "Giá bán:";

            // numGiaBan
            this.numGiaBan.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            this.numGiaBan.Location = new System.Drawing.Point(80, 111);
            this.numGiaBan.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numGiaBan.Name = "numGiaBan";
            this.numGiaBan.Size = new System.Drawing.Size(180, 23);
            this.numGiaBan.ThousandsSeparator = true;

            // lblSoLuongTon
            this.lblSoLuongTon.Location = new System.Drawing.Point(280, 54);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(85, 23);
            this.lblSoLuongTon.Text = "Số lượng tồn:";

            // numSoLuongTon
            this.numSoLuongTon.Location = new System.Drawing.Point(375, 51);
            this.numSoLuongTon.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numSoLuongTon.Name = "numSoLuongTon";
            this.numSoLuongTon.Size = new System.Drawing.Size(190, 23);
            this.numSoLuongTon.ThousandsSeparator = true;

            // lblNgayNhap
            this.lblNgayNhap.Location = new System.Drawing.Point(280, 84);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(85, 23);
            this.lblNgayNhap.Text = "Ngày nhập:";

            // dtpNgayNhap
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(375, 81);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(190, 23);

            // chkConKinhDoanh
            this.chkConKinhDoanh.Checked = true;
            this.chkConKinhDoanh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConKinhDoanh.Location = new System.Drawing.Point(375, 112);
            this.chkConKinhDoanh.Name = "chkConKinhDoanh";
            this.chkConKinhDoanh.Size = new System.Drawing.Size(150, 24);
            this.chkConKinhDoanh.Text = "Còn kinh doanh";

            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.chkChiHienConKinhDoanh);
            this.grpTimKiem.Controls.Add(this.cboLocLoaiHang);
            this.grpTimKiem.Controls.Add(this.txtTimKiem);
            this.grpTimKiem.Location = new System.Drawing.Point(605, 12);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(327, 145);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";

            // txtTimKiem
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(15, 24);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên hàng để tìm...";
            this.txtTimKiem.Size = new System.Drawing.Size(297, 23);

            // cboLocLoaiHang
            this.cboLocLoaiHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiHang.Location = new System.Drawing.Point(15, 60);
            this.cboLocLoaiHang.Name = "cboLocLoaiHang";
            this.cboLocLoaiHang.Size = new System.Drawing.Size(297, 23);

            // chkChiHienConKinhDoanh
            this.chkChiHienConKinhDoanh.Location = new System.Drawing.Point(15, 98);
            this.chkChiHienConKinhDoanh.Name = "chkChiHienConKinhDoanh";
            this.chkChiHienConKinhDoanh.Size = new System.Drawing.Size(200, 24);
            this.chkChiHienConKinhDoanh.Text = "Chỉ hiện hàng còn kinh doanh";

            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AllowUserToAddRows = false;
            this.dgvHangHoa.AllowUserToDeleteRows = false;
            this.dgvHangHoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaHang,
                this.colTenHang,
                this.colLoaiHang,
                this.colDonVi,
                this.colGiaBan,
                this.colSoLuongTon,
                this.colNgayNhap,
                this.colConKinhDoanh
            });
            this.dgvHangHoa.Location = new System.Drawing.Point(12, 168);
            this.dgvHangHoa.MultiSelect = false;
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.RowHeadersWidth = 30;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(920, 280);
            this.dgvHangHoa.TabIndex = 2;

            // colMaHang
            this.colMaHang.DataPropertyName = "MaHang";
            this.colMaHang.HeaderText = "Mã";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.ReadOnly = true;
            this.colMaHang.Width = 60;

            // colTenHang
            this.colTenHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenHang.DataPropertyName = "TenHang";
            this.colTenHang.HeaderText = "Tên hàng";
            this.colTenHang.Name = "colTenHang";
            this.colTenHang.ReadOnly = true;

            // colLoaiHang
            this.colLoaiHang.DataPropertyName = "LoaiHang";
            this.colLoaiHang.HeaderText = "Loại hàng";
            this.colLoaiHang.Name = "colLoaiHang";
            this.colLoaiHang.ReadOnly = true;
            this.colLoaiHang.Width = 120;

            // colDonVi
            this.colDonVi.DataPropertyName = "DonVi";
            this.colDonVi.HeaderText = "Đơn vị";
            this.colDonVi.Name = "colDonVi";
            this.colDonVi.ReadOnly = true;
            this.colDonVi.Width = 70;

            // colGiaBan
            cellStyleGia.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleGia.Format = "N0";
            this.colGiaBan.DefaultCellStyle = cellStyleGia;
            this.colGiaBan.DataPropertyName = "GiaBan";
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            this.colGiaBan.Width = 90;

            // colSoLuongTon
            cellStyleTon.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleTon.Format = "N0";
            this.colSoLuongTon.DefaultCellStyle = cellStyleTon;
            this.colSoLuongTon.DataPropertyName = "SoLuongTon";
            this.colSoLuongTon.HeaderText = "Tồn";
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            this.colSoLuongTon.Width = 70;

            // colNgayNhap
            cellStyleNgay.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleNgay.Format = "dd/MM/yyyy";
            this.colNgayNhap.DefaultCellStyle = cellStyleNgay;
            this.colNgayNhap.DataPropertyName = "NgayNhap";
            this.colNgayNhap.HeaderText = "Ngày nhập";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.ReadOnly = true;
            this.colNgayNhap.Width = 100;

            // colConKinhDoanh
            this.colConKinhDoanh.DataPropertyName = "ConKinhDoanh";
            this.colConKinhDoanh.HeaderText = "Kinh doanh";
            this.colConKinhDoanh.Name = "colConKinhDoanh";
            this.colConKinhDoanh.ReadOnly = true;
            this.colConKinhDoanh.Width = 90;

            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnThem);
            this.pnlButtons.Controls.Add(this.btnSua);
            this.pnlButtons.Controls.Add(this.btnXoa);
            this.pnlButtons.Controls.Add(this.btnLamMoi);
            this.pnlButtons.Controls.Add(this.btnXemBangGia);
            this.pnlButtons.Controls.Add(this.btnXuatPdf);
            this.pnlButtons.Controls.Add(this.btnXuatExcelLuoi);
            this.pnlButtons.Controls.Add(this.btnXuatExcelTonKho);
            this.pnlButtons.Location = new System.Drawing.Point(12, 458);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(920, 38);
            this.pnlButtons.TabIndex = 3;

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 30);
            this.btnThem.Text = "Thêm";

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(94, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 30);
            this.btnSua.Text = "Sửa";

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(185, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 30);
            this.btnXoa.Text = "Xóa";

            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(276, 3);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 30);
            this.btnLamMoi.Text = "Làm mới";

            // btnXemBangGia
            this.btnXemBangGia.Location = new System.Drawing.Point(367, 3);
            this.btnXemBangGia.Name = "btnXemBangGia";
            this.btnXemBangGia.Size = new System.Drawing.Size(110, 30);
            this.btnXemBangGia.Text = "Xem bảng giá";

            // btnXuatPdf
            this.btnXuatPdf.Location = new System.Drawing.Point(483, 3);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(95, 30);
            this.btnXuatPdf.Text = "Xuất PDF";

            // btnXuatExcelLuoi
            this.btnXuatExcelLuoi.Location = new System.Drawing.Point(584, 3);
            this.btnXuatExcelLuoi.Name = "btnXuatExcelLuoi";
            this.btnXuatExcelLuoi.Size = new System.Drawing.Size(130, 30);
            this.btnXuatExcelLuoi.Text = "Xuất Excel (lưới)";

            // btnXuatExcelTonKho
            this.btnXuatExcelTonKho.Location = new System.Drawing.Point(720, 3);
            this.btnXuatExcelTonKho.Name = "btnXuatExcelTonKho";
            this.btnXuatExcelTonKho.Size = new System.Drawing.Size(135, 30);
            this.btnXuatExcelTonKho.Text = "Xuất Excel tồn kho";

            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTrangThai.Location = new System.Drawing.Point(12, 502);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(126, 15);
            this.lblTrangThai.Text = "Tìm thấy 0 mặt hàng";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 526);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.dgvHangHoa);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hàng hóa - Tạp hóa UTC2";
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongTon)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label lblLoaiHang;
        private System.Windows.Forms.ComboBox cboLoaiHang;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.ComboBox cboDonVi;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.NumericUpDown numGiaBan;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.NumericUpDown numSoLuongTon;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.CheckBox chkConKinhDoanh;

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocLoaiHang;
        private System.Windows.Forms.CheckBox chkChiHienConKinhDoanh;

        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colConKinhDoanh;

        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemBangGia;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Button btnXuatExcelLuoi;
        private System.Windows.Forms.Button btnXuatExcelTonKho;

        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Timer tmrTimKiem;
    }
}
