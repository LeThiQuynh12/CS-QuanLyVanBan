using HeThongQuanLyVanBanCongVan.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan.View
{
    public partial class ChiTietVanBanNoiBo : Form
    {
        private readonly SqlConnection _connection;
        public ChiTietVanBanNoiBo(
            string sokyhieu, string tenvanban, string ngayBanHanhStr,
            string loaibanhanh, string phongbanhanh, string phongbannhan,
            string nguoinhan, string nguoiky, string nguoiduyet,
            string trichyeu, string noidung)
        {
            InitializeComponent();
            initTableTaiLieu();
            _connection = new KetNoiCSDL().GetConnection();
            // Nạp dữ liệu vào combobox
            LoadComboboxData();

            // Hiển thị dữ liệu văn bản nội bộ
            txtSoKyHieu.Text = sokyhieu;
            txtTenVanBan.Text = tenvanban;

            if (DateTime.TryParseExact(ngayBanHanhStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngayBanHanh))
            {
                dateNgayBanHanh.Value = ngayBanHanh;
            }

            cmbLoaiBanHanh.SelectedItem = loaibanhanh;
            cmbPhongBanHanh.SelectedItem = phongbanhanh;
            cmbPhongBanNhan.SelectedItem = phongbannhan;

            txtNguoiNhan.Text = nguoinhan;
            txtNguoiKy.Text = nguoiky;
            txtNguoiDuyet.Text = nguoiduyet;
            txtTrichYeu.Text = trichyeu;
            txtNoiDung.Text = noidung;

            // Thiết lập các trường chỉ đọc
            SetReadOnlyFields();

            // Hiển thị danh sách tài liệu đính kèm
            HienThiTaiLieu(sokyhieu);
        }

        private void SetReadOnlyFields()
        {
            txtSoKyHieu.ReadOnly = true;
            txtTenVanBan.ReadOnly = true;
            dateNgayBanHanh.Enabled = false;
            cmbLoaiBanHanh.Enabled = false;
            cmbPhongBanHanh.Enabled = false;
            cmbPhongBanNhan.Enabled = false;
            txtNguoiNhan.ReadOnly = true;
            txtNguoiKy.ReadOnly = true;
            txtNguoiDuyet.ReadOnly = true;
            txtTrichYeu.ReadOnly = true;
            txtNoiDung.ReadOnly = true;
        }





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
        }

        private void HienThiTaiLieu(string soKyHieu)
        {
            try
            {
                string query = @"SELECT 
                                    t.MaTL, 
                                    t.TenTL, 
                                    t.NgayTao, 
                                    t.KichCo, 
                                    t.Loai, 
                                    t.DuongDan 
                                FROM VanBanNoiBo vb
                                JOIN TaiLieu t ON vb.MaTL = t.MaTL
                                WHERE vb.SoKyHieu = @SoKyHieu";

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@SoKyHieu", soKyHieu);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader);

                        foreach (DataRow row in table.Rows)
                        {
                            dataGridViewTaiLieu.Rows.Add(
                                row["MaTL"].ToString(),
                                row["TenTL"].ToString(),
                                row["NgayTao"].ToString(),
                                row["KichCo"].ToString(),
                                row["Loai"].ToString(),
                                row["DuongDan"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn tài liệu đính kèm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public class KetNoiCSDL
        {
            // Đảm bảo kết nối là readonly và sử dụng chuỗi kết nối đúng
            protected readonly SqlConnection conn;

            // Constructor
            public KetNoiCSDL()
            {
                try
                {
                    // Chuỗi kết nối mới
                    string connectionString = @"Data Source=localhost,1433;Initial Catalog=QUANLYCONGVAN;User ID=sa;Password=11101978;Encrypt=False;";

                    // Khởi tạo kết nối
                    conn = new SqlConnection(connectionString);

                    // Mở kết nối
                    conn.Open();
                    Console.WriteLine("Kết nối thành công");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối
                    Console.WriteLine("Lỗi kết nối: " + ex.Message);
                    Console.WriteLine(ex.StackTrace); // In chi tiết lỗi để dễ dàng xác định
                }
            }

            // Phương thức trả về kết nối
            public SqlConnection GetConnection()
            {
                return conn;
            }
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
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            // Lấy hàng được chọn trong DataGridView
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
