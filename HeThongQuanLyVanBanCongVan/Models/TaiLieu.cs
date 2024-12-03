using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class TaiLieu
    {
        private string MaTL;
        private string TenTL;
        private string NgayTao;
        private string KichCo;
        private string Loai;
        private string DuongDan;

        // Constructor sử dụng DataRow
        public TaiLieu(DataRow row)
        {
            this.MaTL = row["MaTL"].ToString();
            this.TenTL = row["TenTL"].ToString();
            this.NgayTao = row["NgayTao"].ToString();
            this.KichCo = row["KichCo"].ToString();
            this.Loai = row["Loai"].ToString();
            this.DuongDan = row["DuongDan"].ToString();
        }

        // Constructor mặc định
        public TaiLieu() { }

        // Constructor với các tham số
        public TaiLieu(string maTL, string tenTL, string ngayTao, string kichCo, string loai, string duongDan)
        {
            this.MaTL = maTL;
            this.TenTL = tenTL;
            this.NgayTao = ngayTao;
            this.KichCo = kichCo;
            this.Loai = loai;
            this.DuongDan = duongDan;
        }
        public TaiLieu(SqlDataReader reader)
        {
            this.MaTL = reader["MaTL"].ToString();
            this.TenTL = reader["TenTL"].ToString();
            this.NgayTao = reader["NgayTao"].ToString();
            this.KichCo = reader["KichCo"].ToString();
            this.Loai = reader["Loai"].ToString();
            this.DuongDan = reader["DuongDan"].ToString();
        }
        // Getter và Setter cho các thuộc tính

        public string GetMaTL()
        {
            return MaTL;
        }

        public void SetMaTL(string maTL)
        {
            this.MaTL = maTL;
        }

        public string GetTenTL()
        {
            return TenTL;
        }

        public void SetTenTL(string tenTL)
        {
            this.TenTL = tenTL;
        }

        public string GetNgayTao()
        {
            return NgayTao;
        }

        public void SetNgayTao(string ngayTao)
        {
            this.NgayTao = ngayTao;
        }

        public string GetKichCo()
        {
            return KichCo;
        }

        public void SetKichCo(string kichCo)
        {
            this.KichCo = kichCo;
        }

        public string GetLoai()
        {
            return Loai;
        }

        public void SetLoai(string loai)
        {
            this.Loai = loai;
        }

        public string GetDuongDan()
        {
            return DuongDan;
        }

        public void SetDuongDan(string duongDan)
        {
            this.DuongDan = duongDan;
        }
    }
}
