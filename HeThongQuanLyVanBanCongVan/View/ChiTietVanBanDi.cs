using HeThongQuanLyVanBanCongVan.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan.View
{
    public partial class ChiTietVanBanDi : Form
    {
        public ChiTietVanBanDi()
        {
            InitializeComponent();
            KhoiTao();
        }
        private void KhoiTao()
        {
            // Khởi tạo controller
            VanBanDiController vbController = new VanBanDiController();

            // Lấy danh sách số văn bản và thêm vào combobox
            List<string> danhsachso = vbController.HienThiSoVanBan();
            foreach (string x in danhsachso)
            {
                cboSoVanBanDi.Items.Add(x);
            }
            VanBanDiController vbController1 = new VanBanDiController();
            // Lấy danh sách loại văn bản và thêm vào combobox
            List<string> danhsachloai = vbController1.HienThiLoaiVanBan();
            foreach (string s in danhsachloai)
            {
                cboLoaiVanBanDi.Items.Add(s);
            }

            // Vô hiệu hóa các nút chức năng
            
            // Vô hiệu hóa các nút chức năng
            btnLuuVanBanDi.Enabled = false;
            btnLuuVanBanDi.BackColor = Color.Gray;
            btnXuatExcelVanBanDi.Enabled = false;
            btnXuatExcelVanBanDi.BackColor = Color.Gray;
            btnXoaVanBanDi.Enabled = false;
            btnXoaVanBanDi.BackColor = Color.Gray;
            btnThemVanBanDi.Enabled = false;
            btnThemVanBanDi.BackColor = Color.Gray;
            btnTaiLaiVanBanDi.Enabled = false;
            btnTaiLaiVanBanDi.BackColor = Color.Gray;
            btnDinhKemFileDi.Enabled = false;
            // Hiển thị thông tin chi tiết từ TrangChu.vanBanDiChiTiet
            Console.WriteLine(TrangChu.vanBanDiChiTiet.ToString());

            cboSoVanBanDi.SelectedItem = $"{TrangChu.vanBanDiChiTiet.TenSo}-{TrangChu.vanBanDiChiTiet.Nam}";
            Console.WriteLine($"{TrangChu.vanBanDiChiTiet.TenSo}-{TrangChu.vanBanDiChiTiet.Nam}");

            txtSoKiHieuDi.Text = TrangChu.vanBanDiChiTiet.SoKyHieu;
            txtSoDi.Text = TrangChu.vanBanDiChiTiet.SoDi.ToString();
            dateNgayBanHanhDi.Value = TrangChu.vanBanDiChiTiet.NgayBanHanh;
            Console.WriteLine(TrangChu.vanBanDiChiTiet.LoaiVanBan);
            cboLoaiVanBanDi.SelectedItem = TrangChu.vanBanDiChiTiet.LoaiVanBan;

            txtSoTrangDi.Text = TrangChu.vanBanDiChiTiet.SoTrang.ToString();
            txtSoLuongBanDi.Text = TrangChu.vanBanDiChiTiet.SlBan.ToString();
            txtNguoiGuiDi.Text = TrangChu.vanBanDiChiTiet.NguoiGui;
            txtNguoiKyDi.Text = TrangChu.vanBanDiChiTiet.NguoiKy;
            txtNguoiDuyetDi.Text = TrangChu.vanBanDiChiTiet.NguoiDuyet;
            txtTrichYeuDi.Text = TrangChu.vanBanDiChiTiet.TrichYeu;
            txtNoiDungDi.Text = TrangChu.vanBanDiChiTiet.NoiDung;
            txtDinhKemFileDi.Text = TrangChu.vanBanDiChiTiet.DuongDanFile;
            cboSoVanBanDi.Enabled = false;
            txtSoKiHieuDi.Enabled = false;
            txtSoDi.Enabled = false;
            dateNgayBanHanhDi.Enabled = false;
            cboLoaiVanBanDi.Enabled = false;
            txtSoTrangDi.Enabled = false;
            txtSoLuongBanDi.Enabled = false;
            txtNguoiGuiDi.Enabled = false;
            txtNguoiKyDi.Enabled = false;
            txtNguoiDuyetDi.Enabled = false;
            txtTrichYeuDi.Enabled = false;
            txtNoiDungDi.Enabled = false;
            txtDinhKemFileDi.Enabled = false;
            txtNoiNhanDi.Enabled = false;

        }

        private void btnXoaVanBanDi_Click(object sender, EventArgs e)
        {

        }

        private void txtSoKiHieuDi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
