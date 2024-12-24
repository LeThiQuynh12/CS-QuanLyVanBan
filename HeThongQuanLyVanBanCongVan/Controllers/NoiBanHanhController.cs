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
    public class NoiBanHanhController : KetNoiCSDL
    {
        public NoiBanHanhController()
        {
            conn = GetConnection();  // Gọi phương thức GetConnection để khởi tạo conn
        }

        public List<NoiBanHanhModel> HienThiNoiBanHanh()
        {
            List<NoiBanHanhModel> dsnoi = new List<NoiBanHanhModel>();
            try
            {
                string sql = "SELECT * FROM NOIBANHANH WHERE DAXOA = 0";
                SqlCommand cmd = new SqlCommand(sql, conn);  // Sử dụng conn từ lớp cha
                SqlDataReader reader = cmd.ExecuteReader();  // Thực thi câu truy vấn

                while (reader.Read())
                {
                    NoiBanHanhModel model = new NoiBanHanhModel
                    {
                        MaNoiBanHanh = reader.GetInt32(reader.GetOrdinal("maNoiBanHanh")),
                        NoiBanHanh = reader.GetString(reader.GetOrdinal("noiBanHanh")),
                        MoTa = reader.GetString(reader.GetOrdinal("moTa")),
                        DaXoa = false
                    };
                    dsnoi.Add(model);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return dsnoi;
        }

        public int ThemNoiBanHanh(NoiBanHanhModel model)
        {
            try
            {
                string sql = "INSERT INTO NOIBANHANH (noiBanHanh, moTa, daXoa) VALUES (@noiBanHanh, @moTa, @daXoa)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noiBanHanh", model.NoiBanHanh);
                cmd.Parameters.AddWithValue("@moTa", model.MoTa);
                cmd.Parameters.AddWithValue("@daXoa", model.DaXoa);

                return cmd.ExecuteNonQuery(); // Trả về số hàng được thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nơi ban hành: " + ex.Message);
            }
            return -1; // Trả về -1 nếu thêm thất bại
        }

        public int CapNhatNoiBanHanh(NoiBanHanhModel model)
        {
            try
            {
                string sql = "UPDATE NOIBANHANH SET noiBanHanh = @noiBanHanh, moTa = @moTa WHERE maNoiBanHanh = @maNoiBanHanh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@noiBanHanh", model.NoiBanHanh);
                cmd.Parameters.AddWithValue("@moTa", model.MoTa);
                cmd.Parameters.AddWithValue("@maNoiBanHanh", model.MaNoiBanHanh);

                return cmd.ExecuteNonQuery(); // Trả về số hàng được cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nơi ban hành: " + ex.Message);
            }
            return -1; // Trả về -1 nếu cập nhật thất bại
        }

        public int XoaNoiBanHanh(NoiBanHanhModel noibanhanh)
        {
            try
            {
                string sql = "UPDATE NOIBANHANH SET daXoa = 1 WHERE maNoiBanHanh = @maNoiBanHanh";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maNoiBanHanh", noibanhanh.MaNoiBanHanh);

                return cmd.ExecuteNonQuery(); // Trả về số hàng được cập nhật
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nơi ban hành: " + ex.Message);
            }
            return -1; // Trả về -1 nếu cập nhật thất bại
        }
    }
}
