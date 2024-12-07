using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public bool XoaPhongBan(string maPhongBan)
        {
            // Kiểm tra xem có bản ghi nào trong bảng VanBanNoiBo tham chiếu đến phòng ban này không
            string queryCheck = "SELECT COUNT(*) FROM VanBanNoiBo WHERE MaBanNhan = @MaPhongBan OR MaBanHanh = @MaPhongBan";

            try
            {
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@MaPhongBan", maPhongBan);

                    // Thực thi câu lệnh kiểm tra
                    int count = (int)cmdCheck.ExecuteScalar();

                    if (count > 0)
                    {
                        // Có bản ghi liên quan, thông báo và không thực hiện xóa
                        MessageBox.Show("Không thể xóa phòng ban vì có dữ liệu liên quan trong VanBanNoiBo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; // Không thực hiện xóa
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Thực hiện xóa phòng ban nếu không có dữ liệu liên quan
            string queryDelete = "DELETE FROM tblPhongBan WHERE MaPhongBan = @MaPhongBan";

            try
            {
                using (SqlCommand cmdDelete = new SqlCommand(queryDelete, conn))
                {
                    cmdDelete.Parameters.AddWithValue("@MaPhongBan", maPhongBan);

                    // Thực thi câu lệnh xóa
                    int rowsAffected = cmdDelete.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu xóa thành công
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng ban: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
