using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class VanBanDiController : KetNoiCSDL
    {
        // Method to display the list of document numbers
        public List<string> HienThiSoVanBan()
        {
            List<string> tenso = new List<string>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "SELECT SOVANBAN, NAM FROM SOVANBAN WHERE DAXOA = 0 AND SOVANBAN = N'Số văn bản đi'";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string ten = reader["SOVANBAN"].ToString();
                    int nam = Convert.ToInt32(reader["NAM"]);
                    tenso.Add(ten + "-" + nam);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tenso;
        }
        public List<string> HienThiLoaiVanBan()
        {
            List<string> loaiVanBan = new List<string>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {

                string sql = "SELECT LOAIVANBAN FROM LOAIVANBAN WHERE DAXOA = 0";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string loai = reader["LOAIVANBAN"].ToString();
                    loaiVanBan.Add(loai);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }


            return loaiVanBan;
        }

        // Method to add a new 'VanBanDi' record
        public int Them(VanBanDiModel vanBanDi)
        {
            SqlCommand cmd = null;

            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "INSERT INTO VANBANDI (TENSO, NAM, SOKYHIEU, NGAYBANHANH, NOINHAN, LOAIVANBAN, SODI, SLBAN, SOTRANG, NGUOIGUI, NGUOIKY, NGUOIDUYET, TRICHYEU, NOIDUNG, DINHKEMFILE, DAXOA) "
                           + "VALUES (@TENSO, @NAM, @SOKYHIEU, @NGAYBANHANH, @NOINHAN, @LOAIVANBAN, @SODI, @SLBAN, @SOTRANG, @NGUOIGUI, @NGUOIKY, @NGUOIDUYET, @TRICHYEU, @NOIDUNG, @DINHKEMFILE, @DAXOA)";

                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TENSO", vanBanDi.TenSo);
                cmd.Parameters.AddWithValue("@NAM", vanBanDi.Nam);
                cmd.Parameters.AddWithValue("@SOKYHIEU", vanBanDi.SoKyHieu);
                cmd.Parameters.AddWithValue("@NGAYBANHANH", vanBanDi.NgayBanHanh);
                cmd.Parameters.AddWithValue("@NOINHAN", vanBanDi.NoiNhan);
                cmd.Parameters.AddWithValue("@LOAIVANBAN", vanBanDi.LoaiVanBan);
                cmd.Parameters.AddWithValue("@SODI", vanBanDi.SoDi);
                cmd.Parameters.AddWithValue("@SLBAN", vanBanDi.SlBan);
                cmd.Parameters.AddWithValue("@SOTRANG", vanBanDi.SoTrang);
                cmd.Parameters.AddWithValue("@NGUOIGUI", vanBanDi.NguoiGui);
                cmd.Parameters.AddWithValue("@NGUOIKY", vanBanDi.NguoiKy);
                cmd.Parameters.AddWithValue("@NGUOIDUYET", vanBanDi.NguoiDuyet);
                cmd.Parameters.AddWithValue("@TRICHYEU", vanBanDi.TrichYeu);
                cmd.Parameters.AddWithValue("@NOIDUNG", vanBanDi.NoiDung);
                cmd.Parameters.AddWithValue("@DINHKEMFILE", vanBanDi.DuongDanFile);
                cmd.Parameters.AddWithValue("@DAXOA", vanBanDi.DaXoa);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        // Method to update 'VanBanDi' record
        public int CapNhat(VanBanDiModel vb)
        {
            int result = 0;
            string sql = "UPDATE VANBANDI SET TENSO = @TENSO, NAM = @NAM, NGAYBANHANH = @NGAYBANHANH, SOKYHIEU = @SOKYHIEU, NOINHAN = @NOINHAN, LOAIVANBAN = @LOAIVANBAN, "
                        + "SODI = @SODI, SLBAN = @SLBAN, SOTRANG = @SOTRANG, NGUOIGUI = @NGUOIGUI, NGUOIKY = @NGUOIKY, NGUOIDUYET = @NGUOIDUYET, TRICHYEU = @TRICHYEU, "
                        + "NOIDUNG = @NOIDUNG, DINHKEMFILE = @DINHKEMFILE, DAXOA = @DAXOA WHERE ID = @ID";
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TENSO", vb.TenSo);
                cmd.Parameters.AddWithValue("@NAM", vb.Nam);
                cmd.Parameters.AddWithValue("@NGAYBANHANH", vb.NgayBanHanh);
                cmd.Parameters.AddWithValue("@SOKYHIEU", vb.SoKyHieu);
                cmd.Parameters.AddWithValue("@NOINHAN", vb.NoiNhan);
                cmd.Parameters.AddWithValue("@LOAIVANBAN", vb.LoaiVanBan);
                cmd.Parameters.AddWithValue("@SODI", vb.SoDi);
                cmd.Parameters.AddWithValue("@SLBAN", vb.SlBan);
                cmd.Parameters.AddWithValue("@SOTRANG", vb.SoTrang);
                cmd.Parameters.AddWithValue("@NGUOIGUI", vb.NguoiGui);
                cmd.Parameters.AddWithValue("@NGUOIKY", vb.NguoiKy);
                cmd.Parameters.AddWithValue("@NGUOIDUYET", vb.NguoiDuyet);
                cmd.Parameters.AddWithValue("@TRICHYEU", vb.TrichYeu);
                cmd.Parameters.AddWithValue("@NOIDUNG", vb.NoiDung);
                cmd.Parameters.AddWithValue("@DINHKEMFILE", vb.DuongDanFile);
                cmd.Parameters.AddWithValue("@DAXOA", vb.DaXoa);
                cmd.Parameters.AddWithValue("@ID", vb.Id);

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        // Method to search for 'VanBanDi' records by date range
        public List<VanBanDiModel> HienThiVanBanDiTheoNgay(DateTime ngaybanmin, DateTime ngaybanmax)
        {
            List<VanBanDiModel> dsDi = new List<VanBanDiModel>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                if (conn == null)
                {
                    conn = GetConnection();
                }

                string sql = "SELECT * FROM VANBANDI WHERE DAXOA = 0 AND NGAYBANHANH BETWEEN @NgayBanMin AND @NgayBanMax";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NgayBanMin", ngaybanmin);
                cmd.Parameters.AddWithValue("@NgayBanMax", ngaybanmax);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VanBanDiModel vbDi = new VanBanDiModel
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nam = Convert.ToInt32(reader["NAM"]),
                        TenSo = reader["TENSO"].ToString(),
                        SoKyHieu = reader["SOKYHIEU"].ToString(),
                        NgayBanHanh = Convert.ToDateTime(reader["NGAYBANHANH"]),
                        NoiNhan = reader["NOINHAN"].ToString(),
                        LoaiVanBan = reader["LOAIVANBAN"].ToString(),
                        SoDi = Convert.ToInt32(reader["SODI"]),
                        SlBan = Convert.ToInt32(reader["SLBAN"]),
                        SoTrang = Convert.ToInt32(reader["SOTRANG"]),
                        NguoiGui = reader["NGUOIGUI"].ToString(),
                        NguoiKy = reader["NGUOIKY"].ToString(),
                        NguoiDuyet = reader["NGUOIDUYET"].ToString(),
                        TrichYeu = reader["TRICHYEU"].ToString(),
                        NoiDung = reader["NOIDUNG"].ToString(),
                        DuongDanFile = reader["DINHKEMFILE"].ToString(),
                        DaXoa = Convert.ToBoolean(reader["DAXOA"])
                    };
                    dsDi.Add(vbDi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dsDi;
        }

        // Method to search VanBanDi with multiple parameters
        public List<VanBanDiModel> Search(string soVanBan, int nam, string loaiVanBan, string soKyHieu, string noiNhan,
                                   string noiDung, DateTime? startDate, DateTime? endDate)
        {
            List<VanBanDiModel> list = new List<VanBanDiModel>();
            string query = "SELECT * FROM VANBANDI WHERE DAXOA = 0";

            if (!string.IsNullOrEmpty(soVanBan))
                query += " AND SOVANBAN = @SoVanBan";
            if (nam != 0)
                query += " AND NAM = @Nam";
            if (!string.IsNullOrEmpty(loaiVanBan))
                query += " AND LOAIVANBAN = @LoaiVanBan";
            if (!string.IsNullOrEmpty(soKyHieu))
                query += " AND SOKYHIEU = @SoKyHieu";
            if (!string.IsNullOrEmpty(noiNhan))
                query += " AND NOINHAN = @NoiNhan";
            if (!string.IsNullOrEmpty(noiDung))
                query += " AND NOIDUNG = @NoiDung";
            if (startDate.HasValue && endDate.HasValue)
                query += " AND NGAYBANHANH BETWEEN @StartDate AND @EndDate";

            SqlCommand cmd = new SqlCommand(query, conn);
            if (!string.IsNullOrEmpty(soVanBan)) cmd.Parameters.AddWithValue("@SoVanBan", soVanBan);
            if (nam != 0) cmd.Parameters.AddWithValue("@Nam", nam);
            if (!string.IsNullOrEmpty(loaiVanBan)) cmd.Parameters.AddWithValue("@LoaiVanBan", loaiVanBan);
            if (!string.IsNullOrEmpty(soKyHieu)) cmd.Parameters.AddWithValue("@SoKyHieu", soKyHieu);
            if (!string.IsNullOrEmpty(noiNhan)) cmd.Parameters.AddWithValue("@NoiNhan", noiNhan);
            if (!string.IsNullOrEmpty(noiDung)) cmd.Parameters.AddWithValue("@NoiDung", noiDung);
            if (startDate.HasValue && endDate.HasValue)
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
            }

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VanBanDiModel vbDi = new VanBanDiModel
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Nam = Convert.ToInt32(reader["NAM"]),
                    TenSo = reader["TENSO"].ToString(),
                    SoKyHieu = reader["SOKYHIEU"].ToString(),
                    NgayBanHanh = Convert.ToDateTime(reader["NGAYBANHANH"]),
                    NoiNhan = reader["NOINHAN"].ToString(),
                    LoaiVanBan = reader["LOAIVANBAN"].ToString(),
                    SoDi = Convert.ToInt32(reader["SODI"]),
                    SlBan = Convert.ToInt32(reader["SLBAN"]),
                    SoTrang = Convert.ToInt32(reader["SOTRANG"]),
                    NguoiGui = reader["NGUOIGUI"].ToString(),
                    NguoiKy = reader["NGUOIKY"].ToString(),
                    NguoiDuyet = reader["NGUOIDUYET"].ToString(),
                    TrichYeu = reader["TRICHYEU"].ToString(),
                    NoiDung = reader["NOIDUNG"].ToString(),
                    DuongDanFile = reader["DINHKEMFILE"].ToString(),
                    DaXoa = Convert.ToBoolean(reader["DAXOA"])
                };
                list.Add(vbDi);
            }

            return list;
        }

        public List<VanBanDiModel> HienThiDanhSachVanBanDi(int nam)
        {
            List<VanBanDiModel> dsDi = new List<VanBanDiModel>();
            SqlCommand cmd = null;
            SqlDataReader rs = null;

            try
            {
                if (conn == null)
                {
                    conn = GetConnection(); // Đảm bảo kết nối không bị null
                }

                string sql = "SELECT * FROM VANBANDI WHERE DAXOA = 0 AND NAM=@Nam";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nam", nam);
                rs = cmd.ExecuteReader();

                while (rs.Read())
                {
                    VanBanDiModel vbDi = new VanBanDiModel();
                    vbDi.Id = rs.GetInt32(rs.GetOrdinal("ID"));
                    vbDi.Nam = rs.GetInt32(rs.GetOrdinal("NAM"));
                    vbDi.TenSo = rs.GetString(rs.GetOrdinal("TENSO"));
                    vbDi.SoKyHieu = rs.GetString(rs.GetOrdinal("SOKYHIEU"));
                    vbDi.NgayBanHanh = rs.GetDateTime(rs.GetOrdinal("NGAYBANHANH"));
                    vbDi.NoiNhan = rs.GetString(rs.GetOrdinal("NoiNhan"));
                    vbDi.LoaiVanBan = rs.GetString(rs.GetOrdinal("LOAIVANBAN"));
                    vbDi.SoDi = rs.GetInt32(rs.GetOrdinal("SODI"));
                    vbDi.SlBan = rs.GetInt32(rs.GetOrdinal("SLBAN"));
                    vbDi.SoTrang = rs.GetInt32(rs.GetOrdinal("SOTRANG"));
                    vbDi.NguoiGui = rs.GetString(rs.GetOrdinal("NGUOIGUI"));
                    vbDi.NguoiKy = rs.GetString(rs.GetOrdinal("NGUOIKY"));
                    vbDi.NguoiDuyet = rs.GetString(rs.GetOrdinal("NGUOIDUYET"));
                    vbDi.TrichYeu = rs.GetString(rs.GetOrdinal("TRICHYEU"));
                    vbDi.NoiDung = rs.GetString(rs.GetOrdinal("NOIDUNG"));
                    vbDi.DuongDanFile = rs.GetString(rs.GetOrdinal("DINHKEMFILE"));
                    vbDi.DaXoa = rs.GetBoolean(rs.GetOrdinal("DAXOA"));

                    dsDi.Add(vbDi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dsDi;
        }
        public int XoaVanBanDi(int idVanBanDi)
        {
            SqlCommand cmd = null;

            try
            {
                // Đảm bảo kết nối cơ sở dữ liệu
                if (conn == null)
                {
                    conn = GetConnection();
                }

                // In log thông tin ID của văn bản cần xóa (hữu ích cho kiểm tra lỗi)
                Console.WriteLine("Đang xóa văn bản ID: " + idVanBanDi);

                // Câu lệnh SQL cập nhật cột DAXOA thành 1 với điều kiện ID
                string sql = "UPDATE VANBANDI SET DAXOA = 1 WHERE ID = @Id";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", idVanBanDi);

                // Thực thi câu lệnh SQL và trả về số bản ghi bị ảnh hưởng
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Ghi log lỗi nếu xảy ra ngoại lệ
                Console.WriteLine(ex.Message);
            }

            return -1; // Trả về -1 nếu có lỗi xảy ra
        }

        // Method to display all 'VanBanDi' records
        public List<VanBanDiModel> HienThiTatCaVanBanDi()
        {
            List<VanBanDiModel> list = new List<VanBanDiModel>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VANBANDI WHERE DAXOA = 0", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VanBanDiModel vbDi = new VanBanDiModel
                {
                    Id = Convert.ToInt32(reader["ID"]),
                    Nam = Convert.ToInt32(reader["NAM"]),
                    TenSo = reader["TENSO"].ToString(),
                    SoKyHieu = reader["SOKYHIEU"].ToString(),
                    NgayBanHanh = Convert.ToDateTime(reader["NGAYBANHANH"]),
                    NoiNhan = reader["NOINHAN"].ToString(),
                    LoaiVanBan = reader["LOAIVANBAN"].ToString(),
                    SoDi = Convert.ToInt32(reader["SODI"]),
                    SlBan = Convert.ToInt32(reader["SLBAN"]),
                    SoTrang = Convert.ToInt32(reader["SOTRANG"]),
                    NguoiGui = reader["NGUOIGUI"].ToString(),
                    NguoiKy = reader["NGUOIKY"].ToString(),
                    NguoiDuyet = reader["NGUOIDUYET"].ToString(),
                    TrichYeu = reader["TRICHYEU"].ToString(),
                    NoiDung = reader["NOIDUNG"].ToString(),
                    DuongDanFile = reader["DINHKEMFILE"].ToString(),
                    DaXoa = Convert.ToBoolean(reader["DAXOA"])
                };
                list.Add(vbDi);
            }

            return list;
        }
    }
}
