using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Controllers
{
    public class VanBanNoiBoController : KetNoiCSDL
    {
        public List<VanBanNoiBo> GetAll()
        {
            List<VanBanNoiBo> list = new List<VanBanNoiBo>();
            string query = @"
            SELECT vb.SoKyHieu, vb.TenVanBan, vb.NgayBanHanh, l.loaivanban AS LoaiBanHanh, 
                   pbH.TenPhongBan AS PhongBanHanh, pbN.TenPhongBan AS PhongNhan, 
                   vb.NguoiNhan, vb.NguoiKy, vb.NguoiDuyet, vb.TrichYeu, vb.NoiDung
            FROM VanBanNoiBo vb
            JOIN LOAIVANBAN l ON vb.maloai = l.maloai
            JOIN tblPhongBan pbH ON vb.MaBanHanh = pbH.MaPhongBan
            JOIN tblPhongBan pbN ON vb.MaBanNhan = pbN.MaPhongBan";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VanBanNoiBo obj = new VanBanNoiBo(reader);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
        public List<string> GetLoaiVanBan()
        {
            List<string> loaiVanBanList = new List<string>();
            string query = "SELECT loaivanban FROM LOAIVANBAN";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loaiVanBanList.Add(reader["loaivanban"].ToString());
                    }
                }
            }
            return loaiVanBanList;
        }

        public List<string> GetPhongBan()
        {
            List<string> phongBanList = new List<string>();
            string query = "SELECT TenPhongBan FROM tblPhongBan";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        phongBanList.Add(reader["TenPhongBan"].ToString());
                    }
                }
            }
            return phongBanList;
        }

        public bool ThemVanBanNoiBo(string soKyHieu, string tenVanBan, DateTime ngayBanHanh, string loaiBanHanh,
                                    string phongBanHanh, string phongBanNhan, string nguoiNhan, string nguoiKy,
                                    string nguoiDuyet, string trichYeu, string noiDung, int maTL)
        {
            string query = @"
            INSERT INTO VanBanNoiBo 
            (SoKyHieu, TenVanBan, NgayBanHanh, maloai, MaBanHanh, MaBanNhan, NguoiNhan, NguoiKy, NguoiDuyet, TrichYeu, NoiDung, MaTL)
            VALUES (@SoKyHieu, @TenVanBan, @NgayBanHanh, @LoaiBanHanh, @PhongBanHanh, @PhongBanNhan, @NguoiNhan, @NguoiKy, @NguoiDuyet, @TrichYeu, @NoiDung, @MaTL)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoKyHieu", soKyHieu);
                cmd.Parameters.AddWithValue("@TenVanBan", tenVanBan);
                cmd.Parameters.AddWithValue("@NgayBanHanh", ngayBanHanh);
                cmd.Parameters.AddWithValue("@LoaiBanHanh", loaiBanHanh);
                cmd.Parameters.AddWithValue("@PhongBanHanh", phongBanHanh);
                cmd.Parameters.AddWithValue("@PhongBanNhan", phongBanNhan);
                cmd.Parameters.AddWithValue("@NguoiNhan", nguoiNhan);
                cmd.Parameters.AddWithValue("@NguoiKy", nguoiKy);
                cmd.Parameters.AddWithValue("@NguoiDuyet", nguoiDuyet);
                cmd.Parameters.AddWithValue("@TrichYeu", trichYeu);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("MaTL", maTL);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public string LayMaLoaiVanBan(string loaiVanBan)
        {
            string query = "SELECT maloai FROM LOAIVANBAN WHERE loaivanban = @LoaiVanBan";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LoaiVanBan", loaiVanBan);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        public string LayMaPhongBan(string tenPhongBan)
        {
            string query = "SELECT MaPhongBan FROM tblPhongBan WHERE TenPhongBan = @TenPhongBan";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                return cmd.ExecuteScalar()?.ToString();
            }
        }

        public bool KiemTraSoKyHieuTonTai(string soKyHieu)
        {
            string query = "SELECT COUNT(*) AS count FROM VanBanNoiBo WHERE SoKyHieu = @SoKyHieu";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoKyHieu", soKyHieu);
                    object result = cmd.ExecuteScalar();
                    int count = result != null ? Convert.ToInt32(result) : 0;
                    return count > 0; // Nếu count > 0 thì số ký hiệu đã tồn tại
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

      

        public bool CapNhatVanBanNoiBo(string soKyHieu, string tenVanBan, DateTime ngayBanHanh, string loaiBanHanh,
            string phongBanHanh, string phongBanNhan, string nguoiNhan, string nguoiKy, string nguoiDuyet,
            string trichYeu, string noiDung, int maTL)
        {
            string query = @"UPDATE VanBanNoiBo 
                         SET TenVanBan = @TenVanBan, NgayBanHanh = @NgayBanHanh, maloai = @LoaiBanHanh, 
                             MaBanHanh = @PhongBanHanh, MaBanNhan = @PhongBanNhan, NguoiNhan = @NguoiNhan, 
                             NguoiKy = @NguoiKy, NguoiDuyet = @NguoiDuyet, TrichYeu = @TrichYeu, NoiDung = @NoiDung, 
                             MaTL = @MaTL WHERE SoKyHieu = @SoKyHieu";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenVanBan", tenVanBan);
                    cmd.Parameters.AddWithValue("@NgayBanHanh", ngayBanHanh);
                    cmd.Parameters.AddWithValue("@LoaiBanHanh", loaiBanHanh);
                    cmd.Parameters.AddWithValue("@PhongBanHanh", phongBanHanh);
                    cmd.Parameters.AddWithValue("@PhongBanNhan", phongBanNhan);
                    cmd.Parameters.AddWithValue("@NguoiNhan", nguoiNhan);
                    cmd.Parameters.AddWithValue("@NguoiKy", nguoiKy);
                    cmd.Parameters.AddWithValue("@NguoiDuyet", nguoiDuyet);
                    cmd.Parameters.AddWithValue("@TrichYeu", trichYeu);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@MaTL", maTL);
                    cmd.Parameters.AddWithValue("@SoKyHieu", soKyHieu);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Xoa(string soKyHieu)
        {
            string query = "DELETE FROM VanBanNoiBo WHERE SoKyHieu = @SoKyHieu";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoKyHieu", soKyHieu);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<VanBanNoiBo> FilterDataByDateRange(DateTime startDate, DateTime endDate)
        {
            List<VanBanNoiBo> list = new List<VanBanNoiBo>();
            string query = @"SELECT vb.SoKyHieu, vb.TenVanBan, vb.NgayBanHanh, l.loaivanban AS LoaiBanHanh, 
                         pbH.TenPhongBan AS PhongBanHanh, pbN.TenPhongBan AS PhongNhan, vb.NguoiNhan, 
                         vb.NguoiKy, vb.NguoiDuyet, vb.TrichYeu, vb.NoiDung 
                         FROM VanBanNoiBo vb 
                         JOIN LOAIVANBAN l ON vb.maloai = l.maloai 
                         JOIN tblPhongBan pbH ON vb.MaBanHanh = pbH.MaPhongBan 
                         JOIN tblPhongBan pbN ON vb.MaBanNhan = pbN.MaPhongBan 
                         WHERE vb.NgayBanHanh BETWEEN @StartDate AND @EndDate";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VanBanNoiBo obj = new VanBanNoiBo(reader); // Giả sử bạn có constructor từ SqlDataReader
                            list.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }


        public List<VanBanNoiBo> Search(
          string loaiBanHanh,
          string phongBanHanh,
          string phongBanNhan,
          string soKyHieu,
          string tenVanBan,
          string trichYeu,
          DateTime? startDate,
          DateTime? endDate)
        {
            List<VanBanNoiBo> list = new List<VanBanNoiBo>();
            string query = @"
            SELECT vb.SoKyHieu, vb.TenVanBan, vb.NgayBanHanh, l.loaivanban AS LoaiBanHanh, 
                   pbH.TenPhongBan AS PhongBanHanh, pbN.TenPhongBan AS PhongNhan, 
                   vb.NguoiNhan, vb.NguoiKy, vb.NguoiDuyet, vb.TrichYeu, vb.NoiDung
            FROM VanBanNoiBo vb
            JOIN LOAIVANBAN l ON vb.maloai = l.maloai
            JOIN tblPhongBan pbH ON vb.MaBanHanh = pbH.MaPhongBan
            JOIN tblPhongBan pbN ON vb.MaBanNhan = pbN.MaPhongBan
            WHERE 1 = 1";

            // Thêm điều kiện lọc
            if (!string.IsNullOrEmpty(loaiBanHanh) && loaiBanHanh != "Tất cả")
                query += " AND l.loaivanban LIKE @LoaiBanHanh";
            if (!string.IsNullOrEmpty(phongBanHanh) && phongBanHanh != "Tất cả")
                query += " AND pbH.TenPhongBan LIKE @PhongBanHanh";
            if (!string.IsNullOrEmpty(phongBanNhan) && phongBanNhan != "Tất cả")
                query += " AND pbN.TenPhongBan LIKE @PhongBanNhan";
            if (!string.IsNullOrEmpty(soKyHieu))
                query += " AND vb.SoKyHieu LIKE @SoKyHieu";
            if (!string.IsNullOrEmpty(tenVanBan))
                query += " AND vb.TenVanBan LIKE @TenVanBan";
            if (!string.IsNullOrEmpty(trichYeu))
                query += " AND vb.TrichYeu LIKE @TrichYeu";
            if (startDate.HasValue && endDate.HasValue)
                query += " AND vb.NgayBanHanh BETWEEN @StartDate AND @EndDate";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(loaiBanHanh) && loaiBanHanh != "Tất cả")
                    cmd.Parameters.AddWithValue("@LoaiBanHanh", "%" + loaiBanHanh + "%");
                if (!string.IsNullOrEmpty(phongBanHanh) && phongBanHanh != "Tất cả")
                    cmd.Parameters.AddWithValue("@PhongBanHanh", "%" + phongBanHanh + "%");
                if (!string.IsNullOrEmpty(phongBanNhan) && phongBanNhan != "Tất cả")
                    cmd.Parameters.AddWithValue("@PhongBanNhan", "%" + phongBanNhan + "%");
                if (!string.IsNullOrEmpty(soKyHieu))
                    cmd.Parameters.AddWithValue("@SoKyHieu", "%" + soKyHieu + "%");
                if (!string.IsNullOrEmpty(tenVanBan))
                    cmd.Parameters.AddWithValue("@TenVanBan", "%" + tenVanBan + "%");
                if (!string.IsNullOrEmpty(trichYeu))
                    cmd.Parameters.AddWithValue("@TrichYeu", "%" + trichYeu + "%");
                if (startDate.HasValue && endDate.HasValue)
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VanBanNoiBo obj = new VanBanNoiBo(reader);
                        list.Add(obj);
                    }
                }
            }

            return list;
        }





    }
}
