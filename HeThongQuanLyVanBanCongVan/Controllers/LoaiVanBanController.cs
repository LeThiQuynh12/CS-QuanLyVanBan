using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class LoaiVanBanController : KetNoiCSDL
    {
        public LoaiVanBanController()
        {
            conn = GetConnection();  // Gọi phương thức GetConnection để khởi tạo conn
        }

        public List<LoaiVanBanModel> HienThiLoaiVanBan()
        {
            List<LoaiVanBanModel> dsl = new List<LoaiVanBanModel>();
            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "SELECT * FROM LOAIVANBAN WHERE DAXOA = 0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoaiVanBanModel loaiVanBan = new LoaiVanBanModel
                    {
                        MaLoai = reader.GetString(reader.GetOrdinal("maLoai")),
                        LoaiVanBan = reader.GetString(reader.GetOrdinal("loaiVanBan")),
                        MoTa = reader.GetString(reader.GetOrdinal("moTa"))
                    };
                    dsl.Add(loaiVanBan);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return dsl;
        }

        public int Xoa(string maLoai)
        {
            try
            {
                if (conn == null)
                {
                    conn = GetConnection(); // Khởi tạo kết nối nếu chưa có
                }

                string sql = "UPDATE LOAIVANBAN SET DAXOA = 1 WHERE MALOAI = @maLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maLoai", maLoai);

                return cmd.ExecuteNonQuery(); // Trả về số hàng bị cập nhật
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return -1;
        }

        public int Them(LoaiVanBanModel loai)
        {
            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "INSERT INTO LOAIVANBAN (MALOAI, LOAIVANBAN, MOTA) VALUES (@maLoai, @loaiVanBan, @moTa)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maLoai", loai.MaLoai);
                cmd.Parameters.AddWithValue("@loaiVanBan", loai.LoaiVanBan);
                cmd.Parameters.AddWithValue("@moTa", loai.MoTa);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return -1;
        }

        public bool KiemTraTonTai(string maLoai)
        {
            string query = "SELECT COUNT(*) FROM LOAIVANBAN WHERE MALOAI = @maLoai";
            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maLoai", maLoai);
                int count = (int)cmd.ExecuteScalar(); // Trả về số lượng kết quả
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return false;
        }

        public int Update(LoaiVanBanModel loaiModel)
        {
            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "UPDATE LOAIVANBAN SET LOAIVANBAN = @loaiVanBan, MOTA = @moTa, DAXOA = @daXoa WHERE MALOAI = @maLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@loaiVanBan", loaiModel.LoaiVanBan);
                cmd.Parameters.AddWithValue("@moTa", loaiModel.MoTa);
                cmd.Parameters.AddWithValue("@daXoa", loaiModel.DaXoa);
                cmd.Parameters.AddWithValue("@maLoai", loaiModel.MaLoai);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return -1;
        }
    }
}
