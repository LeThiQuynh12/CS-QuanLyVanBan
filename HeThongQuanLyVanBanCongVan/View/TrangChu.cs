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

namespace HeThongQuanLyVanBanCongVan
{
    public partial class TrangChu : Form
    {
        private DataGridView tbPhongBan;
        private DataTable tableModelPhongBan;
        public TrangChu()
        {
            InitializeComponent();
            // Phòng ban
            initTablePhongBan();
            fillDataPhongBan();
            //MessageBox.Show("Bảng đã được thêm vào form");


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
        {// Lấy hàng được chọn trong DataGridView
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
            var position = pictureBox2.PointToScreen(new Point(0, pictureBox2.Height));

            // Hiển thị ContextMenuStrip tại vị trí tính toán
            contextMenuStrip2.Show(position);
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {

        }
        private void button15_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageVanBanNoiBo;
       
            tabControl3.SelectedTab = tabPagePhongBan;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = VBNoiBotabPage;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageVanBanNoiBo;

            tabControl3.SelectedTab = tabPageDSVBNoiBo;
        }

        private void btnThemVBNB_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageVanBanNoiBo;
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


            tabControl2.SelectedTab = tabPageVanBanNoiBo;
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

            // Kiểm tra và thiết lập giá trị cho các control hiển thị ngày
            if (startDate.HasValue && endDate.HasValue)
            {
                dateTimePicker3.Value = startDate.Value; // Đặt giá trị "từ ngày"
                dateTimePicker4.Value = endDate.Value;   // Đặt giá trị "đến ngày"

                // Gọi phương thức để hiển thị danh sách văn bản trong khoảng thời gian
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
            tabControl2.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage7;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPageTimKiem;

            tabControl4.SelectedTab = tabPage8;
        }

        private void button20_Click(object sender, EventArgs e)
        {

            tabControl2.SelectedTab = tabPageTimKiem;

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






     
    }
}

