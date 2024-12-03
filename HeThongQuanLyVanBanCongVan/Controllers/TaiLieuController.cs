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
    public class TaiLieuController : KetNoiCSDL
    {
        public List<TaiLieu> GetAll()
        {
            List<TaiLieu> lst = new List<TaiLieu>();
            string query = "SELECT * FROM TAILIEU";

            // Tạo truy vấn
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TaiLieu tm = new TaiLieu(reader);
                lst.Add(tm);
            }
            reader.Close();
            return lst;
        }

        public bool ThemTaiLieu(string TenTaiLieu, DateTime NgayTao, string KichCo, string Loai, string DuongDan)
        {
            string query = "INSERT INTO TAILIEU (TenTL, NgayTao, KichCo, Loai, DuongDan) VALUES (@TenTaiLieu, @NgayTao, @KichCo, @Loai, @DuongDan)";
            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TenTaiLieu", TenTaiLieu);
            cmd.Parameters.AddWithValue("@NgayTao", NgayTao);
            cmd.Parameters.AddWithValue("@KichCo", KichCo);
            cmd.Parameters.AddWithValue("@Loai", Loai);
            cmd.Parameters.AddWithValue("@DuongDan", DuongDan);

            int d = cmd.ExecuteNonQuery();
            return d > 0;
        }

        public bool XoaFile(string MaTaiLieu)
        {
            // Kiểm tra xem MaTaiLieu có tồn tại trong bảng VanBanNoiBo hay không
            string checkQuery = "SELECT COUNT(*) FROM VanBanNoiBo WHERE MaTL = @MaTaiLieu";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@MaTaiLieu", MaTaiLieu);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                // Nếu MaTaiLieu tồn tại trong bảng VanBanNoiBo thì không cho xóa
                MessageBox.Show("Không thể xóa tài liệu vì nó đang được tham chiếu trong bảng VanBanNoiBo.");
                return false;
            }

            // Nếu không có ràng buộc khóa ngoại, tiếp tục xóa tài liệu
            string query = "DELETE FROM TAILIEU WHERE MaTL = @MaTaiLieu";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MaTaiLieu", MaTaiLieu);
            int d = cmd.ExecuteNonQuery();

            return d > 0;
        }
    }
}
