using DTO;

namespace GUI
{
    public static class Session
    {
        public static DTO_DangNhap CurrentUser { get; set; }

        public static void Login(DTO_DangNhap user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static string GetCurrentUserName()
        {
            return CurrentUser?.HoVaTen ?? "Chưa đăng nhập";
        }
        public static string GetCurrentUserID()
        {
            return CurrentUser?.MaND ?? "Chưa đăng nhập";
        }
    }
}