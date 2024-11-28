using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class PhongBanController : KetNoiCSDL
    {
        // Lấy toàn bộ danh sách phòng ban
        public List<PhongBan> GetAll()
        {
            List<PhongBan> list = new List<PhongBan>();
            string query = "SELECT * FROM tblPhongBan";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PhongBan obj = new PhongBan(reader);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }

        // Thêm phòng ban
        public bool ThemPhongBan(string tenPhongBan)
        {
            string query = "INSERT INTO tblPhongBan (TenPhongBan) VALUES (@TenPhongBan)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa thông tin phòng ban
        public bool SuaPhongBan(string maPhongBan, string tenPhongBan)
        {
            string query = "UPDATE tblPhongBan SET TenPhongBan = @TenPhongBan WHERE MaPhongBan = @MaPhongBan";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                cmd.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
