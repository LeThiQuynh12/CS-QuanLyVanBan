using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class SoVanBanController : KetNoiCSDL
    {
        public SoVanBanController()
        {
            conn = GetConnection();  // Khởi tạo kết nối
        }

        public List<SoVanBanModel> HienThiSoVanBan(int year)
        {
            List<SoVanBanModel> dsvb = new List<SoVanBanModel>();
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    conn = GetConnection();  // Khởi tạo kết nối nếu chưa có
                }

                string sql = "SELECT * FROM SOVANBAN WHERE daxoa = 0 AND nam = @year";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@year", year);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SoVanBanModel so = new SoVanBanModel
                    {
                        MaSo = reader.GetInt32(reader.GetOrdinal("maSo")),
                        SoVanBan = reader.GetString(reader.GetOrdinal("soVanBan")),
                        SoDen = reader.GetBoolean(reader.GetOrdinal("soDen")),
                        Nam = reader.GetInt32(reader.GetOrdinal("nam")),
                        DaXoa = reader.GetBoolean(reader.GetOrdinal("daxoa"))
                    };
                    dsvb.Add(so);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return dsvb;
        }

        public int Luu(SoVanBanModel so)
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    conn = GetConnection(); // Tái tạo kết nối nếu cần
                }

                string sql = "UPDATE SOVANBAN SET SOVANBAN = @soVanBan, SODEN = @soDen, NAM = @nam WHERE MASO = @maSo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@soVanBan", so.SoVanBan);
                cmd.Parameters.AddWithValue("@soDen", so.SoDen);
                cmd.Parameters.AddWithValue("@nam", so.Nam);
                cmd.Parameters.AddWithValue("@maSo", so.MaSo);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Cập nhật thành công: " + so.SoVanBan);
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return -1;
        }

        public int Them(SoVanBanModel so)
        {



            string sql = "INSERT INTO SOVANBAN (soVanBan, soDen, nam, daXoa) VALUES (@soVanBan, @soDen, @nam, @daXoa)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@soVanBan", so.SoVanBan);
            cmd.Parameters.AddWithValue("@soDen", so.SoDen);
            cmd.Parameters.AddWithValue("@nam", so.Nam);
            cmd.Parameters.AddWithValue("@daXoa", false); // Mặc định daXoa là false

            int affectedRows = cmd.ExecuteNonQuery();

            if (affectedRows > 0)
            {
                string getIdSql = "SELECT SCOPE_IDENTITY()"; // Lấy giá trị auto increment
                SqlCommand idCmd = new SqlCommand(getIdSql, conn);
                so.MaSo = Convert.ToInt32(idCmd.ExecuteScalar());
                Console.WriteLine("Mã số được tạo tự động: " + so.MaSo);
                return affectedRows;
            }

            return -1;
        }


        public int XoaTaiLieu(SoVanBanModel so)
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                {
                    conn = GetConnection(); // Tái tạo kết nối nếu cần
                }

                string sql = "UPDATE SOVANBAN SET DaXoa = @daXoa WHERE MaSo = @maSo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@daXoa", true);
                cmd.Parameters.AddWithValue("@maSo", so.MaSo);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    return affectedRows;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return -1;
        }
    }
}
