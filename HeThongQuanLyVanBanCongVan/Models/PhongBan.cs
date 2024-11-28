using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class PhongBan
    {
        // Các thuộc tính với tên chuẩn của C#
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }

        // Constructor mặc định
        public PhongBan()
        {
        }

        // Constructor nhận SqlDataReader để ánh xạ dữ liệu từ DB
        public PhongBan(SqlDataReader reader)
        {
            // Đặt tên cột khớp với bảng trong DB
            this.MaPhongBan = reader["MaPhongBan"].ToString();
            this.TenPhongBan = reader["TenPhongBan"].ToString();
        }

        // Constructor nhận giá trị trực tiếp
        public PhongBan(string maPhongBan, string tenPhongBan)
        {
            this.MaPhongBan = maPhongBan;
            this.TenPhongBan = tenPhongBan;
        }
    }
}

