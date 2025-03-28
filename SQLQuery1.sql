CREATE DATABASE CafeShop
GO 
USE CafeShop;

CREATE TABLE NguoiDung (
    MaND NVARCHAR(50) PRIMARY KEY,
    HoVaTen NVARCHAR(100) NOT NULL, 
    email NVARCHAR(100) UNIQUE NOT NULL,
    SDT VARCHAR(15) UNIQUE NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN ('Nam', 'Nữ', 'Khác')) NULL,
    password NVARCHAR(255) NOT NULL,  
    NgayDiLam DATE NULL,
    MaQL NVARCHAR(50) NULL, 
    FOREIGN KEY (MaQL) REFERENCES NguoiDung(MaND)
);


-- Bảng Menu (Thực đơn)
CREATE TABLE Menu (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia > 0),
    LoaiMon NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'Còn bán' CHECK (TrangThai IN ('Còn bán', 'Ngừng bán')),
    HinhAnh NVARCHAR(255) NOT NULL
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
    MaLLV INT IDENTITY(1,1) PRIMARY KEY,
    MaND NVARCHAR(50) FOREIGN KEY REFERENCES NguoiDung(MaND) ON DELETE CASCADE,
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(50) CHECK (CaLam IN ('Sáng', 'Chiều', 'Tối'))
);

-- Bảng Doanh Thu
CREATE TABLE DoanhThu (
    MaDT INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE NOT NULL,
    TongSoDon INT NOT NULL CHECK (TongSoDon >= 0),
    TongTien DECIMAL(10,2) NOT NULL CHECK (TongTien >= 0)
);
-- Thêm lịch làm việc cho người dùng 'ND001'
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV001', '2023-10-26', 'Sáng');
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV001', '2023-10-26', 'Chiều');
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV001', '2023-10-27', 'Tối');

-- Thêm lịch làm việc cho người dùng 'ND002'
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV002', '2023-10-27', 'Sáng');
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV002', '2023-10-28', 'Chiều');

-- Thêm lịch làm việc cho người dùng 'ND003'
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV003', '2023-10-28', 'Tối');
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV003', '2023-10-29', 'Sáng');
INSERT INTO LichLamViec (MaND, Ngay, CaLam) VALUES ('NV003', '2023-10-29', 'Chiều');
DELETE FROM NguoiDung;

-- Thêm dữ liệu vào bảng Quản lý
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES 
    ('QL001', 'Nguyễn Văn A', 'admin@gmail.com', '0123456789', 'Nam', '1234554321', '2023-01-01', NULL),
    ('NV001', 'Trần Văn B', 'nv1@gmail.com', '0345678901', 'Nam','maoimetqua', '2024-01-01', 'QL001'),
    ('NV002', 'Lê Thị C', 'nv2@gmail.com', '0765432109', 'Nữ','cuuchiemoi', '2024-02-01', 'QL001');
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES 	('NV003', 'tran thi tu', 'caolinh14789@gmail.com', '0465432109', 'Nữ','12345678', '2024-02-01', 'QL001');
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
