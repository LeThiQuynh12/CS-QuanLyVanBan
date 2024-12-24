using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyVanBanCongVan.Models
{
    public class NoiBanHanhModel
    {
        public int MaNoiBanHanh { get; set; }
        public string NoiBanHanh { get; set; }
        public string MoTa { get; set; }
        public bool DaXoa { get; set; }

        // Constructor mặc định
        public NoiBanHanhModel() { }

        // Constructor với các tham số
        public NoiBanHanhModel(int maNoiBanHanh, string noiBanHanh, string moTa, bool daXoa)
        {
            MaNoiBanHanh = maNoiBanHanh;
            NoiBanHanh = noiBanHanh;
            MoTa = moTa;
            DaXoa = daXoa;
        }

        // Override phương thức ToString
        public override string ToString()
        {
            return $"NoiBanHanhModel{{MaNoiBanHanh={MaNoiBanHanh}, NoiBanHanh={NoiBanHanh}, MoTa={MoTa}, DaXoa={DaXoa}}}";
        }
    }
}
