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
    public partial class ChiTietVanBanDen : Form
    {
        public ChiTietVanBanDen()
        {
            InitializeComponent();
            KhoiTaoVanBanDen();
        }
        public void KhoiTaoVanBanDen()
        {
            try
            {
                // Lấy ngày hiện tại và gán vào các DateTimePicker
                DateTime currentDate = DateTime.Now.Date; // Lấy ngày hiện tại mà không có giờ
                dateNgayBanHanhDen.Value = currentDate;
                dateNgayDen.Value = currentDate;

                // Vô hiệu hóa các nút chức năng
                btnLuuVanBanDen.Enabled = false;
                btnLuuVanBanDen.BackColor = Color.Gray;
                btnXuatExcelVanBanDen.Enabled = false;
                btnXuatExcelVanBanDen.BackColor = Color.Gray;
                btnXoaVanBanDen.Enabled = false;
                btnXoaVanBanDen.BackColor = Color.Gray;
                btnThemVanBanDen.Enabled = false;
                btnThemVanBanDen.BackColor = Color.Gray;
                btnTaiLaiVanBanDen.Enabled=false;
                btnTaiLaiVanBanDen.BackColor = Color.Gray;
                btnDinhKemFileDen.Enabled = false;
                btnDinhKemFileDen.BackColor = Color.Gray;
                // Xóa các mục cũ trong combobox trước khi thêm mới
                cboSoVanBanDen.Items.Clear();
                cboLoaiVanBanDen.Items.Clear();
                cboNoiBanHanhDen.Items.Clear();

                // Lấy danh sách số văn bản
                var vbController1 = new VanBanDenController();
                var danhSachSo = vbController1.HienThiSoVanBan();
                if (danhSachSo != null && danhSachSo.Count > 0)
                {
                    foreach (string x in danhSachSo)
                    {
                        cboSoVanBanDen.Items.Add(x);
                    }
                }

                // Lấy danh sách loại văn bản
                var vbController2 = new VanBanDenController();
                var danhSachLoai = vbController2.HienThiLoaiVanBan();
                if (danhSachLoai != null && danhSachLoai.Count > 0)
                {
                    foreach (string s in danhSachLoai)
                    {
                        cboLoaiVanBanDen.Items.Add(s);
                    }
                }

                // Lấy danh sách nơi ban hành
                var vbController3 = new VanBanDenController();
                var danhSachNoi = vbController3.HienThiNoiBanHanh();
                if (danhSachNoi != null && danhSachNoi.Count > 0)
                {
                    foreach (string x in danhSachNoi)
                    {
                        cboNoiBanHanhDen.Items.Add(x);
                    }
                }

                // Đặt giá trị mặc định cho các combobox
                //cboSoVanBanDen.SelectedIndex = -1; // Không chọn mục nào mặc định
                //cboLoaiVanBanDen.SelectedIndex = -1;
                //cboNoiBanHanhDen.SelectedIndex = -1;
                //txtSoDen.Clear();
                //txtSoKyHieuDen.Clear();
                //txtSoTrangDen.Clear();
                //txtNguoiDuyetDen.Clear();
                //txtNguoiNhanDen.Clear();
                //txtNguoiKyDen.Clear();
                //txtNoiDungDen.Clear();
                //txtTrichYeuDen.Clear();
                //txtDinhKemFileDen.Clear();

                cboSoVanBanDen.Enabled = false; // Không chọn mục nào mặc định
                cboLoaiVanBanDen.Enabled = false;
                cboNoiBanHanhDen.Enabled = false;
                txtSoDen.Enabled = false;
                txtSoKyHieuDen.Enabled = false;
                txtSoTrangDen.Enabled = false;
                txtNguoiDuyetDen.Enabled = false;
                txtNguoiNhanDen.Enabled = false;
                txtNguoiKyDen.Enabled = false;
                txtNoiDungDen.Enabled = false;
                txtTrichYeuDen.Enabled = false;
                txtDinhKemFileDen.Enabled = false;
                dateNgayBanHanhDen.Enabled = false;
                dateNgayDen.Enabled = false;

                cboSoVanBanDen.SelectedItem = $"{TrangChu.vanBanDenChiTiet.TenSo}-{TrangChu.vanBanDenChiTiet.Nam}";
                Console.WriteLine($"{TrangChu.vanBanDenChiTiet.TenSo}-{TrangChu.vanBanDenChiTiet.Nam}");

                txtSoKyHieuDen.Text = TrangChu.vanBanDenChiTiet.SoKyHieu;
                txtSoDen.Text = TrangChu.vanBanDenChiTiet.SoDen.ToString();
                dateNgayBanHanhDen.Value = TrangChu.vanBanDenChiTiet.NgayBanHanh;
                cboLoaiVanBanDen.SelectedItem = TrangChu.vanBanDenChiTiet.LoaiVanBan;
                Console.WriteLine(TrangChu.vanBanDenChiTiet.LoaiVanBan);
                cboNoiBanHanhDen.SelectedItem = TrangChu.vanBanDenChiTiet.NoiBanHanh;
                Console.WriteLine(TrangChu.vanBanDenChiTiet.NoiBanHanh);
                dateNgayDen.Value = TrangChu.vanBanDenChiTiet.NgayDen;

                txtSoTrangDen.Text = TrangChu.vanBanDenChiTiet.SoTrang.ToString();
                txtNguoiNhanDen.Text = TrangChu.vanBanDenChiTiet.NguoiNhan;
                txtNguoiKyDen.Text = TrangChu.vanBanDenChiTiet.NguoiKy;
                txtNguoiDuyetDen.Text = TrangChu.vanBanDenChiTiet.NguoiDuyet;
                txtTrichYeuDen.Text = TrangChu.vanBanDenChiTiet.TrichYeu;
                txtNoiDungDen.Text = TrangChu.vanBanDenChiTiet.NoiDung;
                txtDinhKemFileDen.Text = TrangChu.vanBanDenChiTiet.DuongDanFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button42_Click(object sender, EventArgs e)
        {

        }

        private void btnThemVanBanDen_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuVanBanDen_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiVanBanDen_Click(object sender, EventArgs e)
        {

        }

        private void cboSoVanBanDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
