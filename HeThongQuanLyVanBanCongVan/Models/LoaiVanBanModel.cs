using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class LoaiVanBanModel
    {
        public string MaLoai { get; set; }
        public string LoaiVanBan { get; set; }
        public string MoTa { get; set; }
        public bool DaXoa { get; set; }

        // Constructor mặc định
        public LoaiVanBanModel() { }

        // Constructor với các tham số
        public LoaiVanBanModel(string maLoai, string loaiVanBan, string moTa, bool daXoa)
        {
            MaLoai = maLoai;
            LoaiVanBan = loaiVanBan;
            MoTa = moTa;
            DaXoa = daXoa;
        }

        // Override phương thức ToString
        public override string ToString()
        {
            return $"LoaiVanBanModel{{MaLoai={MaLoai}, LoaiVanBan={LoaiVanBan}, MoTa={MoTa}, DaXoa={DaXoa}}}";
        }
    }
}
