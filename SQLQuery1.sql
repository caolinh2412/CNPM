CREATE DATABASE CafeShop
GO 
USE CafeShop;

CREATE TABLE NguoiDung (
    MaNV NVARCHAR(10) PRIMARY KEY, 
    HoVaTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    SDT VARCHAR(15) UNIQUE NULL,
    GioiTinh NVARCHAR(10) NULL CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    Password NVARCHAR(255) NOT NULL,
    NgayDiLam DATE NULL,
    MaQL NVARCHAR(10) NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động')),
    FOREIGN KEY (MaQL) REFERENCES NguoiDung(MaNV)
);

CREATE TABLE DanhMuc (
    MaDM VARCHAR(10) PRIMARY KEY,    
    TenDM NVARCHAR(100) NOT NULL
);

-- Bảng Menu (Thực đơn)
CREATE TABLE Menu (
    MaMon NVARCHAR(10) PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia > 0),
    HinhAnh NVARCHAR(255) NULL,
    MaDM VARCHAR(10) NOT NULL,
    FOREIGN KEY (MaDM) REFERENCES DanhMuc(MaDM)
);


-- Bảng Nguyên Liệu
CREATE TABLE NguyenLieu (
    MaNL NVARCHAR(10) PRIMARY KEY, 
    TenNL NVARCHAR(100) NOT NULL,
    SoLuongTon DECIMAL(10, 2) NOT NULL CHECK (SoLuongTon >= 0), 
    DonViTinh NVARCHAR(20) NOT NULL, 
    NgayNhap DATE NOT NULL,
    TenNCC NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL
);

-- Bảng Đơn Hàng

CREATE TABLE DonHang (
    MaDH NVARCHAR(10) PRIMARY KEY, -- Shortened to 10
    NgayDat DATETIME DEFAULT GETDATE(),
    MaNV NVARCHAR(10) NULL,
    TongTien DECIMAL(18,0)  NOT NULL CHECK (TongTien >= 0),
	PhuongThuc NVARCHAR(20) NOT NULL CHECK (PhuongThuc IN (N'Chuyển khoản', N'Tiền mặt')), 
    FOREIGN KEY (MaNV) REFERENCES NguoiDung(MaNV)
);

-- Bảng Chi Tiết Đơn Hàng

CREATE TABLE ChiTietDonHang (
    MaCTDH NVARCHAR(10) PRIMARY KEY,
    MaDH NVARCHAR(10) NOT NULL,
    MaMon NVARCHAR(10) NOT NULL,
    TenMon NVARCHAR(100) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    Gia DECIMAL(18,0) NOT NULL CHECK (Gia >= 0),
    ThanhTien AS (SoLuong * Gia) PERSISTED,
    FOREIGN KEY (MaDH) REFERENCES DonHang(MaDH) ON DELETE CASCADE
);

-- Bảng Lịch Làm Việc
CREATE TABLE LichLamViec (
    MaLLV NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10) NOT NULL,
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES NguoiDung(MaNV) ON DELETE CASCADE
);

--Bảng công thức món 
CREATE TABLE CongThuc (
    MaCT NVARCHAR(10) PRIMARY KEY,
    MaMon NVARCHAR(10) NOT NULL,
    MaNL NVARCHAR(10) NOT NULL,
    SoLuong DECIMAL(10, 2) NOT NULL CHECK (SoLuong > 0),  
    DonViTinh NVARCHAR(20) NOT NULL,
    FOREIGN KEY (MaMon) REFERENCES Menu(MaMon),
    FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);


-- Thủ tục đăng nhập
CREATE PROCEDURE DangNhap (@email NVARCHAR(100), @password NVARCHAR(255))
AS
BEGIN
    SELECT MaNV, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
    FROM NguoiDung 
    WHERE email = @email AND password = @password AND  TrangThai = N'Hoạt động'

    UNION ALL

    SELECT MaNV, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
    FROM NguoiDung 
    WHERE email = @email AND password = @password AND MaQL IS NULL;
END;

--Kiểm tra email có tồn tại không
CREATE PROCEDURE KiemTraEmailTonTai
    @Email VARCHAR(100)
AS
BEGIN
    SELECT COUNT(*) FROM NguoiDung WHERE Email = @Email AND  TrangThai = N'Hoạt động'
END

--đổi lại mật khẩu
CREATE PROCEDURE ResetPassword
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    UPDATE NguoiDung SET Password = @Password WHERE Email = @Email  AND TrangThai = N'Hoạt động'
END


--Lấy thông tin tất cả nhân viên 
CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT MaNV, HoVaTen, GioiTinh, Email, SDT, NgayDiLam, TrangThai
    FROM NguoiDung;
END

CREATE PROCEDURE TatHD
    @MaNV NVARCHAR(10)  -- Sử dụng NVARCHAR để đồng bộ với bảng NguoiDung
AS
BEGIN
    UPDATE NguoiDung
    SET TrangThai = CASE 
                        WHEN TrangThai = N'Hoạt động' THEN N'Không hoạt động'
                        WHEN TrangThai = N'Không hoạt động' THEN N'Hoạt động'
                        ELSE TrangThai  
                    END
    WHERE MaNV = @MaNV;
END

--Chỉnh sửa lại thông tin nhân viên 
CREATE OR ALTER PROCEDURE UpdateEmployee
    @MaNV VARCHAR(10),
    @HoVaTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10),
    @Email NVARCHAR(100),
    @SDT VARCHAR(15),
    @NgayDiLam DATE
AS
BEGIN
    UPDATE NguoiDung 
    SET HoVaTen = @HoVaTen, 
        GioiTinh = @GioiTinh, 
        email = @Email, 
        SDT = @SDT, 
        NgayDiLam = @NgayDiLam 
    WHERE MaNV = @MaNV;
END

--Thêm nhân viên vào bảng
CREATE OR ALTER PROCEDURE InsertEmployee 
    @HoVaTen NVARCHAR(100),
    @Email NVARCHAR(100),
    @SDT VARCHAR(15),
    @GioiTinh NVARCHAR(10),
    @NgayDiLam DATE,
    @MaQL NVARCHAR(10)  
AS
BEGIN
    DECLARE @NewMaNV NVARCHAR(50);
    DECLARE @DefaultPassword NVARCHAR(255);

    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE MaNV LIKE 'NV%')
    BEGIN
        SET @NewMaNV = 'NV001';
    END
    ELSE
    BEGIN
        SELECT @NewMaNV = 'NV' + RIGHT('000' + CAST(CAST(SUBSTRING(MAX(MaNV), 3, 3) AS INT) + 1 AS NVARCHAR(3)), 3)
        FROM NguoiDung 
        WHERE MaNV LIKE 'NV%';
    END

    SET @DefaultPassword = 'CafeShop' + @NewMaNV;

    INSERT INTO NguoiDung (MaNV, HoVaTen, Email, SDT, GioiTinh, password, NgayDiLam, MaQL)
    VALUES 
        (@NewMaNV, @HoVaTen, @Email, @SDT, @GioiTinh, @DefaultPassword, @NgayDiLam, @MaQL);
END;

SELECT * FROM NguoiDung

--Thêm lịch làm việc 
CREATE PROCEDURE InsertWorkSchedule
    @MaNV NVARCHAR(10),
    @Ngay DATE,
    @CaLam NVARCHAR(50)
AS
BEGIN
    DECLARE @NewMaLLV NVARCHAR(50);

    IF NOT EXISTS (SELECT 1 FROM LichLamViec WHERE MaLLV LIKE 'LLV%')
    BEGIN
        SET @NewMaLLV = 'LLV001';
    END
    ELSE
    BEGIN
       SELECT @NewMaLLV = 'LLV' + RIGHT('000' + CAST(CAST(ISNULL(MAX(CAST(SUBSTRING(MaLLV, 4, LEN(MaLLV) - 3) AS INT)), 0) + 1 AS NVARCHAR) AS NVARCHAR), 3)
		FROM LichLamViec 
		WHERE MaLLV LIKE 'LLV%';
    END
    INSERT INTO LichLamViec (MaLLV, MaNV, Ngay, CaLam)
    VALUES (@NewMaLLV, @MaNV, @Ngay, @CaLam);
END;

--Tạo lịch làm việc 
CREATE PROCEDURE DeleteWorkSchedule
    @MaLLV NVARCHAR(50)
AS
BEGIN
    DELETE FROM LichLamViec 
    WHERE MaLLV = @MaLLV;
END;

--Cập nhật lịch làm việc
CREATE PROCEDURE CapNhatLichLamViec
    @MaLLV NVARCHAR(10),
    @MaNV NVARCHAR(10),
    @Ngay DATE,
    @CaLam NVARCHAR(50)
AS
BEGIN
    UPDATE LichLamViec 
    SET MaNV = @MaNV, 
        Ngay = @Ngay, 
        CaLam = @CaLam 
    WHERE MaLLV = @MaLLV;
END;

--Đếm nhân viên
CREATE PROCEDURE DemNv
AS
BEGIN
    SELECT COUNT(*) 
    FROM NguoiDung 
    WHERE MaQL IS NOT NULL AND  TrangThai = N'Hoạt động';;
END;


CREATE PROCEDURE ThemMonMoi
    @MaDM VARCHAR(10),
    @TenMon NVARCHAR(50),
    @Gia DECIMAL(10,2),
    @HinhAnh NVARCHAR(255)
AS
BEGIN
    DECLARE @MaMonMoi NVARCHAR(10);
    DECLARE @SoThuTu INT;

    SELECT @SoThuTu = ISNULL(MAX(CAST(SUBSTRING(MaMon, 3, 4) AS INT)), 0) + 1
    FROM Menu
    WHERE MaMon LIKE @MaDM + '[0-9][0-9][0-9][0-9]';

    SET @MaMonMoi = @MaDM + RIGHT('0000' + CAST(@SoThuTu AS VARCHAR(4)), 4);

    INSERT INTO Menu (MaMon, TenMon, Gia, HinhAnh, MaDM)
    VALUES (@MaMonMoi, @TenMon, @Gia, @HinhAnh, @MaDM);
END;

--lấy danh sách tên danh mục 
CREATE PROCEDURE LayDanhSachTenDanhMuc
AS
BEGIN
    SELECT MaDM, TenDM
    FROM DanhMuc  
END;


--lấy món theo mã món
CREATE PROCEDURE getMonById
    @MaMon NVARCHAR(10)
AS
BEGIN
    SELECT 
        m.MaMon,
        m.TenMon,
        m.Gia,
        m.HinhAnh,
        m.MaDM,
        d.TenDM	
    FROM Menu m
    JOIN DanhMuc d ON m.MaDM = d.MaDM
    WHERE m.MaMon = @MaMon ;
END


--lấy danh sách món theo tên danh mục 
CREATE PROCEDURE LayDanhSachMonTheoMaDanhMuc
    @MaDanhMuc NVARCHAR(100)
AS
BEGIN
    SELECT 
        M.MaMon,
        M.TenMon,
        M.Gia,
        M.HinhAnh,
        M.MaDM		
    FROM Menu M
    JOIN DanhMuc D ON M.MaDM = D.MaDM
    WHERE D.MaDM = @MaDanhMuc  ;
END;

CREATE PROCEDURE LayDanhSachMon
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Menu    
END;


CREATE PROCEDURE sp_ThemDanhMuc
    @MaDM VARCHAR(10),
    @TenDM NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DanhMuc WHERE MaDM = @MaDM)
    BEGIN
        RAISERROR('Mã danh mục đã tồn tại.', 16, 1)
        RETURN
    END

    INSERT INTO DanhMuc (MaDM, TenDM)
    VALUES (@MaDM, @TenDM)
END

CREATE OR ALTER PROCEDURE sp_XoaDanhMuc
    @MaDM VARCHAR(10)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM DanhMuc WHERE MaDM = @MaDM)
    BEGIN
        RAISERROR(N'Danh mục không tồn tại.', 16, 1);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Menu WHERE MaDM = @MaDM)
    BEGIN
        RAISERROR(N'Danh mục này đang có món liên quan. Bạn phải xóa các món thuộc danh mục này trước khi xóa danh mục.', 16, 1);
        RETURN;
    END

    DELETE FROM DanhMuc WHERE MaDM = @MaDM;

END


--Lấy tất cả các món 
CREATE PROCEDURE LayTatCaMonAn
AS
BEGIN
    SELECT MaMon, TenMon, Gia, HinhAnh, MaDM
    FROM Menu
END;


--xóa món
CREATE PROCEDURE sp_XoaMon
    @MaMon NVARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        DELETE FROM CongThuc WHERE MaMon = @MaMon;
        DELETE FROM Menu WHERE MaMon = @MaMon;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT N'Có lỗi xảy ra khi xóa món.';
    END CATCH
END;

CREATE or alter PROCEDURE UpdateMon
    @MaMon NVARCHAR(10),
    @TenMon NVARCHAR(50),
    @Gia DECIMAL(10,2),
    @HinhAnh NVARCHAR(255),
    @MaDM VARCHAR(10)
AS
BEGIN
    DECLARE @NewMaMon NVARCHAR(10)
    DECLARE @SoThuTu INT
    DECLARE @LastMaMon NVARCHAR(10)

    IF EXISTS (SELECT 1 FROM Menu WHERE MaMon = @MaMon)
    BEGIN   
        IF EXISTS (SELECT 1 FROM Menu WHERE MaMon = @MaMon AND MaDM <> @MaDM)
        BEGIN       
            SELECT TOP 1 @LastMaMon = MaMon
            FROM Menu
            WHERE MaMon LIKE @MaDM + '[0-9][0-9][0-9][0-9]' 
            ORDER BY CAST(SUBSTRING(MaMon, LEN(@MaDM) + 1, 4) AS INT) DESC
    
            IF (@LastMaMon IS NOT NULL)
            BEGIN
                DECLARE @SoThuTuStr NVARCHAR(4) = SUBSTRING(@LastMaMon, LEN(@MaDM) + 1, 4)
                SET @SoThuTu = TRY_CAST(@SoThuTuStr AS INT)
                
                IF (@SoThuTu IS NULL)
                    SET @SoThuTu = 0
            END
            ELSE
            BEGIN               
                SET @SoThuTu = 1
            END
          
            SET @SoThuTu = @SoThuTu + 1
          
            SET @NewMaMon = @MaDM + RIGHT('0000' + CAST(@SoThuTu AS VARCHAR(4)), 4)

            BEGIN TRANSACTION
            BEGIN TRY              
                INSERT INTO Menu (MaMon, TenMon, Gia, HinhAnh, MaDM)
                VALUES (@NewMaMon, @TenMon, @Gia, @HinhAnh, @MaDM);

                UPDATE CongThuc
                SET MaMon = @NewMaMon
                WHERE MaMon = @MaMon;

                DELETE FROM Menu
                WHERE MaMon = @MaMon;

                COMMIT TRANSACTION
            END TRY
            BEGIN CATCH
                ROLLBACK TRANSACTION
                DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
                RAISERROR (@ErrorMessage, 16, 1);
            END CATCH
        END
        ELSE
        BEGIN                     
            UPDATE Menu
            SET 
                TenMon = @TenMon,
                Gia = @Gia,
                HinhAnh = @HinhAnh,
                MaDM = @MaDM
            WHERE MaMon = @MaMon;
        END
    END
    ELSE
    BEGIN
        RAISERROR(N'Món không tồn tại để cập nhật.', 16, 1);
    END
END;


--Tính tổng số món
CREATE PROCEDURE sp_TinhTongSoMonTrongMenu
AS
BEGIN
    SELECT COUNT(*) 
    FROM Menu
END;

-- Thêm đơn hàng và chi tiết đơn hàng 
CREATE TYPE ChiTietDonHangType AS TABLE (	
    MaMon NVARCHAR(10),  
    TenMon NVARCHAR(100),
    SoLuong INT,
    Gia DECIMAL(10,2)
);
CREATE PROCEDURE sp_ThemDonHangVaChiTiet
    @NgayDat DATETIME,
    @MaNV NVARCHAR(10),
    @ChiTietDonHang AS ChiTietDonHangType READONLY,
    @MaDH NVARCHAR(10) OUTPUT,
	@PhuongThuc NVARCHAR(20) 
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @NextMaDH INT;
        SELECT @NextMaDH = ISNULL(MAX(CAST(SUBSTRING(MaDH, 3, LEN(MaDH) - 2) AS INT)), 0) + 1
        FROM DonHang;
        SET @MaDH = 'DH' + RIGHT('000' + CAST(@NextMaDH AS NVARCHAR(3)), 3);

        DECLARE @TongTien DECIMAL(18,0);
        SELECT @TongTien = SUM(SoLuong * Gia)
        FROM @ChiTietDonHang;

        INSERT INTO DonHang (MaDH, NgayDat, MaNV, TongTien, PhuongThuc)
        VALUES (@MaDH, @NgayDat, @MaNV, @TongTien, @PhuongThuc);

        DECLARE @MaxChiTietID INT;
        SELECT @MaxChiTietID = ISNULL(MAX(CAST(SUBSTRING(MaCTDH, 3, LEN(MaCTDH) - 2) AS INT)), 0)
        FROM ChiTietDonHang;
        INSERT INTO ChiTietDonHang (MaCTDH, MaDH, MaMon,TenMon, SoLuong, Gia)
        SELECT 
            'CT' + RIGHT('000' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @MaxChiTietID AS NVARCHAR(3)), 3),
            @MaDH,
            MaMon,
			TenMon,
            SoLuong,
            Gia
        FROM @ChiTietDonHang;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;

--Lấy mã đơn hàng tiếp theo 
CREATE  PROCEDURE sp_LayMaDonHangTiepTheo
    @MaDH NVARCHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LastMaDH NVARCHAR(10);
    DECLARE @Number INT;

    SELECT TOP 1 @LastMaDH = MaDH
    FROM DonHang
    ORDER BY MaDH DESC;

    IF @LastMaDH IS NULL
    BEGIN
        SET @MaDH = 'DH001';
    END
    ELSE
    BEGIN
        SET @Number = CAST(SUBSTRING(@LastMaDH, 3, LEN(@LastMaDH)) AS INT) + 1;
        SET @MaDH = 'DH' + RIGHT('000' + CAST(@Number AS NVARCHAR(3)), 3);
    END
END


--Lấy toàn bộ đơn hàng 

CREATE PROCEDURE sp_GetAllDonHang
AS
BEGIN
    SELECT 
        dh.MaDH,
        dh.NgayDat,
        dh.MaNV,
        nd.HoVaTen,
        dh.TongTien,
        dh.PhuongThuc 
    FROM DonHang dh
    INNER JOIN NguoiDung nd ON dh.MaNV = nd.MaNV
END

--Lấy chi tiết đơn hàng theo mã đơn hàng 
CREATE PROCEDURE sp_LayCTHDTheoMaDH
    @MaDH nvarchar(10) 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ctdh.MaCTDH,
        ctdh.MaDH,
        ctdh.MaMon,
        ctdh.SoLuong,
        ctdh.Gia,
        ctdh.ThanhTien,
        m.TenMon
    FROM 
        ChiTietDonHang ctdh
    INNER JOIN 
        Menu m ON ctdh.MaMon = m.MaMon
    WHERE 
        ctdh.MaDH = @MaDH;
END
--TOP 3 
CREATE PROCEDURE sp_GetTop3MonBanChay
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        TenMon,
        SUM(SoLuong) AS TongSoLuong
    INTO #MonBanChay
    FROM ChiTietDonHang
    GROUP BY TenMon;

    SELECT TOP 3
        TenMon,
        TongSoLuong
    FROM #MonBanChay
    ORDER BY TongSoLuong DESC;

    DROP TABLE #MonBanChay;
END

--Tổng số khách
CREATE PROCEDURE sp_TongSoKhach
AS
BEGIN
    SELECT COUNT(*) 
    FROM DonHang;
END;

--Tính doanh thu trong ngày 
CREATE PROCEDURE sp_TinhDoanhThuTrongNgay
    @Ngay DATE
AS
BEGIN
    SELECT ISNULL(SUM(TongTien), 0) AS DoanhThu
    FROM DonHang
    WHERE CAST(NgayDat AS DATE) = @Ngay;
END;

--KHO NGUYÊN LIỆU 
--Lấy nguyên liệu
CREATE PROCEDURE GetAllKho
AS
BEGIN
    SELECT * FROM NguyenLieu;
END
---xóa nguyên liệu 
CREATE PROCEDURE DeleteNguyenLieu
    @MaNL VARCHAR(10)
AS
BEGIN
    DELETE FROM NguyenLieu 
    WHERE MaNL = @MaNL;
END

CREATE OR ALTER PROCEDURE UpdateNguyenLieu
    @MaNL NVARCHAR(10),
    @TenNL NVARCHAR(100),
    @SoLuongTon DECIMAL(10,2),  
    @DonViTinh NVARCHAR(20),
    @NgayNhap DATE,
    @TenNCC NVARCHAR(100),
    @SDT VARCHAR(15)
AS
BEGIN
    UPDATE NguyenLieu
    SET 
        TenNL = @TenNL,
        SoLuongTon = @SoLuongTon, 
        DonViTinh = @DonViTinh,
        NgayNhap = @NgayNhap,
        TenNCC = @TenNCC,
        SDT = @SDT
    WHERE MaNL = @MaNL;
END;

--Thêm nguyên liệu 
CREATE OR ALTER PROCEDURE ThemNguyenLieu
    @TenNL NVARCHAR(100),
    @SoLuongTon DECIMAL(10,2), 
    @DonViTinh NVARCHAR(20),
    @NgayNhap DATE,
    @TenNCC NVARCHAR(100),
    @SDT VARCHAR(15)
AS
BEGIN
    DECLARE @MaNL NVARCHAR(50);
    
    SELECT @MaNL = MAX(MaNL)
    FROM NguyenLieu;

    IF @MaNL IS NULL
    BEGIN       
        SET @MaNL = 'NL01';  
    END
    ELSE
    BEGIN
        DECLARE @SoThuTu INT;
        SET @SoThuTu = CAST(SUBSTRING(@MaNL, 3, LEN(@MaNL) - 2) AS INT) + 1;

        SET @MaNL = 'NL' + RIGHT('00' + CAST(@SoThuTu AS NVARCHAR), 2);
    END

    INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
    VALUES (@MaNL, @TenNL, @SoLuongTon, @DonViTinh, @NgayNhap, @TenNCC, @SDT);
END;

--Lấy mã nguyên liệu tiếp theo 
CREATE PROCEDURE GetNextMaNL
AS
BEGIN
    DECLARE @NextMaNL NVARCHAR(50);
    SELECT @NextMaNL = MAX(MaNL)
    FROM NguyenLieu;

    IF @NextMaNL IS NULL
    BEGIN
        SET @NextMaNL = 'NL01';
    END
    ELSE
    BEGIN        
        DECLARE @NumberPart INT;
        SET @NumberPart = CAST(SUBSTRING(@NextMaNL, 3, LEN(@NextMaNL) - 2) AS INT) + 1;      
        SET @NextMaNL = 'NL' + RIGHT('00' + CAST(@NumberPart AS NVARCHAR), 2);
    END
    SELECT @NextMaNL AS MaNL;
END;

--CÔNG THỨC
CREATE PROCEDURE sp_LayCongThuc
    @MaMon NVARCHAR(10)
AS
BEGIN
    SELECT 
        CT.MaCT,
        CT.MaNL,
        NL.TenNL,
        CT.SoLuong,
        CT.DonViTinh
    FROM 
        CongThuc CT
    INNER JOIN 
        NguyenLieu NL ON CT.MaNL = NL.MaNL
    WHERE 
        CT.MaMon = @MaMon;
END
--Thêm công thức 
CREATE PROCEDURE sp_ThemCongThuc
    @MaMon NVARCHAR(10),
    @MaNL NVARCHAR(10),
    @SoLuong DECIMAL(10, 2),
    @DonViTinh NVARCHAR(20)
AS
BEGIN
    DECLARE @MaCT NVARCHAR(10);
    DECLARE @MaxMaCT NVARCHAR(10);
    DECLARE @Number INT;

    SELECT @MaxMaCT = MAX(MaCT) FROM CongThuc;

    IF @MaxMaCT IS NULL
    BEGIN
        SET @MaCT = 'CT001';
    END
    ELSE
    BEGIN
        SET @Number = CAST(SUBSTRING(@MaxMaCT, 3, LEN(@MaxMaCT) - 2) AS INT);
        SET @Number = @Number + 1;
        SET @MaCT = 'CT' + RIGHT('000' + CAST(@Number AS NVARCHAR(3)), 3);
    END

    BEGIN TRY
        INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh)
        VALUES (@MaCT, @MaMon, @MaNL, @SoLuong, @DonViTinh);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END;


--Xóa công thức 
CREATE PROCEDURE sp_DeleteCongThuc
    @MaCT NVARCHAR(10)
AS
BEGIN
    DELETE FROM CongThuc WHERE MaCT = @MaCT;
END;

--Cập nhật số lượng tồn kho 
CREATE PROCEDURE sp_CapNhatSoLuongTonKho
    @MaDH NVARCHAR(10)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        CREATE TABLE #TempNguyenLieu (
            MaNL NVARCHAR(10),
            SoLuongCanTru DECIMAL(18, 2)
        );

        INSERT INTO #TempNguyenLieu (MaNL, SoLuongCanTru)
        SELECT 
            ct.MaNL,
            SUM(ct.SoLuong * ctdh.SoLuong) AS SoLuongCanTru
        FROM ChiTietDonHang ctdh
        INNER JOIN CongThuc ct ON ctdh.MaMon = ct.MaMon
        WHERE ctdh.MaDH = @MaDH
        GROUP BY ct.MaNL;

        IF EXISTS (
            SELECT 1
            FROM #TempNguyenLieu tmp
            INNER JOIN NguyenLieu nl ON tmp.MaNL = nl.MaNL
            WHERE nl.SoLuongTon < tmp.SoLuongCanTru
        )
        BEGIN
            ROLLBACK TRANSACTION;
            RAISERROR (N'Không đủ số lượng tồn kho để thanh toán đơn hàng!', 16, 1);
            RETURN;
        END

        -- Trừ tồn kho
        UPDATE nl
        SET nl.SoLuongTon = nl.SoLuongTon - tmp.SoLuongCanTru
        FROM NguyenLieu nl
        INNER JOIN #TempNguyenLieu tmp ON nl.MaNL = tmp.MaNL;

        DROP TABLE #TempNguyenLieu;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END


CREATE PROCEDURE sp_KiemTraTonKho
    @MaMon NVARCHAR(10),
    @SoLuong INT,
    @KetQua BIT OUTPUT
AS
BEGIN
    BEGIN TRY
        CREATE TABLE #TempKiemTra (
            MaNL NVARCHAR(10),
            SoLuongCan DECIMAL(18,2),
            SoLuongTon DECIMAL(18,2)
        );
        INSERT INTO #TempKiemTra (MaNL, SoLuongCan, SoLuongTon)
        SELECT 
            ct.MaNL,
            ct.SoLuong * @SoLuong AS SoLuongCan,
            nl.SoLuongTon
        FROM CongThuc ct
        INNER JOIN NguyenLieu nl ON ct.MaNL = nl.MaNL
        WHERE ct.MaMon = @MaMon;

        IF EXISTS (
            SELECT 1 
            FROM #TempKiemTra 
            WHERE SoLuongTon < SoLuongCan
        )
        BEGIN
            SET @KetQua = 0; 
        END
        ELSE
        BEGIN
            SET @KetQua = 1; 
        END
        DROP TABLE #TempKiemTra;
    END TRY
    BEGIN CATCH
        IF OBJECT_ID('tempdb..#TempKiemTra') IS NOT NULL
            DROP TABLE #TempKiemTra;
            
        SET @KetQua = 0; -- Trả về false nếu có lỗi
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END

CREATE PROCEDURE sp_GetDoanhThuTheoThang
    @Nam INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        ThangList.Thang,
        ISNULL(SUM(D.TongTien), 0) AS DoanhThu
    FROM 
    (
        SELECT 1 AS Thang UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION 
        SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION 
        SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12
    ) AS ThangList
    LEFT JOIN DonHang D ON MONTH(D.NgayDat) = ThangList.Thang AND YEAR(D.NgayDat) = @Nam
    GROUP BY ThangList.Thang
    ORDER BY ThangList.Thang;
END



