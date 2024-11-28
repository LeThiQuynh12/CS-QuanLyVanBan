using HeThongQuanLyVanBanCongVan.Controllers;
using HeThongQuanLyVanBanCongVan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan
{
    public partial class TrangChu : Form
    {
        private DataGridView tbPhongBan;
        private DataTable tableModelPhongBan;
        public TrangChu()
        {
            InitializeComponent();
            initTablePhongBan();
            fillDataPhongBan();
            MessageBox.Show("Bảng đã được thêm vào form");
        }
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
                dataGridViewPhongBan.Rows.Add(i + 1, lst[i].TenPhongBan, lst[i].MaPhongBan);
            }
        }

        private void picThemPhongBan_Click(object sender, EventArgs e)
        { // Tạo dòng mới với số thứ tự tự động tăng
            int rowCount = dataGridViewPhongBan.Rows.Count; // Sử dụng đúng đối tượng DataGridView
            dataGridViewPhongBan.Rows.Add(rowCount + 1, "", "null"); // Thêm dòng mới với số thứ tự tự động tăng

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
           // loadComboboxData();
            MessageBox.Show("Lưu toàn bộ dữ liệu thành công.");
        }
    }
}
