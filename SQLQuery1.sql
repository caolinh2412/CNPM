CREATE DATABASE CafeShop
GO 
USE CafeShop;

CREATE TABLE NguoiDung (
    MaND NVARCHAR(10) PRIMARY KEY, 
    HoVaTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    SDT VARCHAR(15) UNIQUE NULL,
    GioiTinh NVARCHAR(10) NULL CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    Password NVARCHAR(255) NOT NULL,
    NgayDiLam DATE NULL,
    MaQL NVARCHAR(10) NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động' CHECK (TrangThai IN (N'Hoạt động', N'Không hoạt động')),
    FOREIGN KEY (MaQL) REFERENCES NguoiDung(MaND)
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
    MaND NVARCHAR(10) NULL,
    TongTien DECIMAL(18,0)  NOT NULL CHECK (TongTien >= 0),
	PhuongThuc NVARCHAR(20) NOT NULL CHECK (PhuongThuc IN (N'Chuyển khoản', N'Tiền mặt')), 
    FOREIGN KEY (MaND) REFERENCES NguoiDung(MaND)
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
    MaND NVARCHAR(10) NOT NULL,
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(20) NOT NULL CHECK (CaLam IN (N'Sáng', N'Chiều', N'Tối')),
    FOREIGN KEY (MaND) REFERENCES NguoiDung(MaND) ON DELETE CASCADE
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
    SELECT MaND, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
    FROM NguoiDung 
    WHERE email = @email AND password = @password AND  TrangThai = N'Hoạt động'

    UNION ALL

    SELECT MaND, HoVaTen, Email, SDT, GioiTinh, Password, NgayDiLam, MaQL
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
    SELECT MaND, HoVaTen, GioiTinh, Email, SDT, NgayDiLam, TrangThai
    FROM NguoiDung;
END

CREATE PROCEDURE TatHD
    @MaND NVARCHAR(10)  -- Sử dụng NVARCHAR để đồng bộ với bảng NguoiDung
AS
BEGIN
    UPDATE NguoiDung
    SET TrangThai = CASE 
                        WHEN TrangThai = N'Hoạt động' THEN N'Không hoạt động'
                        WHEN TrangThai = N'Không hoạt động' THEN N'Hoạt động'
                        ELSE TrangThai  
                    END
    WHERE MaND = @MaND;
END

--Chỉnh sửa lại thông tin nhân viên 
CREATE PROCEDURE UpdateEmployee
    @MaND VARCHAR(10),
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
    WHERE MaND = @MaND;
END

--Thêm nhân viên vào bảng
CREATE PROCEDURE InsertEmployee 
    @HoVaTen NVARCHAR(100),
    @email NVARCHAR(100),
    @SDT VARCHAR(15),
    @GioiTinh NVARCHAR(10),
    @NgayDiLam DATE
AS
BEGIN
    DECLARE @NewMaND NVARCHAR(50);
    DECLARE @DefaultPassword NVARCHAR(255);
    DECLARE @MaQL NVARCHAR(50) = 'QL001';  

    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE MaND LIKE 'NV%')
    BEGIN
        SET @NewMaND = 'NV001';
    END
    ELSE
    BEGIN
        SELECT @NewMaND = 'NV' + RIGHT('000' + CAST(CAST(SUBSTRING(MAX(MaND), 3, 3) AS INT) + 1 AS NVARCHAR(3)), 3)
        FROM NguoiDung 
        WHERE MaND LIKE 'NV%';
    END

    SET @DefaultPassword = 'CafeShop' + @NewMaND;

    INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
    VALUES 
        (@NewMaND, @HoVaTen, @email, @SDT, @GioiTinh, @DefaultPassword, @NgayDiLam, @MaQL);
END;


--Thêm lịch làm việc 
CREATE PROCEDURE InsertWorkSchedule
    @MaND NVARCHAR(50),
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
    INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam)
    VALUES (@NewMaLLV, @MaND, @Ngay, @CaLam);
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
    @MaLLV NVARCHAR(50),
    @MaND NVARCHAR(50),
    @Ngay DATE,
    @CaLam NVARCHAR(50)
AS
BEGIN
    UPDATE LichLamViec 
    SET MaND = @MaND, 
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

CREATE PROCEDURE sp_XoaDanhMuc
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
    RAISERROR(N'Danh mục đã được xóa thành công.', 0, 1);
END;





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

CREATE PROCEDURE UpdateMon
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
                UPDATE CongThuc
                SET MaMon = @NewMaMon
                WHERE MaMon = @MaMon;

                UPDATE Menu
                SET 
                    MaMon = @NewMaMon,
                    TenMon = @TenMon,
                    Gia = @Gia,
                    HinhAnh = @HinhAnh,
                    MaDM = @MaDM
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
USE CafeShop
GO
CREATE PROCEDURE sp_ThemDonHangVaChiTiet
    @NgayDat DATETIME,
    @MaND NVARCHAR(50),
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

        INSERT INTO DonHang (MaDH, NgayDat, MaND, TongTien, PhuongThuc)
        VALUES (@MaDH, @NgayDat, @MaND, @TongTien, @PhuongThuc);

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
use CafeShop
go

CREATE PROCEDURE sp_GetAllDonHang
AS
BEGIN
    SELECT 
        dh.MaDH,
        dh.NgayDat,
        dh.MaND,
        nd.HoVaTen,
        dh.TongTien,
        dh.PhuongThuc 
    FROM DonHang dh
    INNER JOIN NguoiDung nd ON dh.MaND = nd.MaND
END
--Lấy chi tiết đơn hàng theo mã đơn hàng 
CREATE PROCEDURE sp_LayCTHDTheoMaDH
    @MaDH nvarchar(50) 
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
    @MaNL VARCHAR(50)
AS
BEGIN
    DELETE FROM NguyenLieu 
    WHERE MaNL = @MaNL;
END

--chỉnh sửa nguyên liệu 
CREATE PROCEDURE UpdateNguyenLieu
    @MaNL NVARCHAR(50),
    @TenNL NVARCHAR(100),
    @SoLuongTon DECIMAL(10,2),  
    @DonViTinh NVARCHAR(50),
    @NgayNhap DATE,
    @TenNCC NVARCHAR(100),
    @SDT VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;

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
CREATE PROCEDURE ThemNguyenLieu
    @TenNL NVARCHAR(100),
    @SoLuongTon DECIMAL(10,2), 
    @DonViTinh NVARCHAR(50),
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
    @MaMon NVARCHAR(50)
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
    @DonViTinh NVARCHAR(50)
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
    @MaCT NVARCHAR(50)
AS
BEGIN
    DELETE FROM CongThuc WHERE MaCT = @MaCT;
END;

--Cập nhật số lượng tồn kho 
CREATE PROCEDURE sp_CapNhatSoLuongTonKho
    @MaDH NVARCHAR(50)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Tạo bảng tạm với kiểu dữ liệu chính xác
        CREATE TABLE #TempNguyenLieu (
            MaNL NVARCHAR(50),
            SoLuongCanTru DECIMAL(18, 2)
        );

        -- Tính tổng số lượng cần trừ dựa theo công thức và chi tiết đơn hàng
        INSERT INTO #TempNguyenLieu (MaNL, SoLuongCanTru)
        SELECT 
            ct.MaNL,
            SUM(ct.SoLuong * ctdh.SoLuong) AS SoLuongCanTru
        FROM ChiTietDonHang ctdh
        INNER JOIN CongThuc ct ON ctdh.MaMon = ct.MaMon
        WHERE ctdh.MaDH = @MaDH
        GROUP BY ct.MaNL;

        -- Kiểm tra tồn kho có đủ không
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

        -- Dọn dẹp bảng tạm
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


--NHẬP THÔNG TIN THỬ NGHIỆM 

-- Nhập dữ liệu cho quản lý (MaQL là NULL)
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES
('QL001', N'Nguyễn Văn A', 'admin@gmail.com', '0901234567', N'Nam', '1234554321', '2023-01-01', NULL);

-- Nhập dữ liệu cho nhân viên (MaQL tham chiếu đến quản lý)
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES
('NV001', N'Lê Văn C', 'levanc@gmail.com', '0923456789', N'Nam', 'pass789', '2023-03-01', 'QL001'),
('NV002', N'Phạm Thị D', 'phamthid@gmail.com', '0934567890', N'Nữ', 'pass1011', '2023-04-10', 'QL001'),
('NV003', N'Hoàng Văn E', 'hoangvane@gmail.com', '0945678901', N'Nam', 'pass1213', '2023-05-20', 'QL001'),
('NV004', N'Vũ Thị F', 'vuthif@gmail.com', '0956789012', N'Nữ', 'pass1415', '2023-06-30', 'QL001');


INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam) VALUES
('LLV001', 'NV002', '2024-10-26', N'Sáng'),
('LLV002', 'NV002', '2024-10-26', N'Chiều'),
('LLV003', 'NV003', '2024-10-27', N'Tối'),
('LLV004', 'NV003', '2024-10-28', N'Chiều');

-- Thêm món Cà phê sữa đá
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('CF0001', N'Cà phê sữa đá', 25000, 'CF');

-- Thêm món Trà sữa trân châu đường đen
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('TS0001', N'Trà sữa trân châu đường đen', 35000, 'TS');

-- Thêm món Nước ép cam
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('NE0001', N'Nước ép cam', 30000, 'NE');

-- Thêm món Sinh tố bơ
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('ST0001', N'Sinh tố bơ', 40000, 'ST');

-- Thêm món Trà đào cam sả
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('T0001', N'Trà đào cam sả', 38000, 'T');

-- Thêm món Đá xay socola
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('DX0001', N'Đá xay socola', 45000, 'DX');

-- Thêm món Bánh ngọt Tiramisu
INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('BN0001', N'Bánh ngọt Tiramisu', 50000, 'BN');

INSERT INTO Menu (MaMon, TenMon, Gia, MaDM)
VALUES ('CF0002', N'Cà phê đen đá', 20000, 'CF');

-- Thêm món không có hình ảnh
INSERT INTO Menu (MaMon, TenMon, Gia,MaDM)
VALUES ('TS0002', N'Trà sữa matcha', 32000, 'TS');

-- Thêm danh mục Cà phê
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('CF', N'Cà phê');

-- Thêm danh mục Trà sữa
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('TS', N'Trà sữa');

-- Thêm danh mục Nước ép
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('NE', N'Nước ép');

-- Thêm danh mục Sinh tố
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('ST', N'Sinh tố');

-- Thêm danh mục Trà
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('T', N'Trà');

-- Thêm danh mục Đá xay
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('DX', N'Đá xay');

-- Thêm danh mục Bánh ngọt
INSERT INTO DanhMuc (MaDM, TenDM)
VALUES ('BN', N'Bánh ngọt');


INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL01', N'Bột cà phê', 10000, N'gram', '2025-04-01', N'Công ty Cà phê ABC', '0901234567');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL02', N'Sữa đặc', 100000, N'ml', '2025-04-02', N'Công ty Sữa XYZ', '0902345678');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL03', N'Đá', 50000, N'gram', '2025-04-03', N'Công ty Đá ABC', '0903456789');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL04', N'Trà đen', 20000, N'gram', '2025-04-01', N'Công ty Trà XYZ', '0904567890');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL05', N'Sữa tươi', 100000, N'ml', '2025-04-02', N'Công ty Sữa DEF', '0905678901');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL06', N'Đường đen', 20000, N'gram', '2025-04-01', N'Công ty Đường JKL', '0906789012');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL07', N'Trân châu', 50000, N'gram', '2025-04-03', N'Công ty Trân châu GHI', '0907890123');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL08', N'Cam tươi', 10000, N'quả', '2025-04-02', N'Công ty Cam ABC', '0908901234');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL09', N'Đường', 30000, N'gram', '2025-04-01', N'Công ty Đường MNO', '0909012345');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL10', N'Bơ chín', 5000, N'quả', '2025-04-02', N'Công ty Bơ XYZ', '0902345678');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL11', N'Bột matcha', 10000, N'gram', '2025-04-01', N'Công ty Matcha PQR', '0903456789');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL12', N'Siro socola', 50000, N'ml', '2025-04-03', N'Công ty Socola TUV', '0904567890');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL13', N'Phô mai mascarpone', 5000, N'gram', '2025-04-02', N'Công ty Phô mai ABC', '0905678901');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL14', N'Bánh ladyfinger', 1000, N'gram', '2025-04-01', N'Công ty Bánh GHI', '0906789012');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL15', N'Trứng', 1000, N'quả', '2025-04-03', N'Công ty Trứng ABC', '0907890123');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL16', N'Rượu Marsala', 5000, N'ml', '2025-04-02', N'Công ty Rượu DEF', '0908901234');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL17', N'Cacao bột', 10000, N'gram', '2025-04-01', N'Công ty Cacao GHI', '0909012345');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL18', N'Nước cam', 20000, N'ml', '2025-04-03', N'Công ty Cam XYZ', '0902345678');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL19', N'Đào tươi', 5000, N'quả', '2025-04-02', N'Công ty Đào ABC', '0903456789');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL20', N'Sả', 5000, N'gram', '2025-04-01', N'Công ty Sả XYZ', '0904567890');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL21', N'Bột cacao', 5000, N'gram', '2025-04-03', N'Công ty Cacao PQR', '0905678901');

INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
VALUES ('NL22', N'Siro đào', 50000, N'ml', '2025-04-02', N'Công ty Siro ABC', '0906789012');


-- Cà phê sữa đá (CF0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT001', 'CF0001', 'NL01', 50, 'gram'); -- Bột cà phê
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT002', 'CF0001', 'NL02', 30, 'ml');   -- Sữa đặc
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT003', 'CF0001', 'NL03', 100, 'gram');-- Đá

-- Trà sữa trân châu đường đen (TS0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT004', 'TS0001', 'NL04', 5, 'gram');  -- Trà đen
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT005', 'TS0001', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT006', 'TS0001', 'NL06', 30, 'gram'); -- Đường đen
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT007', 'TS0001', 'NL07', 50, 'gram'); -- Trân châu

-- Nước ép cam (NE0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT008', 'NE0001', 'NL08', 200, 'ml');  -- Nước cam
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT009', 'NE0001', 'NL09', 20, 'gram'); -- Đường

-- Sinh tố bơ (ST0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT010', 'ST0001', 'NL10', 1, 'quả');   -- Bơ chín
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT011', 'ST0001', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT012', 'ST0001', 'NL09', 20, 'gram'); -- Đường

-- Trà đào cam sả (T0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT013', 'T0001', 'NL04', 5, 'gram');   -- Trà đen
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT014', 'T0001', 'NL18', 200, 'ml');   -- Nước cam
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT015', 'T0001', 'NL19', 100, 'gram'); -- Đào tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT016', 'T0001', 'NL20', 1, 'cây');    -- Sả

-- Đá xay socola (DX0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT017', 'DX0001', 'NL17', 50, 'gram'); -- Bột cacao
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT018', 'DX0001', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT019', 'DX0001', 'NL03', 100, 'gram');-- Đá

-- Bánh ngọt Tiramisu (BN0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT020', 'BN0001', 'NL13', 200, 'gram');-- Phô mai mascarpone
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT021', 'BN0001', 'NL14', 10, 'cái');  -- Bánh ladyfinger
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT022', 'BN0001', 'NL15', 3, 'quả');   -- Trứng
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT023', 'BN0001', 'NL16', 50, 'ml');   -- Rượu Marsala
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT024', 'BN0001', 'NL04', 20, 'gram'); -- Bột cacao

-- Trà sữa matcha (TS0002)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT025', 'TS0002', 'NL11', 5, 'gram');  -- Bột matcha
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT026', 'TS0002', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT027', 'TS0002', 'NL07', 50, 'gram'); -- Trân châu

