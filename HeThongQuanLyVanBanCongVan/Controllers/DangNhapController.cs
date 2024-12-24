using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class DangNhapController : KetNoiCSDL
    {
        // Phương thức mã hóa mật khẩu với Salt
        private string HashPasswordWithSalt(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = new byte[salt.Length + Encoding.UTF8.GetBytes(password).Length];
                Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
                Buffer.BlockCopy(Encoding.UTF8.GetBytes(password), 0, saltedPassword, salt.Length, password.Length);

                var hash = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hash);
            }
        }

        // Kiểm tra thông tin đăng nhập (Tên tài khoản và mật khẩu)
        public bool KiemTraDangNhap(string tenTaiKhoan, string matKhau)
        {
            string sql = "SELECT MatKhau, Salt FROM tblNguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["MatKhau"].ToString();
                            byte[] salt = (byte[])reader["Salt"];
                            string hashedInputPassword = HashPasswordWithSalt(matKhau, salt);

                            return storedPassword == hashedInputPassword; // Đăng nhập thành công
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false; // Đăng nhập thất bại
        }

        // Đổi mật khẩu
        public bool DoiMatKhau(string tenTaiKhoan, string matKhauCu, string matKhauMoi)
        {
            string sql = "SELECT Salt FROM tblNguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] salt = (byte[])reader["Salt"];
                            string hashedNewPassword = HashPasswordWithSalt(matKhauMoi, salt);

                            string updateSql = "UPDATE tblNguoiDung SET MatKhau = @MatKhauMoi WHERE TenTaiKhoan = @TenTaiKhoan";
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@MatKhauMoi", hashedNewPassword);
                                updateCmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                                return updateCmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        // Kiểm tra tên tài khoản và email
        public bool IsTenTaiKhoanAndEmailValid(string tenTaiKhoan, string email)
        {
            string sql = "SELECT COUNT(*) FROM tblNguoiDung WHERE TenTaiKhoan = @TenTaiKhoan AND Email = @Email";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@Email", email);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        // Thay đổi mật khẩu
        public bool ChangePassword(string tenTaiKhoan, string matKhauMoi)
        {
            string sql = "SELECT Salt FROM tblNguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] salt = (byte[])reader["Salt"];
                            string hashedNewPassword = HashPasswordWithSalt(matKhauMoi, salt);

                            string updateSql = "UPDATE tblNguoiDung SET MatKhau = @MatKhauMoi WHERE TenTaiKhoan = @TenTaiKhoan";
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@MatKhauMoi", hashedNewPassword);
                                updateCmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                                return updateCmd.ExecuteNonQuery() > 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
