using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class VanBanDiModel
    {
        public int Id { get; set; }
        public string TenSo { get; set; }
        public int Nam { get; set; }
        public string SoKyHieu { get; set; }
        public DateTime NgayBanHanh { get; set; }
        public string NoiNhan { get; set; }
        public string LoaiVanBan { get; set; }
        public int SoDi { get; set; }
        public int SlBan { get; set; }
        public int SoTrang { get; set; }
        public string NguoiGui { get; set; }
        public string NguoiKy { get; set; }
        public string NguoiDuyet { get; set; }
        public string TrichYeu { get; set; }
        public string NoiDung { get; set; }
        public string DuongDanFile { get; set; }
        public bool DaXoa { get; set; }

        // Constructor mặc định
        public VanBanDiModel() { }

        // Constructor với các tham số
        public VanBanDiModel(int id, string tenSo, int nam, string soKyHieu, DateTime ngayBanHanh, string noiNhan, string loaiVanBan, int soDi, int slBan, int soTrang, string nguoiGui, string nguoiKy, string nguoiDuyet, string trichYeu, string noiDung, string duongDanFile, bool daXoa)
        {
            Id = id;
            TenSo = tenSo;
            Nam = nam;
            SoKyHieu = soKyHieu;
            NgayBanHanh = ngayBanHanh;
            NoiNhan = noiNhan;
            LoaiVanBan = loaiVanBan;
            SoDi = soDi;
            SlBan = slBan;
            SoTrang = soTrang;
            NguoiGui = nguoiGui;
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
            return $"VanBanDiModel{{Id={Id}, TenSo={TenSo}, Nam={Nam}, SoKyHieu={SoKyHieu}, NgayBanHanh={NgayBanHanh}, NoiNhan={NoiNhan}, LoaiVanBan={LoaiVanBan}, SoDi={SoDi}, SlBan={SlBan}, SoTrang={SoTrang}, NguoiGui={NguoiGui}, NguoiKy={NguoiKy}, NguoiDuyet={NguoiDuyet}, TrichYeu={TrichYeu}, NoiDung={NoiDung}, DuongDanFile={DuongDanFile}, DaXoa={DaXoa}}}";
        }
    }
}
