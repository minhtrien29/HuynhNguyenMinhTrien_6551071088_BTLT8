-- =======================================================
-- Script tạo CSDL và dữ liệu mẫu cho Câu 1: Tiệm tạp hóa UTC2
-- =======================================================

IF DB_ID(N'TiemTapHoa') IS NULL
    CREATE DATABASE TiemTapHoa;
GO

USE TiemTapHoa;
GO

IF OBJECT_ID(N'dbo.HangHoa', N'U') IS NOT NULL 
    DROP TABLE dbo.HangHoa;
GO

CREATE TABLE dbo.HangHoa (
    MaHang INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HangHoa PRIMARY KEY,
    TenHang NVARCHAR(100) NOT NULL,
    LoaiHang NVARCHAR(50) NULL,
    DonVi NVARCHAR(20) NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    SoLuongTon INT NOT NULL,
    NgayNhap DATETIME NOT NULL,
    ConKinhDoanh BIT NOT NULL
);
GO

-- 6 dòng dữ liệu mẫu theo yêu cầu đề bài
INSERT INTO dbo.HangHoa (TenHang, LoaiHang, DonVi, GiaBan, SoLuongTon, NgayNhap, ConKinhDoanh) VALUES
(N'Nước suối Aquafina 500ml', N'Đồ uống', N'Chai', 6000, 120, '2026-10-02', 1),
(N'Mì Hảo Hảo tôm chua cay', N'Thực phẩm khô', N'Gói', 4500, 200, '2026-10-02', 1),
(N'Dầu ăn Tường An 1L', N'Gia vị', N'Chai', 48000, 35, '2026-10-05', 1),
(N'Bột giặt OMO 800g', N'Đồ gia dụng', N'Túi', 52000, 40, '2026-10-05', 1),
(N'Sữa tươi Vinamilk 1L', N'Đồ uống', N'Hộp', 32000, 60, '2026-10-08', 1),
(N'Nước mắm Nam Ngư 500ml', N'Gia vị', N'Chai', 38000, 25, '2026-01-10', 0);
GO
