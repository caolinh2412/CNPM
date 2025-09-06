
📘 README - Hướng dẫn chạy phần mềm C# - CafeShop

---

🧰 Yêu cầu hệ thống

1. Visual Studio 2022 hoặc mới hơn  
   - Cài workload ".NET Desktop Development"
2. .NET 7 SDK (tự động có nếu dùng Visual Studio 2022 mới)
3. SQL Server (Express hoặc bản đầy đủ)
4. SQL Server Management Studio (SSMS)

---

🗃️ Kết nối cơ sở dữ liệu

Phần mềm sử dụng file `.mdf` và `.ldf` để gắn cơ sở dữ liệu. Bạn cần gắn database thủ công như sau:

✅ **Bước 1: Gắn database từ file .mdf**

1. Mở **SQL Server Management Studio (SSMS)**
2. Kết nối đến SQL Server
3. Chuột phải vào **Databases** > chọn **Attach...**
4. Nhấn **Add** và chọn file:
   ```
   Database\CafeShop.mdf
   ```
5. Kiểm tra file log `CafeShop_log.ldf` đã đúng vị trí chưa. Nếu thiếu, chọn **Add** thủ công.
6. Nhấn OK để hoàn tất gắn database.

📌 **Tên database sau khi attach:** `CafeShop`

## ⚠️ Khắc phục lỗi Mark of the Web (MOTW)

Khi tải project từ Internet (ví dụ: từ GitHub hoặc Google Drive), Windows có thể đánh dấu các tệp là không an toàn bằng Mark of the Web (MOTW), gây ra lỗi khi mở hoặc build project trong Visual Studio — đặc biệt là với các tệp `.resx`.

### 🛠 Cách khắc phục:

Mở **PowerShell** tại thư mục gốc của project và chạy lệnh sau để gỡ chặn toàn bộ các tệp `.resx`:

```powershell
Get-ChildItem -Recurse -Path . -Filter *.resx | Unblock-File
```

🔌 **Kết nối dữ liệu khi chạy chương trình**

Khi mở phần mềm và chạy, người dùng cần **nhập thông tin kết nối SQL Server**, với tên database là:

- **Database name:** `CafeShop`

Phần mềm sẽ dùng thông tin này để thiết lập kết nối đến SQL Server.

---

🔐 Tài khoản đăng nhập

| Email                     | Mật khẩu     | Vai trò        |
|---------------------------|--------------|----------------|
| minhquan5439@gmail.com    | 1234554321   | Quản lý        |
| vuthif@gmail.com          | pass1415     | Nhân viên      |

---

📌 Ghi chú

- Nếu không đăng nhập được, kiểm tra lại kết nối đến SQL Server và xem database đã attach thành công chưa.
- Nếu bạn dùng **SQL Server Authentication**, hãy chắc rằng server đã bật chế độ này và thông tin tài khoản đúng.
- Nếu gặp lỗi liên quan đến chuỗi kết nối, hãy kiểm tra kỹ lại phần mềm yêu cầu nhập `Server name` và `Database` đúng với máy của bạn.

---

✅ Phiên bản phần mềm

- .NET: 7.0
- Database: SQL Server (file `.mdf` + `.ldf`)
- CSDL: CafeShop

