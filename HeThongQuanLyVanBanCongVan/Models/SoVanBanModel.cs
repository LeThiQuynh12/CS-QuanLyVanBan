using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class SoVanBanModel
    {
        public int MaSo { get; set; }
        public string SoVanBan { get; set; }
        public bool SoDen { get; set; }
        public int Nam { get; set; }
        public bool DaXoa { get; set; }

        // Constructor mặc định
        public SoVanBanModel() { }

        // Constructor với các tham số
        public SoVanBanModel(int maSo, string soVanBan, bool soDen, int nam, bool daXoa)
        {
            MaSo = maSo;
            SoVanBan = soVanBan;
            SoDen = soDen;
            Nam = nam;
            DaXoa = daXoa;
        }

        // Override phương thức ToString
        public override string ToString()
        {
            return $"SoVanBanModel{{MaSo={MaSo}, SoVanBan={SoVanBan}, SoDen={SoDen}, Nam={Nam}, DaXoa={DaXoa}}}";
        }
    }
}
