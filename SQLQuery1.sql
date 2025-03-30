CREATE DATABASE CafeShop
GO 
USE CafeShop;

CREATE TABLE NguoiDung (
    MaND NVARCHAR(50) PRIMARY KEY,
    HoVaTen NVARCHAR(100) NOT NULL, 
    email NVARCHAR(100) UNIQUE NOT NULL,
    SDT VARCHAR(15) UNIQUE NULL,
    GioiTinh NVARCHAR(10) NULL,
    password NVARCHAR(255) NOT NULL,  
    NgayDiLam DATE NULL,
    MaQL NVARCHAR(50) NULL, 
    FOREIGN KEY (MaQL) REFERENCES NguoiDung(MaND)
);

INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES 
    ('NV001', N'Nguyễn Văn A', 'admin@gmail.com', '0123456789', 'Nam', '1234554321', '2023-01-01', NULL), 
    ('NV002', N'Trần Văn B', 'nv1@gmail.com', '0345678901', 'Nam', 'maoimetqua', '2024-01-01', 'NV001'),  
    ('NV003', N'Lê Thị C', 'nv2@gmail.com', '0765432109', 'Nữ', 'cuuchiemoi', '2024-02-01', 'NV001');

-- Bảng Menu (Thực đơn)
CREATE TABLE Menu (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia > 0),
    LoaiMon NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'Còn bán' CHECK (TrangThai IN ('Còn bán', 'Ngừng bán')),
    HinhAnh NVARCHAR(255) 
);



-- Bảng Nguyên Liệu
CREATE TABLE NguyenLieu (
    MaNL INT IDENTITY(1,1) PRIMARY KEY,
    TenNL NVARCHAR(100) NOT NULL,
    SoLuongTon INT NOT NULL CHECK (SoLuongTon >= 0),
    DonViTinh NVARCHAR(50) NOT NULL,
    NgayNhap DATE NOT NULL,
    TenNCC NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL
);

-- Bảng Đơn Hàng
CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,
    NgayDat DATETIME DEFAULT GETDATE(),
    MaND NVARCHAR(50) FOREIGN KEY REFERENCES NguoiDung(MaND) ON DELETE SET NULL, 
    TongTien DECIMAL(10,2) NOT NULL CHECK (TongTien >= 0),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('Đã thanh toán', 'Hủy'))
);

-- Bảng Chi Tiết Đơn Hàng
CREATE TABLE ChiTietDonHang (
    MaCTDH INT IDENTITY(1,1) PRIMARY KEY,
    MaDH INT FOREIGN KEY REFERENCES DonHang(MaDH) ON DELETE CASCADE,
    MaMon INT FOREIGN KEY REFERENCES Menu(MaMon),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia >= 0),
    GhiChu NVARCHAR(255) NULL
);

-- Bảng Lịch Làm Việc
CREATE TABLE LichLamViec (
    MaLLV NVARCHAR(50) PRIMARY KEY,
    MaND NVARCHAR(50) FOREIGN KEY REFERENCES NguoiDung(MaND) ON DELETE CASCADE,
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(50) CHECK (CaLam IN ('Sáng', 'Chiều', 'Tối'))
);

ALTER TABLE LichLamViec
DROP COLUMN MaLLV;
-- Bảng Doanh Thu
CREATE TABLE DoanhThu (
    MaDT INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE NOT NULL,
    TongSoDon INT NOT NULL CHECK (TongSoDon >= 0),
    TongTien DECIMAL(10,2) NOT NULL CHECK (TongTien >= 0)
);
INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam) VALUES
('LLV001', 'NV002', '2024-10-26', N'Sáng'),
('LLV002', 'NV002', '2024-10-26', N'Chiều'),
('LLV003', 'NV003', '2024-10-27', N'Tối'),
('LLV004', 'NV003', '2024-10-28', N'Chiều');

GO
SELECT * FROM NguoiDung
go
-- Thủ tục đăng nhập
CREATE PROCEDURE DangNhap (@email NVARCHAR(100), @password NVARCHAR(255))
AS
BEGIN
    SELECT MaND, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
    FROM NguoiDung 
    WHERE email = @email AND password = @password

    UNION ALL

    SELECT MaND, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
    FROM NguoiDung 
    WHERE email = @email AND password = @password AND MaQL IS NULL;
END;
 DROP PROCEDURE DangNhap;

GO

-- Thủ tục thêm người dùng
CREATE PROCEDURE ThemNguoiDung 
    @HoVaTen NVARCHAR(100),
    @email NVARCHAR(100),
    @SDT VARCHAR(15),
    @GioiTinh NVARCHAR(10),
    @password NVARCHAR(255),
    @NgayDiLam DATE,
    @MaQL NVARCHAR(50) NULL  -- Mã quản lý cho người dùng
AS
BEGIN
    DECLARE @NewMaND NVARCHAR(50);

    -- Kiểm tra bảng NguoiDung có dữ liệu không
    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE MaND LIKE 'NV%')
    BEGIN
        -- Nếu không có, bắt đầu từ NV001
        SET @NewMaND = 'NV001';
    END
    ELSE
    BEGIN
        -- Nếu có người dùng, tạo mã người dùng tự động
        SET @NewMaND = 'NV' + RIGHT('000' + CAST((SELECT COUNT(*) FROM NguoiDung WHERE MaND LIKE 'NV%') + 1 AS NVARCHAR(3)), 3);
    END

    -- Thêm người dùng vào bảng NguoiDung
    INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
    VALUES 
        (@NewMaND, @HoVaTen, @email, @SDT, @GioiTinh, @password, @NgayDiLam, @MaQL);
END;


CREATE PROCEDURE GenerateMaLLV 
AS
BEGIN
    DECLARE @MaLLV NVARCHAR(50);
    DECLARE @Count INT;

    -- Đếm số lượng bản ghi hiện có trong bảng LichLamViec
    SELECT @Count = COUNT(*) + 1 FROM LichLamViec;

    -- Tạo mã lịch làm việc theo định dạng 'LLV' + số thứ tự
    SET @MaLLV = 'LLV' + RIGHT('000' + CAST(@Count AS NVARCHAR), 3);

    -- Trả về mã lịch làm việc
    SELECT @MaLLV;
END;



-- Thức uống cà phê
INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Cà phê đen', 20000, N'Cà phê', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Cà phê sữa', 25000, N'Cà phê', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Bạc xỉu', 30000, N'Cà phê', N'Còn bán', NULL);

-- Thức uống trà sữa
INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Trá sữa truyền thống', 35000, N'Trá sữa', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Trá sữa matcha', 40000, N'Trà sữa', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Trá sữa socola', 40000, N'Trà sữa', N'Còn bán', NULL);

-- Thức uống nước ép
INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Nước ép cam', 30000, N'Nước ép', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Nước ép dưa hấu', 30000, N'Nước ép', N'Còn bán', NULL);

-- Thức uống sinh tố
INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Sinh tố bơ', 40000, N'Sinh tố', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Sinh tố xoài', 40000, N'Sinh tố', N'Còn bán', NULL);

INSERT INTO Menu (TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES (N'Sinh tố dâu', 40000, N'Sinh tố', N'Còn bán', NULL);

select * from Menu

DROP table Menu