-- =======================================================
-- Script tạo CSDL và dữ liệu mẫu cho Câu 3: Phiếu báo điểm của khoa
-- =======================================================

IF DB_ID(N'QuanLyDiem') IS NULL
    CREATE DATABASE QuanLyDiem;
GO

USE QuanLyDiem;
GO

IF OBJECT_ID(N'dbo.DiemMon',  N'U') IS NOT NULL DROP TABLE dbo.DiemMon;
IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NOT NULL DROP TABLE dbo.SinhVien;
IF OBJECT_ID(N'dbo.Lop',      N'U') IS NOT NULL DROP TABLE dbo.Lop;
GO

CREATE TABLE dbo.Lop (
    MaLop VARCHAR(10) NOT NULL CONSTRAINT PK_Lop PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE dbo.SinhVien (
    MaSV VARCHAR(10) NOT NULL CONSTRAINT PK_SinhVien PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATETIME NOT NULL,
    GioiTinh NVARCHAR(3) NOT NULL,
    MaLop VARCHAR(10) NOT NULL CONSTRAINT FK_SinhVien_Lop REFERENCES dbo.Lop(MaLop)
);
GO

CREATE TABLE dbo.DiemMon (
    MaDiem INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_DiemMon PRIMARY KEY,
    MaSV VARCHAR(10) NOT NULL CONSTRAINT FK_DiemMon_SinhVien REFERENCES dbo.SinhVien(MaSV) ON DELETE CASCADE,
    TenMon NVARCHAR(100) NOT NULL,
    SoTinChi INT NOT NULL,
    Diem DECIMAL(4,2) NOT NULL
);
GO

INSERT INTO dbo.Lop (MaLop, TenLop) VALUES
('CNTT01', N'Công nghệ thông tin K01'),
('KT01', N'Kế toán K01');
GO

INSERT INTO dbo.SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) VALUES
('SV001', N'Nguyễn Minh Anh', '2005-03-15', N'Nữ', 'CNTT01'),
('SV002', N'Trần Quốc Bảo', '2005-07-22', N'Nam', 'CNTT01'),
('SV003', N'Lê Thị Cẩm Tú', '2005-11-09', N'Nữ', 'KT01');
GO

INSERT INTO dbo.DiemMon (MaSV, TenMon, SoTinChi, Diem) VALUES
('SV001', N'Lập trình trực quan', 3, 8.5),
('SV001', N'Cơ sở dữ liệu', 3, 7.5),
('SV001', N'Tiếng Anh chuyên ngành', 2, 9.0),
('SV001', N'Toán rời rạc', 3, 6.5),
('SV002', N'Lập trình trực quan', 3, 9.0),
('SV002', N'Cơ sở dữ liệu', 3, 8.0),
('SV002', N'Tiếng Anh chuyên ngành', 2, 8.5);
GO
