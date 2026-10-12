-- =======================================================
-- Script tạo CSDL và dữ liệu mẫu cho Câu 2: Quán cà phê Góc Phố
-- =======================================================

IF DB_ID(N'QuanCaPhe') IS NULL
    CREATE DATABASE QuanCaPhe;
GO

USE QuanCaPhe;
GO

IF OBJECT_ID(N'dbo.ChiTietHoaDon', N'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID(N'dbo.HoaDon',        N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.Mon',           N'U') IS NOT NULL DROP TABLE dbo.Mon;
GO

CREATE TABLE dbo.Mon (
    MaMon INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Mon PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    NhomMon NVARCHAR(30) NULL,
    DonGia DECIMAL(18,0) NOT NULL
);
GO

CREATE TABLE dbo.HoaDon (
    MaHD INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HoaDon PRIMARY KEY,
    NgayLap DATETIME NOT NULL,
    SoBan INT NOT NULL,
    HinhThucTT NVARCHAR(20) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

CREATE TABLE dbo.ChiTietHoaDon (
    MaCT INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY,
    MaHD INT NOT NULL CONSTRAINT FK_ChiTietHoaDon_HoaDon REFERENCES dbo.HoaDon(MaHD) ON DELETE CASCADE,
    MaMon INT NOT NULL CONSTRAINT FK_ChiTietHoaDon_Mon REFERENCES dbo.Mon(MaMon),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL
);
GO

INSERT INTO dbo.Mon (TenMon, NhomMon, DonGia) VALUES
(N'Cà phê sữa đá', N'Cà phê', 29000),
(N'Bạc xỉu', N'Cà phê', 32000),
(N'Trà đào cam sả', N'Trà', 45000),
(N'Bánh tiramisu', N'Bánh', 39000),
(N'Nước suối', N'Nước đóng chai', 12000);
GO

INSERT INTO dbo.HoaDon (NgayLap, SoBan, HinhThucTT, GhiChu) VALUES
('2026-10-09 08:15:00', 3, N'Tiền mặt', NULL),
('2026-10-09 09:40:00', 5, N'Chuyển khoản', NULL);
GO

INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, SoLuong, DonGia) VALUES
(1, 1, 2, 29000),
(1, 3, 1, 45000),
(1, 4, 1, 39000),
(2, 2, 1, 32000),
(2, 5, 2, 12000);
GO
