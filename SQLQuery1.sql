CREATE TABLE NhanVien(
	id NVARCHAR(50) PRIMARY KEY,
	username NVARCHAR(255) NULL,
	email NVARCHAR(100) UNIQUE NOT NULL,
	gioiTinh NVARCHAR(10),
	password NVARCHAR(255) NULL,
	date_signup DATE NULL
)

CREATE TABLE QuanLy (
    id NVARCHAR(50) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL
)

INSERT INTO QuanLy (id, username, email, password)  
VALUES  
('QL001', 'admin', 'admin@gmail.com', '1234554321')

SELECT* FROM NhanVien
SELECT* FROM QuanLy

CREATE TABLE Menu (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL,
    LoaiMon NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'Còn bán' CHECK (TrangThai IN ('Còn bán', 'Ngừng bán')),
    HinhAnh NVARCHAR(255) NOT NULL
);

CREATE TABLE NguyenLieu (
    MaNL INT IDENTITY(1,1) PRIMARY KEY,
    TenNL NVARCHAR(100) NOT NULL,
    SoLuongTon INT NOT NULL,
    DonViTinh NVARCHAR(50) NOT NULL,
    NgayNhap DATE NOT NULL,
    TenNCC NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
);

CREATE TABLE DonHang (
    MaDH INT IDENTITY(1,1) PRIMARY KEY,
    NgayDat DATETIME DEFAULT GETDATE(),
    MaNV  NVARCHAR(50) FOREIGN KEY REFERENCES NhanVien(id),
    TongTien DECIMAL(10,2) NOT NULL,
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('Đã thanh toán', 'Hủy'))
);

CREATE TABLE ChiTietDonHang (
    MaCTDH INT IDENTITY(1,1) PRIMARY KEY,
    MaDH INT FOREIGN KEY REFERENCES DonHang(MaDH),
    MaMon INT FOREIGN KEY REFERENCES Menu(MaMon),
    SoLuong INT NOT NULL,
    Gia DECIMAL(10,2) NOT NULL,
    GhiChu NVARCHAR(255)
);

CREATE TABLE LichLamViec (
    MaLLV INT IDENTITY(1,1) PRIMARY KEY,
    MaNV  NVARCHAR(50) FOREIGN KEY REFERENCES NhanVien(id),
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(50) CHECK (CaLam IN ('Sáng', 'Chiều', 'Tối'))
);

CREATE TABLE DoanhThu (
    MaDT INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE NOT NULL,
    TongSoDon INT NOT NULL,
    TongTien DECIMAL(10,2) NOT NULL
);