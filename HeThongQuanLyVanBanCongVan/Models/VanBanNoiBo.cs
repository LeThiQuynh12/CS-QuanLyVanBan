using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class VanBanNoiBo
    {
        // Thuộc tính private, không thể truy cập trực tiếp từ bên ngoài
        private string soKyHieu;
        private string tenVanBan;
        private DateTime ngayBanHanh;
        private string loaiBanHanh;
        private string phongBanHanh;
        private string phongNhan;
        private string nguoiNhan;
        private string nguoiKy;
        private string nguoiDuyet;
        private string trichYeu;
        private string noiDung;

        // Getter và Setter
        public string SoKyHieu
        {
            get { return soKyHieu; }
            set { soKyHieu = value; }
        }

        public string TenVanBan
        {
            get { return tenVanBan; }
            set { tenVanBan = value; }
        }

        public DateTime NgayBanHanh
        {
            get { return ngayBanHanh; }
            set { ngayBanHanh = value; }
        }

        public string LoaiBanHanh
        {
            get { return loaiBanHanh; }
            set { loaiBanHanh = value; }
        }

        public string PhongBanHanh
        {
            get { return phongBanHanh; }
            set { phongBanHanh = value; }
        }

        public string PhongNhan
        {
            get { return phongNhan; }
            set { phongNhan = value; }
        }

        public string NguoiNhan
        {
            get { return nguoiNhan; }
            set { nguoiNhan = value; }
        }

        public string NguoiKy
        {
            get { return nguoiKy; }
            set { nguoiKy = value; }
        }

        public string NguoiDuyet
        {
            get { return nguoiDuyet; }
            set { nguoiDuyet = value; }
        }

        public string TrichYeu
        {
            get { return trichYeu; }
            set { trichYeu = value; }
        }

        public string NoiDung
        {
            get { return noiDung; }
            set { noiDung = value; }
        }

        // Constructor nhận dữ liệu từ SqlDataReader
        public VanBanNoiBo(System.Data.SqlClient.SqlDataReader reader)
        {
            soKyHieu = reader["SoKyHieu"].ToString();
            tenVanBan = reader["TenVanBan"].ToString();
            ngayBanHanh = Convert.ToDateTime(reader["NgayBanHanh"]);
            loaiBanHanh = reader["LoaiBanHanh"].ToString();
            phongBanHanh = reader["PhongBanHanh"].ToString();
            phongNhan = reader["PhongNhan"].ToString();
            nguoiNhan = reader["NguoiNhan"].ToString();
            nguoiKy = reader["NguoiKy"].ToString();
            nguoiDuyet = reader["NguoiDuyet"].ToString();
            trichYeu = reader["TrichYeu"].ToString();
            noiDung = reader["NoiDung"].ToString();
        }

    }

}