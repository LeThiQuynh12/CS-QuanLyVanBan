using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class DangNhapModel
    {
        private string tenTaiKhoan;
        private string matKhau;

        // Constructor không tham số
        public DangNhapModel()
        {
        }

        // Constructor có tham số
        public DangNhapModel(string tenTaiKhoan, string matKhau)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.matKhau = matKhau;
        }

        // Getter và Setter cho tenTaiKhoan
        public string TenTaiKhoan
        {
            get { return tenTaiKhoan; }
            set { tenTaiKhoan = value; }
        }

        // Getter và Setter cho matKhau
        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        // Ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"ModelDangNhap {{ TenTaiKhoan = {tenTaiKhoan}, MatKhau = {matKhau} }}";
        }
    }
}
