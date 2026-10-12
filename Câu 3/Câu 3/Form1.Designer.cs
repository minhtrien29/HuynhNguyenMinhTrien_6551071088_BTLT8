namespace Câu_3
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
            System.Windows.Forms.DataGridViewCellStyle cellStyleNgaySinh = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyleDiem = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblLop = new System.Windows.Forms.Label();
            this.lstLop = new System.Windows.Forms.ListBox();

            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.colMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.grpThongTinSV = new System.Windows.Forms.GroupBox();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblLopSV = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.btnThemSV = new System.Windows.Forms.Button();
            this.btnSuaSV = new System.Windows.Forms.Button();
            this.btnXoaSV = new System.Windows.Forms.Button();

            this.grpDiem = new System.Windows.Forms.GroupBox();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.colDiem_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem_TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem_SoTinChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem_Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblTenMon = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.lblSoTinChi = new System.Windows.Forms.Label();
            this.numSoTinChi = new System.Windows.Forms.NumericUpDown();
            this.lblDiem = new System.Windows.Forms.Label();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnSuaDiem = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();

            this.lblTongTinChi = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();

            this.pnlBottomButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnXemTruocPhieu = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.btnCaiDatTrang = new System.Windows.Forms.Button();
            this.btnXuatExcelDiemLop = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.grpThongTinSV.SuspendLayout();
            this.grpDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTinChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.pnlBottomButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLop.Location = new System.Drawing.Point(12, 10);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(28, 15);
            this.lblLop.Text = "Lớp";

            // lstLop
            this.lstLop.ItemHeight = 15;
            this.lstLop.Location = new System.Drawing.Point(12, 30);
            this.lstLop.Name = "lstLop";
            this.lstLop.Size = new System.Drawing.Size(180, 214);
            this.lstLop.TabIndex = 0;

            // lblTimKiem
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(205, 10);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(107, 15);
            this.lblTimKiem.Text = "Tìm MSSV / họ tên:";

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(318, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(350, 23);
            this.txtTimKiem.TabIndex = 1;

            // dgvSinhVien
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMaSV,
                this.colHoTen,
                this.colNgaySinh,
                this.colGioiTinh,
                this.colMaLop
            });
            this.dgvSinhVien.Location = new System.Drawing.Point(205, 33);
            this.dgvSinhVien.MultiSelect = false;
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.RowHeadersWidth = 25;
            this.dgvSinhVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSinhVien.Size = new System.Drawing.Size(463, 211);
            this.dgvSinhVien.TabIndex = 2;

            // colMaSV
            this.colMaSV.DataPropertyName = "MaSV";
            this.colMaSV.HeaderText = "MSSV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.ReadOnly = true;
            this.colMaSV.Width = 70;

            // colHoTen
            this.colHoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;

            // colNgaySinh
            cellStyleNgaySinh.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            cellStyleNgaySinh.Format = "dd/MM/yyyy";
            this.colNgaySinh.DefaultCellStyle = cellStyleNgaySinh;
            this.colNgaySinh.DataPropertyName = "NgaySinh";
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            this.colNgaySinh.Width = 95;

            // colGioiTinh
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            this.colGioiTinh.Width = 65;

            // colMaLop
            this.colMaLop.DataPropertyName = "MaLop";
            this.colMaLop.HeaderText = "Lớp";
            this.colMaLop.Name = "colMaLop";
            this.colMaLop.ReadOnly = true;
            this.colMaLop.Width = 70;

            // 
            // grpThongTinSV
            // 
            this.grpThongTinSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTinSV.Controls.Add(this.btnXoaSV);
            this.grpThongTinSV.Controls.Add(this.btnSuaSV);
            this.grpThongTinSV.Controls.Add(this.btnThemSV);
            this.grpThongTinSV.Controls.Add(this.cboLop);
            this.grpThongTinSV.Controls.Add(this.lblLopSV);
            this.grpThongTinSV.Controls.Add(this.rdoNu);
            this.grpThongTinSV.Controls.Add(this.rdoNam);
            this.grpThongTinSV.Controls.Add(this.dtpNgaySinh);
            this.grpThongTinSV.Controls.Add(this.lblNgaySinh);
            this.grpThongTinSV.Controls.Add(this.txtHoTen);
            this.grpThongTinSV.Controls.Add(this.lblHoTen);
            this.grpThongTinSV.Controls.Add(this.txtMSSV);
            this.grpThongTinSV.Controls.Add(this.lblMSSV);
            this.grpThongTinSV.Location = new System.Drawing.Point(678, 10);
            this.grpThongTinSV.Name = "grpThongTinSV";
            this.grpThongTinSV.Size = new System.Drawing.Size(304, 234);
            this.grpThongTinSV.TabIndex = 3;
            this.grpThongTinSV.TabStop = false;
            this.grpThongTinSV.Text = "Thông tin sinh viên";

            // lblMSSV
            this.lblMSSV.Location = new System.Drawing.Point(10, 23);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(65, 18);
            this.lblMSSV.Text = "MSSV:";

            // txtMSSV
            this.txtMSSV.Location = new System.Drawing.Point(80, 20);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(210, 23);

            // lblHoTen
            this.lblHoTen.Location = new System.Drawing.Point(10, 53);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(65, 18);
            this.lblHoTen.Text = "Họ tên:";

            // txtHoTen
            this.txtHoTen.Location = new System.Drawing.Point(80, 50);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(210, 23);

            // lblNgaySinh
            this.lblNgaySinh.Location = new System.Drawing.Point(10, 83);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(65, 18);
            this.lblNgaySinh.Text = "Ngày sinh:";

            // dtpNgaySinh
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(80, 80);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(210, 23);

            // rdoNam
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(80, 110);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(60, 20);
            this.rdoNam.Text = "Nam";

            // rdoNu
            this.rdoNu.Location = new System.Drawing.Point(150, 110);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(60, 20);
            this.rdoNu.Text = "Nữ";

            // lblLopSV
            this.lblLopSV.Location = new System.Drawing.Point(10, 140);
            this.lblLopSV.Name = "lblLopSV";
            this.lblLopSV.Size = new System.Drawing.Size(65, 18);
            this.lblLopSV.Text = "Lớp:";

            // cboLop
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.Location = new System.Drawing.Point(80, 137);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(210, 23);

            // btnThemSV
            this.btnThemSV.Location = new System.Drawing.Point(30, 180);
            this.btnThemSV.Name = "btnThemSV";
            this.btnThemSV.Size = new System.Drawing.Size(75, 30);
            this.btnThemSV.Text = "Thêm";

            // btnSuaSV
            this.btnSuaSV.Location = new System.Drawing.Point(115, 180);
            this.btnSuaSV.Name = "btnSuaSV";
            this.btnSuaSV.Size = new System.Drawing.Size(75, 30);
            this.btnSuaSV.Text = "Sửa";

            // btnXoaSV
            this.btnXoaSV.Location = new System.Drawing.Point(200, 180);
            this.btnXoaSV.Name = "btnXoaSV";
            this.btnXoaSV.Size = new System.Drawing.Size(75, 30);
            this.btnXoaSV.Text = "Xóa";

            // 
            // grpDiem
            // 
            this.grpDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDiem.Controls.Add(this.lblXepLoai);
            this.grpDiem.Controls.Add(this.lblDiemTB);
            this.grpDiem.Controls.Add(this.lblTongTinChi);
            this.grpDiem.Controls.Add(this.btnXoaMon);
            this.grpDiem.Controls.Add(this.btnSuaDiem);
            this.grpDiem.Controls.Add(this.btnThemMon);
            this.grpDiem.Controls.Add(this.numDiem);
            this.grpDiem.Controls.Add(this.lblDiem);
            this.grpDiem.Controls.Add(this.numSoTinChi);
            this.grpDiem.Controls.Add(this.lblSoTinChi);
            this.grpDiem.Controls.Add(this.txtTenMon);
            this.grpDiem.Controls.Add(this.lblTenMon);
            this.grpDiem.Controls.Add(this.dgvDiem);
            this.grpDiem.Location = new System.Drawing.Point(12, 255);
            this.grpDiem.Name = "grpDiem";
            this.grpDiem.Size = new System.Drawing.Size(970, 255);
            this.grpDiem.TabIndex = 4;
            this.grpDiem.TabStop = false;
            this.grpDiem.Text = "Điểm của sinh viên";

            // dgvDiem
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDiem_STT,
                this.colDiem_TenMon,
                this.colDiem_SoTinChi,
                this.colDiem_Diem
            });
            this.dgvDiem.Location = new System.Drawing.Point(10, 22);
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.ReadOnly = true;
            this.dgvDiem.RowHeadersWidth = 25;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(450, 225);
            this.dgvDiem.TabIndex = 0;

            // colDiem_STT
            this.colDiem_STT.DataPropertyName = "STT";
            this.colDiem_STT.HeaderText = "STT";
            this.colDiem_STT.Name = "colDiem_STT";
            this.colDiem_STT.ReadOnly = true;
            this.colDiem_STT.Width = 45;

            // colDiem_TenMon
            this.colDiem_TenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDiem_TenMon.DataPropertyName = "TenMon";
            this.colDiem_TenMon.HeaderText = "Môn học";
            this.colDiem_TenMon.Name = "colDiem_TenMon";
            this.colDiem_TenMon.ReadOnly = true;

            // colDiem_SoTinChi
            this.colDiem_SoTinChi.DataPropertyName = "SoTinChi";
            this.colDiem_SoTinChi.HeaderText = "Số TC";
            this.colDiem_SoTinChi.Name = "colDiem_SoTinChi";
            this.colDiem_SoTinChi.ReadOnly = true;
            this.colDiem_SoTinChi.Width = 65;

            // colDiem_Diem
            cellStyleDiem.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            cellStyleDiem.Format = "0.0";
            this.colDiem_Diem.DefaultCellStyle = cellStyleDiem;
            this.colDiem_Diem.DataPropertyName = "Diem";
            this.colDiem_Diem.HeaderText = "Điểm";
            this.colDiem_Diem.Name = "colDiem_Diem";
            this.colDiem_Diem.ReadOnly = true;
            this.colDiem_Diem.Width = 65;

            // lblTenMon
            this.lblTenMon.Location = new System.Drawing.Point(480, 30);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(65, 18);
            this.lblTenMon.Text = "Tên môn:";

            // txtTenMon
            this.txtTenMon.Location = new System.Drawing.Point(550, 27);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(200, 23);

            // lblSoTinChi
            this.lblSoTinChi.Location = new System.Drawing.Point(760, 30);
            this.lblSoTinChi.Name = "lblSoTinChi";
            this.lblSoTinChi.Size = new System.Drawing.Size(45, 18);
            this.lblSoTinChi.Text = "Số TC:";

            // numSoTinChi
            this.numSoTinChi.Location = new System.Drawing.Point(810, 27);
            this.numSoTinChi.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            this.numSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoTinChi.Name = "numSoTinChi";
            this.numSoTinChi.Size = new System.Drawing.Size(45, 23);
            this.numSoTinChi.Value = new decimal(new int[] { 3, 0, 0, 0 });

            // lblDiem
            this.lblDiem.Location = new System.Drawing.Point(865, 30);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(40, 18);
            this.lblDiem.Text = "Điểm:";

            // numDiem
            this.numDiem.DecimalPlaces = 1;
            this.numDiem.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numDiem.Location = new System.Drawing.Point(905, 27);
            this.numDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(55, 23);
            this.numDiem.Value = new decimal(new int[] { 8, 0, 0, 0 });

            // btnThemMon
            this.btnThemMon.Location = new System.Drawing.Point(550, 65);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(85, 28);
            this.btnThemMon.Text = "Thêm môn";

            // btnSuaDiem
            this.btnSuaDiem.Location = new System.Drawing.Point(645, 65);
            this.btnSuaDiem.Name = "btnSuaDiem";
            this.btnSuaDiem.Size = new System.Drawing.Size(85, 28);
            this.btnSuaDiem.Text = "Sửa điểm";

            // btnXoaMon
            this.btnXoaMon.Location = new System.Drawing.Point(740, 65);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(85, 28);
            this.btnXoaMon.Text = "Xóa môn";

            // lblTongTinChi
            this.lblTongTinChi.AutoSize = true;
            this.lblTongTinChi.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTinChi.Location = new System.Drawing.Point(480, 130);
            this.lblTongTinChi.Name = "lblTongTinChi";
            this.lblTongTinChi.Size = new System.Drawing.Size(121, 20);
            this.lblTongTinChi.Text = "Tổng tín chỉ: 0";

            // lblDiemTB
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiemTB.Location = new System.Drawing.Point(630, 130);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(117, 20);
            this.lblDiemTB.Text = "Điểm TB: 0.00";

            // lblXepLoai
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblXepLoai.Location = new System.Drawing.Point(780, 130);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(107, 20);
            this.lblXepLoai.Text = "Xếp loại: -";

            // 
            // pnlBottomButtons
            // 
            this.pnlBottomButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomButtons.Controls.Add(this.btnXemTruocPhieu);
            this.pnlBottomButtons.Controls.Add(this.btnInPhieu);
            this.pnlBottomButtons.Controls.Add(this.btnCaiDatTrang);
            this.pnlBottomButtons.Controls.Add(this.btnXuatExcelDiemLop);
            this.pnlBottomButtons.Location = new System.Drawing.Point(12, 520);
            this.pnlBottomButtons.Name = "pnlBottomButtons";
            this.pnlBottomButtons.Size = new System.Drawing.Size(970, 38);
            this.pnlBottomButtons.TabIndex = 5;

            // btnXemTruocPhieu
            this.btnXemTruocPhieu.Location = new System.Drawing.Point(3, 3);
            this.btnXemTruocPhieu.Name = "btnXemTruocPhieu";
            this.btnXemTruocPhieu.Size = new System.Drawing.Size(130, 30);
            this.btnXemTruocPhieu.Text = "Xem trước phiếu";

            // btnInPhieu
            this.btnInPhieu.Location = new System.Drawing.Point(139, 3);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(80, 30);
            this.btnInPhieu.Text = "In…";

            // btnCaiDatTrang
            this.btnCaiDatTrang.Location = new System.Drawing.Point(225, 3);
            this.btnCaiDatTrang.Name = "btnCaiDatTrang";
            this.btnCaiDatTrang.Size = new System.Drawing.Size(110, 30);
            this.btnCaiDatTrang.Text = "Cài đặt trang…";

            // btnXuatExcelDiemLop
            this.btnXuatExcelDiemLop.Location = new System.Drawing.Point(341, 3);
            this.btnXuatExcelDiemLop.Name = "btnXuatExcelDiemLop";
            this.btnXuatExcelDiemLop.Size = new System.Drawing.Size(145, 30);
            this.btnXuatExcelDiemLop.Text = "Xuất Excel điểm lớp";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 566);
            this.Controls.Add(this.pnlBottomButtons);
            this.Controls.Add(this.grpDiem);
            this.Controls.Add(this.grpThongTinSV);
            this.Controls.Add(this.dgvSinhVien);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.lstLop);
            this.Controls.Add(this.lblLop);
            this.MinimumSize = new System.Drawing.Size(950, 580);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sinh viên và điểm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.grpThongTinSV.ResumeLayout(false);
            this.grpThongTinSV.PerformLayout();
            this.grpDiem.ResumeLayout(false);
            this.grpDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTinChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.pnlBottomButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ListBox lstLop;

        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLop;

        private System.Windows.Forms.GroupBox grpThongTinSV;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.Label lblLopSV;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Button btnThemSV;
        private System.Windows.Forms.Button btnSuaSV;
        private System.Windows.Forms.Button btnXoaSV;

        private System.Windows.Forms.GroupBox grpDiem;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem_TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem_SoTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem_Diem;

        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Label lblSoTinChi;
        private System.Windows.Forms.NumericUpDown numSoTinChi;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSuaDiem;
        private System.Windows.Forms.Button btnXoaMon;

        private System.Windows.Forms.Label lblTongTinChi;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblXepLoai;

        private System.Windows.Forms.FlowLayoutPanel pnlBottomButtons;
        private System.Windows.Forms.Button btnXemTruocPhieu;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Button btnCaiDatTrang;
        private System.Windows.Forms.Button btnXuatExcelDiemLop;
    }
}
