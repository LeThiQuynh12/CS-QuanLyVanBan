using System;
using System.Data.SqlClient;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class KetNoiCSDL
    {
        // Đảm bảo kết nối là readonly và sử dụng chuỗi kết nối đúng
        protected  SqlConnection conn;

        // Constructor
        public KetNoiCSDL()
        {
            try
            {
                // Chuỗi kết nối mới
                string connectionString = @"Data Source=localhost,1433;Initial Catalog=QUANLYCONGVAN;User ID=sa;Password=11101978;Encrypt=False;";

                // Khởi tạo kết nối
                conn = new SqlConnection(connectionString);

                // Mở kết nối
                conn.Open();
                Console.WriteLine("Kết nối thành công");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi kết nối
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
                Console.WriteLine(ex.StackTrace); // In chi tiết lỗi để dễ dàng xác định
            }
        }

        // Phương thức trả về kết nối
        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
