using HeThongQuanLyVanBanCongVan.Controllers;
using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using HeThongQuanLyVanBanCongVan.View;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Diagnostics;

namespace HeThongQuanLyVanBanCongVan
{
    public partial class TrangChu : Form
    {
        private DataGridView tbPhongBan;
        private DataTable tableModelPhongBan;
        private List<SoVanBanModel> dsvb;
        private List<LoaiVanBanModel> dsl;
        private List<NoiBanHanhModel> dsnoi;
        private List<VanBanDenModel> dsvbden;
        private List<VanBanDiModel> dsvbdi;
        private List<VanBanDenModel> dstimkiemden;
        private List<VanBanDiModel> dstimkiemdi;
        public static VanBanDenModel vanBanDenChiTiet;
        public static VanBanDiModel vanBanDiChiTiet;
        public TrangChu()
        {
            InitializeComponent();
            // Phòng ban
            initTablePhongBan();
            fillDataPhongBan();
            //MessageBox.Show("Bảng đã được thêm vào form");
            //So van ban
            InitializeDataGridViewSoVanBan();
            InitializeNamSoVanBan();
            HienThiTableSoVanBan();
            //Loai van ban
            HienThiTableLoaiVanBan();
            //Noi ban hanh
            HienThiTableNoiBanHanh();
            //Van ban den
            KhoiTaoVanBanDen();
            //Danh sach van ban den
            InitializeDataGridViewVanBanDen();
            HienThiDanhSachVanBanDen();
            // Van ban di
            KhoiTaoVanBanDi();
            //Danh sach van ban di
            InitializeDataGridViewVanBanDi();
            HienThiDanhSachVanBanDi();

            // Văn bản nội bộ
            LoadComboboxData();
            InitTableVanBanNoiBo();
            FillDataVanBanNoiBo();

            // Tài liệu
            initTableTaiLieu();
            FillDataTaiLieu();

            // Tim kiém thống kê
            LoadComboboxData1();
            InitTableVanBanNoiBo1();
            FillDataVanBanNoiBo1();

            //Tìm kiếm văn bản đến
            KhoiTaoTimKiemVanBanDen();
            //Tìm kiếm văn bản đi
            KhoiTaoTimKiemVanBanDi();

        }




        //-----------------------------------Sổ văn bản------------------------------------------
        private void InitializeNamSoVanBan()
        {
            int currentYear = DateTime.Now.Year;

            // Duyệt từ năm 1980 đến năm hiện tại và thêm vào ComboBox
            for (int year = 1980; year <= currentYear; year++)
            {
                cboNamSoVanBan.Items.Add(year.ToString());
                cboNamDen.Items.Add(year.ToString());
                cboNamDi.Items.Add(year.ToString());
            }

            // Đảm bảo có ít nhất một item trong combo box trước khi chọn
            if (cboNamSoVanBan.Items.Count > 0)
                cboNamSoVanBan.SelectedItem = currentYear.ToString();

            if (cboNamDen.Items.Count > 0)
                cboNamDen.SelectedItem = currentYear.ToString();

            if (cboNamDi.Items.Count > 0)
                cboNamDi.SelectedItem = currentYear.ToString();
            cboNamDi.Items.Add("Tất cả");
            cboNamDen.Items.Add("Tất cả");
        }
        private void InitializeDataGridViewSoVanBan()
        {

            // Xóa hết các cột và dòng hiện tại
            tblSoVanBan.Columns.Clear();
            tblSoVanBan.Rows.Clear();

            // Thiết lập cột STT (số thứ tự)
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblSoVanBan.Columns.Add(colSTT);

            // Thiết lập cột Số Văn Bản
            DataGridViewTextBoxColumn colSoVanBan = new DataGridViewTextBoxColumn();
            colSoVanBan.HeaderText = "Số Văn Bản";
            colSoVanBan.Name = "SoVanBan";
            tblSoVanBan.Columns.Add(colSoVanBan);
            colSoVanBan.Width = 700;

            // Thiết lập cột Số Đến (Checkbox)
            DataGridViewCheckBoxColumn colSoDen = new DataGridViewCheckBoxColumn();
            colSoDen.HeaderText = "Số Đến";
            colSoDen.Name = "SoDen";
            tblSoVanBan.Columns.Add(colSoDen);
            colSoDen.Width = 150;
            // Thiết lập cột Năm
            DataGridViewTextBoxColumn colNam = new DataGridViewTextBoxColumn();
            colNam.HeaderText = "Năm";
            colNam.Name = "Nam";
            tblSoVanBan.Columns.Add(colNam);
            colNam.Width = 200;
            // Thiết lập không có dòng thừa
            tblSoVanBan.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblSoVanBan.AllowUserToDeleteRows = false; // Không cho phép xóa dòng khi không có dữ liệu
            tblSoVanBan.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột

        }

        public void HienThiTableSoVanBan()
        {
            InitializeDataGridViewSoVanBan();
            // Khởi tạo controller và lấy dữ liệu
            SoVanBanController soControl = new SoVanBanController();
            int year = int.Parse(cboNamSoVanBan.SelectedItem.ToString()); // Lấy năm từ ComboBox
            Console.WriteLine("Năm chọn: " + year);

            // Lấy dữ liệu danh sách số văn bản
            dsvb = soControl.HienThiSoVanBan(year);

            // Xóa hết các dòng trong DataGridView trước khi thêm mới
            tblSoVanBan.Rows.Clear();

            // Kiểm tra nếu có dữ liệu để hiển thị
            if (dsvb != null && dsvb.Count > 0)
            {
                // Duyệt qua danh sách số văn bản và thêm vào DataGridView
                for (int i = 0; i < dsvb.Count; i++)
                {
                    int stt = i + 1;  // Tính số thứ tự tự động
                    string soVanBan = dsvb[i].SoVanBan;
                    bool soden = dsvb[i].SoDen;  // Kiểm tra xem có "Số Đến" hay không
                    int nam = dsvb[i].Nam;

                    // Thêm dòng vào DataGridView
                    tblSoVanBan.Rows.Add(stt, soVanBan, soden, nam);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }


        }


        //-----------------------------------------Loai van ban----------------------------------
        private void InitializeDataGridViewLoaiVanBan()
        {
            // Xóa hết các cột và dòng hiện tại
            tblLoaiVanBan.Columns.Clear();
            tblLoaiVanBan.Rows.Clear();

            // Thiết lập cột STT (Số thứ tự)
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblLoaiVanBan.Columns.Add(colSTT);

            // Thiết lập cột Mã Loại
            DataGridViewTextBoxColumn colMaLoai = new DataGridViewTextBoxColumn();
            colMaLoai.HeaderText = "Mã Loại";
            colMaLoai.Name = "MaLoai";
            tblLoaiVanBan.Columns.Add(colMaLoai);
            colMaLoai.Width = 150;

            // Thiết lập cột Loại Văn Bản
            DataGridViewTextBoxColumn colLoaiVanBan = new DataGridViewTextBoxColumn();
            colLoaiVanBan.HeaderText = "Loại Văn Bản";
            colLoaiVanBan.Name = "LoaiVanBan";
            tblLoaiVanBan.Columns.Add(colLoaiVanBan);
            colLoaiVanBan.Width = 400;

            // Thiết lập cột Mô Tả
            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.HeaderText = "Mô Tả";
            colMoTa.Name = "MoTa";
            tblLoaiVanBan.Columns.Add(colMoTa);
            colMoTa.Width = 500;

            // Thiết lập không có dòng thừa
            tblLoaiVanBan.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblLoaiVanBan.AllowUserToDeleteRows = false; // Không cho phép xóa dòng khi không có dữ liệu
            tblLoaiVanBan.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột
        }

        public void HienThiTableLoaiVanBan()
        {
            InitializeDataGridViewLoaiVanBan();

            LoaiVanBanController loaiVBControl = new LoaiVanBanController();

            dsl = loaiVBControl.HienThiLoaiVanBan();

            tblLoaiVanBan.Rows.Clear();

            if (dsl != null && dsl.Count > 0)
            {
                for (int i = 0; i < dsl.Count; i++)
                {
                    int stt = i + 1;
                    string maLoai = dsl[i].MaLoai;
                    string loaiVanBan = dsl[i].LoaiVanBan;
                    string moTa = dsl[i].MoTa;

                    tblLoaiVanBan.Rows.Add(stt, maLoai, loaiVanBan, moTa);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }
        // Noi ban hanh
        private void InitializeDataGridViewNoiBanHanh()
        {
            // Xóa hết các cột và dòng hiện tại
            tblNoiBanHanh.Columns.Clear();
            tblNoiBanHanh.Rows.Clear();

            // Thiết lập cột STT (Số thứ tự)
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblNoiBanHanh.Columns.Add(colSTT);

            // Thiết lập cột Nơi Ban Hành
            DataGridViewTextBoxColumn colNoiBanHanh = new DataGridViewTextBoxColumn();
            colNoiBanHanh.HeaderText = "Nơi Ban Hành";
            colNoiBanHanh.Name = "NoiBanHanh";
            tblNoiBanHanh.Columns.Add(colNoiBanHanh);
            colNoiBanHanh.Width = 500;

            // Thiết lập cột Mô Tả
            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.HeaderText = "Mô Tả";
            colMoTa.Name = "MoTa";
            tblNoiBanHanh.Columns.Add(colMoTa);
            colMoTa.Width = 550;

            // Thiết lập không có dòng thừa
            tblNoiBanHanh.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblNoiBanHanh.AllowUserToDeleteRows = false; // Không cho phép xóa dòng khi không có dữ liệu
            tblNoiBanHanh.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột
        }
        public void HienThiTableNoiBanHanh()
        {
            InitializeDataGridViewNoiBanHanh();
            // Khởi tạo controller và lấy dữ liệu
            NoiBanHanhController noiBanHanhControl = new NoiBanHanhController();
            // Lấy dữ liệu danh sách nơi ban hành
            dsnoi = noiBanHanhControl.HienThiNoiBanHanh();

            // Xóa hết các dòng trong DataGridView trước khi thêm mới
            tblNoiBanHanh.Rows.Clear();

            // Kiểm tra nếu có dữ liệu để hiển thị
            if (dsnoi != null && dsnoi.Count > 0)
            {
                // Duyệt qua danh sách nơi ban hành và thêm vào DataGridView
                for (int i = 0; i < dsnoi.Count; i++)
                {
                    int stt = i + 1;  // Tính số thứ tự tự động
                    string noiBanHanh = dsnoi[i].NoiBanHanh;
                    string moTa = dsnoi[i].MoTa;  // Mô tả

                    // Thêm dòng vào DataGridView
                    tblNoiBanHanh.Rows.Add(stt, noiBanHanh, moTa);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }

        //-----------------------------------------------------Van ban den--------------------------------

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
                cboSoVanBanDen.SelectedIndex = -1; // Không chọn mục nào mặc định
                cboLoaiVanBanDen.SelectedIndex = -1;
                cboNoiBanHanhDen.SelectedIndex = -1;

                // Reset giá trị các trường nhập liệu
                txtSoDen.Clear();
                txtSoKyHieuDen.Clear();
                txtSoTrangDen.Clear();
                txtNguoiDuyetDen.Clear();
                txtNguoiNhanDen.Clear();
                txtNguoiKyDen.Clear();
                txtNoiDungDen.Clear();
                txtTrichYeuDen.Clear();
                txtDinhKemFileDen.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //------------------------------DANH SACH VAN BAN DEN----------------------------------
        private void InitializeDataGridViewVanBanDen()
        {
            // Xóa hết các cột và dòng hiện tại
            tblDanhSachVanBanDen.Columns.Clear();
            tblDanhSachVanBanDen.Rows.Clear();

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblDanhSachVanBanDen.Columns.Add(colSTT);

            // Thiết lập cột Số văn bản
            DataGridViewTextBoxColumn colSoVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Văn Bản",
                Name = "SoVanBan",
                ReadOnly = true,
                Width = 120
            };
            tblDanhSachVanBanDen.Columns.Add(colSoVanBan);

            // Thiết lập cột Loại văn bản
            DataGridViewTextBoxColumn colLoaiVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại Văn Bản",
                Name = "LoaiVanBan",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDen.Columns.Add(colLoaiVanBan);

            // Thiết lập cột Số ký hiệu
            DataGridViewTextBoxColumn colSoKyHieu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Ký Hiệu",
                Name = "SoKyHieu",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDen.Columns.Add(colSoKyHieu);

            // Thiết lập cột Số đến
            DataGridViewTextBoxColumn colSoDen = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Đến",
                Name = "SoDen",
                ReadOnly = true,
                Width = 100
            };
            tblDanhSachVanBanDen.Columns.Add(colSoDen);

            // Thiết lập cột Ngày ban hành
            DataGridViewTextBoxColumn colNgayBanHanh = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Ban Hành",
                Name = "NgayBanHanh",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDen.Columns.Add(colNgayBanHanh);

            // Thiết lập cột Ngày đến
            DataGridViewTextBoxColumn colNgayDen = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Đến",
                Name = "NgayDen",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDen.Columns.Add(colNgayDen);

            // Thiết lập cột Đơn vị gửi
            DataGridViewTextBoxColumn colDonViGui = new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn Vị Gửi",
                Name = "DonViGui",
                ReadOnly = true,
                Width = 200
            };
            tblDanhSachVanBanDen.Columns.Add(colDonViGui);

            // Thiết lập cột Trích yếu
            DataGridViewTextBoxColumn colTrichYeu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Trích Yếu",
                Name = "TrichYeu",
                ReadOnly = true,
                Width = 300
            };
            tblDanhSachVanBanDen.Columns.Add(colTrichYeu);

            // Thiết lập DataGridView
            tblDanhSachVanBanDen.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblDanhSachVanBanDen.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
            tblDanhSachVanBanDen.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột
            tblDanhSachVanBanDen.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn toàn bộ dòng khi click
            tblDanhSachVanBanDen.MultiSelect = false; // Không cho phép chọn nhiều dòng
            tblDanhSachVanBanDen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
        }
        private void HienThiDanhSachVanBanDen()
        {
            InitializeDataGridViewVanBanDen();
            try
            {
                btnLuuDSDen.Enabled = false;
                btnLuuDSDen.BackColor = Color.Gray;
                VanBanDenController dsden = new VanBanDenController();
                if (cboNamDen.SelectedItem.ToString() == "Tất cả")
                {
                    dsvbden = dsden.HienThiTatCaVanBanDen();
                }
                else
                {
                    int nam = int.Parse(cboNamDen.SelectedItem.ToString());
                    dsvbden = dsden.HienThiDanhSachVanBanDen(nam);
                }

                DataGridViewRowCollection danhSachDen = tblDanhSachVanBanDen.Rows;

                // Xóa tất cả dòng trong bảng trước khi thêm mới
                danhSachDen.Clear();

                for (int i = 0; i < dsvbden.Count; i++)
                {
                    VanBanDenModel vb = dsvbden[i];
                    string soVanBan = vb.TenSo;
                    string loaiVanBan = vb.LoaiVanBan;
                    string soKyHieu = vb.SoKyHieu;
                    int soDen = vb.SoDen;
                    DateTime ngayBanHanh = vb.NgayBanHanh.Date; // Lấy chỉ ngày
                    DateTime ngayDen = vb.NgayDen.Date; // Lấy chỉ ngày
                    string donViGui = vb.NoiBanHanh;
                    string trichYeu = vb.TrichYeu;

                    // Thêm một dòng vào bảng
                    danhSachDen.Add(new DataGridViewRow
                    {
                        Cells =
                {
                    new DataGridViewTextBoxCell { Value = i + 1 },
                    new DataGridViewTextBoxCell { Value = soVanBan },
                    new DataGridViewTextBoxCell { Value = loaiVanBan },
                    new DataGridViewTextBoxCell { Value = soKyHieu },
                    new DataGridViewTextBoxCell { Value = soDen },
                    new DataGridViewTextBoxCell { Value = ngayBanHanh.ToShortDateString() }, // Hiển thị ngày
                    new DataGridViewTextBoxCell { Value = ngayDen.ToShortDateString() }, // Hiển thị ngày
                    new DataGridViewTextBoxCell { Value = donViGui },
                    new DataGridViewTextBoxCell { Value = trichYeu }
                }
                    });
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        //Van ban di 
        public void KhoiTaoVanBanDi()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                dateNgayBanHanhDi.Value = currentDate;

                // Vô hiệu hóa các nút chức năng

                btnXuatExcelVanBanDi.Enabled = false;
                btnXuatExcelVanBanDi.BackColor = Color.Gray;
                btnXoaVanBanDi.Enabled = false;
                btnXoaVanBanDi.BackColor = Color.Gray;
                btnLuuVanBanDi.Enabled = false;
                btnLuuVanBanDi.BackColor = Color.Gray;

                // Lấy danh sách loại văn bản
                var vbController1 = new VanBanDiController();
                var danhSachLoai = vbController1.HienThiLoaiVanBan();
                cboLoaiVanBanDi.Items.Clear();
                foreach (string s in danhSachLoai)
                {
                    cboLoaiVanBanDi.Items.Add(s);
                }

                // Lấy danh sách số văn bản đi
                var vbController2 = new VanBanDiController();
                var danhSachSo = vbController2.HienThiSoVanBan();
                cboSoVanBanDi.Items.Clear();
                foreach (string x in danhSachSo)
                {
                    cboSoVanBanDi.Items.Add(x);
                }

                // Đặt giá trị mặc định cho các combobox
                cboSoVanBanDi.SelectedIndex = -1;
                cboLoaiVanBanDi.SelectedIndex = -1;

                // Đặt lại giá trị các trường nhập liệu (textbox)
                txtSoDi.Clear();
                txtSoKiHieuDi.Clear();
                txtSoLuongBanDi.Clear();
                txtSoTrangDi.Clear();
                txtNguoiGuiDi.Clear();
                txtNguoiKyDi.Clear();
                txtNguoiDuyetDi.Clear();
                txtNoiNhanDi.Clear();
                DateTime today = DateTime.Now.Date;
                dateNgayBanHanhDi.Value = today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //------------------------------DANH SACH VAN BAN DI----------------------------------
        private void InitializeDataGridViewVanBanDi()
        {
            // Xóa hết các cột và dòng hiện tại
            tblDanhSachVanBanDi.Columns.Clear();
            tblDanhSachVanBanDi.Rows.Clear();

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblDanhSachVanBanDi.Columns.Add(colSTT);
            // Thiết lập cột Số văn bản
            DataGridViewTextBoxColumn colSoVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Văn Bản",
                Name = "SoVanBan",
                ReadOnly = true,
                Width = 120
            };
            tblDanhSachVanBanDi.Columns.Add(colSoVanBan);

            // Thiết lập cột Loại văn bản
            DataGridViewTextBoxColumn colLoaiVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại Văn Bản",
                Name = "LoaiVanBan",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDi.Columns.Add(colLoaiVanBan);

            // Thiết lập cột Số ký hiệu
            DataGridViewTextBoxColumn colSoKyHieu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Ký Hiệu",
                Name = "SoKyHieu",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDi.Columns.Add(colSoKyHieu);

            // Thiết lập cột Số
            DataGridViewTextBoxColumn colSo = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số",
                Name = "So",
                ReadOnly = true,
                Width = 100
            };
            tblDanhSachVanBanDi.Columns.Add(colSo);

            // Thiết lập cột Ngày ban hành
            DataGridViewTextBoxColumn colNgayBanHanh = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Ban Hành",
                Name = "NgayBanHanh",
                ReadOnly = true,
                Width = 150
            };
            tblDanhSachVanBanDi.Columns.Add(colNgayBanHanh);

            // Thiết lập cột Nơi nhận
            DataGridViewTextBoxColumn colNoiNhan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nơi Nhận",
                Name = "NoiNhan",
                ReadOnly = true,
                Width = 200
            };
            tblDanhSachVanBanDi.Columns.Add(colNoiNhan);

            // Thiết lập cột Trích yếu
            DataGridViewTextBoxColumn colTrichYeu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Trích Yếu",
                Name = "TrichYeu",
                ReadOnly = true,
                Width = 300
            };
            tblDanhSachVanBanDi.Columns.Add(colTrichYeu);

            // Thiết lập DataGridView
            tblDanhSachVanBanDi.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblDanhSachVanBanDi.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
            tblDanhSachVanBanDi.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột
            tblDanhSachVanBanDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn toàn bộ dòng khi click
            tblDanhSachVanBanDi.MultiSelect = false; // Không cho phép chọn nhiều dòng
            tblDanhSachVanBanDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
        }



        public void HienThiDanhSachVanBanDi()
        {
            InitializeDataGridViewVanBanDi();
            btnLuuDSDi.Enabled = false;
            btnLuuDSDi.BackColor = Color.Gray;
            try
            {
                // Vô hiệu hóa nút lưu (nếu cần)
                btnLuuDSDi.Enabled = false;

                // Lấy danh sách văn bản đi
                VanBanDiController vbDiController = new VanBanDiController();

                if (cboNamDi.SelectedItem.ToString() == "Tất cả")
                {
                    dsvbdi = vbDiController.HienThiTatCaVanBanDi();
                }
                else
                {
                    int nam = int.Parse(cboNamDi.SelectedItem.ToString());
                    dsvbdi = vbDiController.HienThiDanhSachVanBanDi(nam);
                }

                // Lấy mô hình của bảng
                DataGridViewRowCollection danhSachDi = tblDanhSachVanBanDi.Rows;

                // Xóa toàn bộ dữ liệu trong bảng
                danhSachDi.Clear();

                // Duyệt qua danh sách và thêm vào bảng
                for (int i = 0; i < dsvbdi.Count; i++)
                {
                    VanBanDiModel vb = dsvbdi[i];
                    string soVanBan = vb.TenSo;
                    string loaiVanBan = vb.LoaiVanBan;
                    string soKyHieu = vb.SoKyHieu;
                    int soDi = vb.SoDi;
                    DateTime ngayBanHanh = vb.NgayBanHanh.Date;
                    string noiNhan = vb.NoiNhan;
                    string trichYeu = vb.TrichYeu;

                    // Thêm một dòng vào bảng
                    danhSachDi.Add(new DataGridViewRow
                    {
                        Cells =
                {
                    new DataGridViewTextBoxCell { Value = i + 1 },
                    new DataGridViewTextBoxCell { Value = soVanBan },
                    new DataGridViewTextBoxCell { Value = loaiVanBan },
                    new DataGridViewTextBoxCell { Value = soKyHieu },
                    new DataGridViewTextBoxCell { Value = soDi },
                    new DataGridViewTextBoxCell { Value = ngayBanHanh },
                    new DataGridViewTextBoxCell { Value = noiNhan },
                    new DataGridViewTextBoxCell { Value = trichYeu }
                }
                    });
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------------------Tìm kiếm văn bản đến----------------------------------
        private void InitializeDataGridViewTimKiemVanBanDen()
        {
            // Xóa hết các cột và dòng hiện tại
            tblTimKiemDanhSachVanBanDen.Columns.Clear();
            tblTimKiemDanhSachVanBanDen.Rows.Clear();

            // Thiết lập cột cho bảng
            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số TT",
                Name = "STT",
                ReadOnly = true,
                Width = 100
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colSTT);

            DataGridViewTextBoxColumn colSoVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Văn Bản",
                Name = "SoVanBan",
                ReadOnly = true,
                Width = 120
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colSoVanBan);

            DataGridViewTextBoxColumn colLoaiVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại Văn Bản",
                Name = "LoaiVanBan",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colLoaiVanBan);

            DataGridViewTextBoxColumn colSoKyHieu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Ký Hiệu",
                Name = "SoKyHieu",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colSoKyHieu);

            DataGridViewTextBoxColumn colSoDen = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Đến",
                Name = "SoDen",
                ReadOnly = true,
                Width = 100
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colSoDen);

            DataGridViewTextBoxColumn colNgayBanHanh = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Ban Hành",
                Name = "NgayBanHanh",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colNgayBanHanh);

            DataGridViewTextBoxColumn colNgayDen = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Đến",
                Name = "NgayDen",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colNgayDen);

            DataGridViewTextBoxColumn colDonViGui = new DataGridViewTextBoxColumn
            {
                HeaderText = "Đơn Vị Gửi",
                Name = "DonViGui",
                ReadOnly = true,
                Width = 200
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colDonViGui);

            DataGridViewTextBoxColumn colTrichYeu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Trích Yếu",
                Name = "TrichYeu",
                ReadOnly = true,
                Width = 300
            };
            tblTimKiemDanhSachVanBanDen.Columns.Add(colTrichYeu);

            // Cấu hình DataGridView
            tblTimKiemDanhSachVanBanDen.AllowUserToAddRows = false;
            tblTimKiemDanhSachVanBanDen.AllowUserToDeleteRows = false;
            tblTimKiemDanhSachVanBanDen.AllowUserToOrderColumns = true;
            tblTimKiemDanhSachVanBanDen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tblTimKiemDanhSachVanBanDen.MultiSelect = false;
            tblTimKiemDanhSachVanBanDen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void KhoiTaoTimKiemVanBanDen()
        {
            InitializeDataGridViewTimKiemVanBanDen();
            try
            {
                // Khởi tạo controller
                var vbController = new VanBanDenController();

                // Lấy danh sách số văn bản và thêm vào combobox
                var danhsachso = vbController.HienThiSoVanBan();
                foreach (var x in danhsachso)
                {
                    cboTimKiemSoVanBanDen.Items.Add(x);
                }
                cboTimKiemSoVanBanDen.Items.Add("Tất cả"); // Thêm lựa chọn "Tất cả"
                var vbController1 = new VanBanDenController();
                // Lấy danh sách loại văn bản và thêm vào combobox
                var danhsachloai = vbController1.HienThiLoaiVanBan();
                foreach (var s in danhsachloai)
                {
                    cboTimKiemLoaiVanBanDen.Items.Add(s);
                }
                cboTimKiemLoaiVanBanDen.Items.Add("Tất cả"); // Thêm lựa chọn "Tất cả"

                // Mặc định chọn "Tất cả" cho cả hai combobox
                cboTimKiemSoVanBanDen.SelectedItem = "Tất cả";
                cboTimKiemLoaiVanBanDen.SelectedItem = "Tất cả";

                // Hiển thị dữ liệu theo ngày hiện tại
                DateTime currentDate = DateTime.Now;
                DateTime ngayDenMin = currentDate;
                DateTime ngayDenMax = currentDate;
                HienThiDanhSachVanBanDiTheoNgay(ngayDenMin, ngayDenMax);

                // Làm mới DataGridView
                tblTimKiemDanhSachVanBanDen.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSachVanBanDenTheoNgay(DateTime startDate, DateTime endDate)
        {
            try
            {
                VanBanDenController vbdenContrl = new VanBanDenController();
                // Xóa tất cả dòng trong bảng
                tblTimKiemDanhSachVanBanDen.Rows.Clear();

                // Gọi controller để lấy dữ liệu
                dstimkiemden = vbdenContrl.HienThiVanBanDenTheoNgay(startDate, endDate);

                if (dstimkiemden.Count == 0)
                {

                }
                else
                {
                    // Thêm các dòng vào bảng nếu có dữ liệu
                    for (int i = 0; i < dstimkiemden.Count; i++)
                    {
                        VanBanDenModel vbDen = dstimkiemden[i];
                        tblTimKiemDanhSachVanBanDen.Rows.Add(
                            i + 1,                          // STT
                            vbDen.TenSo,                     // Tên số
                            vbDen.LoaiVanBan,                // Loại văn bản
                            vbDen.SoKyHieu,                  // Số ký hiệu
                            vbDen.SoDen,                     // Số đến
                            vbDen.NgayBanHanh.ToString("dd/MM/yyyy"), // Ngày ban hành
                            vbDen.NgayDen.ToString("dd/MM/yyyy"), // Ngày đến
                            vbDen.NoiBanHanh,                // Đơn vị gửi
                            vbDen.TrichYeu                   // Trích yếu
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------Tìm kiếm văn bản đi-----------------------------------
        private void InitializeDataGridViewTimKiemVanBanDi()
        {
            // Xóa hết các cột và dòng hiện tại
            tblTimKiemDanhSachVanBanDi.Columns.Clear();
            tblTimKiemDanhSachVanBanDi.Rows.Clear();

            DataGridViewTextBoxColumn colSTT = new DataGridViewTextBoxColumn();
            colSTT.HeaderText = "Số TT";
            colSTT.Name = "STT";
            colSTT.ReadOnly = true;  // Không cho phép chỉnh sửa số thứ tự
            colSTT.Width = 100;
            tblTimKiemDanhSachVanBanDi.Columns.Add(colSTT);
            // Thiết lập cột Số văn bản
            DataGridViewTextBoxColumn colSoVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Văn Bản",
                Name = "SoVanBan",
                ReadOnly = true,
                Width = 120
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colSoVanBan);

            // Thiết lập cột Loại văn bản
            DataGridViewTextBoxColumn colLoaiVanBan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại Văn Bản",
                Name = "LoaiVanBan",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colLoaiVanBan);

            // Thiết lập cột Số ký hiệu
            DataGridViewTextBoxColumn colSoKyHieu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số Ký Hiệu",
                Name = "SoKyHieu",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colSoKyHieu);

            // Thiết lập cột Số
            DataGridViewTextBoxColumn colSo = new DataGridViewTextBoxColumn
            {
                HeaderText = "Số",
                Name = "So",
                ReadOnly = true,
                Width = 100
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colSo);

            // Thiết lập cột Ngày ban hành
            DataGridViewTextBoxColumn colNgayBanHanh = new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Ban Hành",
                Name = "NgayBanHanh",
                ReadOnly = true,
                Width = 150
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colNgayBanHanh);

            // Thiết lập cột Nơi nhận
            DataGridViewTextBoxColumn colNoiNhan = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nơi Nhận",
                Name = "NoiNhan",
                ReadOnly = true,
                Width = 200
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colNoiNhan);

            // Thiết lập cột Trích yếu
            DataGridViewTextBoxColumn colTrichYeu = new DataGridViewTextBoxColumn
            {
                HeaderText = "Trích Yếu",
                Name = "TrichYeu",
                ReadOnly = true,
                Width = 300
            };
            tblTimKiemDanhSachVanBanDi.Columns.Add(colTrichYeu);

            // Thiết lập DataGridView
            tblTimKiemDanhSachVanBanDi.AllowUserToAddRows = false;  // Không cho phép thêm dòng mới khi không có dữ liệu
            tblTimKiemDanhSachVanBanDi.AllowUserToDeleteRows = false; // Không cho phép xóa dòng
            tblTimKiemDanhSachVanBanDi.AllowUserToOrderColumns = true; // Cho phép sắp xếp các cột
            tblTimKiemDanhSachVanBanDi.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chọn toàn bộ dòng khi click
            tblTimKiemDanhSachVanBanDi.MultiSelect = false; // Không cho phép chọn nhiều dòng
            tblTimKiemDanhSachVanBanDi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột
        }
        private void KhoiTaoTimKiemVanBanDi()
        {
            try
            {
                InitializeDataGridViewTimKiemVanBanDi();
                VanBanDiController vbController = new VanBanDiController();
                var danhsachso = vbController.HienThiSoVanBan();
                foreach (var x in danhsachso)
                {
                    cboTimKiemSoVanBanDi.Items.Add(x);
                }

                VanBanDiController vbController1 = new VanBanDiController();
                var danhsachloai = vbController1.HienThiLoaiVanBan();
                foreach (var s in danhsachloai)
                {
                    cboTimKiemLoaiVanBanDi.Items.Add(s);
                }

                // Thêm các phần tử vào ComboBox
                cboTimKiemLoaiVanBanDi.Items.Add("Tất cả");
                cboTimKiemSoVanBanDi.Items.Add("Tất cả");

                // Chọn mục "Tất cả" trong ComboBox
                cboTimKiemLoaiVanBanDi.SelectedItem = "Tất cả";
                cboTimKiemSoVanBanDi.SelectedItem = "Tất cả";

                DateTime currentDate = DateTime.Now;
                DateTime ngaybanmin = currentDate;
                DateTime ngaybanmax = currentDate;

                // Khởi tạo controller và tìm kiếm theo ngày
                HienThiDanhSachVanBanDiTheoNgay(ngaybanmin, ngaybanmax);

                // Làm mới bảng hiển thị
                tblTimKiemDanhSachVanBanDi.Refresh();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HienThiDanhSachVanBanDiTheoNgay(DateTime start, DateTime end)
        {
            try
            {
                // Xóa tất cả dòng trong bảng
                tblTimKiemDanhSachVanBanDi.Rows.Clear();

                // Gọi controller để lấy dữ liệu
                VanBanDiController vbienContrl = new VanBanDiController();
                dstimkiemdi = vbienContrl.HienThiVanBanDiTheoNgay(start, end);

                if (dstimkiemdi.Count == 0)
                {

                }
                else
                {
                    // Thêm các dòng vào bảng nếu có dữ liệu
                    for (int i = 0; i < dstimkiemdi.Count; i++)
                    {
                        VanBanDiModel vbDi = dstimkiemdi[i];
                        tblTimKiemDanhSachVanBanDi.Rows.Add(
                            i + 1,                          // STT
                            vbDi.TenSo,                     // Tên số
                            vbDi.LoaiVanBan,                // Loại văn bản
                            vbDi.SoKyHieu,                  // Số ký hiệu
                            vbDi.SoDi,                      // Số đi
                            vbDi.NgayBanHanh.ToString("dd/MM/yyyy"),  // Ngày ban hành
                            vbDi.NoiNhan,                   // Nơi nhận
                            vbDi.TrichYeu                   // Trích yếu
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        // --------------------------   PHÒNG BAN ---------------------------------------------- 
        // Khởi tạo bảng
        public void initTablePhongBan()
        {
            // Đặt tiêu đề cột
            dataGridViewPhongBan.Columns.Add("STT", "STT");
            dataGridViewPhongBan.Columns.Add("TenPhongBan", "TÊN PHÒNG BAN");
            dataGridViewPhongBan.Columns.Add("MaPhongBan", "MÃ PHÒNG BAN");

            // Ẩn cột "MÃ PHÒNG BAN"
            dataGridViewPhongBan.Columns["MaPhongBan"].Visible = false;

            // Đặt chế độ không chỉnh sửa trực tiếp trong bảng
            dataGridViewPhongBan.AllowUserToAddRows = false;
            dataGridViewPhongBan.AllowUserToDeleteRows = false;
            dataGridViewPhongBan.ReadOnly = false;

            // Đặt kích thước cột theo tỷ lệ phần trăm
            AdjustColumnWidths();
        }
        private void dataGridViewPhongBan_Resize(object sender, EventArgs e)
        {
            AdjustColumnWidths(); // Cập nhật lại kích thước cột khi kích thước DataGridView thay đổi
        }

        // Hàm điều chỉnh kích thước cột theo tỷ lệ phần trăm
        public void AdjustColumnWidths()
        {
            // Lấy chiều rộng của DataGridView
            int totalWidth = dataGridViewPhongBan.Width;

            // Tính toán kích thước của từng cột theo tỷ lệ phần trăm
            int sttWidth = totalWidth * 3 / 10; // 3 phần
            int tenPhongBanWidth = totalWidth * 7 / 10; // 7 phần

            // Áp dụng kích thước cho các cột
            dataGridViewPhongBan.Columns["STT"].Width = sttWidth;
            dataGridViewPhongBan.Columns["TenPhongBan"].Width = tenPhongBanWidth;
        }
        // Điền dữ liệu vào bảng
        public void fillDataPhongBan()
        {

            List<PhongBan> lst = null;
            try
            {
                lst = new PhongBanController().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                return;
            }

            // Xóa dữ liệu cũ trong bảng
            dataGridViewPhongBan.Rows.Clear();

            // Thêm từng dòng vào DataGridView
            for (int i = 0; i < lst.Count; i++)
            {
                string tenPhongBan = lst[i].GetTenPhongBan() ?? ""; // Thay thế null bằng chuỗi rỗng
                string maPhongBan = lst[i].GetMaPhongBan() ?? ""; // Thay thế null bằng chuỗi rỗng

                dataGridViewPhongBan.Rows.Add(i + 1, tenPhongBan, maPhongBan);
            }

        }

        private void picThemPhongBan_Click(object sender, EventArgs e)
        { // Tạo dòng mới với số thứ tự tự động tăng
            int rowCount = dataGridViewPhongBan.Rows.Count; // Sử dụng đúng đối tượng DataGridView
            dataGridViewPhongBan.Rows.Add(rowCount + 1, "", "null"); // Thêm dòng mới với số thứ tự tự động tăng

        }


        private void picLuu_Click(object sender, EventArgs e)
        {
            if (dataGridViewPhongBan.Rows.Count == 0)
            {
                initTablePhongBan();
            }
            PhongBanController controller = new PhongBanController();

            // Duyệt qua các dòng trong bảng
            for (int i = 0; i < dataGridViewPhongBan.Rows.Count; i++)
            {
                // Lấy dữ liệu từ các cột
                string tenPhongBan = dataGridViewPhongBan.Rows[i].Cells[1].Value.ToString(); // Cột tên phòng ban
                string maPhongBan = dataGridViewPhongBan.Rows[i].Cells[2].Value.ToString(); // Cột mã phòng ban (ẩn)

                // Kiểm tra dữ liệu rỗng
                if (string.IsNullOrWhiteSpace(tenPhongBan))
                {
                    MessageBox.Show("Vui lòng điền tên phòng ban ở dòng " + (i + 1) + ".");
                    return;
                }

                // Kiểm tra trùng lặp trong bảng
                for (int j = 0; j < dataGridViewPhongBan.Rows.Count; j++)
                {
                    if (i != j) // Không so sánh với chính dòng hiện tại
                    {
                        string tenPhongBanKhac = dataGridViewPhongBan.Rows[j].Cells[1].Value.ToString();
                        if (tenPhongBan.Equals(tenPhongBanKhac, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Dữ liệu nhập ở dòng " + (i + 1) + " trùng với dòng " + (j + 1) + " trong bảng.");
                            return;
                        }
                    }
                }

                try
                {
                    if (string.IsNullOrWhiteSpace(maPhongBan) || maPhongBan == "null")
                    {
                        // Thêm mới nếu mã phòng ban không tồn tại
                        bool isSuccess = controller.ThemPhongBan(tenPhongBan);
                        if (!isSuccess)
                        {
                            MessageBox.Show("Thêm mới phòng ban thất bại: " + tenPhongBan);
                        }
                    }
                    else
                    {
                        // Cập nhật nếu mã phòng ban đã tồn tại
                        bool isSuccess = controller.SuaPhongBan(maPhongBan, tenPhongBan);
                        if (!isSuccess)
                        {
                            MessageBox.Show("Cập nhật phòng ban thất bại: " + tenPhongBan);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu phòng: " + tenPhongBan);
                    // Log lỗi nếu cần
                    Console.WriteLine(ex.Message);
                }
            }

            // Xóa dữ liệu hiện tại trên giao diện
            dataGridViewPhongBan.Rows.Clear();
            fillDataPhongBan(); // Nạp lại dữ liệu mới từ CSDL
            LoadComboboxData();
            MessageBox.Show("Lưu toàn bộ dữ liệu thành công.");
        }



        // ---------------------- VĂN BẢN NỘI BỘ ------------------------------



        private void ThemVBNB_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các trường nhập liệu
            txtSoKyHieu.Text = string.Empty;
            txtTenVanBan.Text = string.Empty;
            txtNguoiNhan.Text = string.Empty;
            txtNguoiKy.Text = string.Empty;
            txtNguoiDuyet.Text = string.Empty;
            txtTrichYeu.Text = string.Empty;
            txtNoiDung.Text = string.Empty;

            // Đặt lại ngày hiện tại cho trường Ngày ban hành
            dateNgayBanHanh.Value = DateTime.Now;

            // Đặt giá trị mặc định cho các combobox
            if (cmbLoaiBanHanh.Items.Count > 0) cmbLoaiBanHanh.SelectedIndex = 0;
            if (cmbPhongBanHanh.Items.Count > 0) cmbPhongBanHanh.SelectedIndex = 0;
            if (cmbPhongBanNhan.Items.Count > 0) cmbPhongBanNhan.SelectedIndex = 0;

            // Khôi phục trạng thái hiển thị và kích hoạt của txtSoKyHieu
            txtSoKyHieu.Visible = true;
            txtSoKyHieu.Enabled = true;

            // Đặt con trỏ lại trường "Số ký hiệu"
            txtSoKyHieu.Focus();
        }



        public void LoadComboboxData()
        {
            try
            {
                VanBanNoiBoController controller = new VanBanNoiBoController();

                // Load dữ liệu cho cmbLoaiBanHanh
                List<string> loaiVanBanList = controller.GetLoaiVanBan();
                cmbLoaiBanHanh.Items.Clear(); // Xóa dữ liệu cũ
                foreach (string loaiVanBan in loaiVanBanList)
                {
                    cmbLoaiBanHanh.Items.Add(loaiVanBan); // Thêm từng mục vào combobox
                }

                // Load dữ liệu cho cmbPhongBanHanh và cmbPhongBanNhan
                List<string> phongBanList = controller.GetPhongBan();
                cmbPhongBanHanh.Items.Clear();
                cmbPhongBanNhan.Items.Clear();
                foreach (string phongBan in phongBanList)
                {
                    cmbPhongBanHanh.Items.Add(phongBan);
                    cmbPhongBanNhan.Items.Add(phongBan); // Phòng nhận dùng cùng dữ liệu
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Lỗi khi tải dữ liệu lên Combobox: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khởi tạo bảng và cột tiêu đề
        public void InitTableVanBanNoiBo()
        {
            // Đặt tiêu đề các cột
            dataGridViewVBNB.Columns.Add("SoKyHieu", "SỐ KÝ HIỆU");
            dataGridViewVBNB.Columns.Add("TenVanBan", "TÊN VĂN BẢN");
            dataGridViewVBNB.Columns.Add("NgayBanHanh", "NGÀY BAN HÀNH");
            dataGridViewVBNB.Columns.Add("LoaiBanHanh", "LOẠI BAN HÀNH");
            dataGridViewVBNB.Columns.Add("PhongBanHanh", "PHÒNG BAN HÀNH");
            dataGridViewVBNB.Columns.Add("PhongNhan", "PHÒNG BAN NHẬN");
            dataGridViewVBNB.Columns.Add("NguoiNhan", "NGƯỜI NHẬN");
            dataGridViewVBNB.Columns.Add("NguoiKy", "NGƯỜI KÝ");
            dataGridViewVBNB.Columns.Add("NguoiDuyet", "NGƯỜI DUYỆT");
            dataGridViewVBNB.Columns.Add("TrichYeu", "TRÍCH YẾU");
            dataGridViewVBNB.Columns.Add("NoiDung", "NỘI DUNG");

            // Đặt chế độ không chỉnh sửa trực tiếp trong bảng
            dataGridViewVBNB.AllowUserToAddRows = false;
            dataGridViewVBNB.AllowUserToDeleteRows = false;
            dataGridViewVBNB.ReadOnly = true;
        }

        // Điền dữ liệu vào bảng
        public void FillDataVanBanNoiBo()
        {
            List<VanBanNoiBo> lst = null;

            try
            {
                // Lấy dữ liệu từ Controller
                lst = new VanBanNoiBoController().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xóa dữ liệu cũ trong bảng
            dataGridViewVBNB.Rows.Clear();

            // Thêm từng dòng vào DataGridView
            for (int i = 0; i < lst.Count; i++)
            {
                VanBanNoiBo vb = lst[i];

                dataGridViewVBNB.Rows.Add(
                    vb.SoKyHieu ?? "", // Xử lý null thành chuỗi rỗng
                    vb.TenVanBan ?? "",
                    vb.NgayBanHanh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng
                    vb.LoaiBanHanh ?? "",
                    vb.PhongBanHanh ?? "",
                    vb.PhongNhan ?? "",
                    vb.NguoiNhan ?? "",
                    vb.NguoiKy ?? "",
                    vb.NguoiDuyet ?? "",
                    vb.TrichYeu ?? "",
                    vb.NoiDung ?? ""
                );
            }
        }


        public void FillDataVanBanNoiBo1()
        {
            List<VanBanNoiBo> lst = null;

            try
            {
                // Lấy dữ liệu từ Controller
                lst = new VanBanNoiBoController().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xóa dữ liệu cũ trong bảng
            dataGridViewVBNB1.Rows.Clear();

            // Thêm từng dòng vào DataGridView
            for (int i = 0; i < lst.Count; i++)
            {
                VanBanNoiBo vb = lst[i];

                dataGridViewVBNB1.Rows.Add(
                    vb.SoKyHieu ?? "", // Xử lý null thành chuỗi rỗng
                    vb.TenVanBan ?? "",
                    vb.NgayBanHanh.ToString("yyyy-MM-dd"), // Định dạng ngày tháng
                    vb.LoaiBanHanh ?? "",
                    vb.PhongBanHanh ?? "",
                    vb.PhongNhan ?? "",
                    vb.NguoiNhan ?? "",
                    vb.NguoiKy ?? "",
                    vb.NguoiDuyet ?? "",
                    vb.TrichYeu ?? "",
                    vb.NoiDung ?? ""
                );
            }
        }


        // ------------------------- TÀI LIỆU ----------------------------

        public void initTableTaiLieu()
        {
            // Đặt tên các cột
            dataGridViewTaiLieu.Columns.Add("MaTaiLieu", "Mã tài liệu");
            dataGridViewTaiLieu.Columns.Add("TenTaiLieu", "Tên tài liệu");
            dataGridViewTaiLieu.Columns.Add("NgayTao", "Ngày tạo");
            dataGridViewTaiLieu.Columns.Add("KichCo", "Kích cỡ");
            dataGridViewTaiLieu.Columns.Add("Loai", "Loại");
            dataGridViewTaiLieu.Columns.Add("DuongDan", "Đường dẫn");

            // Ẩn cột "Mã tài liệu"
            dataGridViewTaiLieu.Columns["MaTaiLieu"].Visible = false;

            // Ẩn cột "Đường dẫn"
            dataGridViewTaiLieu.Columns["DuongDan"].Visible = false;

            // Thiết lập không cho phép thêm và xóa dòng
            dataGridViewTaiLieu.AllowUserToAddRows = false;
            dataGridViewTaiLieu.AllowUserToDeleteRows = false;

            // Đặt chế độ AutoSizeMode là Fill cho các cột cần chiếm diện tích đều
            dataGridViewTaiLieu.Columns["TenTaiLieu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTaiLieu.Columns["NgayTao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTaiLieu.Columns["KichCo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTaiLieu.Columns["Loai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Nếu muốn các cột có kích thước cố định có thể để AutoSizeMode là AllCells
            // dataGridViewTaiLieu.Columns["TenTaiLieu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        public void FillDataTaiLieu()
        {
            List<TaiLieu> lst = null;

            try
            {
                // Lấy danh sách tài liệu từ Controller
                lst = new TaiLieuController().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xóa dữ liệu cũ trong DataGridView
            dataGridViewTaiLieu.Rows.Clear();

            // Thêm từng dòng vào DataGridView
            foreach (var tl in lst)
            {
                string ngayTao = string.Empty;
                if (DateTime.TryParse(tl.GetNgayTao(), out DateTime parsedDate))
                {
                    ngayTao = parsedDate.ToString("dd/MM/yyyy");
                }

                dataGridViewTaiLieu.Rows.Add(
                    tl.GetMaTL() ?? "",               // Xử lý null thành chuỗi rỗng
                    tl.GetTenTL() ?? "",
                    ngayTao,                          // Nếu không phải DateTime hợp lệ, để trống
                    tl.GetKichCo() ?? "",
                    tl.GetLoai() ?? "",
                    tl.GetDuongDan() ?? ""
                );
            }
        }



        private void TaiLaiVBNB_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các trường nhập liệu
            txtSoKyHieu.Text = string.Empty;
            txtTenVanBan.Text = string.Empty;
            txtNguoiNhan.Text = string.Empty;
            txtNguoiKy.Text = string.Empty;
            txtNguoiDuyet.Text = string.Empty;
            txtTrichYeu.Text = string.Empty;
            txtNoiDung.Text = string.Empty;

            // Đặt lại ngày hiện tại cho trường Ngày ban hành
            dateNgayBanHanh.Value = DateTime.Now; // Hoặc bạn có thể để null nếu trường đó có thể nhận giá trị null

            // Đặt giá trị mặc định cho các combobox
            cmbLoaiBanHanh.SelectedIndex = 0;
            cmbPhongBanHanh.SelectedIndex = 0;
            cmbPhongBanNhan.SelectedIndex = 0;

            // Thông báo (nếu cần)
            MessageBox.Show("Các trường đã được đặt lại!");
        }




        private bool isEditing = false;
        private void LuuVBNB_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy tất cả các hàng được chọn
                var selectedRows = dataGridViewTaiLieu.SelectedRows;

                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một tài liệu.");
                    return;
                }

                string soKyHieu = txtSoKyHieu.Text;
                string tenVanBan = txtTenVanBan.Text;
                DateTime? ngayBanHanh = dateNgayBanHanh.Value; // Nếu cần, có thể kiểm tra null với kiểu dữ liệu Nullable
                string tenLoaiBanHanh = cmbLoaiBanHanh.SelectedItem.ToString();
                string tenPhongBanHanh = cmbPhongBanHanh.SelectedItem.ToString();
                string tenPhongBanNhan = cmbPhongBanNhan.SelectedItem.ToString();
                string nguoiNhan = txtNguoiNhan.Text;
                string nguoiKy = txtNguoiKy.Text;
                string nguoiDuyet = txtNguoiDuyet.Text;
                string trichYeu = txtTrichYeu.Text;
                string noiDung = txtNoiDung.Text;

                VanBanNoiBoController controller = new VanBanNoiBoController();

                // Kiểm tra các trường nhập liệu
                if (string.IsNullOrEmpty(soKyHieu))
                {
                    MessageBox.Show("Vui lòng nhập số ký hiệu.");
                    txtSoKyHieu.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tenVanBan))
                {
                    MessageBox.Show("Vui lòng nhập tên văn bản.");
                    txtTenVanBan.Focus();
                    return;
                }

                if (!ngayBanHanh.HasValue)
                {
                    MessageBox.Show("Vui lòng chọn ngày ban hành.");
                    dateNgayBanHanh.Focus();
                    return;
                }

                if (!isEditing && controller.KiemTraSoKyHieuTonTai(soKyHieu))
                {
                    MessageBox.Show("Số ký hiệu đã tồn tại. Vui lòng nhập số ký hiệu khác.");
                    txtSoKyHieu.Focus();
                    return;
                }

                string maLoaiBanHanh = controller.LayMaLoaiVanBan(tenLoaiBanHanh);
                string maPhongBanHanh = controller.LayMaPhongBan(tenPhongBanHanh);
                string maPhongBanNhan = controller.LayMaPhongBan(tenPhongBanNhan);

                // Duyệt qua từng hàng được chọn
                bool success = true;
                foreach (DataGridViewRow row in selectedRows)
                {
                    int maTL = Convert.ToInt32(row.Cells[0].Value); // Lấy giá trị mã tài liệu từ bảng

                    if (isEditing)
                    {
                        // Gọi hàm cập nhật
                        if (!controller.CapNhatVanBanNoiBo(soKyHieu, tenVanBan, ngayBanHanh.Value, maLoaiBanHanh, maPhongBanHanh, maPhongBanNhan, nguoiNhan, nguoiKy, nguoiDuyet, trichYeu, noiDung, maTL))
                        {
                            success = false;
                        }
                    }
                    else
                    {
                        // Gọi hàm thêm mới
                        if (!controller.ThemVanBanNoiBo(soKyHieu, tenVanBan, ngayBanHanh.Value, maLoaiBanHanh, maPhongBanHanh, maPhongBanNhan, nguoiNhan, nguoiKy, nguoiDuyet, trichYeu, noiDung, maTL))
                        {
                            success = false;
                        }
                    }
                }

                // Hiển thị thông báo thành công hoặc thất bại
                if (success)
                {
                    MessageBox.Show((isEditing ? "Cập nhật" : "Thêm") + " thành công.");
                    isEditing = false; // Reset trạng thái
                    FillDataVanBanNoiBo(); // Cập nhật lại dữ liệu
                }
                else
                {
                    MessageBox.Show((isEditing ? "Cập nhật" : "Thêm") + " thất bại cho một hoặc nhiều tài liệu.");
                }
            }
            catch (Exception ex) { MessageBox.Show("Loi" + ex.Message); }


        }
        private static string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            Uri fullUri = new Uri(fullPath);
            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);

            return Uri.UnescapeDataString(relativeUri.ToString().Replace('/', '\\'));
        }

        private void btnDinhKem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thư mục gốc dự án (lùi lên 3 cấp)
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                // Thư mục VanBanNoiBo
                string allowedFolder = Path.Combine(projectRoot, "VanBanNoiBo");

                // Kiểm tra nếu thư mục VanBanNoiBo không tồn tại
                if (!Directory.Exists(allowedFolder))
                {
                    MessageBox.Show("Thư mục VanBanNoiBo không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Khởi tạo hộp thoại chọn file
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Tất cả các tệp (*.*)|*.*",
                    Title = "Chọn tệp đính kèm",
                    InitialDirectory = allowedFolder // Thiết lập thư mục mặc định
                };

                // Hiển thị hộp thoại
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string absolutePath = fileDialog.FileName;

                    // Kiểm tra xem tệp có nằm trong thư mục VanBanNoiBo không
                    if (!absolutePath.StartsWith(allowedFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Tệp đã chọn không nằm trong thư mục VanBanNoiBo của dự án.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Chuyển đổi sang đường dẫn tương đối
                    string relativePath = GetRelativePath(projectRoot, absolutePath).Replace("\\", "/");

                    // Lấy thông tin tài liệu
                    string tenTL = Path.GetFileName(absolutePath); // Tên tệp tin
                    DateTime ngayTao = DateTime.Now; // Ngày tạo (hiện tại)
                    string kichCo = new FileInfo(absolutePath).Length.ToString(); // Kích thước file
                    string loaiTL = Path.GetExtension(absolutePath).TrimStart('.'); // Phần mở rộng file

                    // Kiểm tra định dạng file hợp lệ
                    if (string.IsNullOrEmpty(loaiTL))
                    {
                        MessageBox.Show("Tệp tin không có phần mở rộng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thực hiện thêm tài liệu vào cơ sở dữ liệu
                    TaiLieuController controller = new TaiLieuController();
                    if (controller.ThemTaiLieu(tenTL, ngayTao, kichCo, loaiTL, relativePath))
                    {
                        MessageBox.Show("Đính kèm tệp tin thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDataTaiLieu(); // Cập nhật lại danh sách tài liệu
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra khi tải lên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            if (dataGridViewTaiLieu.SelectedRows.Count > 0)
            {
                // Lấy đường dẫn từ cột thứ 6 (index 5)
                int rowIndex = dataGridViewTaiLieu.SelectedRows[0].Index;
                string duongDanFile = dataGridViewTaiLieu.Rows[rowIndex].Cells[5].Value?.ToString();

                if (!string.IsNullOrEmpty(duongDanFile))
                {
                    // Chuyển đường dẫn tương đối thành tuyệt đối
                    string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                    string fullPath = Path.Combine(projectRoot, duongDanFile);

                    FileInfo fileTaiXuong = new FileInfo(fullPath);
                    if (fileTaiXuong.Exists)
                    {
                        try
                        {
                            // Mở tài liệu bằng System.Diagnostics.Process
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = fileTaiXuong.FullName,
                                UseShellExecute = true // Dùng shell mặc định của hệ thống để mở tệp
                            });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể mở tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // In ra đường dẫn tuyệt đối để kiểm tra
                        MessageBox.Show("Tệp không tồn tại: " + fileTaiXuong.FullName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đường dẫn tài liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnXoaFile_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dataGridViewTaiLieu.SelectedRows.Count > 0)
            {
                // Lấy giá trị từ cột đầu tiên (index 0) của dòng được chọn
                int rowIndex = dataGridViewTaiLieu.SelectedRows[0].Index;
                string maTaiLieu = dataGridViewTaiLieu.Rows[rowIndex].Cells[0].Value?.ToString();

                if (!string.IsNullOrEmpty(maTaiLieu))
                {
                    try
                    {
                        // Gọi controller để xóa tài liệu
                        TaiLieuController controller = new TaiLieuController();
                        if (controller.XoaFile(maTaiLieu))
                        {
                            MessageBox.Show("Xóa tài liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDataTaiLieu(); // Cập nhật lại danh sách
                        }
                        else
                        {
                            MessageBox.Show("Xóa tài liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không thể lấy mã tài liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private DateTime GetTodayStart()
        {
            DateTime today = DateTime.Today;
            return today.Date; // Lấy ngày hôm nay với giờ 00:00:00
        }

        private DateTime GetTodayEnd()
        {
            DateTime today = DateTime.Today;
            return today.Date.AddDays(1).AddMilliseconds(-1); // Lấy ngày hôm nay với giờ 23:59:59.999
        }

        private DateTime GetWeekStart()
        {
            DateTime today = DateTime.Today;
            int diff = today.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
            {
                diff += 7;
            }
            DateTime weekStart = today.AddDays(-diff);
            return weekStart.Date; // Lấy ngày đầu tuần với giờ 00:00:00
        }

        private DateTime GetWeekEnd()
        {
            DateTime today = DateTime.Today;
            int diff = today.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
            {
                diff += 7;
            }
            DateTime weekEnd = today.AddDays(6 - diff);
            return weekEnd.Date.AddDays(1).AddMilliseconds(-1); // Lấy ngày cuối tuần với giờ 23:59:59.999
        }

        private DateTime GetMonthStart()
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);
            return monthStart.Date; // Ngày đầu tháng
        }

        private DateTime GetMonthEnd()
        {
            DateTime today = DateTime.Today;
            DateTime monthEnd = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            return monthEnd.Date.AddDays(1).AddMilliseconds(-1); // Ngày cuối tháng
        }

        private DateTime GetMonthStart(int month)
        {
            DateTime today = DateTime.Today;
            DateTime monthStart = new DateTime(today.Year, month, 1);
            return monthStart.Date; // Ngày đầu tháng chỉ định
        }

        private DateTime GetMonthEnd(int month)
        {
            DateTime today = DateTime.Today;
            DateTime monthEnd = new DateTime(today.Year, month, DateTime.DaysInMonth(today.Year, month));
            return monthEnd.Date.AddDays(1).AddMilliseconds(-1); // Ngày cuối tháng chỉ định
        }

        private DateTime GetYearStart()
        {
            DateTime today = DateTime.Today;
            DateTime yearStart = new DateTime(today.Year, 1, 1);
            return yearStart.Date; // Ngày đầu năm
        }

        private DateTime GetYearEnd()
        {
            DateTime today = DateTime.Today;
            DateTime yearEnd = new DateTime(today.Year, 12, 31);
            return yearEnd.Date.AddDays(1).AddMilliseconds(-1); // Ngày cuối năm
        }

        private DateTime GetPreviousYearStart()
        {
            DateTime today = DateTime.Today;
            DateTime previousYearStart = new DateTime(today.Year - 1, 1, 1);
            return previousYearStart.Date; // Ngày đầu năm trước
        }

        private DateTime GetPreviousYearEnd()
        {
            DateTime today = DateTime.Today;
            DateTime previousYearEnd = new DateTime(today.Year - 1, 12, 31);
            return previousYearEnd.Date.AddDays(1).AddMilliseconds(-1); // Ngày cuối năm trước
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ ComboBox
            string selectedItem = comboBox1.SelectedItem.ToString();
            DateTime? startDate = null, endDate = null;

            // Kiểm tra giá trị đã chọn và thiết lập thời gian bắt đầu và kết thúc
            switch (selectedItem)
            {
                case "Hôm nay":
                    startDate = GetTodayStart();
                    endDate = GetTodayEnd();
                    break;
                case "Tuần này":
                    startDate = GetWeekStart();
                    endDate = GetWeekEnd();
                    break;
                case "Tháng này":
                    startDate = GetMonthStart();
                    endDate = GetMonthEnd();
                    break;
                case "Năm nay":
                    startDate = GetYearStart();
                    endDate = GetYearEnd();
                    break;
                case "Tháng 1":
                    startDate = GetMonthStart(1);
                    endDate = GetMonthEnd(1);
                    break;
                case "Tháng 2":
                    startDate = GetMonthStart(2);
                    endDate = GetMonthEnd(2);
                    break;
                case "Tháng 3":
                    startDate = GetMonthStart(3);
                    endDate = GetMonthEnd(3);
                    break;
                case "Tháng 4":
                    startDate = GetMonthStart(4);
                    endDate = GetMonthEnd(4);
                    break;
                case "Tháng 5":
                    startDate = GetMonthStart(5);
                    endDate = GetMonthEnd(5);
                    break;
                case "Tháng 6":
                    startDate = GetMonthStart(6);
                    endDate = GetMonthEnd(6);
                    break;
                case "Tháng 7":
                    startDate = GetMonthStart(7);
                    endDate = GetMonthEnd(7);
                    break;
                case "Tháng 8":
                    startDate = GetMonthStart(8);
                    endDate = GetMonthEnd(8);
                    break;
                case "Tháng 9":
                    startDate = GetMonthStart(9);
                    endDate = GetMonthEnd(9);
                    break;
                case "Tháng 10":
                    startDate = GetMonthStart(10);
                    endDate = GetMonthEnd(10);
                    break;
                case "Tháng 11":
                    startDate = GetMonthStart(11);
                    endDate = GetMonthEnd(11);
                    break;
                case "Tháng 12":
                    startDate = GetMonthStart(12);
                    endDate = GetMonthEnd(12);
                    break;
                case "Năm trước":
                    startDate = GetPreviousYearStart();
                    endDate = GetPreviousYearEnd();
                    break;
                default:
                    break;
            }

            // Kiểm tra và thiết lập giá trị cho các control hiển thị ngày
            if (startDate.HasValue && endDate.HasValue)
            {
                dateTimePicker1.Value = startDate.Value; // Đặt giá trị "từ ngày"
                dateTimePicker2.Value = endDate.Value;   // Đặt giá trị "đến ngày"

                // Gọi phương thức để hiển thị danh sách văn bản trong khoảng thời gian
                FilterAndDisplayVanBan(startDate.Value, endDate.Value);
            }
        }
        private void FilterAndDisplayVanBan(DateTime startDate, DateTime endDate)
        {
            VanBanNoiBoController controller = new VanBanNoiBoController();
            try
            {
                // Lấy danh sách văn bản nội bộ theo khoảng thời gian
                List<VanBanNoiBo> vanBanList = controller.FilterDataByDateRange(startDate, endDate);

                // Xóa toàn bộ dữ liệu cũ trong bảng
                dataGridViewVBNB.Rows.Clear();

                // Thêm dữ liệu mới
                foreach (VanBanNoiBo vanBan in vanBanList)
                {
                    dataGridViewVBNB.Rows.Add(
                        vanBan.SoKyHieu,
                        vanBan.TenVanBan,
                        vanBan.NgayBanHanh,
                        vanBan.LoaiBanHanh,
                        vanBan.PhongBanHanh,
                        vanBan.PhongNhan,
                        vanBan.NguoiNhan,
                        vanBan.NguoiKy,
                        vanBan.NguoiDuyet,
                        vanBan.TrichYeu,
                        vanBan.NoiDung
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + e.Message);
            }

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnQuanLyVanBan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;

        }

        private void btnQuanLyVbNoiBo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void btnTimKiemThongKe_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Kiểm tra nút chuột trái
            {
                // Tính vị trí bên dưới PictureBox
                var position = pictureBox1.PointToScreen(new Point(0, pictureBox1.Height));

                // Hiển thị ContextMenuStrip tại vị trí tính toán
                contextMenuStrip1.Show(position);
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            // Tính vị trí bên dưới PictureBox
            //     var position = pictureBox2.PointToScreen(new Point(0, pictureBox2.Height));

            // Hiển thị ContextMenuStrip tại vị trí tính toán
            //contextMenuStrip2.Show(position);
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
        private void button15_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPagePhongBan;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = VBNoiBotabPage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPageDSVBNoiBo;
        }

        private void btnThemVBNB_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;
            tabControl3.SelectedTab = VBNoiBotabPage;

            txtSoKyHieu.Text = "";
            txtTenVanBan.Text = "";
            txtNguoiNhan.Text = "";
            txtNguoiKy.Text = "";
            txtNguoiDuyet.Text = "";
            txtTrichYeu.Text = "";
            txtNoiDung.Text = "";

            // Đặt lại ngày hiện tại cho trường Ngày ban hành
            //dateNgayBanHanh.Value = null;

            // Đặt giá trị mặc định cho các combobox
            cmbLoaiBanHanh.SelectedIndex = 0;
            cmbPhongBanHanh.SelectedIndex = 0;
            cmbPhongBanNhan.SelectedIndex = 0;

            // Khôi phục trạng thái hiển thị và kích hoạt của txtSoKyHieu
            txtSoKyHieu.Visible = true;
            txtSoKyHieu.Enabled = true;

            // Đặt con trỏ lại trường "Số ký hiệu"
            txtSoKyHieu.Focus();

        }

        private void btnSuaVBNB_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridViewVBNB.SelectedRows.Count > 0 ? dataGridViewVBNB.SelectedRows[0].Index : -1;
            if (selectedRow == -1)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true; // Chuyển sang trạng thái sửa

            string soKyHieu = dataGridViewVBNB.Rows[selectedRow].Cells[0].Value.ToString();
            txtSoKyHieu.Text = soKyHieu;
            txtSoKyHieu.Enabled = false; // Không cho phép sửa số ký hiệu


            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;
            tabControl3.SelectedTab = VBNoiBotabPage;
        }

        private void dataGridViewVBNB_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dataGridViewVBNB.SelectedRows.Count > 0)
                {
                    int row = dataGridViewVBNB.SelectedRows[0].Index;
                    string sokyhieu = dataGridViewVBNB.Rows[row].Cells[0].Value.ToString();
                    string tenvanban = dataGridViewVBNB.Rows[row].Cells[1].Value.ToString();
                    string ngayBanHanhStr = dataGridViewVBNB.Rows[row].Cells[2].Value.ToString();
                    string loaibanhanh = dataGridViewVBNB.Rows[row].Cells[3].Value.ToString();
                    string phongbanhanh = dataGridViewVBNB.Rows[row].Cells[4].Value.ToString();
                    string phongbannhan = dataGridViewVBNB.Rows[row].Cells[5].Value.ToString();
                    string trichyeu = dataGridViewVBNB.Rows[row].Cells[6].Value.ToString();

                    // Set giá trị cho các trường
                    txtSoKyHieu.Text = sokyhieu;
                    txtTenVanBan.Text = tenvanban;

                    if (!string.IsNullOrEmpty(ngayBanHanhStr))
                    {
                        try
                        {
                            // Định dạng "dd/MM/yyyy"
                            DateTime ngaybanhanh = DateTime.ParseExact(ngayBanHanhStr, "yyyy/MM/dd", null);
                            dateNgayBanHanh.Value = ngaybanhanh;
                        }
                        catch (FormatException)
                        {
                            // MessageBox.Show("Ngày ban hành không hợp lệ! Vui lòng kiểm tra định dạng ngày: dd/MM/yyyy.");
                        }
                    }


                    // Cập nhật các ComboBox
                    if (cmbLoaiBanHanh.Items.Contains(loaibanhanh))
                    {
                        cmbLoaiBanHanh.SelectedItem = loaibanhanh;
                    }
                    if (cmbPhongBanHanh.Items.Contains(phongbanhanh))
                    {
                        cmbPhongBanHanh.SelectedItem = phongbanhanh;
                    }
                    if (cmbPhongBanNhan.Items.Contains(phongbannhan))
                    {
                        cmbPhongBanNhan.SelectedItem = phongbannhan;
                    }

                    txtTrichYeu.Text = trichyeu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


        // ---------------- --------------  TÌM KIẾM THỐNG KÊ ---------------------------

        public void LoadComboboxData1()
        {
            try
            {
                VanBanNoiBoController controller = new VanBanNoiBoController();

                // Load dữ liệu cho cmbLoaiBanHanh
                List<string> loaiVanBanList = controller.GetLoaiVanBan();
                chonCmbLoaiBanHanh.Items.Clear(); // Xóa dữ liệu cũ
                chonCmbLoaiBanHanh.Items.Add("Tất cả"); // Thêm lựa chọn "Tất cả"
                foreach (var loaiVanBan in loaiVanBanList)
                {
                    chonCmbLoaiBanHanh.Items.Add(loaiVanBan); // Thêm từng mục vào combobox
                }

                // Load dữ liệu cho cmbPhongBanHanh và cmbPhongBanNhan
                List<string> phongBanList = controller.GetPhongBan();
                chonCmbPhongBanHanh.Items.Clear();
                ChonCmbPhongBanNhan.Items.Clear();
                chonCmbPhongBanHanh.Items.Add("Tất cả"); // Thêm lựa chọn "Tất cả"
                ChonCmbPhongBanNhan.Items.Add("Tất cả"); // Thêm lựa chọn "Tất cả"
                foreach (var phongBan in phongBanList)
                {
                    chonCmbPhongBanHanh.Items.Add(phongBan);
                    ChonCmbPhongBanNhan.Items.Add(phongBan); // Phòng nhận dùng cùng dữ liệu
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu lên Combobox: " + e.Message);
            }
        }


        public void InitTableVanBanNoiBo1()
        {
            // Đặt tiêu đề các cột
            dataGridViewVBNB1.Columns.Add("SoKyHieu", "SỐ KÝ HIỆU");
            dataGridViewVBNB1.Columns.Add("TenVanBan", "TÊN VĂN BẢN");
            dataGridViewVBNB1.Columns.Add("NgayBanHanh", "NGÀY BAN HÀNH");
            dataGridViewVBNB1.Columns.Add("LoaiBanHanh", "LOẠI BAN HÀNH");
            dataGridViewVBNB1.Columns.Add("PhongBanHanh", "PHÒNG BAN HÀNH");
            dataGridViewVBNB1.Columns.Add("PhongNhan", "PHÒNG BAN NHẬN");
            dataGridViewVBNB1.Columns.Add("NguoiNhan", "NGƯỜI NHẬN");
            dataGridViewVBNB1.Columns.Add("NguoiKy", "NGƯỜI KÝ");
            dataGridViewVBNB1.Columns.Add("NguoiDuyet", "NGƯỜI DUYỆT");
            dataGridViewVBNB1.Columns.Add("TrichYeu", "TRÍCH YẾU");
            dataGridViewVBNB1.Columns.Add("NoiDung", "NỘI DUNG");

            // Đặt chế độ không chỉnh sửa trực tiếp trong bảng
            dataGridViewVBNB1.AllowUserToAddRows = false;
            dataGridViewVBNB1.AllowUserToDeleteRows = false;
            dataGridViewVBNB1.ReadOnly = true;
        }

        // Điền dữ liệu vào bảng


        private void ThoiGianTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ ComboBox
            string selectedItem = ThoiGianTimKiem.SelectedItem.ToString();
            DateTime? startDate = null, endDate = null;

            // Kiểm tra giá trị đã chọn và thiết lập thời gian bắt đầu và kết thúc
            switch (selectedItem)
            {
                case "Hôm nay":
                    startDate = GetTodayStart();
                    endDate = GetTodayEnd();
                    break;
                case "Tuần này":
                    startDate = GetWeekStart();
                    endDate = GetWeekEnd();
                    break;
                case "Tháng này":
                    startDate = GetMonthStart();
                    endDate = GetMonthEnd();
                    break;
                case "Năm nay":
                    startDate = GetYearStart();
                    endDate = GetYearEnd();
                    break;
                case "Tháng 1":
                    startDate = GetMonthStart(1);
                    endDate = GetMonthEnd(1);
                    break;
                case "Tháng 2":
                    startDate = GetMonthStart(2);
                    endDate = GetMonthEnd(2);
                    break;
                case "Tháng 3":
                    startDate = GetMonthStart(3);
                    endDate = GetMonthEnd(3);
                    break;
                case "Tháng 4":
                    startDate = GetMonthStart(4);
                    endDate = GetMonthEnd(4);
                    break;
                case "Tháng 5":
                    startDate = GetMonthStart(5);
                    endDate = GetMonthEnd(5);
                    break;
                case "Tháng 6":
                    startDate = GetMonthStart(6);
                    endDate = GetMonthEnd(6);
                    break;
                case "Tháng 7":
                    startDate = GetMonthStart(7);
                    endDate = GetMonthEnd(7);
                    break;
                case "Tháng 8":
                    startDate = GetMonthStart(8);
                    endDate = GetMonthEnd(8);
                    break;
                case "Tháng 9":
                    startDate = GetMonthStart(9);
                    endDate = GetMonthEnd(9);
                    break;
                case "Tháng 10":
                    startDate = GetMonthStart(10);
                    endDate = GetMonthEnd(10);
                    break;
                case "Tháng 11":
                    startDate = GetMonthStart(11);
                    endDate = GetMonthEnd(11);
                    break;
                case "Tháng 12":
                    startDate = GetMonthStart(12);
                    endDate = GetMonthEnd(12);
                    break;
                case "Năm trước":
                    startDate = GetPreviousYearStart();
                    endDate = GetPreviousYearEnd();
                    break;
                default:
                    break;
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                dateTimePicker3.Value = startDate.Value; // Đặt giá trị "từ ngày"
                dateTimePicker4.Value = endDate.Value;   // Đặt giá trị "đến ngày"

                FilterAndDisplayVanBan1(startDate.Value, endDate.Value);
            }

        }


        private void FilterAndDisplayVanBan1(DateTime startDate, DateTime endDate)
        {
            VanBanNoiBoController controller = new VanBanNoiBoController();
            try
            {
                // Lấy danh sách văn bản nội bộ theo khoảng thời gian
                List<VanBanNoiBo> vanBanList = controller.FilterDataByDateRange(startDate, endDate);

                // Xóa toàn bộ dữ liệu cũ trong bảng
                dataGridViewVBNB1.Rows.Clear();

                // Thêm dữ liệu mới
                foreach (VanBanNoiBo vanBan in vanBanList)
                {
                    dataGridViewVBNB1.Rows.Add(
                        vanBan.SoKyHieu,
                        vanBan.TenVanBan,
                        vanBan.NgayBanHanh,
                        vanBan.LoaiBanHanh,
                        vanBan.PhongBanHanh,
                        vanBan.PhongNhan,
                        vanBan.NguoiNhan,
                        vanBan.NguoiKy,
                        vanBan.NguoiDuyet,
                        vanBan.TrichYeu,
                        vanBan.NoiDung
                    );
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + e.Message);
            }

        }



        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void XuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("VanBanNoiBo");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = dataGridViewPhongBan;

                            // Tạo header (bỏ qua cột "Mã Phòng Ban", index = 2)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void picXoa_Click(object sender, EventArgs e)
        {
            // Lấy chỉ số dòng được chọn
            int selectedRow = dataGridViewPhongBan.SelectedRows.Count > 0 ? dataGridViewPhongBan.SelectedRows[0].Index : -1;

            if (selectedRow == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã phòng ban từ cột ẩn (giả sử cột MaPhongBan là cột thứ 2)
            string maPhongBan = dataGridViewPhongBan.Rows[selectedRow].Cells[2].Value.ToString();

            // Hỏi xác nhận xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    PhongBanController controller = new PhongBanController();

                    // Gọi phương thức XoaPhongBan để xóa phòng ban
                    if (controller.XoaPhongBan(maPhongBan))
                    {
                        MessageBox.Show("Xóa phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillDataPhongBan(); // Cập nhật lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Log lỗi nếu cần
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void btnXoaVBNB_Click(object sender, EventArgs e)
        {
            // Lấy dòng đã chọn từ DataGridView
            int selectedRow = dataGridViewVBNB.SelectedRows.Count > 0 ? dataGridViewVBNB.SelectedRows[0].Index : -1;

            if (selectedRow == -1)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
                return;
            }

            // Lấy giá trị từ ô text
            string soKyHieu = txtSoKyHieu.Text;

            // Hỏi xác nhận xóa
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tài liệu này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Gọi phương thức xóa từ controller
                    VanBanNoiBoController controller = new VanBanNoiBoController();
                    if (controller.Xoa(soKyHieu))
                    {
                        try
                        {
                            MessageBox.Show("Xóa thành công.");
                            FillDataVanBanNoiBo();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi khi làm mới dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Log lỗi nếu cần
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa tài liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Log lỗi nếu cần
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("VanBanNoiBo");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = dataGridViewVBNB;

                            // Tạo header (bỏ qua cột "Mã Phòng Ban", index = 2)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage7;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage8;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage9;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            int row = this.dataGridViewVBNB1.SelectedCells[0].RowIndex;

            if (row != -1)
            {
                // Lấy thông tin từ dòng được chọn
                string sokyhieu = this.dataGridViewVBNB1.Rows[row].Cells[0].Value.ToString();
                string tenvanban = this.dataGridViewVBNB1.Rows[row].Cells[1].Value.ToString();
                string ngayBanHanhStr = this.dataGridViewVBNB1.Rows[row].Cells[2].Value.ToString();
                string loaibanhanh = this.dataGridViewVBNB1.Rows[row].Cells[3].Value.ToString();
                string phongbanhanh = this.dataGridViewVBNB1.Rows[row].Cells[4].Value.ToString();
                string phongbannhan = this.dataGridViewVBNB1.Rows[row].Cells[5].Value.ToString();
                string nguoinhan = this.dataGridViewVBNB1.Rows[row].Cells[6].Value.ToString();
                string nguoiky = this.dataGridViewVBNB1.Rows[row].Cells[7].Value.ToString();
                string nguoiduyet = this.dataGridViewVBNB1.Rows[row].Cells[8].Value.ToString();
                string trichyeu = this.dataGridViewVBNB1.Rows[row].Cells[9].Value.ToString();
                string noidung = this.dataGridViewVBNB1.Rows[row].Cells[10].Value.ToString();

                // Mở form Chi tiết và truyền dữ liệu
                ChiTietVanBanNoiBo vbChiTiet = new ChiTietVanBanNoiBo(
                    sokyhieu, tenvanban, ngayBanHanhStr, loaibanhanh, phongbanhanh, phongbannhan,
                    nguoinhan, nguoiky, nguoiduyet, trichyeu, noidung);
                vbChiTiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
            }
        }

        private void dataGridViewVBNB1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;

            if (row != -1)
            {
                // Lấy thông tin từ dòng được chọn
                string sokyhieu = this.dataGridViewVBNB1.Rows[row].Cells[0].Value.ToString();
                string tenvanban = this.dataGridViewVBNB1.Rows[row].Cells[1].Value.ToString();
                string ngayBanHanhStr = this.dataGridViewVBNB1.Rows[row].Cells[2].Value.ToString();
                string loaibanhanh = this.dataGridViewVBNB1.Rows[row].Cells[3].Value.ToString();
                string phongbanhanh = this.dataGridViewVBNB1.Rows[row].Cells[4].Value.ToString();
                string phongbannhan = this.dataGridViewVBNB1.Rows[row].Cells[5].Value.ToString();
                string nguoinhan = this.dataGridViewVBNB1.Rows[row].Cells[6].Value.ToString();
                string nguoiky = this.dataGridViewVBNB1.Rows[row].Cells[7].Value.ToString();
                string nguoiduyet = this.dataGridViewVBNB1.Rows[row].Cells[8].Value.ToString();
                string trichyeu = this.dataGridViewVBNB1.Rows[row].Cells[9].Value.ToString();
                string noidung = this.dataGridViewVBNB1.Rows[row].Cells[10].Value.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng!");
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("VanBanNoiBo");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = dataGridViewVBNB1;

                            // Tạo header (bỏ qua cột "Mã Phòng Ban", index = 2)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 2) continue; // Bỏ qua cột "Mã Phòng Ban"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnInbaocao_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dữ liệu trong DataGridView
            if (dataGridViewVBNB1.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tăng kích cỡ chữ và chiều cao dòng của DataGridView
            dataGridViewVBNB1.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dataGridViewVBNB1.RowTemplate.Height = 22;
            dataGridViewVBNB1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Thiết lập in
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);

            PrintPreviewDialog printPreview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };

            // Hiển thị hộp thoại xem trước in
            printPreview.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int x = 50; // Lề trái
            int y = 100; // Lề trên
            int cellHeight = 30;
            int colWidth = 100; // Chiều rộng cột cố định (có thể thay đổi tùy theo nội dung)

            // Tiêu đề báo cáo
            e.Graphics.DrawString("Danh sách văn bản nội bộ", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(250, 50));

            // Vẽ header của bảng
            for (int i = 0; i < dataGridViewVBNB1.Columns.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(x, y, colWidth, cellHeight));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, colWidth, cellHeight));
                e.Graphics.DrawString(dataGridViewVBNB1.Columns[i].HeaderText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(x + 5, y + 5));
                x += colWidth;
            }

            y += cellHeight; // Xuống dòng sau header
            x = 50; // Reset vị trí lề trái

            // Vẽ dữ liệu từ DataGridView
            foreach (DataGridViewRow row in dataGridViewVBNB1.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới

                for (int i = 0; i < dataGridViewVBNB1.Columns.Count; i++)
                {
                    string value = row.Cells[i].Value?.ToString() ?? "";
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, colWidth, cellHeight));
                    e.Graphics.DrawString(value, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new PointF(x + 5, y + 5));
                    x += colWidth;
                }

                y += cellHeight; // Xuống dòng sau mỗi hàng
                x = 50; // Reset vị trí lề trái

                // Nếu vượt quá chiều cao trang, ngắt trang
                if (y + cellHeight > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false; // Kết thúc trang

            // Chân trang
            e.Graphics.DrawString("Quản lý văn bản", new Font("Arial", 12, FontStyle.Italic), Brushes.Black, new Point(250, e.MarginBounds.Bottom + 20));
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string loaiBanHanh = chonCmbLoaiBanHanh.SelectedItem?.ToString();
            string phongBanHanh = chonCmbPhongBanHanh.SelectedItem?.ToString();
            string phongBanNhan = ChonCmbPhongBanNhan.SelectedItem?.ToString();
            string soKyHieu = nhapSoKyHieu.Text.Trim();
            string tenVanBan = nhapTenVanBan.Text.Trim();
            string trichYeu = nhapTrichYeu.Text.Trim();

            DateTime? startDate = null, endDate = null;
            switch (ThoiGianTimKiem.SelectedItem?.ToString())
            {
                case "Hôm nay":
                    startDate = DateTime.Today;
                    endDate = DateTime.Today.AddDays(1).AddSeconds(-1);
                    break;
                case "Tuần này":
                    startDate = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
                    endDate = startDate.Value.AddDays(7).AddSeconds(-1);
                    break;
                case "Tháng này":
                    startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    endDate = startDate.Value.AddMonths(1).AddSeconds(-1);
                    break;
                case "Năm nay":
                    startDate = new DateTime(DateTime.Today.Year, 1, 1);
                    endDate = startDate.Value.AddYears(1).AddSeconds(-1);
                    break;
                case "Năm trước":
                    startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                    endDate = startDate.Value.AddYears(1).AddSeconds(-1);
                    break;
            }

            VanBanNoiBoController controller = new VanBanNoiBoController();
            try
            {
                List<VanBanNoiBo> resultList = controller.Search(loaiBanHanh, phongBanHanh, phongBanNhan,
                                                                  soKyHieu, tenVanBan, trichYeu, startDate, endDate);

                dataGridViewVBNB1.Rows.Clear(); // Xóa dữ liệu cũ
                foreach (VanBanNoiBo item in resultList)
                {
                    dataGridViewVBNB1.Rows.Add(
                        item.SoKyHieu,
                        item.TenVanBan,
                        item.NgayBanHanh,
                        item.LoaiBanHanh,
                        item.PhongBanHanh,
                        item.PhongNhan,
                        item.NguoiNhan,
                        item.NguoiKy,
                        item.NguoiDuyet,
                        item.TrichYeu,
                        item.NoiDung
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cboNamSoVanBan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuSoVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaSoVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiSoVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcelSoVanBan_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void bnLuuLoaiVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaLoaiVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiLoaiVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExxcelLoaiVanBan_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNoiBanHanh_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuNoiBanHanh_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNoiBanHanh_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiNoiBanHanh_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcelNoiBanHanh_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuVanBanDen_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuVanBanDi_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaVanBanDi_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiVanBanDi_Click(object sender, EventArgs e)
        {

        }

        private void btnThemDSDen_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaDSDen_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiDSDen_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcelDSDen_Click(object sender, EventArgs e)
        {

        }

        private void cboNamDen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tblDanhSachVanBanDen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemDSDi_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaDSDi_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiLaiDSDi_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcelDSDi_Click(object sender, EventArgs e)
        {

        }

        private void cboNamDi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tblDanhSachVanBanDi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboNamDi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            HienThiDanhSachVanBanDi();
        }

        private void btnXuatExcelDSDi_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("Danh sach di");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = tblDanhSachVanBanDi;

                            // Tạo header (bỏ qua cột "Mã So", index = 0 nếu cần)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 0) continue; // Bỏ qua cột "Mã So" nếu cần
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 0) continue; // Bỏ qua cột "Mã So"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
        }

        private void btnTaiLaiDSDi_Click_1(object sender, EventArgs e)
        {
            HienThiDanhSachVanBanDi();
        }

        private void btnXoaDSDi_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tblDanhSachVanBanDi.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một văn bản để xóa!");
                    return;
                }

                int selectedRow = tblDanhSachVanBanDi.SelectedRows[0].Index;

                VanBanDiModel vanbandi = dsvbdi[selectedRow];
                int idVanBan = vanbandi.Id;
                Console.WriteLine(idVanBan);
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa văn bản này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    VanBanDiController controller = new VanBanDiController();

                    int result = controller.XoaVanBanDi(idVanBan);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa văn bản thành công!");
                        HienThiDanhSachVanBanDi(); // Tải lại danh sách văn bản sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa văn bản thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemDSDi_Click_1(object sender, EventArgs e)
        {
            TabChua.SelectTab(4);
            cboSoVanBanDi.SelectedIndex = -1;
            txtSoKiHieuDi.Clear();
            txtSoDi.Clear();
            dateNgayBanHanhDi.Value = DateTime.Now;
            cboLoaiVanBanDi.SelectedIndex = -1;
            txtSoTrangDi.Clear();
            txtSoLuongBanDi.Clear();
            txtNguoiGuiDi.Clear();
            txtNguoiKyDi.Clear();
            txtNguoiDuyetDi.Clear();
            txtTrichYeuDi.Clear();
            txtNoiDungDi.Clear();
            txtDinhKemFileDi.Clear();
            txtNoiNhanDi.Clear();
            KhoiTaoVanBanDi();
        }

        private void btnXuatExcelDSDen_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("Danh sach den");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = tblDanhSachVanBanDen;

                            // Tạo header (bỏ qua cột "Mã So", index = 0 nếu cần)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 0) continue; // Bỏ qua cột "Mã So" nếu cần
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 0) continue; // Bỏ qua cột "Mã So"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
        }

        private void btnTaiLaiDSDen_Click_1(object sender, EventArgs e)
        {
            HienThiDanhSachVanBanDen();
        }

        private void btnXoaDSDen_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dòng nào được chọn không
                if (tblDanhSachVanBanDen.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một văn bản để xóa!");
                    return;
                }

                // Lấy id của văn bản từ dòng được chọn
                int selectedRow = tblDanhSachVanBanDen.SelectedRows[0].Index;
                VanBanDenModel vanbanden = dsvbden[selectedRow];
                int idVanBan = vanbanden.Id;
                Console.WriteLine(idVanBan);
                // Hiển thị hộp thoại xác nhận xóa
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa văn bản này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo
                );

                if (confirm == DialogResult.Yes)
                {
                    VanBanDenController controller = new VanBanDenController();

                    // Gọi phương thức xóa văn bản
                    int result = controller.XoaVanBanDen(idVanBan);

                    // Kiểm tra kết quả
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa văn bản thành công!");
                        HienThiDanhSachVanBanDen(); // Cập nhật lại danh sách sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Xóa văn bản thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message); // Hiển thị thông báo lỗi nếu có
            }
        }

        private void btnThemDSDen_Click_1(object sender, EventArgs e)
        {
            KhoiTaoTimKiemVanBanDen();
            cboSoVanBanDen.SelectedIndex = -1;
            cboLoaiVanBanDen.SelectedIndex = -1;
            cboNoiBanHanhDen.SelectedIndex = -1;
            txtSoDen.Clear();
            txtSoKyHieuDen.Clear();
            txtSoTrangDen.Clear();
            txtNguoiDuyetDen.Clear();
            txtNguoiNhanDen.Clear();
            txtNguoiKyDen.Clear();
            txtNoiDungDen.Clear();
            txtTrichYeuDen.Clear();
            txtDinhKemFileDen.Clear();

            dateNgayBanHanhDen.Value = DateTime.Now;
            dateNgayDen.Value = DateTime.Now;
            TabChua.SelectTab(3);
        }

        private void cboNamDen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            HienThiDanhSachVanBanDen();
        }

        private void btnThemSoVanBan_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu danh sách dsvb là null, cần khởi tạo nó
            if (dsvb == null)
            {
                dsvb = new List<SoVanBanModel>();
            }

            // Kiểm tra nếu DataGridView đã có một dòng trống
            if (tblSoVanBan.Rows.Count > 0)
            {
                DataGridViewRow lastRow = tblSoVanBan.Rows[tblSoVanBan.Rows.Count - 1];
                if (lastRow.Cells["SoVanBan"].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells["SoVanBan"].Value.ToString()))
                {
                    // Nếu dòng cuối cùng trống, không thêm dòng mới
                    return;
                }
            }

            // Tạo đối tượng mới với giá trị mặc định
            SoVanBanModel newSoVanBan = new SoVanBanModel
            {
                SoVanBan = "",                     // Giá trị mặc định
                SoDen = false,                     // Giá trị mặc định
                Nam = int.Parse(cboNamSoVanBan.SelectedItem.ToString()) // Giá trị mặc định
            };

            // Thêm đối tượng vào danh sách dsvb
            dsvb.Add(newSoVanBan);

            // Thêm dòng trống vào DataGridView
            tblSoVanBan.Rows.Add(
                tblSoVanBan.Rows.Count + 1,       // Số TT
                "",                               // Số Văn Bản (trống)
                false,                            // Số Đến (checkbox)
                int.Parse(cboNamSoVanBan.SelectedItem.ToString()) // Năm
            );

        }

        private void btnLuuSoVanBan_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ DataGridView
                bool isSuccess = true;
                SoVanBanController soController = new SoVanBanController();

                // Đảm bảo commit các thay đổi từ DataGridView
                tblSoVanBan.EndEdit(); // Bổ sung dòng này để kết thúc chế độ chỉnh sửa

                for (int row = 0; row < tblSoVanBan.Rows.Count; row++)
                {
                    DataGridViewRow dgvRow = tblSoVanBan.Rows[row];

                    string soVanBan = dgvRow.Cells["SoVanBan"].Value?.ToString();
                    bool soDen = Convert.ToBoolean(dgvRow.Cells["SoDen"].Value ?? false); // Lấy giá trị checkbox đã cập nhật
                    Console.WriteLine(soDen);
                    int nam = dgvRow.Cells["Nam"].Value != null ? Convert.ToInt32(dgvRow.Cells["Nam"].Value) : 0;

                    // Kiểm tra dữ liệu nhập
                    if (string.IsNullOrWhiteSpace(soVanBan))
                    {
                        MessageBox.Show($"Sổ văn bản không được để trống tại dòng {row + 1}", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SoVanBanModel soVanBanModel = dsvb[row]; // Lấy dữ liệu từ danh sách
                    int maSo = soVanBanModel.MaSo;

                    // Cập nhật thông tin
                    soVanBanModel.SoVanBan = soVanBan;
                    soVanBanModel.SoDen = soDen;
                    soVanBanModel.Nam = nam;

                    int result;
                    if (maSo == 0)
                    {
                        // Bản ghi mới -> gọi hàm Them
                        result = soController.Them(soVanBanModel);
                    }
                    else
                    {
                        // Bản ghi cũ -> gọi hàm Luu
                        result = soController.Luu(soVanBanModel);
                    }
                }

                // Hiển thị thông báo nếu thành công
                if (isSuccess)
                {
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSoVanBan_Click_1(object sender, EventArgs e)
        {
            if (tblSoVanBan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn số văn bản cần xóa!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dòng đã chọn
            DataGridViewRow selectedRow = tblSoVanBan.SelectedRows[0];
            int selectedRowIndex = selectedRow.Index;

            // Hiển thị hộp thoại xác nhận xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa số văn bản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                return;  // Nếu người dùng chọn "No", không thực hiện xóa
            }

            // Lấy đối tượng SoVanBanModel từ danh sách dsvb dựa trên chỉ số dòng
            SoVanBanModel soVanBanModel = dsvb[selectedRowIndex];

            // Tạo controller để gọi phương thức xóa
            SoVanBanController soControl = new SoVanBanController();
            int result = soControl.XoaTaiLieu(soVanBanModel);  // Gọi phương thức xóa tài liệu

            // Kiểm tra kết quả xóa
            if (result > 0)
            {
                MessageBox.Show("Xóa số văn bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật lại danh sách dsvb và bảng sau khi xóa thành công
                dsvb.RemoveAt(selectedRowIndex);  // Loại bỏ đối tượng khỏi danh sách dsvb
                tblSoVanBan.Rows.RemoveAt(selectedRowIndex);  // Xóa dòng trong DataGridView
            }
            else
            {
                MessageBox.Show("Xóa số văn bản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiSoVanBan_Click_1(object sender, EventArgs e)
        {
            HienThiTableSoVanBan();
        }

        private void btnXuatExcelSoVanBan_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("So Van Ban");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = tblSoVanBan;

                            // Tạo header (bỏ qua cột "Mã So", index = 0 nếu cần)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 0) continue; // Bỏ qua cột "Mã So" nếu cần
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 0) continue; // Bỏ qua cột "Mã So"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cboNamSoVanBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            HienThiTableSoVanBan();
        }

        private void btnThemLoaiVanBan_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu danh sách dsl là null, cần khởi tạo nó
                if (dsl == null)
                {
                    dsl = new List<LoaiVanBanModel>();
                }

                // Kiểm tra nếu DataGridView đã có một dòng trống
                if (tblLoaiVanBan.Rows.Count > 0)
                {
                    DataGridViewRow lastRow = tblLoaiVanBan.Rows[tblLoaiVanBan.Rows.Count - 1];
                    if (lastRow.Cells["LoaiVanBan"].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells["LoaiVanBan"].Value.ToString()))
                    {
                        // Nếu dòng cuối cùng trống, không thêm dòng mới
                        return;
                    }
                }

                // Tạo đối tượng mới với giá trị mặc định
                LoaiVanBanModel newLoaiVanBan = new LoaiVanBanModel
                {
                    MaLoai = "",              // Mã loại (trống)
                    LoaiVanBan = "",          // Loại văn bản (trống)
                    MoTa = ""                 // Mô tả (trống)
                };

                // Thêm đối tượng vào danh sách dsl
                dsl.Add(newLoaiVanBan);

                // Thêm dòng trống vào DataGridView
                tblLoaiVanBan.Rows.Add(
                    tblLoaiVanBan.Rows.Count + 1,  // Số TT (tăng dần)
                    "",                             // Mã Loại (trống)
                    "",                             // Loại Văn Bản (trống)
                    ""                              // Mô Tả (trống)
                );
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnLuuLoaiVanBan_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool isSuccess = true;

                LoaiVanBanController loaiController = new LoaiVanBanController();

                // Duyệt qua từng dòng của DataGridView
                for (int row = 0; row < tblLoaiVanBan.Rows.Count; row++)
                {
                    // Lấy giá trị từ các ô trong bảng
                    string maLoai = tblLoaiVanBan.Rows[row].Cells["MaLoai"].Value?.ToString();
                    string tenLoai = tblLoaiVanBan.Rows[row].Cells["LoaiVanBan"].Value?.ToString();
                    string moTa = tblLoaiVanBan.Rows[row].Cells["MoTa"].Value?.ToString();

                    // Kiểm tra dữ liệu nhập vào
                    if (string.IsNullOrWhiteSpace(maLoai))
                    {
                        MessageBox.Show($"Mã loại văn bản không được để trống tại dòng {row + 1}", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(tenLoai))
                    {
                        MessageBox.Show($"Loại văn bản không được để trống tại dòng {row + 1}", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy đối tượng mô hình loại văn bản và cập nhật thông tin
                    LoaiVanBanModel loaiVanBanModel = dsl[row];
                    loaiVanBanModel.MaLoai = maLoai;
                    loaiVanBanModel.LoaiVanBan = tenLoai;
                    loaiVanBanModel.MoTa = moTa;
                    loaiVanBanModel.DaXoa = false;

                    int result;
                    if (!loaiController.KiemTraTonTai(maLoai))
                    {
                        // Bản ghi mới -> gọi hàm Thêm
                        result = loaiController.Them(loaiVanBanModel);
                    }
                    else
                    {
                        // Bản ghi cũ -> gọi hàm Cập Nhật
                        result = loaiController.Update(loaiVanBanModel);
                    }

                    // Kiểm tra kết quả
                    if (result <= 0)
                    {
                        isSuccess = false;
                        MessageBox.Show($"Lưu thất bại tại dòng: {row + 1}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (isSuccess)
                {
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLoaiVanBan_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy mô hình bảng hiện tại
                DataGridViewRow selectedRow = tblLoaiVanBan.CurrentRow;

                // Kiểm tra nếu không có hàng nào được chọn
                if (selectedRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một tài liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã loại từ bảng
                string maLoai = selectedRow.Cells["MaLoai"].Value.ToString(); // Cột mã loại
                Console.WriteLine(maLoai);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài liệu này?",
                                                       "Xác nhận xóa",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gọi phương thức xóa từ controller
                    LoaiVanBanController loaiVBController = new LoaiVanBanController();
                    int deleteResult = loaiVBController.Xoa(maLoai);

                    if (deleteResult > 0)
                    {
                        // Xóa thành công: cập nhật lại bảng
                        MessageBox.Show("Xóa loại văn bản  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HienThiTableLoaiVanBan(); // Hàm cập nhật lại bảng
                    }
                    else
                    {
                        // Xóa thất bại
                        MessageBox.Show("Xóa loại văn bản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiLoaiVanBan_Click_1(object sender, EventArgs e)
        {
            HienThiTableLoaiVanBan();
        }

        private void btnXuatExxcelLoaiVanBan_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("Loai van ban");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = tblLoaiVanBan;

                            // Tạo header (bỏ qua cột "Mã So", index = 0 nếu cần)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 0) continue; // Bỏ qua cột "Mã So" nếu cần
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 0) continue; // Bỏ qua cột "Mã So"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemNoiBanHanh_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu danh sách dsnoi là null, cần khởi tạo nó
                if (dsnoi == null)
                {
                    dsnoi = new List<NoiBanHanhModel>();
                }

                // Kiểm tra nếu DataGridView đã có một dòng trống
                if (tblNoiBanHanh.Rows.Count > 0)
                {
                    DataGridViewRow lastRow = tblNoiBanHanh.Rows[tblNoiBanHanh.Rows.Count - 1];
                    if (lastRow.Cells["NoiBanHanh"].Value == null || string.IsNullOrWhiteSpace(lastRow.Cells["NoiBanHanh"].Value.ToString()))
                    {
                        // Nếu dòng cuối cùng trống, không thêm dòng mới
                        return;
                    }
                }

                // Tạo đối tượng mới với giá trị mặc định
                NoiBanHanhModel newNoiBanHanh = new NoiBanHanhModel
                {
                    NoiBanHanh = "",  // Giá trị mặc định
                    MoTa = ""          // Giá trị mặc định
                };

                // Thêm đối tượng vào danh sách dsnoi
                dsnoi.Add(newNoiBanHanh);

                // Thêm dòng trống vào DataGridView
                tblNoiBanHanh.Rows.Add(
                    tblNoiBanHanh.Rows.Count + 1, // Số TT
                    "",                           // Nơi Ban Hành (trống)
                    ""                            // Mô Tả (trống)
                );
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuNoiBanHanh_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy mô hình DataGridView hiện tại
                var tableModel = tblNoiBanHanh.DataSource as BindingList<NoiBanHanhModel>;
                bool isSuccess = true;

                NoiBanHanhController noiController = new NoiBanHanhController();

                // Duyệt qua từng dòng của bảng
                for (int row = 0; row < tblNoiBanHanh.Rows.Count; row++)
                {
                    // Lấy giá trị từ các ô trong bảng
                    string noiBanHanh = tblNoiBanHanh.Rows[row].Cells["NoiBanHanh"].Value?.ToString();
                    string moTa = tblNoiBanHanh.Rows[row].Cells["MoTa"].Value?.ToString();

                    // Kiểm tra dữ liệu
                    if (string.IsNullOrWhiteSpace(noiBanHanh))
                    {
                        MessageBox.Show($"Nơi ban hành không được để trống tại dòng {row + 1}", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy đối tượng mô hình và cập nhật thông tin
                    NoiBanHanhModel noiModel = tableModel[row];
                    int maNoi = noiModel.MaNoiBanHanh;
                    noiModel.NoiBanHanh = noiBanHanh;
                    noiModel.MoTa = moTa;
                    noiModel.DaXoa = false;

                    int result;
                    if (maNoi == 0)
                    {
                        // Bản ghi mới -> gọi hàm Thêm
                        result = noiController.ThemNoiBanHanh(noiModel);
                    }
                    else
                    {
                        // Bản ghi cũ -> gọi hàm Cập Nhật
                        result = noiController.CapNhatNoiBanHanh(noiModel);
                    }

                    // Kiểm tra kết quả
                    if (result <= 0)
                    {
                        isSuccess = false;
                        MessageBox.Show($"Lưu thất bại tại dòng: {row + 1}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (isSuccess)
                {
                    MessageBox.Show("Lưu dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaNoiBanHanh_Click_1(object sender, EventArgs e)
        {
            // Lấy dòng đã chọn trong DataGridView
            int selectedRow = tblNoiBanHanh.SelectedRows.Count > 0 ? tblNoiBanHanh.SelectedRows[0].Index : -1;

            if (selectedRow == -1)
            {
                MessageBox.Show("Vui lòng chọn nơi ban hành cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nơi ban hành này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No)
            {
                return;
            }

            // Lấy đối tượng Nơi Ban Hành từ danh sách
            NoiBanHanhModel noiModel = dsnoi[selectedRow];

            // Debug: In ra thông tin của các đối tượng trong dsnoi
            foreach (var noi in dsnoi)
            {
                Console.WriteLine(noi.ToString());
            }

            // Tạo đối tượng controller và gọi phương thức xóa
            NoiBanHanhController noiControl = new NoiBanHanhController();
            int result = noiControl.XoaNoiBanHanh(noiModel);  // Gọi phương thức xóa nơi ban hành

            // Kiểm tra kết quả xóa
            if (result > 0)
            {
                MessageBox.Show("Xóa nơi ban hành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại bảng
                HienThiTableNoiBanHanh();
            }
            else
            {
                MessageBox.Show("Xóa nơi ban hành thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaiLaiNoiBanHanh_Click_1(object sender, EventArgs e)
        {
            HienThiTableNoiBanHanh();
        }

        private void btnXuatExcelNoiBanHanh_Click_1(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Chọn nơi lưu file Excel";
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Khởi tạo workbook và sheet
                        using (var package = new OfficeOpenXml.ExcelPackage())
                        {
                            var sheet = package.Workbook.Worksheets.Add("Noi Ban Hanh");

                            // Lấy dữ liệu từ DataGridView
                            DataGridView gridView = tblNoiBanHanh;

                            // Tạo header (bỏ qua cột "Mã So", index = 0 nếu cần)
                            int colIndex = 1;
                            for (int i = 0; i < gridView.ColumnCount; i++)
                            {
                                if (i == 0) continue; // Bỏ qua cột "Mã So" nếu cần
                                sheet.Cells[1, colIndex].Value = gridView.Columns[i].HeaderText;

                                // Thiết lập style cho tiêu đề
                                var headerCell = sheet.Cells[1, colIndex];
                                headerCell.Style.Font.Bold = true;
                                headerCell.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                colIndex++;
                            }

                            // Ghi dữ liệu từ bảng vào file Excel
                            for (int row = 0; row < gridView.RowCount; row++)
                            {
                                colIndex = 1;
                                for (int col = 0; col < gridView.ColumnCount; col++)
                                {
                                    if (col == 0) continue; // Bỏ qua cột "Mã So"
                                    var value = gridView.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, colIndex].Value = value != null ? value.ToString() : "";
                                    colIndex++;
                                }
                            }

                            // Lưu file ra đĩa
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                        else
                        {
                            MessageBox.Show("Máy tính của bạn không hỗ trợ mở file tự động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThemVanBanDen_Click(object sender, EventArgs e)
        {
            try
            {
                VanBanDenController vbController = new VanBanDenController();

                // Kiểm tra dữ liệu nhập
                string input = cboSoVanBanDen.SelectedItem.ToString().Trim();
                if (string.IsNullOrEmpty(input) || !input.Contains("-"))
                {
                    MessageBox.Show("Chuỗi không hợp lệ. Vui lòng nhập theo định dạng 'Tên văn bản - Năm'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VanBanDenModel vb = new VanBanDenModel();
                string tenso = null;
                int nam = 0;

                string[] parts = input.Split('-');
                if (parts.Length == 2)
                {
                    tenso = parts[0].Trim();
                    if (!int.TryParse(parts[1].Trim(), out nam))
                    {
                        MessageBox.Show("Năm không hợp lệ. Vui lòng nhập năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int currentYear = DateTime.Now.Year;
                    if (nam < 1900 || nam > currentYear)
                    {
                        MessageBox.Show("Năm không hợp lệ. Vui lòng nhập năm trong khoảng từ 1900 đến " + currentYear + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chuỗi không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vb.TenSo = tenso;
                vb.Nam = nam;

                vb.SoKyHieu = txtSoKyHieuDen.Text.Trim();
                vb.NgayBanHanh = dateNgayBanHanhDen.Value;
                vb.NoiBanHanh = cboNoiBanHanhDen.SelectedItem.ToString().Trim();
                vb.LoaiVanBan = cboLoaiVanBanDen.SelectedItem.ToString().Trim();

                if (string.IsNullOrEmpty(txtSoDen.Text.Trim()) || !int.TryParse(txtSoDen.Text.Trim(), out int soDen))
                {
                    MessageBox.Show("Số đến phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vb.SoDen = soDen;

                vb.NgayDen = dateNgayDen.Value;

                if (string.IsNullOrEmpty(txtSoTrangDen.Text.Trim()) || !int.TryParse(txtSoTrangDen.Text.Trim(), out int soTrang))
                {
                    MessageBox.Show("Số trang phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                vb.SoTrang = soTrang;

                vb.NguoiNhan = txtNguoiNhanDen.Text.Trim();
                vb.NguoiKy = txtNguoiKyDen.Text.Trim();
                vb.NguoiDuyet = txtNguoiDuyetDen.Text.Trim();
                vb.TrichYeu = txtTrichYeuDen.Text.Trim();
                vb.NoiDung = txtNoiDungDen.Text.Trim();
                vb.DuongDanFile = txtDinhKemFileDen.Text.Trim();
                vb.DaXoa = false;

                string filePath = txtDinhKemFileDen.Text.Trim();
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Vui lòng chọn file đính kèm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int result = vbController.Them(vb);
                if (result > 0)
                {
                    MessageBox.Show("Thêm văn bản đến thành công!");

                    cboSoVanBanDen.SelectedIndex = -1;
                    cboLoaiVanBanDen.SelectedIndex = -1;
                    cboNoiBanHanhDen.SelectedIndex = -1;
                    txtSoDen.Clear();
                    txtSoKyHieuDen.Clear();
                    txtSoTrangDen.Clear();
                    txtNguoiDuyetDen.Clear();
                    txtNguoiNhanDen.Clear();
                    txtNguoiKyDen.Clear();
                    txtNoiDungDen.Clear();
                    txtTrichYeuDen.Clear();
                    txtDinhKemFileDen.Clear();

                }
                else
                {
                    MessageBox.Show("Thêm văn bản đến thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra trong quá trình xử lý: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int rowSelectedDen;
        private void btnLuuVanBanDen_Click_1(object sender, EventArgs e)
        {
            try
            {
                VanBanDenController vbDenContrl = new VanBanDenController();

                // Lấy văn bản đã chọn từ danh sách và lấy id
                VanBanDenModel vanbanden = dsvbden[rowSelectedDen];  // Lấy văn bản từ danh sách
                int id = vanbanden.Id;
                Console.WriteLine("ID LA: " + id);

                // Khởi tạo đối tượng Văn Bản Đến
                VanBanDenModel vb = new VanBanDenModel();
                vb.Id = id;  // Gán id vào văn bản

                string input = cboSoVanBanDen.SelectedItem.ToString().Trim();
                string tenso = null;
                int nam = 0;

                // Kiểm tra định dạng chuỗi
                if (string.IsNullOrEmpty(input) || !input.Contains("-"))
                {
                    MessageBox.Show("Chuỗi không hợp lệ. Vui lòng nhập theo định dạng 'Tên văn bản - Năm'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string[] parts = input.Split('-');
                    if (parts.Length == 2)
                    {
                        tenso = parts[0].Trim();
                        try
                        {
                            nam = int.Parse(parts[1].Trim());
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Năm không hợp lệ. Vui lòng nhập năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chuỗi không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                vb.TenSo = tenso;
                vb.Nam = nam;

                // Kiểm tra ngày tháng
                if (dateNgayBanHanhDen.Value == null || dateNgayDen.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ ngày tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vb.SoKyHieu = txtSoKyHieuDen.Text.Trim();
                vb.NgayBanHanh = dateNgayBanHanhDen.Value;
                vb.NoiBanHanh = cboNoiBanHanhDen.SelectedItem.ToString().Trim();
                vb.LoaiVanBan = cboLoaiVanBanDen.SelectedItem.ToString().Trim();

                // Kiểm tra số đến
                try
                {
                    vb.SoDen = int.Parse(txtSoDen.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số đến phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vb.NgayDen = dateNgayDen.Value;
                vb.SoTrang = int.Parse(txtSoTrangDen.Text.Trim());
                vb.NguoiNhan = txtNguoiNhanDen.Text.Trim();
                vb.NguoiKy = txtNguoiKyDen.Text.Trim();
                vb.NguoiDuyet = txtNguoiDuyetDen.Text.Trim();
                vb.TrichYeu = txtTrichYeuDen.Text.Trim();
                vb.NoiDung = txtNoiDungDen.Text.Trim();
                vb.DuongDanFile = txtDinhKemFileDen.Text.Trim();
                vb.DaXoa = false; // Mặc định là chưa xóa

                // Cập nhật văn bản đến
                int result = vbDenContrl.CapNhat(vb);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật văn bản đến thành công!");
                    cboSoVanBanDen.SelectedIndex = -1;
                    cboLoaiVanBanDen.SelectedIndex = -1;
                    cboNoiBanHanhDen.SelectedIndex = -1;
                    txtSoDen.Clear();
                    txtSoKyHieuDen.Clear();
                    txtSoTrangDen.Clear();
                    txtNguoiDuyetDen.Clear();
                    txtNguoiNhanDen.Clear();
                    txtNguoiKyDen.Clear();
                    txtNoiDungDen.Clear();
                    txtTrichYeuDen.Clear();
                    txtDinhKemFileDen.Clear();

                    dateNgayBanHanhDen.Value = DateTime.Now;
                    dateNgayDen.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("Cập nhật văn bản đến thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemVanBanDi_Click(object sender, EventArgs e)
        {
            try
            {
                string input = cboSoVanBanDi.SelectedItem.ToString().Trim();
                if (string.IsNullOrEmpty(input) || !input.Contains("-"))
                {
                    MessageBox.Show("Chuỗi không hợp lệ. Vui lòng nhập theo định dạng 'Tên văn bản - Năm'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VanBanDiModel vbDi = new VanBanDiModel();
                string tenso = null;
                int nam = 0;

                string[] parts = input.Split('-');
                if (parts.Length == 2)
                {
                    tenso = parts[0].Trim();
                    try
                    {
                        nam = int.Parse(parts[1].Trim());
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Năm không hợp lệ. Vui lòng nhập năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chuỗi không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vbDi.TenSo = tenso;
                vbDi.Nam = nam;

                // Kiểm tra các trường nhập liệu khác 
                if (string.IsNullOrEmpty(txtNoiNhanDi.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng chọn nơi nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboLoaiVanBanDi.SelectedItem == null || string.IsNullOrEmpty(cboLoaiVanBanDi.SelectedItem.ToString().Trim()))
                {
                    MessageBox.Show("Vui lòng chọn loại văn bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra ngày tháng 
                if (dateNgayBanHanhDi.Value == null || dateNgayBanHanhDi.Value == DateTime.MinValue)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ ngày tháng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vbDi.SoKyHieu = txtSoKiHieuDi.Text.Trim();
                vbDi.NgayBanHanh = dateNgayBanHanhDi.Value;
                vbDi.NoiNhan = txtNoiNhanDi.Text.Trim();
                vbDi.LoaiVanBan = cboLoaiVanBanDi.SelectedItem.ToString().Trim();

                try
                {
                    vbDi.SoDi = int.Parse(txtSoDi.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Số đi phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vbDi.NgayBanHanh = dateNgayBanHanhDi.Value;
                vbDi.SoTrang = int.Parse(txtSoTrangDi.Text.Trim());
                vbDi.NguoiGui = txtNguoiGuiDi.Text.Trim();
                vbDi.NguoiKy = txtNguoiKyDi.Text.Trim();
                vbDi.NguoiDuyet = txtNguoiDuyetDi.Text.Trim();
                vbDi.TrichYeu = txtTrichYeuDi.Text.Trim();
                vbDi.NoiDung = txtNoiDungDi.Text.Trim();
                vbDi.DuongDanFile = txtDinhKemFileDi.Text.Trim();
                vbDi.DaXoa = false; // Mặc định là chưa xóa 

                // Kiểm tra xem file đính kèm có hợp lệ không 
                string filePath = txtDinhKemFileDi.Text.Trim();
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Vui lòng chọn file đính kèm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm văn bản đi vào cơ sở dữ liệu 
                VanBanDiController vbDiController = new VanBanDiController();
                int result = vbDiController.Them(vbDi);
                if (result > 0)
                {
                    MessageBox.Show("Thêm văn bản đi thành công!");
                    TabChua.SelectTab(4);
                    cboSoVanBanDi.SelectedIndex = -1;
                    txtSoKiHieuDi.Clear();
                    txtSoDi.Clear();
                    dateNgayBanHanhDi.Value = DateTime.Now;
                    cboLoaiVanBanDi.SelectedIndex = -1;
                    txtSoTrangDi.Clear();
                    txtSoLuongBanDi.Clear();
                    txtNguoiGuiDi.Clear();
                    txtNguoiKyDi.Clear();
                    txtNguoiDuyetDi.Clear();
                    txtTrichYeuDi.Clear();
                    txtNoiDungDi.Clear();
                    txtDinhKemFileDi.Clear();
                    txtNoiNhanDi.Clear();
                    KhoiTaoVanBanDi();

                    KhoiTaoVanBanDi();
                }
                else
                {
                    MessageBox.Show("Thêm văn bản đi thất bại!");
                }
            }
            catch (Exception ex) // Sửa tên biến ở đây
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thư mục gốc dự án (lùi lên 3 cấp)
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                // Thư mục Quan ly van ban
                string allowedFolder = Path.Combine(projectRoot, "Quan ly van ban");

                // Kiểm tra nếu thư mục Quan ly van ban không tồn tại
                if (!Directory.Exists(allowedFolder))
                {
                    MessageBox.Show("Thư mục Quan ly van ban không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Khởi tạo hộp thoại chọn file
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Tất cả các tệp (*.*)|*.*",
                    Title = "Chọn tệp đính kèm",
                    InitialDirectory = allowedFolder // Thiết lập thư mục mặc định
                };

                // Hiển thị hộp thoại
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string absolutePath = fileDialog.FileName;

                    // Kiểm tra xem tệp có nằm trong thư mục Quan ly van ban không
                    if (!absolutePath.StartsWith(allowedFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Tệp đã chọn không nằm trong thư mục Quan ly van ban của dự án.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy tên tệp tin (chỉ lấy tên không có đường dẫn)
                    string tenTL = Path.GetFileName(absolutePath); // Tên tệp tin

                    // Lưu tên tệp vào textbox
                    txtDinhKemFileDi.Text = tenTL;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thư mục gốc dự án (lùi lên 3 cấp)
                string projectRoot = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

                // Thư mục Quan ly van ban
                string allowedFolder = Path.Combine(projectRoot, "Quan ly van ban");

                // Kiểm tra nếu thư mục Quan ly van ban không tồn tại
                if (!Directory.Exists(allowedFolder))
                {
                    MessageBox.Show("Thư mục Quan ly van ban không tồn tại. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Khởi tạo hộp thoại chọn file
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "Tất cả các tệp (*.*)|*.*",
                    Title = "Chọn tệp đính kèm",
                    InitialDirectory = allowedFolder // Thiết lập thư mục mặc định
                };

                // Hiển thị hộp thoại
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string absolutePath = fileDialog.FileName;

                    // Kiểm tra xem tệp có nằm trong thư mục Quan ly van ban không
                    if (!absolutePath.StartsWith(allowedFolder, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Tệp đã chọn không nằm trong thư mục Quan ly van ban của dự án.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lấy tên tệp tin (chỉ lấy tên không có đường dẫn)
                    string tenTL = Path.GetFileName(absolutePath); // Tên tệp tin

                    // Lưu tên tệp vào textbox
                    txtDinhKemFileDen.Text = tenTL;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tblDanhSachVanBanDen_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        int rowSelectedDi;
        private void tblDanhSachVanBanDi_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnLuuDSDen_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuuVanBanDi_Click_1(object sender, EventArgs e)
        {
            try
            {
                VanBanDiController vbDiController = new VanBanDiController();

                // Lấy văn bản đã chọn từ danh sách và id (nếu có danh sách trước đó)
                VanBanDiModel vanbandi = dsvbdi[rowSelectedDi];
                int id = vanbandi.Id;
                Console.WriteLine("ID LÀ: " + id);

                // Khởi tạo đối tượng Văn Bản Đi
                VanBanDiModel vb = new VanBanDiModel();
                vb.Id = id; // Gán id văn bản đi (nếu cập nhật)

                string input = cboSoVanBanDi.SelectedItem.ToString().Trim();
                string tenso = null;
                int nam = 0;

                // Kiểm tra định dạng chuỗi
                if (string.IsNullOrEmpty(input) || !input.Contains("-"))
                {
                    MessageBox.Show("Chuỗi không hợp lệ. Vui lòng nhập theo định dạng 'Tên văn bản - Năm'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string[] parts = input.Split('-');
                    if (parts.Length == 2)
                    {
                        tenso = parts[0].Trim();
                        try
                        {
                            nam = int.Parse(parts[1].Trim());
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show("Năm không hợp lệ. Vui lòng nhập năm hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chuỗi không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Gán thông tin vào đối tượng Văn Bản Đi
                vb.TenSo = tenso;
                vb.Nam = nam;

                // Kiểm tra ngày tháng
                if (dateNgayBanHanhDi.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn ngày ban hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                vb.NgayBanHanh = dateNgayBanHanhDi.Value;
                vb.SoKyHieu = txtSoKiHieuDi.Text.Trim();
                vb.NoiNhan = txtNoiNhanDi.Text.Trim();
                vb.LoaiVanBan = cboLoaiVanBanDi.SelectedItem.ToString().Trim();

                // Kiểm tra số đi
                try
                {
                    vb.SoDi = int.Parse(txtSoDi.Text.Trim());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Số đi phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra số lượng bản và số trang
                try
                {
                    vb.SlBan = int.Parse(txtSoLuongBanDi.Text.Trim());
                    vb.SoTrang = int.Parse(txtSoTrangDi.Text.Trim());
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Số lượng bản và số trang phải là các số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                vb.NguoiGui = txtNguoiGuiDi.Text.Trim();
                vb.NguoiKy = txtNguoiKyDi.Text.Trim();
                vb.NguoiDuyet = txtNguoiDuyetDi.Text.Trim();
                vb.TrichYeu = txtTrichYeuDi.Text.Trim();
                vb.NoiDung = txtNoiDungDi.Text.Trim();
                vb.DuongDanFile = txtDinhKemFileDi.Text.Trim();
                vb.DaXoa = false; // Mặc định là chưa xóa

                // Gọi phương thức cập nhật văn bản đi
                int result = vbDiController.CapNhat(vb);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật văn bản đi thành công!");
                    cboSoVanBanDi.SelectedIndex = -1;
                    txtSoKiHieuDi.Clear();
                    txtSoDi.Clear();
                    dateNgayBanHanhDi.Value = DateTime.Now;
                    cboLoaiVanBanDi.SelectedIndex = -1;
                    txtSoTrangDi.Clear();
                    txtSoLuongBanDi.Clear();
                    txtNguoiGuiDi.Clear();
                    txtNguoiKyDi.Clear();
                    txtNguoiDuyetDi.Clear();
                    txtTrichYeuDi.Clear();
                    txtNoiDungDi.Clear();
                    txtDinhKemFileDi.Clear();
                    txtNoiNhanDi.Clear();
                    KhoiTaoVanBanDi();
                }
                else
                {
                    MessageBox.Show("Cập nhật văn bản đi thất bại!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi ngoại lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnTaiLaiVanBanDi_Click_1(object sender, EventArgs e)
        {
            KhoiTaoVanBanDi();
            cboSoVanBanDi.SelectedIndex = -1;
            cboLoaiVanBanDi.SelectedIndex = -1;
            txtSoKiHieuDi.Clear();
            txtSoDi.Clear();
            txtSoTrangDi.Clear();
            txtNguoiGuiDi.Clear();
            txtNguoiKyDi.Clear();
            txtNguoiDuyetDi.Clear();
            txtTrichYeuDi.Clear();
            txtNoiDungDi.Clear();
            txtDinhKemFileDi.Clear();
        }

        private void btnTaiLaiVanBanDen_Click(object sender, EventArgs e)
        {
            KhoiTaoVanBanDen();
            cboSoVanBanDen.SelectedIndex = -1;
            cboLoaiVanBanDen.SelectedIndex = -1;
            cboNoiBanHanhDen.SelectedIndex = -1;
            txtSoKyHieuDen.Clear();
            txtSoDen.Clear();
            txtSoTrangDen.Clear();
            txtNguoiNhanDen.Clear();
            txtNguoiKyDen.Clear();
            txtNguoiDuyetDen.Clear();
            txtTrichYeuDen.Clear();
            txtNoiDungDen.Clear();
            txtDinhKemFileDen.Clear();
        }

        private void tblDanhSachVanBanDen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bật nút Lưu và tắt nút Thêm
            btnLuuVanBanDen.Enabled = true;
            btnThemVanBanDen.Enabled = false;

            // Kiểm tra nếu có dòng nào được chọn
            if (e.RowIndex >= 0)
            {
                // Lấy chỉ mục dòng đã chọn
                rowSelectedDen = e.RowIndex;

                // Lấy đối tượng VanBanDen từ danh sách dsvbden
                VanBanDenModel vanbanden = dsvbden[rowSelectedDen];

                // Cập nhật các trường trong giao diện với thông tin từ đối tượng vanbanden
                cboSoVanBanDen.SelectedItem = $"{vanbanden.TenSo}-{vanbanden.Nam}"; // Cập nhật tên sổ
                txtSoKyHieuDen.Text = vanbanden.SoKyHieu; // Cập nhật số ký hiệu

                // Cập nhật ngày ban hành
                dateNgayBanHanhDen.Value = vanbanden.NgayBanHanh;

                // Cập nhật nơi ban hành
                cboNoiBanHanhDen.SelectedItem = vanbanden.NoiBanHanh;

                // Cập nhật loại văn bản
                cboLoaiVanBanDen.SelectedItem = vanbanden.LoaiVanBan;

                // Cập nhật số đến
                txtSoDen.Text = vanbanden.SoDen.ToString();
                dateNgayDen.Value = vanbanden.NgayDen;
                txtSoTrangDen.Text = vanbanden.SoTrang.ToString();

                // Cập nhật người nhận
                txtNguoiNhanDen.Text = vanbanden.NguoiNhan;

                // Cập nhật người ký
                txtNguoiKyDen.Text = vanbanden.NguoiKy;

                // Cập nhật người duyệt
                txtNguoiDuyetDen.Text = vanbanden.NguoiDuyet;
                txtTrichYeuDen.Text = vanbanden.TrichYeu;
                txtNoiDungDen.Text = vanbanden.NoiDung;
                txtDinhKemFileDen.Text = vanbanden.DuongDanFile;
            }
            TabChua.SelectedIndex = 3;

        }

        private void tblDanhSachVanBanDi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuuVanBanDi.Enabled = true;
            btnThemVanBanDi.Enabled = false;

            // Kiểm tra nếu có dòng nào được chọn
            if (e.RowIndex >= 0)
            {
                // Lấy chỉ mục dòng đã chọn
                rowSelectedDi = e.RowIndex;

                // Lấy đối tượng VanBanDi từ danh sách dsvbdi
                VanBanDiModel vanbandi = dsvbdi[rowSelectedDi];

                // Cập nhật các trường trong giao diện với thông tin từ đối tượng vanbandi
                cboSoVanBanDi.SelectedItem = $"{vanbandi.TenSo}-{vanbandi.Nam}"; // Cập nhật tên sổ
                txtSoKiHieuDi.Text = vanbandi.SoKyHieu; // Cập nhật số ký hiệu

                // Cập nhật ngày ban hành
                dateNgayBanHanhDi.Value = vanbandi.NgayBanHanh;

                // Cập nhật nơi nhận
                cboLoaiVanBanDi.SelectedItem = vanbandi.NoiNhan;

                // Cập nhật loại văn bản
                cboLoaiVanBanDi.SelectedItem = vanbandi.LoaiVanBan;
                txtNoiNhanDi.Text = vanbandi.NoiNhan;

                // Cập nhật số đi
                txtSoDi.Text = vanbandi.SoDi.ToString();
                txtSoLuongBanDi.Text = vanbandi.SlBan.ToString();
                txtSoTrangDi.Text = vanbandi.SoTrang.ToString();

                // Cập nhật người nhận
                txtNguoiGuiDi.Text = vanbandi.NguoiGui;

                // Cập nhật người ký
                txtNguoiKyDi.Text = vanbandi.NguoiKy;

                // Cập nhật người duyệt
                txtNguoiDuyetDi.Text = vanbandi.NguoiDuyet;
                txtTrichYeuDi.Text = vanbandi.TrichYeu;
                txtNoiDungDi.Text = vanbandi.NoiDung;
                txtDinhKemFileDi.Text = vanbandi.DuongDanFile;

                // Chuyển sang tab thứ 4


            }
            TabChua.SelectedIndex = 4;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = SoVanBan;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = LoaiVanBan;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = NoiBanHanh;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = VanBanDen;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = VanBanDi;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = DanhSachVanBanDen;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = DanhSachVanBanDi;
        }

        private void button4_Click(object sender, EventArgs e)
        {


            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = VanBanDen;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = SoVanBan;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = DanhSachVanBanDen;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage8;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = VanBanDi;
        }

        private void button21_Click(object sender, EventArgs e)
        {

            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = NoiBanHanh;
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = LoaiVanBan;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabQuanLyVanBan;

            TabChua.SelectedTab = LoaiVanBan;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPagePhongBan;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPageDSVBNoiBo;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPageDSVBNoiBo;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPagePhongBan;
        }

        private void button32_Click(object sender, EventArgs e)
        {

            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage9;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage7;
        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = ThoiGianTimKiemDi.SelectedItem.ToString();
            DateTime? startDate = null, endDate = null;

            switch (selectedItem)
            {
                case "Hôm nay":
                    startDate = GetTodayStart();
                    endDate = GetTodayEnd();
                    break;
                case "Tuần này":
                    startDate = GetWeekStart();
                    endDate = GetWeekEnd();
                    break;
                case "Tháng này":
                    startDate = GetMonthStart();
                    endDate = GetMonthEnd();
                    break;
                case "Năm nay":
                    startDate = GetYearStart();
                    endDate = GetYearEnd();
                    break;
                case "Tháng 1":
                    startDate = GetMonthStart(1);
                    endDate = GetMonthEnd(1);
                    break;
                case "Tháng 2":
                    startDate = GetMonthStart(2);
                    endDate = GetMonthEnd(2);
                    break;
                case "Tháng 3":
                    startDate = GetMonthStart(3);
                    endDate = GetMonthEnd(3);
                    break;
                case "Tháng 4":
                    startDate = GetMonthStart(4);
                    endDate = GetMonthEnd(4);
                    break;
                case "Tháng 5":
                    startDate = GetMonthStart(5);
                    endDate = GetMonthEnd(5);
                    break;
                case "Tháng 6":
                    startDate = GetMonthStart(6);
                    endDate = GetMonthEnd(6);
                    break;
                case "Tháng 7":
                    startDate = GetMonthStart(7);
                    endDate = GetMonthEnd(7);
                    break;
                case "Tháng 8":
                    startDate = GetMonthStart(8);
                    endDate = GetMonthEnd(8);
                    break;
                case "Tháng 9":
                    startDate = GetMonthStart(9);
                    endDate = GetMonthEnd(9);
                    break;
                case "Tháng 10":
                    startDate = GetMonthStart(10);
                    endDate = GetMonthEnd(10);
                    break;
                case "Tháng 11":
                    startDate = GetMonthStart(11);
                    endDate = GetMonthEnd(11);
                    break;
                case "Tháng 12":
                    startDate = GetMonthStart(12);
                    endDate = GetMonthEnd(12);
                    break;
                case "Năm trước":
                    startDate = GetPreviousYearStart();
                    endDate = GetPreviousYearEnd();
                    break;
                default:
                    break;
            }

            // Kiểm tra và thiết lập giá trị cho các control hiển thị ngày
            if (startDate.HasValue && endDate.HasValue)
            {
                dateTimKiemDiMin.Value = startDate.Value; // Đặt giá trị "từ ngày"
                dateTimKiemDiMax.Value = endDate.Value;   // Đặt giá trị "đến ngày"

                // Gọi phương thức để hiển thị danh sách văn bản trong khoảng thời gian
                HienThiDanhSachVanBanDiTheoNgay(startDate.Value, endDate.Value);
            }

        }



        private void ThoiGianTimKiemDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = ThoiGianTimKiemDen.SelectedItem.ToString();
            DateTime? startDate = null, endDate = null;
            switch (selectedItem)
            {
                case "Hôm nay":
                    startDate = GetTodayStart();
                    endDate = GetTodayEnd();
                    break;
                case "Tuần này":
                    startDate = GetWeekStart();
                    endDate = GetWeekEnd();
                    break;
                case "Tháng này":
                    startDate = GetMonthStart();
                    endDate = GetMonthEnd();
                    break;
                case "Năm nay":
                    startDate = GetYearStart();
                    endDate = GetYearEnd();
                    break;
                case "Tháng 1":
                    startDate = GetMonthStart(1);
                    endDate = GetMonthEnd(1);
                    break;
                case "Tháng 2":
                    startDate = GetMonthStart(2);
                    endDate = GetMonthEnd(2);
                    break;
                case "Tháng 3":
                    startDate = GetMonthStart(3);
                    endDate = GetMonthEnd(3);
                    break;
                case "Tháng 4":
                    startDate = GetMonthStart(4);
                    endDate = GetMonthEnd(4);
                    break;
                case "Tháng 5":
                    startDate = GetMonthStart(5);
                    endDate = GetMonthEnd(5);
                    break;
                case "Tháng 6":
                    startDate = GetMonthStart(6);
                    endDate = GetMonthEnd(6);
                    break;
                case "Tháng 7":
                    startDate = GetMonthStart(7);
                    endDate = GetMonthEnd(7);
                    break;
                case "Tháng 8":
                    startDate = GetMonthStart(8);
                    endDate = GetMonthEnd(8);
                    break;
                case "Tháng 9":
                    startDate = GetMonthStart(9);
                    endDate = GetMonthEnd(9);
                    break;
                case "Tháng 10":
                    startDate = GetMonthStart(10);
                    endDate = GetMonthEnd(10);
                    break;
                case "Tháng 11":
                    startDate = GetMonthStart(11);
                    endDate = GetMonthEnd(11);
                    break;
                case "Tháng 12":
                    startDate = GetMonthStart(12);
                    endDate = GetMonthEnd(12);
                    break;
                case "Năm trước":
                    startDate = GetPreviousYearStart();
                    endDate = GetPreviousYearEnd();
                    break;
                default:
                    break;
            }

            // Kiểm tra và thiết lập giá trị cho các control hiển thị ngày
            if (startDate.HasValue && endDate.HasValue)
            {
                dateTimKiemDenMin.Value = startDate.Value; // Đặt giá trị "từ ngày"
                dateTimKiemDenMax.Value = endDate.Value;   // Đặt giá trị "đến ngày"
                Console.WriteLine(dateTimKiemDenMax.Value + "" + dateTimKiemDenMin);
                HienThiDanhSachVanBanDenTheoNgay(startDate.Value, endDate.Value);
            }

        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = ThoiGianTimKiemDen.SelectedItem.ToString();
                DateTime? startDate = null, endDate = null;

                // Kiểm tra giá trị đã chọn và thiết lập thời gian bắt đầu và kết thúc
                switch (selectedItem)
                {
                    case "Hôm nay":
                        startDate = GetTodayStart();
                        endDate = GetTodayEnd();
                        break;
                    case "Tuần này":
                        startDate = GetWeekStart();
                        endDate = GetWeekEnd();
                        break;
                    case "Tháng này":
                        startDate = GetMonthStart();
                        endDate = GetMonthEnd();
                        break;
                    case "Năm nay":
                        startDate = GetYearStart();
                        endDate = GetYearEnd();
                        break;
                    case "Năm trước":
                        startDate = GetPreviousYearStart();
                        endDate = GetPreviousYearEnd();
                        break;
                    default:
                        break;
                }

                // Lấy giá trị tìm kiếm từ các trường nhập liệu
                string input = cboTimKiemSoVanBanDen.SelectedItem.ToString().Trim();
                string[] parts = input.Split('-');

                string soVanBan = parts.Length > 0 ? parts[0].Trim() : "";
                int nam = parts.Length > 1 ? int.Parse(parts[1].Trim()) : 0;
                string loaiVanBanDi = cboTimKiemLoaiVanBanDen.SelectedItem.ToString().Trim();
                string soKyHieu = txtTimKiemSoKyHieuDen.Text.Trim();
                string noiBanHanh = txtNoiBanHanhDen.Text.Trim();
                string noiDung = txtTimKiemDen.Text.Trim();

                // Kiểm tra và gán null cho các giá trị "Tất cả"
                if (soVanBan.Equals("Tất cả"))
                    soVanBan = null;
                if (loaiVanBanDi.Equals("Tất cả"))
                    loaiVanBanDi = null;

                Console.WriteLine($"{soVanBan} {loaiVanBanDi} {soKyHieu} {noiBanHanh} {noiDung} {nam}");

                // Gọi phương thức tìm kiếm văn bản đến
                VanBanDenController vbdiContrl = new VanBanDenController();
                var dsden = vbdiContrl.SearchVanBanDen(soVanBan, nam, loaiVanBanDi, soKyHieu, noiBanHanh, noiDung, startDate, endDate);


                // Lấy DataGridView để hiển thị kết quả
                DataGridView dgv = tblTimKiemDanhSachVanBanDen;  // Assuming tblTimKiemDanhSachVanBanDen is a DataGridView
                dgv.Rows.Clear(); // Xóa dữ liệu cũ trên bảng

                // Kiểm tra và hiển thị kết quả
                if (dsden.Count == 0)
                {
                    // Nếu không tìm thấy dữ liệu
                    MessageBox.Show("Không tìm thấy văn bản nào thỏa mãn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Hiển thị kết quả tìm kiếm
                    foreach (var vbDen in dsden)
                    {
                        dgv.Rows.Add(new object[]
                        {
                    dgv.Rows.Count + 1, // STT
                    vbDen.TenSo,
                    vbDen.LoaiVanBan,
                    vbDen.SoKyHieu,
                    vbDen.SoDen,
                    vbDen.NgayBanHanh,
                    vbDen.NgayDen,
                    vbDen.NoiBanHanh,
                    vbDen.TrichYeu
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị thời gian tìm kiếm
                string selectedItem = ThoiGianTimKiemDi.SelectedItem.ToString();
                DateTime? startDate = null, endDate = null;

                // Thiết lập thời gian bắt đầu và kết thúc dựa trên lựa chọn
                switch (selectedItem)
                {
                    case "Hôm nay":
                        startDate = GetTodayStart();
                        endDate = GetTodayEnd();
                        break;
                    case "Tuần này":
                        startDate = GetWeekStart();
                        endDate = GetWeekEnd();
                        break;
                    case "Tháng này":
                        startDate = GetMonthStart();
                        endDate = GetMonthEnd();
                        break;
                    case "Năm nay":
                        startDate = GetYearStart();
                        endDate = GetYearEnd();
                        break;
                    case "Năm trước":
                        startDate = GetPreviousYearStart();
                        endDate = GetPreviousYearEnd();
                        break;
                    default:
                        break;
                }

                // Tách và lấy giá trị từ combobox và textboxes
                string input = cboTimKiemSoVanBanDi.SelectedItem.ToString().Trim();
                string[] parts = input.Split('-'); // Tách chuỗi tại dấu '-'

                string soVanBan = parts.Length > 0 ? parts[0].Trim() : "";
                int nam = parts.Length > 1 ? int.Parse(parts[1].Trim()) : 0;
                string loaiVanBanDi = cboTimKiemLoaiVanBanDi.SelectedItem.ToString().Trim();
                string soKyHieu = txtTimKiemSoKyHieuDi.Text;
                string noiNhan = txtNoiNhanTimKiemDi.Text;
                string noiDung = txtTimKiemDi.Text;

                // Nếu "Tất cả", gán null cho các giá trị tương ứng
                if (soVanBan.Equals("Tất cả"))
                    soVanBan = null;
                if (loaiVanBanDi.Equals("Tất cả"))
                    loaiVanBanDi = null;

                // In ra các giá trị tìm kiếm để kiểm tra
                Console.WriteLine($"{soVanBan} {loaiVanBanDi} {soKyHieu} {noiNhan} {noiDung} {nam}");

                // Gọi controller và tìm kiếm
                VanBanDiController vbdiController = new VanBanDiController();
                var dsdi = vbdiController.Search(soVanBan, nam, loaiVanBanDi, soKyHieu, noiNhan, noiDung, startDate, endDate);

                // Cập nhật DataGridView
                tblTimKiemDanhSachVanBanDi.Rows.Clear(); // Xóa dữ liệu cũ trên bảng

                if (dsdi.Count == 0)
                {
                    // Nếu không tìm thấy dữ liệu
                    MessageBox.Show("Không tìm thấy văn bản nào thỏa mãn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Hiển thị kết quả tìm kiếm
                    for (int i = 0; i < dsdi.Count; i++)
                    {
                        VanBanDiModel vbDi = dsdi[i];
                        tblTimKiemDanhSachVanBanDi.Rows.Add(new object[]
                        {
                    i + 1, // STT
                    vbDi.TenSo,
                    vbDi.LoaiVanBan,
                    vbDi.SoKyHieu,
                    vbDi.SoDi,
                    vbDi.NgayBanHanh,
                    vbDi.NoiNhan,
                    vbDi.TrichYeu
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button40_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (tblTimKiemDanhSachVanBanDi.SelectedRows.Count > 0)
            {
                // Lấy chỉ số dòng được chọn
                int rowIndex = tblTimKiemDanhSachVanBanDi.SelectedRows[0].Index;

                // Lấy dữ liệu từ danh sách dựa trên chỉ số dòng
                vanBanDiChiTiet = dstimkiemdi[rowIndex];

                // Hiển thị thông tin chi tiết (nếu cần)
                Console.WriteLine(vanBanDiChiTiet.ToString());

                // Mở form chi tiết và truyền dữ liệu nếu cần

                ChiTietVanBanDi form = new ChiTietVanBanDi();
                form.Show();
            }
            else
            {
                // Thông báo nếu chưa chọn dòng nào
                MessageBox.Show("Chưa chọn dòng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button36_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (tblTimKiemDanhSachVanBanDen.SelectedRows.Count > 0)
            {
                // Lấy chỉ số dòng được chọn
                int rowIndex = tblTimKiemDanhSachVanBanDen.SelectedRows[0].Index;

                // Giả sử `dstimkiemden` là danh sách dữ liệu được bind vào DataGridView
                vanBanDenChiTiet = dstimkiemden[rowIndex];

                // Hiển thị thông tin chi tiết (ví dụ: trong console hoặc log)
                Console.WriteLine(vanBanDenChiTiet.ToString());

                // Mở form chi tiết
                ChiTietVanBanDen form = new ChiTietVanBanDen();
                form.Show();
            }
            else
            {
                // Thông báo nếu không có dòng nào được chọn
                MessageBox.Show("Chưa chọn dòng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đăngNhậpLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Hide();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabTongQuat.SelectedTab = tabTrangChu;


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuDSDi_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị SaveFileDialog để chọn nơi lưu file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Chọn nơi lưu file Excel";
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Lấy dữ liệu từ DataGridView
                        DataGridView table = tblDanhSachVanBanDen; // Thay bằng tên DataGridView của bạn
                        int rowCount = table.Rows.Count;
                        int columnCount = table.Columns.Count;

                        // Tạo file Excel mới
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet sheet = excelPackage.Workbook.Worksheets.Add("Văn Bản Đến");

                            // Thêm tiêu đề vào Excel
                            for (int col = 0; col < columnCount; col++)
                            {
                                sheet.Cells[1, col + 1].Value = table.Columns[col].HeaderText;
                                sheet.Cells[1, col + 1].Style.Font.Bold = true;
                                sheet.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                sheet.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                                sheet.Cells[1, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            // Thêm dữ liệu vào Excel
                            for (int row = 0; row < rowCount; row++)
                            {
                                for (int col = 0; col < columnCount; col++)
                                {
                                    var cellValue = table.Rows[row].Cells[col].Value;
                                    sheet.Cells[row + 2, col + 1].Value = cellValue?.ToString() ?? string.Empty;
                                    sheet.Cells[row + 2, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }
                            }

                            // Tự động điều chỉnh độ rộng cột
                            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                            // Lưu file ra đĩa
                            FileInfo fileInfo = new FileInfo(filePath);
                            excelPackage.SaveAs(fileInfo);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel sau khi xuất
                        if (File.Exists(filePath))
                        {
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị SaveFileDialog để chọn nơi lưu file
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Chọn nơi lưu file Excel";
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Lấy dữ liệu từ DataGridView
                        DataGridView dataGridView = tblTimKiemDanhSachVanBanDi; // Thay bằng tên DataGridView của bạn
                        int rowCount = dataGridView.Rows.Count;
                        int columnCount = dataGridView.Columns.Count;

                        // Tạo file Excel mới
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Văn Bản Đi");

                            // Thêm tiêu đề cột
                            for (int col = 0; col < columnCount; col++)
                            {
                                worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                                worksheet.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                                worksheet.Cells[1, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }

                            // Thêm dữ liệu từ DataGridView
                            for (int row = 0; row < rowCount; row++)
                            {
                                for (int col = 0; col < columnCount; col++)
                                {
                                    var cellValue = dataGridView.Rows[row].Cells[col].Value;
                                    worksheet.Cells[row + 2, col + 1].Value = cellValue?.ToString() ?? string.Empty;
                                    worksheet.Cells[row + 2, col + 1].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                }
                            }

                            // Tự động điều chỉnh độ rộng cột
                            worksheet.Cells.AutoFitColumns();

                            // Lưu file Excel ra đĩa
                            FileInfo fileInfo = new FileInfo(filePath);
                            excelPackage.SaveAs(fileInfo);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở file Excel vừa xuất
                        if (File.Exists(filePath))
                        {
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelVanBanDi_Click(object sender, EventArgs e)
        {

        }
    }
}
