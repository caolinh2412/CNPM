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

-- Nhập dữ liệu cho quản lý (MaQL là NULL)
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES
('QL001', N'Nguyễn Văn A', 'admin@example.com', '0901234567', N'Nam', '1234554321', '2023-01-01', NULL);

-- Nhập dữ liệu cho nhân viên (MaQL tham chiếu đến quản lý)
INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
VALUES
('NV001', N'Lê Văn C', 'levanc@example.com', '0923456789', N'Nam', 'pass789', '2023-03-01', 'QL001'),
('NV002', N'Phạm Thị D', 'phamthid@example.com', '0934567890', N'Nữ', 'pass1011', '2023-04-10', 'QL001'),
('NV003', N'Hoàng Văn E', 'hoangvane@example.com', '0945678901', N'Nam', 'pass1213', '2023-05-20', 'QL001'),
('NV004', N'Vũ Thị F', 'vuthif@example.com', '0956789012', N'Nữ', 'pass1415', '2023-06-30', 'QL001');

UPDATE NguoiDung
SET email = 'vuthif@gmail.com'
WHERE MaND = 'NV004';

-- Bảng Menu (Thực đơn)
CREATE TABLE Menu (
    MaMon NVARCHAR(10) PRIMARY KEY,
    TenMon NVARCHAR(50) NOT NULL,
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia > 0),
    LoaiMon NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT 'Còn bán' CHECK (TrangThai IN ('Còn bán', 'Ngừng bán')),
    HinhAnh NVARCHAR(255)
);
USE CafeShop
-- Bảng Nguyên Liệu
CREATE TABLE NguyenLieu (
    MaNL NVARCHAR(50) PRIMARY KEY,
    TenNL NVARCHAR(100) NOT NULL,
    SoLuongTon INT NOT NULL CHECK (SoLuongTon >= 0),
    DonViTinh NVARCHAR(50) NOT NULL,
    NgayNhap DATE NOT NULL,
    TenNCC NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL
);

DROP TABLE NguyenLieu
USE CafeShop;
-- Bảng Đơn Hàng
CREATE TABLE DonHang (
    MaDH NVARCHAR(50) PRIMARY KEY,
    NgayDat DATETIME DEFAULT GETDATE(),
    MaND NVARCHAR(50) NULL FOREIGN KEY REFERENCES NguoiDung(MaND) ON DELETE SET NULL, 
    TongTien DECIMAL(10,2) NOT NULL CHECK (TongTien >= 0)
);

-- Bảng Chi Tiết Đơn Hàng

CREATE TABLE ChiTietDonHang (
    MaCTDH NVARCHAR(10) PRIMARY KEY,
    MaDH  NVARCHAR(50) FOREIGN KEY REFERENCES DonHang(MaDH) ON DELETE CASCADE,
    MaMon NVARCHAR(10) FOREIGN KEY REFERENCES Menu(MaMon),
    TenMon NVARCHAR(100) NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    Gia DECIMAL(10,2) NOT NULL CHECK (Gia >= 0),
    ThanhTien AS (SoLuong * Gia) PERSISTED
);

DROP TABLE ChiTietDonHang
DROP TABLE DonHang 
-- Bảng Lịch Làm Việc
CREATE TABLE LichLamViec (
    MaLLV NVARCHAR(50) PRIMARY KEY,
    MaND NVARCHAR(50) FOREIGN KEY REFERENCES NguoiDung(MaND) ON DELETE CASCADE,
    Ngay DATE NOT NULL,
    CaLam NVARCHAR(50) CHECK (CaLam IN (N'Sáng', N'Chiều', N'Tối'))
);

-- Bảng Doanh Thu
CREATE TABLE DoanhThu (
    MaDT INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE NOT NULL,
    TongSoDon INT NOT NULL CHECK (TongSoDon >= 0),
    TongTien DECIMAL(10,2) NOT NULL CHECK (TongTien >= 0)
);

CREATE TABLE CongThuc (
    MaCT NVARCHAR(10) PRIMARY KEY, 
    MaMon NVARCHAR(10) FOREIGN KEY REFERENCES Menu(MaMon), 
    MaNL NVARCHAR(50) FOREIGN KEY REFERENCES NguyenLieu(MaNL), 
    SoLuong INT NOT NULL CHECK (SoLuong > 0),  
    DonViTinh NVARCHAR(10) NOT NULL 
);

INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam) VALUES
('LLV001', 'NV002', '2024-10-26', N'Sáng'),
('LLV002', 'NV002', '2024-10-26', N'Chiều'),
('LLV003', 'NV003', '2024-10-27', N'Tối'),
('LLV004', 'NV003', '2024-10-28', N'Chiều');

GO

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
 

GO

CREATE PROCEDURE KiemTraEmailTonTai
    @Email VARCHAR(100)
AS
BEGIN
    SELECT COUNT(*) FROM NguoiDung WHERE Email = @Email
END

CREATE PROCEDURE ResetPassword
    @Email VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    UPDATE NguoiDung SET Password = @Password WHERE Email = @Email
END

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT MaND, HoVaTen, GioiTinh, email, SDT, NgayDiLam 
    FROM NguoiDung 
    WHERE MaQL IS NOT NULL;
END

CREATE PROCEDURE DeleteEmployee
    @MaND VARCHAR(10)
AS
BEGIN
    DELETE FROM NguoiDung 
    WHERE MaND = @MaND;
END

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
    DECLARE @MaQL NVARCHAR(50) = 'NV001';  -- Mã quản lý cố định

    -- Tạo mã nhân viên mới (bắt đầu bằng 'NV')
    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE MaND LIKE 'NV%')
    BEGIN
        SET @NewMaND = 'NV001';
    END
    ELSE
    BEGIN
        -- Lấy mã lớn nhất và tăng thêm 1
        SELECT @NewMaND = 'NV' + RIGHT('000' + CAST(CAST(SUBSTRING(MAX(MaND), 3, 3) AS INT) + 1 AS NVARCHAR(3)), 3)
        FROM NguoiDung 
        WHERE MaND LIKE 'NV%';
    END

    -- Tạo mật khẩu tự động: CafeShop + MaND
    SET @DefaultPassword = 'CafeShop' + @NewMaND;

    -- Thêm người dùng vào bảng NguoiDung với MaQL cố định là 'QL001'
    INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam, MaQL)
    VALUES 
        (@NewMaND, @HoVaTen, @email, @SDT, @GioiTinh, @DefaultPassword, @NgayDiLam, @MaQL);
END;


CREATE PROCEDURE InsertWorkSchedule
    @MaND NVARCHAR(50),
    @Ngay DATE,
    @CaLam NVARCHAR(50)
AS
BEGIN
    DECLARE @NewMaLLV NVARCHAR(50);

    -- Tạo mã MaLLV mới
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
    -- Thêm bản ghi vào bảng LichLamViec
    INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam)
    VALUES (@NewMaLLV, @MaND, @Ngay, @CaLam);
END;

CREATE PROCEDURE DeleteWorkSchedule
    @MaLLV NVARCHAR(50)
AS
BEGIN
    DELETE FROM LichLamViec 
    WHERE MaLLV = @MaLLV;
END;

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

CREATE PROCEDURE DemNv
AS
BEGIN
    SELECT COUNT(*) 
    FROM NguoiDung 
    WHERE MaQL IS NOT NULL;
END;

 -- Thêm món
CREATE PROCEDURE ThemMon 
    @LoaiMon NVARCHAR(50),  -- Loại món (Ví dụ: Cà phê, Trà sữa, ...)
    @TenMon NVARCHAR(100),  -- Tên món
    @Gia DECIMAL(10,2),     -- Giá món
    @HinhAnh NVARCHAR(255), -- Hình ảnh của món
    @MaMon NVARCHAR(10) OUTPUT  -- Mã món được trả về
AS
BEGIN
    DECLARE @MaMonMoi NVARCHAR(10);
    DECLARE @SoThuTu INT;
    DECLARE @Prefix NVARCHAR(2);

    -- Lấy tiền tố dựa trên LoaiMon
    SET @Prefix = CASE 
                      WHEN @LoaiMon = 'Cà phê' THEN 'CF'
                      WHEN @LoaiMon = 'Trà sữa' THEN 'TS'
                      WHEN @LoaiMon = 'Nước ép' THEN 'NE'
                      WHEN @LoaiMon = 'Sinh tố' THEN 'ST'
                      WHEN @LoaiMon = 'Trà' THEN 'T'
                      WHEN @LoaiMon = 'Đá xay' THEN 'DX'
                      WHEN @LoaiMon = 'Bánh ngọt' THEN 'BN'
                      ELSE 'KH'
                  END;

    -- Lấy MaMon lớn nhất hiện có với hậu tố là số
    SELECT @MaMonMoi = MAX(MaMon) 
    FROM Menu
    WHERE MaMon LIKE @Prefix + '%'
    AND LEN(MaMon) >= 3
    AND ISNUMERIC(SUBSTRING(MaMon, 3, LEN(MaMon) - 2)) = 1;

    -- Xác định số thứ tự tiếp theo
    IF @MaMonMoi IS NULL
    BEGIN
        SET @SoThuTu = 1;
    END
    ELSE
    BEGIN
        SET @SoThuTu = CAST(SUBSTRING(@MaMonMoi, 3, LEN(@MaMonMoi) - 2) AS INT) + 1;
    END

    -- Tạo MaMon mới từ số thứ tự, đệm số 0 để đủ 4 chữ số
    SET @MaMonMoi = @Prefix + RIGHT('0000' + CAST(@SoThuTu AS NVARCHAR), 4);

    -- Thêm món mới vào bảng Menu
    BEGIN TRY
        INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
        VALUES (@MaMonMoi, @TenMon, @Gia, @LoaiMon, 'Còn bán', @HinhAnh);

        -- Trả về mã món mới
        SET @MaMon = @MaMonMoi;
    END TRY
    BEGIN CATCH
        THROW;  -- Ném lỗi để ứng dụng xử lý
    END CATCH
END;


-- Điều chỉnh TYPE để khớp với bảng
CREATE TYPE ChiTietDonHangType AS TABLE (	
    MaMon NVARCHAR(10),  -- Khớp với MaMon trong ChiTietDonHang
    TenMon NVARCHAR(100),
    SoLuong INT,
    Gia DECIMAL(10,2)
);

CREATE PROCEDURE sp_ThemDonHangVaChiTiet
    @NgayDat DATETIME,
    @MaND NVARCHAR(50),
    @ChiTietDonHang AS ChiTietDonHangType READONLY,
    @MaDH NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Tạo MaDH tự động (DH001, DH002, ...)
        DECLARE @NextMaDH INT;
        SELECT @NextMaDH = ISNULL(MAX(CAST(SUBSTRING(MaDH, 3, LEN(MaDH) - 2) AS INT)), 0) + 1
        FROM DonHang;
        SET @MaDH = 'DH' + RIGHT('000' + CAST(@NextMaDH AS NVARCHAR(3)), 3);

        -- Tính tổng tiền từ chi tiết đơn hàng
        DECLARE @TongTien DECIMAL(18,2);
        SELECT @TongTien = SUM(SoLuong * Gia)
        FROM @ChiTietDonHang;

        -- Thêm vào bảng DonHang
        INSERT INTO DonHang (MaDH, NgayDat, MaND, TongTien)
        VALUES (@MaDH, @NgayDat, @MaND, @TongTien);

        -- Thêm chi tiết đơn hàng với MaCTDH tự động tăng
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

CREATE  PROCEDURE sp_LayMaDonHangTiepTheo
    @MaDH NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LastMaDH NVARCHAR(50);
    DECLARE @Number INT;

    -- Truy vấn mã đơn hàng cuối cùng
    SELECT TOP 1 @LastMaDH = MaDH
    FROM DonHang
    ORDER BY MaDH DESC;

    -- Nếu không có đơn hàng nào, trả về "DH0001"
    IF @LastMaDH IS NULL
    BEGIN
        SET @MaDH = 'DH001';
    END
    ELSE
    BEGIN
        -- Tách số thứ tự từ mã cuối cùng (bỏ "DH")
        SET @Number = CAST(SUBSTRING(@LastMaDH, 3, LEN(@LastMaDH)) AS INT) + 1;

        -- Định dạng lại mã mới: "DH" + số thứ tự (4 chữ số)
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
        dh.MaND,
        nd.HoVaTen,
        dh.TongTien
    FROM DonHang dh
    INNER JOIN NguoiDung nd ON dh.MaND = nd.MaND
END

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

--KHO NGUYÊN LIỆU 
CREATE PROCEDURE GetAllKho
AS
BEGIN
    SELECT * FROM NguyenLieu;
END

CREATE PROCEDURE DeleteNguyenLieu
    @MaNL VARCHAR(50)
AS
BEGIN
    DELETE FROM NguyenLieu 
    WHERE MaNL = @MaNL;
END

DROP PROCEDURE DeleteNguyeLieu
CREATE PROCEDURE UpdateNguyenLieu
    @MaNL NVARCHAR(50),
    @TenNL NVARCHAR(100),
    @SoLuongTon INT,
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
END

CREATE PROCEDURE ThemNguyenLieu
    @TenNL NVARCHAR(100),
    @SoLuongTon INT,
    @DonViTinh NVARCHAR(50),
    @NgayNhap DATE,
    @TenNCC NVARCHAR(100),
    @SDT VARCHAR(15)
AS
BEGIN
    DECLARE @MaNL NVARCHAR(50);

    -- Lấy mã lớn nhất hiện tại trong bảng NguyenLieu
    SELECT @MaNL = MAX(MaNL)
    FROM NguyenLieu;

    IF @MaNL IS NULL
    BEGIN
        -- Nếu bảng chưa có dữ liệu thì bắt đầu từ NL01
        SET @MaNL = 'NL01';
    END
    ELSE
    BEGIN
        -- Tách phần số ra từ mã hiện tại và tăng lên 1
        DECLARE @SoThuTu INT;
        SET @SoThuTu = CAST(SUBSTRING(@MaNL, 3, LEN(@MaNL) - 2) AS INT) + 1;

        -- Tạo mã mới dạng NL01, NL02, ...
        SET @MaNL = 'NL' + RIGHT('00' + CAST(@SoThuTu AS NVARCHAR), 2);
    END

    -- Thêm nguyên liệu mới vào bảng NguyenLieu
    INSERT INTO NguyenLieu (MaNL, TenNL, SoLuongTon, DonViTinh, NgayNhap, TenNCC, SDT)
    VALUES (@MaNL, @TenNL, @SoLuongTon, @DonViTinh, @NgayNhap, @TenNCC, @SDT);
END

CREATE PROCEDURE GetNextMaNL
AS
BEGIN
    DECLARE @NextMaNL NVARCHAR(50);
    
    -- Lấy mã lớn nhất hiện tại
    SELECT @NextMaNL = MAX(MaNL)
    FROM NguyenLieu;

    -- Nếu bảng rỗng, bắt đầu từ 'NL01'
    IF @NextMaNL IS NULL
    BEGIN
        SET @NextMaNL = 'NL01';
    END
    ELSE
    BEGIN
        -- Tách số phía sau 'NL' và tăng lên 1
        DECLARE @NumberPart INT;
        SET @NumberPart = CAST(SUBSTRING(@NextMaNL, 3, LEN(@NextMaNL) - 2) AS INT) + 1;

        -- Ghép lại với tiền tố 'NL' và thêm các số 0 nếu cần
        SET @NextMaNL = 'NL' + RIGHT('00' + CAST(@NumberPart AS NVARCHAR), 2);
    END

    -- Trả về kết quả
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

CREATE PROCEDURE sp_ThemCongThuc
    @MaMon NVARCHAR(10),
    @MaNL NVARCHAR(10),
    @SoLuong INT,
    @DonViTinh NVARCHAR(50)
AS
BEGIN
    DECLARE @MaCT NVARCHAR(10)
    DECLARE @MaxMaCT NVARCHAR(10)
    DECLARE @Number INT

    -- Lấy mã MaCT lớn nhất hiện có
    SELECT @MaxMaCT = MAX(MaCT) FROM CongThuc

    -- Nếu chưa có mã nào, bắt đầu từ CT001
    IF @MaxMaCT IS NULL
        SET @MaCT = 'CT001'
    ELSE
    BEGIN
        -- Lấy phần số từ MaCT lớn nhất (bỏ "CT")
        SET @Number = CAST(SUBSTRING(@MaxMaCT, 3, LEN(@MaxMaCT) - 2) AS INT)
        -- Tăng số lên 1
        SET @Number = @Number + 1
        -- Định dạng lại thành CTxxx (ví dụ: CT002)
        SET @MaCT = 'CT' + RIGHT('000' + CAST(@Number AS NVARCHAR(3)), 3)
    END

    -- Chèn bản ghi mới với MaCT vừa tạo
    INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh)
    VALUES (@MaCT, @MaMon, @MaNL, @SoLuong, @DonViTinh)
END

CREATE PROCEDURE sp_DeleteCongThuc
    @MaCT NVARCHAR(50)
AS
BEGIN
    -- Xóa công thức theo mã công thức
    DELETE FROM CongThuc WHERE MaCT = @MaCT;
END;

CREATE PROCEDURE sp_CapNhatSoLuongTonKho
    @MaDH NVARCHAR(50) -- Mã đơn hàng cần xử lý
AS
BEGIN
    BEGIN TRY
        -- Bắt đầu giao dịch để đảm bảo tính toàn vẹn dữ liệu
        BEGIN TRANSACTION;

        -- Tạo bảng tạm để lưu tổng số lượng nguyên liệu cần trừ
        CREATE TABLE #TempNguyenLieu (
            MaNL NVARCHAR(50),
            SoLuongCanTru INT
        );

        -- Tính tổng số lượng nguyên liệu cần dùng dựa trên đơn hàng
        INSERT INTO #TempNguyenLieu (MaNL, SoLuongCanTru)
        SELECT 
            ct.MaNL,
            SUM(ct.SoLuong * ctdh.SoLuong) AS SoLuongCanTru
        FROM ChiTietDonHang ctdh
        INNER JOIN CongThuc ct ON ctdh.MaMon = ct.MaMon
        WHERE ctdh.MaDH = @MaDH
        GROUP BY ct.MaNL;

        -- Kiểm tra xem số lượng tồn kho có đủ để trừ không
        IF EXISTS (
            SELECT 1
            FROM #TempNguyenLieu tmp
            INNER JOIN NguyenLieu nl ON tmp.MaNL = nl.MaNL
            WHERE nl.SoLuongTon < tmp.SoLuongCanTru
        )
        BEGIN
            -- Nếu không đủ tồn kho, rollback và báo lỗi
            ROLLBACK TRANSACTION;
            RAISERROR ('Không đủ số lượng tồn kho để thanh toán đơn hàng!', 16, 1);
            RETURN;
        END

        -- Cập nhật số lượng tồn kho trong bảng NguyenLieu
        UPDATE nl
        SET nl.SoLuongTon = nl.SoLuongTon - tmp.SoLuongCanTru
        FROM NguyenLieu nl
        INNER JOIN #TempNguyenLieu tmp ON nl.MaNL = tmp.MaNL;

        -- Xóa bảng tạm
        DROP TABLE #TempNguyenLieu;

        -- Commit giao dịch nếu thành công
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback và báo lỗi
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 16, 1);
    END CATCH
END
-- Thêm món Cà phê sữa đá
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('CF0001', N'Cà phê sữa đá', 25000, N'Cà phê', 'cafesua.jpg');

-- Thêm món Trà sữa trân châu đường đen
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('TS0001', N'Trà sữa trân châu đường đen', 35000, N'Trà sữa', 'trasua.jpg');

-- Thêm món Nước ép cam
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('NE0001', N'Nước ép cam', 30000, N'Nước ép', 'nuocep.jpg');

-- Thêm món Sinh tố bơ
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('ST0001', N'Sinh tố bơ', 40000, N'Sinh tố', 'sinhto.jpg');

-- Thêm món Trà đào cam sả
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('T0001', N'Trà đào cam sả', 38000, N'Trà', 'tradao.jpg');

-- Thêm món Đá xay socola
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('DX0001', N'Đá xay socola', 45000, N'Đá xay', 'daxay.jpg');

-- Thêm món Bánh ngọt Tiramisu
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, HinhAnh)
VALUES ('BN0001', N'Bánh ngọt Tiramisu', 50000, N'Bánh ngọt', 'banhngot.jpg');

-- Thêm món với trạng thái Ngừng bán
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon, TrangThai, HinhAnh)
VALUES ('CF0002', N'Cà phê đen đá', 20000, N'Cà phê', N'Ngừng bán', 'cafeden.jpg');

-- Thêm món không có hình ảnh
INSERT INTO Menu (MaMon, TenMon, Gia, LoaiMon)
VALUES ('TS0002', N'Trà sữa matcha', 32000, N'Trà sữa');

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
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT014', 'T0001', 'NL11', 200, 'ml');   -- Nước cam
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT015', 'T0001', 'NL19', 50, 'gram');  -- Đào tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT016', 'T0001', 'NL20', 5, 'gram');   -- Sả

-- Đá xay socola (DX0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT017', 'DX0001', 'NL14', 50, 'gram'); -- Bột cacao
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT018', 'DX0001', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT019', 'DX0001', 'NL03', 100, 'gram');-- Đá

-- Bánh ngọt Tiramisu (BN0001)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT020', 'BN0001', 'NL13', 200, 'gram');-- Phô mai mascarpone
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT021', 'BN0001', 'NL14', 10, 'cái');  -- Bánh ladyfinger
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT022', 'BN0001', 'NL15', 3, 'quả');   -- Trứng
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT023', 'BN0001', 'NL16', 50, 'ml');   -- Rượu Marsala
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT024', 'BN0001', 'NL04', 20, 'gram'); -- Bột cacao

-- Trà sữa matcha (TS0002)
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT025', 'TS0002', 'NL17', 5, 'gram');  -- Bột matcha
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT026', 'TS0002', 'NL05', 150, 'ml');  -- Sữa tươi
INSERT INTO CongThuc (MaCT, MaMon, MaNL, SoLuong, DonViTinh) VALUES ('CT027', 'TS0002', 'NL07', 50, 'gram'); -- Trân châu
