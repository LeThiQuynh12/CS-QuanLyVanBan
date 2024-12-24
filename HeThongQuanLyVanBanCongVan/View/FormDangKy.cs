using HeThongQuanLyVanBanCongVan.Controllers;
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

namespace HeThongQuanLyVanBanCongVan.View
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string coQuan = txtCoQuan.Text.Trim();
            string hoVaTen = txtHovaten.Text.Trim();
            string email = txtEmail.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
            string tenTaiKhoan = txtTenTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string vaitro = "user";
            // Kiểm tra tính hợp lệ
            if (string.IsNullOrEmpty(coQuan) || string.IsNullOrEmpty(hoVaTen) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau) )
                
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Khởi tạo controller
                DangKyController controller = new DangKyController();

                // Kiểm tra tồn tại
                if (controller.IsPhoneNumberExist(soDienThoai))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (controller.IsEmailExist(email))
                {
                    MessageBox.Show("Email đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (controller.IsUsernameExist(tenTaiKhoan))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm người dùng
                controller.ThemNguoiDung(coQuan, hoVaTen, soDienThoai, email, tenTaiKhoan, matKhau, vaitro);
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng các ô nhập liệu
                ClearForm();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi cơ sở dữ liệu: {sqlEx.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Hàm xóa trắng các ô nhập liệu
        private void ClearForm()
        {
            txtCoQuan.Text = "";
            txtHovaten.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            dn.ShowDialog();
            this.Hide();
        }
    }

    }
