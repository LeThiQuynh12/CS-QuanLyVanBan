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
        private string MaPhongBan;
        private string TenPhongBan;

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

        public string GetMaPhongBan()
        {
            return this.MaPhongBan;
        }
        public string GetTenPhongBan() 
        { 
            return this.TenPhongBan; 
        }

        public void SetMaPhongBan(String maPhongBan)
        {
            this.MaPhongBan = maPhongBan;
        }
        public void SetTenPhongBan(String tenPhongBan)
        {
            this.TenPhongBan = tenPhongBan;
        }
    }
}

