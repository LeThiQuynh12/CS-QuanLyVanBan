using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class VanBanDenModel
    {
        public int Id { get; set; }
        public string TenSo { get; set; }
        public int Nam { get; set; }
        public string SoKyHieu { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string NoiBanHanh { get; set; }
        public string LoaiVanBan { get; set; }
        public int SoDen { get; set; }
        public DateTime NgayDen { get; set; }
        public int SoTrang { get; set; }
        public string NguoiNhan { get; set; }
        public string NguoiKy { get; set; }
        public string NguoiDuyet { get; set; }
        public string TrichYeu { get; set; }
        public string NoiDung { get; set; }
        public string DuongDanFile { get; set; }
        public bool DaXoa { get; set; }

        // Constructor mặc định
        public VanBanDenModel() { }

        // Constructor với các tham số
        public VanBanDenModel(int id, string tenSo, int nam, string soKyHieu, DateTime ngayBanHanh, string noiBanHanh, string loaiVanBan, int soDen, DateTime ngayDen, int soTrang, string nguoiNhan, string nguoiKy, string nguoiDuyet, string trichYeu, string noiDung, string duongDanFile, bool daXoa)
        {
            Id = id;
            TenSo = tenSo;
            Nam = nam;
            SoKyHieu = soKyHieu;
            NgayBanHanh = ngayBanHanh;
            NoiBanHanh = noiBanHanh;
            LoaiVanBan = loaiVanBan;
            SoDen = soDen;
            NgayDen = ngayDen;
            SoTrang = soTrang;
            NguoiNhan = nguoiNhan;
            NguoiKy = nguoiKy;
            NguoiDuyet = nguoiDuyet;
            TrichYeu = trichYeu;
            NoiDung = noiDung;
            DuongDanFile = duongDanFile;
            DaXoa = daXoa;
        }

        // Override phương thức ToString
        public override string ToString()
        {
            return $"VanBanDenModel{{Id={Id}, TenSo={TenSo}, Nam={Nam}, SoKyHieu={SoKyHieu}, NgayBanHanh={NgayBanHanh}, NoiBanHanh={NoiBanHanh}, LoaiVanBan={LoaiVanBan}, SoDen={SoDen}, NgayDen={NgayDen}, SoTrang={SoTrang}, NguoiNhan={NguoiNhan}, NguoiKy={NguoiKy}, NguoiDuyet={NguoiDuyet}, TrichYeu={TrichYeu}, NoiDung={NoiDung}, DuongDanFile={DuongDanFile}, DaXoa={DaXoa}}}";
        }
    }
}
