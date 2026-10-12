namespace Câu_2
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
            System.Windows.Forms.DataGridViewCellStyle cellStyleTongTien = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDonGia = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleThanhTien = new System.Windows.Forms.DataGridViewCellStyle();

            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocSoBan = new System.Windows.Forms.Label();
            this.cboLocSoBan = new System.Windows.Forms.ComboBox();
            this.lblLocHinhThuc = new System.Windows.Forms.Label();
            this.cboLocHinhThuc = new System.Windows.Forms.ComboBox();
            this.lblLocTenMon = new System.Windows.Forms.Label();
            this.txtLocTenMon = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();

            this.pnlTrai = new System.Windows.Forms.Panel();
            this.lblDanhSachHD = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHinhThucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();

            this.pnlPhai = new System.Windows.Forms.Panel();
            this.lblChiTietTieuDe = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblSoBan = new System.Windows.Forms.Label();
            this.cboSoBan = new System.Windows.Forms.ComboBox();
            this.rdoTienMat = new System.Windows.Forms.RadioButton();
            this.rdoChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();

            this.lblChonMon = new System.Windows.Forms.Label();
            this.cboChonMon = new System.Windows.Forms.ComboBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();

            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colCT_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_SL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCT_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTongCong = new System.Windows.Forms.Label();

            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnHoaDonMoi = new System.Windows.Forms.Button();
            this.btnSuaHoaDon = new System.Windows.Forms.Button();
            this.btnXoaHoaDon = new System.Windows.Forms.Button();
            this.btnSuaSL = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnXemHoaDon = new System.Windows.Forms.Button();
            this.btnXuatPdf = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();

            this.grpTimKiem.SuspendLayout();
            this.pnlTrai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlPhai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Controls.Add(this.txtLocTenMon);
            this.grpTimKiem.Controls.Add(this.lblLocTenMon);
            this.grpTimKiem.Controls.Add(this.cboLocHinhThuc);
            this.grpTimKiem.Controls.Add(this.lblLocHinhThuc);
            this.grpTimKiem.Controls.Add(this.cboLocSoBan);
            this.grpTimKiem.Controls.Add(this.lblLocSoBan);
            this.grpTimKiem.Controls.Add(this.dtpDenNgay);
            this.grpTimKiem.Controls.Add(this.lblDenNgay);
            this.grpTimKiem.Controls.Add(this.dtpTuNgay);
            this.grpTimKiem.Controls.Add(this.lblTuNgay);
            this.grpTimKiem.Location = new System.Drawing.Point(12, 10);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(980, 75);
            this.grpTimKiem.TabIndex = 0;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm hóa đơn";

            // lblTuNgay
            this.lblTuNgay.Location = new System.Drawing.Point(10, 20);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 18);
            this.lblTuNgay.Text = "Từ ngày";

            // dtpTuNgay
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(10, 40);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(105, 23);

            // lblDenNgay
            this.lblDenNgay.Location = new System.Drawing.Point(125, 20);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(65, 18);
            this.lblDenNgay.Text = "Đến ngày";

            // dtpDenNgay
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(125, 40);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(105, 23);

            // lblLocSoBan
            this.lblLocSoBan.Location = new System.Drawing.Point(240, 20);
            this.lblLocSoBan.Name = "lblLocSoBan";
            this.lblLocSoBan.Size = new System.Drawing.Size(65, 18);
            this.lblLocSoBan.Text = "Số bàn";

            // cboLocSoBan
            this.cboLocSoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocSoBan.Location = new System.Drawing.Point(240, 40);
            this.cboLocSoBan.Name = "cboLocSoBan";
            this.cboLocSoBan.Size = new System.Drawing.Size(90, 23);

            // lblLocHinhThuc
            this.lblLocHinhThuc.Location = new System.Drawing.Point(340, 20);
            this.lblLocHinhThuc.Name = "lblLocHinhThuc";
            this.lblLocHinhThuc.Size = new System.Drawing.Size(75, 18);
            this.lblLocHinhThuc.Text = "Hình thức";

            // cboLocHinhThuc
            this.cboLocHinhThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocHinhThuc.Location = new System.Drawing.Point(340, 40);
            this.cboLocHinhThuc.Name = "cboLocHinhThuc";
            this.cboLocHinhThuc.Size = new System.Drawing.Size(110, 23);

            // lblLocTenMon
            this.lblLocTenMon.Location = new System.Drawing.Point(460, 20);
            this.lblLocTenMon.Name = "lblLocTenMon";
            this.lblLocTenMon.Size = new System.Drawing.Size(75, 18);
            this.lblLocTenMon.Text = "Tên món";

            // txtLocTenMon
            this.txtLocTenMon.Location = new System.Drawing.Point(460, 40);
            this.txtLocTenMon.Name = "txtLocTenMon";
            this.txtLocTenMon.Size = new System.Drawing.Size(180, 23);

            // btnTim
            this.btnTim.Location = new System.Drawing.Point(650, 39);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(80, 25);
            this.btnTim.Text = "Tìm";

            // 
            // pnlTrai
            // 
            this.pnlTrai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTrai.Controls.Add(this.lblTongDoanhThu);
            this.pnlTrai.Controls.Add(this.dgvHoaDon);
            this.pnlTrai.Controls.Add(this.lblDanhSachHD);
            this.pnlTrai.Location = new System.Drawing.Point(12, 90);
            this.pnlTrai.Name = "pnlTrai";
            this.pnlTrai.Size = new System.Drawing.Size(460, 430);
            this.pnlTrai.TabIndex = 1;

            // lblDanhSachHD
            this.lblDanhSachHD.AutoSize = true;
            this.lblDanhSachHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDanhSachHD.Location = new System.Drawing.Point(3, 4);
            this.lblDanhSachHD.Name = "lblDanhSachHD";
            this.lblDanhSachHD.Size = new System.Drawing.Size(111, 15);
            this.lblDanhSachHD.Text = "Danh sách hóa đơn";

            // dgvHoaDon
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaHD,
                this.colNgayLap,
                this.colSoBan,
                this.colHinhThucTT,
                this.colTongTien
            });
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 24);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersWidth = 25;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(454, 370);
            this.dgvHoaDon.TabIndex = 1;

            // colMaHD
            this.colMaHD.DataPropertyName = "MaHDHienThi";
            this.colMaHD.HeaderText = "Mã HD";
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            this.colMaHD.Width = 75;

            // colNgayLap
            this.colNgayLap.DataPropertyName = "NgayLap";
            this.colNgayLap.HeaderText = "Ngày lập";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.ReadOnly = true;
            this.colNgayLap.Width = 115;

            // colSoBan
            this.colSoBan.DataPropertyName = "SoBan";
            this.colSoBan.HeaderText = "Số bàn";
            this.colSoBan.Name = "colSoBan";
            this.colSoBan.ReadOnly = true;
            this.colSoBan.Width = 65;

            // colHinhThucTT
            this.colHinhThucTT.DataPropertyName = "HinhThucTT";
            this.colHinhThucTT.HeaderText = "Hình thức TT";
            this.colHinhThucTT.Name = "colHinhThucTT";
            this.colHinhThucTT.ReadOnly = true;
            this.colHinhThucTT.Width = 85;

            // colTongTien
            cellStyleTongTien.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleTongTien.Format = "N0";
            this.colTongTien.DefaultCellStyle = cellStyleTongTien;
            this.colTongTien.DataPropertyName = "TongTien";
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            this.colTongTien.Width = 85;

            // lblTongDoanhThu
            this.lblTongDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongDoanhThu.Location = new System.Drawing.Point(3, 402);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(260, 20);
            this.lblTongDoanhThu.Text = "Tổng doanh thu đang hiển thị: 0 đ";

            // 
            // pnlPhai
            // 
            this.pnlPhai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPhai.Controls.Add(this.lblTongCong);
            this.pnlPhai.Controls.Add(this.dgvChiTiet);
            this.pnlPhai.Controls.Add(this.btnThemMon);
            this.pnlPhai.Controls.Add(this.numSoLuong);
            this.pnlPhai.Controls.Add(this.lblSL);
            this.pnlPhai.Controls.Add(this.cboChonMon);
            this.pnlPhai.Controls.Add(this.lblChonMon);
            this.pnlPhai.Controls.Add(this.txtGhiChu);
            this.pnlPhai.Controls.Add(this.lblGhiChu);
            this.pnlPhai.Controls.Add(this.rdoChuyenKhoan);
            this.pnlPhai.Controls.Add(this.rdoTienMat);
            this.pnlPhai.Controls.Add(this.cboSoBan);
            this.pnlPhai.Controls.Add(this.lblSoBan);
            this.pnlPhai.Controls.Add(this.dtpNgayLap);
            this.pnlPhai.Controls.Add(this.lblChiTietTieuDe);
            this.pnlPhai.Location = new System.Drawing.Point(480, 90);
            this.pnlPhai.Name = "pnlPhai";
            this.pnlPhai.Size = new System.Drawing.Size(512, 430);
            this.pnlPhai.TabIndex = 2;

            // lblChiTietTieuDe
            this.lblChiTietTieuDe.AutoSize = true;
            this.lblChiTietTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblChiTietTieuDe.Location = new System.Drawing.Point(3, 4);
            this.lblChiTietTieuDe.Name = "lblChiTietTieuDe";
            this.lblChiTietTieuDe.Size = new System.Drawing.Size(95, 15);
            this.lblChiTietTieuDe.Text = "Chi tiết hóa đơn";

            // dtpNgayLap
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(6, 24);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(130, 23);

            // lblSoBan
            this.lblSoBan.Location = new System.Drawing.Point(145, 27);
            this.lblSoBan.Name = "lblSoBan";
            this.lblSoBan.Size = new System.Drawing.Size(45, 20);
            this.lblSoBan.Text = "Số bàn:";

            // cboSoBan
            this.cboSoBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSoBan.Location = new System.Drawing.Point(195, 24);
            this.cboSoBan.Name = "cboSoBan";
            this.cboSoBan.Size = new System.Drawing.Size(55, 23);

            // rdoTienMat
            this.rdoTienMat.Checked = true;
            this.rdoTienMat.Location = new System.Drawing.Point(260, 24);
            this.rdoTienMat.Name = "rdoTienMat";
            this.rdoTienMat.Size = new System.Drawing.Size(75, 23);
            this.rdoTienMat.Text = "Tiền mặt";

            // rdoChuyenKhoan
            this.rdoChuyenKhoan.Location = new System.Drawing.Point(340, 24);
            this.rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            this.rdoChuyenKhoan.Size = new System.Drawing.Size(100, 23);
            this.rdoChuyenKhoan.Text = "Chuyển khoản";

            // lblGhiChu
            this.lblGhiChu.Location = new System.Drawing.Point(6, 55);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(55, 20);
            this.lblGhiChu.Text = "Ghi chú:";

            // txtGhiChu
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(65, 52);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(440, 35);

            // lblChonMon
            this.lblChonMon.Location = new System.Drawing.Point(6, 95);
            this.lblChonMon.Name = "lblChonMon";
            this.lblChonMon.Size = new System.Drawing.Size(65, 20);
            this.lblChonMon.Text = "Chọn món:";

            // cboChonMon
            this.cboChonMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChonMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChonMon.Location = new System.Drawing.Point(75, 92);
            this.cboChonMon.Name = "cboChonMon";
            this.cboChonMon.Size = new System.Drawing.Size(185, 23);

            // lblSL
            this.lblSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSL.Location = new System.Drawing.Point(265, 95);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(25, 20);
            this.lblSL.Text = "SL:";

            // numSoLuong
            this.numSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoLuong.Location = new System.Drawing.Point(295, 92);
            this.numSoLuong.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(55, 23);
            this.numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnThemMon
            this.btnThemMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemMon.Location = new System.Drawing.Point(360, 91);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(85, 25);
            this.btnThemMon.Text = "Thêm món";

            // dgvChiTiet
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCT_STT,
                this.colCT_TenMon,
                this.colCT_SL,
                this.colCT_DonGia,
                this.colCT_ThanhTien
            });
            this.dgvChiTiet.Location = new System.Drawing.Point(6, 122);
            this.dgvChiTiet.MultiSelect = false;
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersWidth = 25;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(499, 272);
            this.dgvChiTiet.TabIndex = 2;

            // colCT_STT
            this.colCT_STT.DataPropertyName = "STT";
            this.colCT_STT.HeaderText = "STT";
            this.colCT_STT.Name = "colCT_STT";
            this.colCT_STT.ReadOnly = true;
            this.colCT_STT.Width = 45;

            // colCT_TenMon
            this.colCT_TenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCT_TenMon.DataPropertyName = "TenMon";
            this.colCT_TenMon.HeaderText = "Tên món";
            this.colCT_TenMon.Name = "colCT_TenMon";
            this.colCT_TenMon.ReadOnly = true;

            // colCT_SL
            this.colCT_SL.DataPropertyName = "SoLuong";
            this.colCT_SL.HeaderText = "SL";
            this.colCT_SL.Name = "colCT_SL";
            this.colCT_SL.ReadOnly = true;
            this.colCT_SL.Width = 45;

            // colCT_DonGia
            cellStyleDonGia.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleDonGia.Format = "N0";
            this.colCT_DonGia.DefaultCellStyle = cellStyleDonGia;
            this.colCT_DonGia.DataPropertyName = "DonGia";
            this.colCT_DonGia.HeaderText = "Đơn giá";
            this.colCT_DonGia.Name = "colCT_DonGia";
            this.colCT_DonGia.ReadOnly = true;
            this.colCT_DonGia.Width = 80;

            // colCT_ThanhTien
            cellStyleThanhTien.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleThanhTien.Format = "N0";
            this.colCT_ThanhTien.DefaultCellStyle = cellStyleThanhTien;
            this.colCT_ThanhTien.DataPropertyName = "ThanhTien";
            this.colCT_ThanhTien.HeaderText = "Thành tiền";
            this.colCT_ThanhTien.Name = "colCT_ThanhTien";
            this.colCT_ThanhTien.ReadOnly = true;
            this.colCT_ThanhTien.Width = 90;

            // lblTongCong
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongCong.AutoSize = true;
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongCong.Location = new System.Drawing.Point(230, 399);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(185, 25);
            this.lblTongCong.Text = "Tổng cộng: 0 đ";
            this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnHoaDonMoi);
            this.pnlButtons.Controls.Add(this.btnSuaHoaDon);
            this.pnlButtons.Controls.Add(this.btnXoaHoaDon);
            this.pnlButtons.Controls.Add(this.btnSuaSL);
            this.pnlButtons.Controls.Add(this.btnXoaMon);
            this.pnlButtons.Controls.Add(this.btnXemHoaDon);
            this.pnlButtons.Controls.Add(this.btnXuatPdf);
            this.pnlButtons.Controls.Add(this.btnIn);
            this.pnlButtons.Location = new System.Drawing.Point(12, 526);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(980, 38);
            this.pnlButtons.TabIndex = 3;

            // btnHoaDonMoi
            this.btnHoaDonMoi.Location = new System.Drawing.Point(3, 3);
            this.btnHoaDonMoi.Name = "btnHoaDonMoi";
            this.btnHoaDonMoi.Size = new System.Drawing.Size(105, 30);
            this.btnHoaDonMoi.Text = "Hóa đơn mới";

            // btnSuaHoaDon
            this.btnSuaHoaDon.Location = new System.Drawing.Point(114, 3);
            this.btnSuaHoaDon.Name = "btnSuaHoaDon";
            this.btnSuaHoaDon.Size = new System.Drawing.Size(100, 30);
            this.btnSuaHoaDon.Text = "Sửa hóa đơn";

            // btnXoaHoaDon
            this.btnXoaHoaDon.Location = new System.Drawing.Point(220, 3);
            this.btnXoaHoaDon.Name = "btnXoaHoaDon";
            this.btnXoaHoaDon.Size = new System.Drawing.Size(100, 30);
            this.btnXoaHoaDon.Text = "Xóa hóa đơn";

            // btnSuaSL
            this.btnSuaSL.Location = new System.Drawing.Point(326, 3);
            this.btnSuaSL.Name = "btnSuaSL";
            this.btnSuaSL.Size = new System.Drawing.Size(85, 30);
            this.btnSuaSL.Text = "Sửa SL";

            // btnXoaMon
            this.btnXoaMon.Location = new System.Drawing.Point(417, 3);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(85, 30);
            this.btnXoaMon.Text = "Xóa món";

            // btnXemHoaDon
            this.btnXemHoaDon.Location = new System.Drawing.Point(508, 3);
            this.btnXemHoaDon.Name = "btnXemHoaDon";
            this.btnXemHoaDon.Size = new System.Drawing.Size(105, 30);
            this.btnXemHoaDon.Text = "Xem hóa đơn";

            // btnXuatPdf
            this.btnXuatPdf.Location = new System.Drawing.Point(619, 3);
            this.btnXuatPdf.Name = "btnXuatPdf";
            this.btnXuatPdf.Size = new System.Drawing.Size(95, 30);
            this.btnXuatPdf.Text = "Xuất PDF";

            // btnIn
            this.btnIn.Location = new System.Drawing.Point(720, 3);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 30);
            this.btnIn.Text = "In";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 571);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlPhai);
            this.Controls.Add(this.pnlTrai);
            this.Controls.Add(this.grpTimKiem);
            this.MinimumSize = new System.Drawing.Size(950, 580);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quán cà phê Góc Phố - Quản lý hóa đơn";
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.pnlTrai.ResumeLayout(false);
            this.pnlTrai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlPhai.ResumeLayout(false);
            this.pnlPhai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocSoBan;
        private System.Windows.Forms.ComboBox cboLocSoBan;
        private System.Windows.Forms.Label lblLocHinhThuc;
        private System.Windows.Forms.ComboBox cboLocHinhThuc;
        private System.Windows.Forms.Label lblLocTenMon;
        private System.Windows.Forms.TextBox txtLocTenMon;
        private System.Windows.Forms.Button btnTim;

        private System.Windows.Forms.Panel pnlTrai;
        private System.Windows.Forms.Label lblDanhSachHD;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHinhThucTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.Label lblTongDoanhThu;

        private System.Windows.Forms.Panel pnlPhai;
        private System.Windows.Forms.Label lblChiTietTieuDe;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblSoBan;
        private System.Windows.Forms.ComboBox cboSoBan;
        private System.Windows.Forms.RadioButton rdoTienMat;
        private System.Windows.Forms.RadioButton rdoChuyenKhoan;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;

        private System.Windows.Forms.Label lblChonMon;
        private System.Windows.Forms.ComboBox cboChonMon;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThemMon;

        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_SL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCT_ThanhTien;
        private System.Windows.Forms.Label lblTongCong;

        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private System.Windows.Forms.Button btnHoaDonMoi;
        private System.Windows.Forms.Button btnSuaHoaDon;
        private System.Windows.Forms.Button btnXoaHoaDon;
        private System.Windows.Forms.Button btnSuaSL;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnXemHoaDon;
        private System.Windows.Forms.Button btnXuatPdf;
        private System.Windows.Forms.Button btnIn;
    }
}
