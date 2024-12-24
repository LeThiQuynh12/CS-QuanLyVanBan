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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent(); txtMatKhau.PasswordChar = '●'; // Hoặc bất kỳ ký tự thay thế nào
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                string tenTaiKhoan = txtTenTaiKhoan.Text; // TextBox
                string matKhau = txtMatKhau.Text; // TextBox sử dụng PasswordChar



                // Thiết lập PasswordChar
                //txtMatKhau.PasswordChar = '●';

                // Hoặc sử dụng hệ thống mật khẩu mặc định
               // txtMatKhau.UseSystemPasswordChar = true;


                // Kiểm tra đăng nhập
                if (tenTaiKhoan == "admin" && matKhau == "admin12345")
                {
                    // Đăng nhập admin
                    MessageBox.Show("Đăng nhập với quyền admin thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrangChu form = new TrangChu();
                    form.Show();
                    this.Close();
                }
                else
                {
                    // Đăng nhập người dùng thường
                    DangNhapController controller = new DangNhapController();
                    if (controller.KiemTraDangNhap(tenTaiKhoan, matKhau))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TrangChu form = new TrangChu();
                        form.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDangKy dk = new FormDangKy();
            dk.Show();
            this.Hide();
        }
    }
}
