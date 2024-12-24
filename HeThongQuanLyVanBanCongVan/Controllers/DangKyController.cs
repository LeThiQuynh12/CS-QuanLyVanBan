using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class DangKyController:KetNoiCSDL
    {

        // Phương thức mã hóa mật khẩu với Salt
        private string HashPasswordWithSalt(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Kết hợp Salt và mật khẩu
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] passwordWithSalt = new byte[salt.Length + passwordBytes.Length];

                Buffer.BlockCopy(salt, 0, passwordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(passwordBytes, 0, passwordWithSalt, salt.Length, passwordBytes.Length);

                // Tạo mã băm
                byte[] hash = sha256.ComputeHash(passwordWithSalt);
                return Convert.ToBase64String(hash);
            }
        }

        // Tạo Salt ngẫu nhiên
        private byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16]; // Độ dài của Salt
                rng.GetBytes(salt);
                return salt;
            }
        }

        // Thêm người dùng mới vào cơ sở dữ liệu với mật khẩu được mã hóa
        public void ThemNguoiDung(string coQuan, string hoVaTen, string soDienThoai, string email, string tenTaiKhoan, string matKhau, string vaiTro)
        {
            string sql = "INSERT INTO tblNguoiDung (CoQuan, HoVaTen, SoDienThoai, Email, TenTaiKhoan, MatKhau, VaiTro, Salt) VALUES (@CoQuan, @HoVaTen, @SoDienThoai, @Email, @TenTaiKhoan, @MatKhau, @VaiTro, @Salt)";

            try
            {
                // Tạo Salt ngẫu nhiên
                byte[] salt = GenerateSalt();

                // Mã hóa mật khẩu với Salt
                string hashedPassword = HashPasswordWithSalt(matKhau, salt);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CoQuan", coQuan);
                    cmd.Parameters.AddWithValue("@HoVaTen", hoVaTen);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", hashedPassword);
                    cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
                    cmd.Parameters.AddWithValue("@Salt", salt);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine(rowsAffected > 0 ? "Thêm thành công!" : "Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // Kiểm tra xem số điện thoại đã tồn tại hay chưa
        public bool IsPhoneNumberExist(string soDienThoai)
        {
            string sql = "SELECT COUNT(*) FROM tblNguoiDung WHERE SoDienThoai = @SoDienThoai";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        // Kiểm tra xem email đã tồn tại hay chưa
        public bool IsEmailExist(string email)
        {
            string sql = "SELECT COUNT(*) FROM tblNguoiDung WHERE Email = @Email";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

        // Kiểm tra xem tên tài khoản đã tồn tại hay chưa
        public bool IsUsernameExist(string tenTaiKhoan)
        {
            string sql = "SELECT COUNT(*) FROM tblNguoiDung WHERE TenTaiKhoan = @TenTaiKhoan";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTaiKhoan);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
    }
    }
