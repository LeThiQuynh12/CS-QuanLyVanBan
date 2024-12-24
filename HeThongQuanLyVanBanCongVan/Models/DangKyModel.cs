using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class DangKyModel
    {
        public string CoQuan { get; set; }        // Thêm trường CoQuan
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }        // Thêm trường VaiTro
        public byte[] Salt { get; set; }          // Thêm trường Salt (byte[] tương ứng với VARBINARY trong cơ sở dữ liệu)

        // Constructor mặc định
        public DangKyModel() { }

        // Constructor với tất cả các trường
        public DangKyModel(string coQuan, string hoVaTen, string email, string soDienThoai, string tenTaiKhoan, string matKhau, string vaiTro, byte[] salt)
        {
            CoQuan = coQuan;
            HoVaTen = hoVaTen;
            Email = email;
            SoDienThoai = soDienThoai;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            VaiTro = vaiTro;
            Salt = salt;
        }

        // Phương thức ToString() để hiển thị thông tin đối tượng
        public override string ToString()
        {
            return $"DangKyModel {{ CoQuan='{CoQuan}', HoVaTen='{HoVaTen}', Email='{Email}', SoDienThoai='{SoDienThoai}', " +
                   $"TenTaiKhoan='{TenTaiKhoan}', MatKhau='{MatKhau}', VaiTro='{VaiTro}', Salt={(Salt != null ? "exists" : "null")} }}";
        }
    }
    }
