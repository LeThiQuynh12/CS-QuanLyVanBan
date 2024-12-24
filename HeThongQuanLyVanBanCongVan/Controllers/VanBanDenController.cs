using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class VanBanDenController : KetNoiCSDL
    {
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

                string sql = "SELECT SOVANBAN, NAM FROM SOVANBAN WHERE DAXOA = 0 AND SOVANBAN = N'Số văn bản đến'";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string ten = reader.GetString(reader.GetOrdinal("SOVANBAN"));
                    int nam = reader.GetInt32(reader.GetOrdinal("NAM"));
                    tenso.Add(ten + "-" + nam); // Thêm vào danh sách
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // In lỗi ra console
            }
            return tenso;
        }
        public List<VanBanDenModel> HienThiTimKiemVanBanDen()
        {
            List<VanBanDenModel> dsden = new List<VanBanDenModel>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {

                conn.Open();

                // Câu lệnh SQL
                string sql = "SELECT * FROM VANBANDEN WHERE DAXOA = 0";
                cmd = new SqlCommand(sql, conn);

                // Thực thi truy vấn
                reader = cmd.ExecuteReader();

                // Duyệt kết quả trả về
                while (reader.Read())
                {
                    VanBanDenModel vbden = new VanBanDenModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nam = reader.GetInt32(reader.GetOrdinal("Nam")),
                        TenSo = reader.GetString(reader.GetOrdinal("TENSO")),
                        SoKyHieu = reader.GetString(reader.GetOrdinal("SOKYHIEU")),
                        NgayBanHanh = reader.GetDateTime(reader.GetOrdinal("NGAYBANHANH")),
                        NoiBanHanh = reader.GetString(reader.GetOrdinal("NOIBANHANH")),
                        LoaiVanBan = reader.GetString(reader.GetOrdinal("LOAIVANBAN")),
                        SoDen = reader.GetInt32(reader.GetOrdinal("SODEN")),
                        NgayDen = reader.GetDateTime(reader.GetOrdinal("NGAYDEN")),
                        SoTrang = reader.GetInt32(reader.GetOrdinal("SOTRANG")),
                        NguoiNhan = reader.GetString(reader.GetOrdinal("NGUOINHAN")),
                        NguoiKy = reader.GetString(reader.GetOrdinal("NGUOIKY")),
                        NguoiDuyet = reader.GetString(reader.GetOrdinal("NGUOIDUYET")),
                        TrichYeu = reader.GetString(reader.GetOrdinal("TRICHYEU")),
                        NoiDung = reader.GetString(reader.GetOrdinal("NOIDUNG")),
                        DuongDanFile = reader.GetString(reader.GetOrdinal("DINHKEMFILE")),
                        DaXoa = reader.GetBoolean(reader.GetOrdinal("DAXOA"))
                    };

                    dsden.Add(vbden);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
           

            return dsden;
        
        
    }

        // Hiển thị danh sách Loại văn bản
        public List<string> HienThiLoaiVanBan()
        {
            List<string> loaivb = new List<string>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string sql = "SELECT LOAIVANBAN FROM LOAIVANBAN WHERE DAXOA=0";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string loai = reader.GetString(reader.GetOrdinal("LOAIVANBAN"));
                    loaivb.Add(loai);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return loaivb;
        }

        public List<string> HienThiNoiBanHanh()
        {
            List<string> dsnoi = new List<string>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string sql = "SELECT NOIBANHANH FROM NOIBANHANH WHERE DAXOA=0";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string noi = reader.GetString(reader.GetOrdinal("NOIBANHANH"));
                    dsnoi.Add(noi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dsnoi;
        }

        // Hiển thị danh sách văn bản đến theo năm
        public List<VanBanDenModel> HienThiDanhSachVanBanDen(int nam)
        {
            List<VanBanDenModel> dsden = new List<VanBanDenModel>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string sql = "SELECT * FROM VANBANDEN WHERE DAXOA = 0 and nam=@nam";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nam", nam);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VanBanDenModel vbden = new VanBanDenModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nam = reader.GetInt32(reader.GetOrdinal("Nam")),
                        TenSo = reader.GetString(reader.GetOrdinal("TENSO")),
                        SoKyHieu = reader.GetString(reader.GetOrdinal("SOKYHIEU")),
                        NgayBanHanh = reader.GetDateTime(reader.GetOrdinal("NGAYBANHANH")),
                        NoiBanHanh = reader.GetString(reader.GetOrdinal("NOIBANHANH")),
                        LoaiVanBan = reader.GetString(reader.GetOrdinal("LOAIVANBAN")),
                        SoDen = reader.GetInt32(reader.GetOrdinal("SODEN")),
                        NgayDen = reader.GetDateTime(reader.GetOrdinal("NGAYDEN")),
                        SoTrang = reader.GetInt32(reader.GetOrdinal("SOTRANG")),
                        NguoiNhan = reader.GetString(reader.GetOrdinal("NGUOINHAN")),
                        NguoiKy = reader.GetString(reader.GetOrdinal("NGUOIKY")),
                        NguoiDuyet = reader.GetString(reader.GetOrdinal("NGUOIDUYET")),
                        TrichYeu = reader.GetString(reader.GetOrdinal("TRICHYEU")),
                        NoiDung = reader.GetString(reader.GetOrdinal("NOIDUNG")),
                        DuongDanFile = reader.GetString(reader.GetOrdinal("dinhKemfile")),
                        DaXoa = reader.GetBoolean(reader.GetOrdinal("DAXOA"))
                    };
                    dsden.Add(vbden);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dsden;
        }
        public List<VanBanDenModel> HienThiTatCaVanBanDen()
        {
            List<VanBanDenModel> dsden = new List<VanBanDenModel>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                string sql = "SELECT * FROM VANBANDEN WHERE DAXOA = 0";
                cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VanBanDenModel vbden = new VanBanDenModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nam = reader.GetInt32(reader.GetOrdinal("Nam")),
                        TenSo = reader.GetString(reader.GetOrdinal("TENSO")),
                        SoKyHieu = reader.GetString(reader.GetOrdinal("SOKYHIEU")),
                        NgayBanHanh = reader.GetDateTime(reader.GetOrdinal("NGAYBANHANH")),
                        NoiBanHanh = reader.GetString(reader.GetOrdinal("NOIBANHANH")),
                        LoaiVanBan = reader.GetString(reader.GetOrdinal("LOAIVANBAN")),
                        SoDen = reader.GetInt32(reader.GetOrdinal("SODEN")),
                        NgayDen = reader.GetDateTime(reader.GetOrdinal("NGAYDEN")),
                        SoTrang = reader.GetInt32(reader.GetOrdinal("SOTRANG")),
                        NguoiNhan = reader.GetString(reader.GetOrdinal("NGUOINHAN")),
                        NguoiKy = reader.GetString(reader.GetOrdinal("NGUOIKY")),
                        NguoiDuyet = reader.GetString(reader.GetOrdinal("NGUOIDUYET")),
                        TrichYeu = reader.GetString(reader.GetOrdinal("TRICHYEU")),
                        NoiDung = reader.GetString(reader.GetOrdinal("NOIDUNG")),
                        DuongDanFile = reader.GetString(reader.GetOrdinal("dinhKemfile")),
                        DaXoa = reader.GetBoolean(reader.GetOrdinal("DAXOA"))
                    };
                    dsden.Add(vbden);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dsden;
        }
        public int CapNhat(VanBanDenModel vanBan)
        {
            int rowsAffected = -1; // Mặc định nếu xảy ra lỗi sẽ trả về -1

            try
            {


                // Câu lệnh SQL để cập nhật văn bản đến
                string sql = @"
                UPDATE VANBANDEN SET 
                    TENSO = @TenSo, 
                    Nam = @Nam, 
                    SOKYHIEU = @SoKyHieu, 
                    NGAYBANHANH = @NgayBanHanh, 
                    NOIBANHANH = @NoiBanHanh, 
                    LOAIVANBAN = @LoaiVanBan, 
                    SODEN = @SoDen, 
                    NGAYDEN = @NgayDen, 
                    SOTRANG = @SoTrang, 
                    NGUOINHAN = @NguoiNhan, 
                    NGUOIKY = @NguoiKy, 
                    NGUOIDUYET = @NguoiDuyet, 
                    TRICHYEU = @TrichYeu, 
                    NOIDUNG = @NoiDung, 
                    DINHKEMFILE = @DuongDanFile, 
                    DAXOA = @DaXoa 
                WHERE ID = @Id";

                // Chuẩn bị câu lệnh và gán tham số
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSo", vanBan.TenSo);
                    cmd.Parameters.AddWithValue("@Nam", vanBan.Nam);
                    cmd.Parameters.AddWithValue("@SoKyHieu", vanBan.SoKyHieu);
                    cmd.Parameters.AddWithValue("@NgayBanHanh", vanBan.NgayBanHanh);
                    cmd.Parameters.AddWithValue("@NoiBanHanh", vanBan.NoiBanHanh);
                    cmd.Parameters.AddWithValue("@LoaiVanBan", vanBan.LoaiVanBan);
                    cmd.Parameters.AddWithValue("@SoDen", vanBan.SoDen);
                    cmd.Parameters.AddWithValue("@NgayDen", vanBan.NgayDen);
                    cmd.Parameters.AddWithValue("@SoTrang", vanBan.SoTrang);
                    cmd.Parameters.AddWithValue("@NguoiNhan", vanBan.NguoiNhan);
                    cmd.Parameters.AddWithValue("@NguoiKy", vanBan.NguoiKy);
                    cmd.Parameters.AddWithValue("@NguoiDuyet", vanBan.NguoiDuyet);
                    cmd.Parameters.AddWithValue("@TrichYeu", vanBan.TrichYeu);
                    cmd.Parameters.AddWithValue("@NoiDung", vanBan.NoiDung);
                    cmd.Parameters.AddWithValue("@DuongDanFile", vanBan.DuongDanFile);
                    cmd.Parameters.AddWithValue("@DaXoa", vanBan.DaXoa);
                    cmd.Parameters.AddWithValue("@Id", vanBan.Id);

                    // Thực thi câu lệnh SQL
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return rowsAffected;
        }
        // Controller: Xóa Văn Bản Đến
        public int XoaVanBanDen(int id)
        {
            try
            {
                // Kiểm tra kết nối
                using (SqlConnection conn = GetConnection()) // Sử dụng using để đảm bảo kết nối được đóng đúng cách
                {
                    // Câu lệnh SQL cập nhật cột DaXoa thành 1 theo id
                    string sql = "UPDATE VANBANDEN SET DAXOA = 1 WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Dùng using để tự động giải phóng tài nguyên
                    {
                        cmd.Parameters.AddWithValue("@id", id); // Thêm tham số @id vào câu lệnh SQL

                        // Mở kết nối nếu chưa mở
                        if (conn.State != System.Data.ConnectionState.Open)
                        {
                            conn.Open();
                        }

                        // Thực thi câu lệnh SQL và trả về số bản ghi bị ảnh hưởng
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message); // In lỗi ra console
                return -1;
            }
        }

        public bool KiemTraId(int id)
        {
            try
            {
                    conn.Open();

                    // Câu lệnh SQL kiểm tra ID đã tồn tại hay chưa
                    string sql = "SELECT COUNT(*) FROM VANBANDEN WHERE ID = @Id AND DAXOA = 0";

                    // Chuẩn bị câu lệnh và gán tham số
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        // Kiểm tra nếu có kết quả trả về lớn hơn 0, nghĩa là ID đã tồn tại
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return false; // ID không tồn tại
        }
        public List<VanBanDenModel> HienThiVanBanDenTheoNgay(DateTime ngaydenmin, DateTime ngaydenmax)
        {
            List<VanBanDenModel> dsden = new List<VanBanDenModel>();
            SqlCommand cmd = null;
            SqlDataReader rs = null;

            try
            {
              
                string sql = "SELECT * FROM VANBANDEN WHERE DAXOA = 0 AND NGAYDEN BETWEEN @NgayDenMin AND @NgayDenMax";

                // Tạo câu lệnh SQL
                cmd = new SqlCommand(sql, conn);

                // Thêm tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@NgayDenMin", ngaydenmin);
                cmd.Parameters.AddWithValue("@NgayDenMax", ngaydenmax);


                // Thực thi câu lệnh SQL
                rs = cmd.ExecuteReader();

                // Duyệt qua kết quả trả về
                while (rs.Read())
                {
                    VanBanDenModel vbden = new VanBanDenModel
                    {
                        Id = rs.GetInt32(rs.GetOrdinal("ID")),
                        Nam = rs.GetInt32(rs.GetOrdinal("Nam")),
                        TenSo = rs.GetString(rs.GetOrdinal("TENSO")),
                        SoKyHieu = rs.GetString(rs.GetOrdinal("SOKYHIEU")),
                        NgayBanHanh = rs.GetDateTime(rs.GetOrdinal("NGAYBANHANH")),
                        NoiBanHanh = rs.GetString(rs.GetOrdinal("NOIBANHANH")),
                        LoaiVanBan = rs.GetString(rs.GetOrdinal("LOAIVANBAN")),
                        SoDen = rs.GetInt32(rs.GetOrdinal("SODEN")),
                        NgayDen = rs.GetDateTime(rs.GetOrdinal("NGAYDEN")),
                        SoTrang = rs.GetInt32(rs.GetOrdinal("SOTRANG")),
                        NguoiNhan = rs.GetString(rs.GetOrdinal("NGUOINHAN")),
                        NguoiKy = rs.GetString(rs.GetOrdinal("NGUOIKY")),
                        NguoiDuyet = rs.GetString(rs.GetOrdinal("NGUOIDUYET")),
                        TrichYeu = rs.GetString(rs.GetOrdinal("TRICHYEU")),
                        NoiDung = rs.GetString(rs.GetOrdinal("NOIDUNG")),
                        DuongDanFile = rs.GetString(rs.GetOrdinal("DINHKEMFILE")),
                        DaXoa = rs.GetBoolean(rs.GetOrdinal("DAXOA"))
                    };

                    dsden.Add(vbden);
                }
            }
            catch (Exception ex)
            {
                // In lỗi nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return dsden;


        }
        public int Them(VanBanDenModel vanBan)
        {
                
                SqlCommand cmd = null;

                try
                {
                
                // Câu lệnh SQL để thêm văn bản
                string sql = "INSERT INTO VANBANDEN (TENSO, Nam, SOKYHIEU, NGAYBANHANH, NOIBANHANH, LOAIVANBAN, SODEN, NGAYDEN, SOTRANG, NGUOINHAN, NGUOIKY, NGUOIDUYET, TRICHYEU, NOIDUNG, dinhKemfile, DaXoa) " +
                                 "VALUES (@TenSo, @Nam, @SoKyHieu, @NgayBanHanh, @NoiBanHanh, @LoaiVanBan, @SoDen, @NgayDen, @SoTrang, @NguoiNhan, @NguoiKy, @NguoiDuyet, @TrichYeu, @NoiDung, @DinhKemFile, @DaXoa)";

                    // Chuẩn bị câu lệnh SQL
                    cmd = new SqlCommand(sql, conn);

                    // Thêm tham số vào câu lệnh SQL
                    cmd.Parameters.AddWithValue("@TenSo", vanBan.TenSo);
                    cmd.Parameters.AddWithValue("@Nam", vanBan.Nam);
                    cmd.Parameters.AddWithValue("@SoKyHieu", vanBan.SoKyHieu);
                    cmd.Parameters.AddWithValue("@NgayBanHanh", vanBan.NgayBanHanh);
                    cmd.Parameters.AddWithValue("@NoiBanHanh", vanBan.NoiBanHanh);
                    cmd.Parameters.AddWithValue("@LoaiVanBan", vanBan.LoaiVanBan);
                    cmd.Parameters.AddWithValue("@SoDen", vanBan.SoDen);
                    cmd.Parameters.AddWithValue("@NgayDen", vanBan.NgayDen);
                    cmd.Parameters.AddWithValue("@SoTrang", vanBan.SoTrang);
                    cmd.Parameters.AddWithValue("@NguoiNhan", vanBan.NguoiNhan);
                    cmd.Parameters.AddWithValue("@NguoiKy", vanBan.NguoiKy);
                    cmd.Parameters.AddWithValue("@NguoiDuyet", vanBan.NguoiDuyet);
                    cmd.Parameters.AddWithValue("@TrichYeu", vanBan.TrichYeu);
                    cmd.Parameters.AddWithValue("@NoiDung", vanBan.NoiDung);
                    cmd.Parameters.AddWithValue("@DinhKemFile", vanBan.DuongDanFile);
                    cmd.Parameters.AddWithValue("@DaXoa", vanBan.DaXoa);

                    // Thực thi câu lệnh SQL và trả về số bản ghi bị ảnh hưởng
                    return cmd.ExecuteNonQuery();  // Trả về số bản ghi bị ảnh hưởng
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Lỗi SQL: " + ex.Message);
                    return -1;  // Trả về -1 nếu có lỗi
                }
                
            
            }
        public int XoaVanBanDen(VanBanDenModel vbden)
        {
            try
            {
                // Chuỗi kết nối đến cơ sở dữ liệu (thay đổi theo cấu hình của bạn)
                using (SqlConnection conn = new SqlConnection("your_connection_string"))
                {
                    // Mở kết nối
                    conn.Open();

                    // Câu lệnh SQL cập nhật cột DaXoa thành 1 theo ID
                    string sql = "UPDATE VANBANDEN SET DAXOA = 1 WHERE ID = @Id";

                    // Chuẩn bị câu lệnh và gán tham số
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", vbden.Id);

                        // Thực thi câu lệnh SQL và trả về số bản ghi bị ảnh hưởng
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // In lỗi ra console nếu có
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            return -1; // Trả về -1 nếu có lỗi
        }

        // Chuyển đổi java.util.Date sang java.sql.Date
        public static System.Data.SqlTypes.SqlDateTime DateConversion(DateTime utilDate)
        {
            if (utilDate == null)
            {
                throw new ArgumentException("Ngày không được để trống!");
            }

            Console.WriteLine("DateTime: " + utilDate);

            return new System.Data.SqlTypes.SqlDateTime(utilDate);
        }

        public List<VanBanDenModel> SearchVanBanDen(string soVanBan, int nam, string loaiVanBan, string soKyHieu, string noiBanHanh, string noiDung, DateTime? startDate, DateTime? endDate)
        {
            List<VanBanDenModel> list = new List<VanBanDenModel>();
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                // Tạo truy vấn SQL cơ bản
                string query = "SELECT * FROM VanBanDen WHERE DAXOA = 0";

                // Thêm các điều kiện tìm kiếm nếu có
                if (!string.IsNullOrEmpty(soVanBan) && soVanBan != "Tất cả")
                {
                    query += " AND TenSo LIKE @soVanBan";
                }

                if (!string.IsNullOrEmpty(loaiVanBan) && loaiVanBan != "Tất cả")
                {
                    query += " AND LoaiVanBan LIKE @loaiVanBan";
                }

                if (!string.IsNullOrEmpty(soKyHieu))
                {
                    query += " AND SoKyHieu LIKE @soKyHieu";
                }

                if (!string.IsNullOrEmpty(noiBanHanh))
                {
                    query += " AND NoiBanHanh LIKE @noiBanHanh";
                }

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND NgayDen BETWEEN @startDate AND @endDate";
                }

                if (!string.IsNullOrEmpty(noiDung))
                {
                    query += " AND NoiDung LIKE @noiDung";
                }

                if (nam > 0)
                {
                    query += " AND Nam = @nam";
                }

                cmd = new SqlCommand(query, conn);

                // Gán các tham số cho câu truy vấn
                if (!string.IsNullOrEmpty(soVanBan) && soVanBan != "Tất cả")
                {
                    cmd.Parameters.AddWithValue("@soVanBan", "%" + soVanBan + "%");
                }

                if (!string.IsNullOrEmpty(loaiVanBan) && loaiVanBan != "Tất cả")
                {
                    cmd.Parameters.AddWithValue("@loaiVanBan", "%" + loaiVanBan + "%");
                }

                if (!string.IsNullOrEmpty(soKyHieu))
                {
                    cmd.Parameters.AddWithValue("@soKyHieu", "%" + soKyHieu + "%");
                }

                if (!string.IsNullOrEmpty(noiBanHanh))
                {
                    cmd.Parameters.AddWithValue("@noiBanHanh", "%" + noiBanHanh + "%");
                }

                if (startDate.HasValue && endDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@startDate", DateConversion(startDate.Value));
                    cmd.Parameters.AddWithValue("@endDate", DateConversion(endDate.Value));
                }

                if (!string.IsNullOrEmpty(noiDung))
                {
                    cmd.Parameters.AddWithValue("@noiDung", "%" + noiDung + "%");
                }

                if (nam > 0)
                {
                    cmd.Parameters.AddWithValue("@nam", nam);
                }

                // Thực thi truy vấn và đọc dữ liệu
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VanBanDenModel vbden = new VanBanDenModel
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nam = reader.GetInt32(reader.GetOrdinal("Nam")),
                        TenSo = reader.GetString(reader.GetOrdinal("TENSO")),
                        SoKyHieu = reader.GetString(reader.GetOrdinal("SOKYHIEU")),
                        NgayBanHanh = reader.GetDateTime(reader.GetOrdinal("NGAYBANHANH")),
                        NoiBanHanh = reader.GetString(reader.GetOrdinal("NOIBANHANH")),
                        LoaiVanBan = reader.GetString(reader.GetOrdinal("LOAIVANBAN")),
                        SoDen = reader.GetInt32(reader.GetOrdinal("SODEN")),
                        NgayDen = reader.GetDateTime(reader.GetOrdinal("NGAYDEN")),
                        SoTrang = reader.GetInt32(reader.GetOrdinal("SOTRANG")),
                        NguoiNhan = reader.GetString(reader.GetOrdinal("NGUOINHAN")),
                        NguoiKy = reader.GetString(reader.GetOrdinal("NGUOIKY")),
                        NguoiDuyet = reader.GetString(reader.GetOrdinal("NGUOIDUYET")),
                        TrichYeu = reader.GetString(reader.GetOrdinal("TRICHYEU")),
                        NoiDung = reader.GetString(reader.GetOrdinal("NOIDUNG")),
                        DuongDanFile = reader.GetString(reader.GetOrdinal("DINHKEMFILE"))
                    };
                    list.Add(vbden);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Đảm bảo đóng reader và cmd
                reader?.Close();
                cmd?.Dispose();
            }

            return list;
        }

    }
}
