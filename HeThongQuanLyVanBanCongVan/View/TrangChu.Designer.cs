using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan
{
    partial class TrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1; // Sự kiện nhấn chuột trái trên non-client area
            const int HTCAPTION = 0x2;        // Khu vực tiêu đề của form

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == HTCAPTION)
            {
                return; // Ngăn không cho xử lý sự kiện di chuyển form
            }

            base.WndProc(ref m); // Xử lý các thông điệp khác bình thường
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabPageVanBanNoiBo = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPagePhongBan = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.XuatExcel = new System.Windows.Forms.PictureBox();
            this.picLuu = new System.Windows.Forms.PictureBox();
            this.picXoa = new System.Windows.Forms.PictureBox();
            this.picThemPhongBan = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewPhongBan = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.VBNoiBotabPage = new System.Windows.Forms.TabPage();
            this.btnXoaFile = new System.Windows.Forms.Button();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.btnDinhKem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNguoiDuyet = new System.Windows.Forms.TextBox();
            this.txtNguoiKy = new System.Windows.Forms.TextBox();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.LuuVBNB = new System.Windows.Forms.PictureBox();
            this.ThemVBNB = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dataGridViewTaiLieu = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtNoiDung = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTrichYeu = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dateNgayBanHanh = new System.Windows.Forms.DateTimePicker();
            this.cmbPhongBanNhan = new System.Windows.Forms.ComboBox();
            this.cmbPhongBanHanh = new System.Windows.Forms.ComboBox();
            this.cmbLoaiBanHanh = new System.Windows.Forms.ComboBox();
            this.txtTenVanBan = new System.Windows.Forms.TextBox();
            this.txtSoKyHieu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageDSVBNoiBo = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnXoaVBNB = new System.Windows.Forms.PictureBox();
            this.btnSuaVBNB = new System.Windows.Forms.PictureBox();
            this.btnThemVBNB = new System.Windows.Forms.PictureBox();
            this.dataGridViewVBNB = new System.Windows.Forms.DataGridView();
            this.tabPageTimKiem = new System.Windows.Forms.TabPage();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dataGridViewVBNB1 = new System.Windows.Forms.DataGridView();
            this.label32 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnInbaocao = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.ThoiGianTimKiem = new System.Windows.Forms.ComboBox();
            this.nhapTrichYeu = new System.Windows.Forms.RichTextBox();
            this.nhapTenVanBan = new System.Windows.Forms.TextBox();
            this.nhapSoKyHieu = new System.Windows.Forms.TextBox();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.ChonCmbPhongBanNhan = new System.Windows.Forms.ComboBox();
            this.chonCmbPhongBanHanh = new System.Windows.Forms.ComboBox();
            this.chonCmbLoaiBanHanh = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnTimKiemThongKe = new System.Windows.Forms.Button();
            this.btnQuanLyVbNoiBo = new System.Windows.Forms.Button();
            this.btnQuanLyVanBan = new System.Windows.Forms.Button();
            this.btnHeThong = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đăngNhậpLạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sửaThôngTinNgườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPageVanBanNoiBo.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPagePhongBan.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XuatExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhongBan)).BeginInit();
            this.VBNoiBotabPage.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LuuVBNB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemVBNB)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaiLieu)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPageDSVBNoiBo.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaVBNB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSuaVBNB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemVBNB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVBNB)).BeginInit();
            this.tabPageTimKiem.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVBNB1)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1051);
            this.panel1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPageVanBanNoiBo);
            this.tabControl2.Controls.Add(this.tabPageTimKiem);
            this.tabControl2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(419, 47);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1920, 1056);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pictureBox3);
            this.tabPage5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1912, 1018);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Trang chủ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(6, 7);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1920, 1051);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // tabPageVanBanNoiBo
            // 
            this.tabPageVanBanNoiBo.BackColor = System.Drawing.Color.Lavender;
            this.tabPageVanBanNoiBo.Controls.Add(this.tabControl3);
            this.tabPageVanBanNoiBo.Location = new System.Drawing.Point(4, 34);
            this.tabPageVanBanNoiBo.Name = "tabPageVanBanNoiBo";
            this.tabPageVanBanNoiBo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVanBanNoiBo.Size = new System.Drawing.Size(1912, 1018);
            this.tabPageVanBanNoiBo.TabIndex = 1;
            this.tabPageVanBanNoiBo.Text = "Văn bản nội bộ";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPagePhongBan);
            this.tabControl3.Controls.Add(this.VBNoiBotabPage);
            this.tabControl3.Controls.Add(this.tabPageDSVBNoiBo);
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1920, 1056);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPagePhongBan
            // 
            this.tabPagePhongBan.Controls.Add(this.panel5);
            this.tabPagePhongBan.Controls.Add(this.label5);
            this.tabPagePhongBan.Controls.Add(this.dataGridViewPhongBan);
            this.tabPagePhongBan.Controls.Add(this.label4);
            this.tabPagePhongBan.Controls.Add(this.label3);
            this.tabPagePhongBan.Controls.Add(this.label2);
            this.tabPagePhongBan.Controls.Add(this.label1);
            this.tabPagePhongBan.Location = new System.Drawing.Point(4, 34);
            this.tabPagePhongBan.Name = "tabPagePhongBan";
            this.tabPagePhongBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhongBan.Size = new System.Drawing.Size(1912, 1018);
            this.tabPagePhongBan.TabIndex = 0;
            this.tabPagePhongBan.Text = "Phòng ban";
            this.tabPagePhongBan.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SeaShell;
            this.panel5.Controls.Add(this.XuatExcel);
            this.panel5.Controls.Add(this.picLuu);
            this.panel5.Controls.Add(this.picXoa);
            this.panel5.Controls.Add(this.picThemPhongBan);
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1578, 52);
            this.panel5.TabIndex = 6;
            // 
            // XuatExcel
            // 
            this.XuatExcel.BackColor = System.Drawing.Color.LightYellow;
            this.XuatExcel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.XuatExcel.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.ex;
            this.XuatExcel.Location = new System.Drawing.Point(197, 3);
            this.XuatExcel.Name = "XuatExcel";
            this.XuatExcel.Size = new System.Drawing.Size(47, 46);
            this.XuatExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.XuatExcel.TabIndex = 8;
            this.XuatExcel.TabStop = false;
            this.XuatExcel.Click += new System.EventHandler(this.XuatExcel_Click);
            // 
            // picLuu
            // 
            this.picLuu.BackColor = System.Drawing.Color.LightYellow;
            this.picLuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLuu.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.encrypted;
            this.picLuu.Location = new System.Drawing.Point(132, 3);
            this.picLuu.Name = "picLuu";
            this.picLuu.Size = new System.Drawing.Size(47, 46);
            this.picLuu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLuu.TabIndex = 7;
            this.picLuu.TabStop = false;
            this.picLuu.Click += new System.EventHandler(this.picLuu_Click);
            // 
            // picXoa
            // 
            this.picXoa.BackColor = System.Drawing.Color.LightYellow;
            this.picXoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picXoa.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.trash;
            this.picXoa.Location = new System.Drawing.Point(68, 3);
            this.picXoa.Name = "picXoa";
            this.picXoa.Size = new System.Drawing.Size(47, 46);
            this.picXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picXoa.TabIndex = 2;
            this.picXoa.TabStop = false;
            this.picXoa.Click += new System.EventHandler(this.picXoa_Click);
            // 
            // picThemPhongBan
            // 
            this.picThemPhongBan.BackColor = System.Drawing.Color.LightYellow;
            this.picThemPhongBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picThemPhongBan.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.insert;
            this.picThemPhongBan.Location = new System.Drawing.Point(4, 3);
            this.picThemPhongBan.Name = "picThemPhongBan";
            this.picThemPhongBan.Size = new System.Drawing.Size(47, 46);
            this.picThemPhongBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThemPhongBan.TabIndex = 0;
            this.picThemPhongBan.TabStop = false;
            this.picThemPhongBan.Click += new System.EventHandler(this.picThemPhongBan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(66, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "BẢNG DỮ LIỆU PHÒNG BAN";
            // 
            // dataGridViewPhongBan
            // 
            this.dataGridViewPhongBan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhongBan.Location = new System.Drawing.Point(117, 294);
            this.dataGridViewPhongBan.Name = "dataGridViewPhongBan";
            this.dataGridViewPhongBan.RowHeadersWidth = 51;
            this.dataGridViewPhongBan.RowTemplate.Height = 24;
            this.dataGridViewPhongBan.Size = new System.Drawing.Size(1364, 476);
            this.dataGridViewPhongBan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orchid;
            this.label4.Location = new System.Drawing.Point(248, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(746, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phòng ban hành: Khởi tạo/gửi tài liệu, quyết định, thông tin nội bộ hoặc ra bên n" +
    "goài.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkViolet;
            this.label3.Location = new System.Drawing.Point(249, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(735, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phòng ban nhận: Tiếp nhận tài liệu, thông tin hoặc công việc từ các phòng ban khá" +
    "c.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(125, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng ban có: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(66, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN PHÒNG BAN";
            // 
            // VBNoiBotabPage
            // 
            this.VBNoiBotabPage.Controls.Add(this.btnXoaFile);
            this.VBNoiBotabPage.Controls.Add(this.btnDocFile);
            this.VBNoiBotabPage.Controls.Add(this.btnDinhKem);
            this.VBNoiBotabPage.Controls.Add(this.button2);
            this.VBNoiBotabPage.Controls.Add(this.txtNguoiDuyet);
            this.VBNoiBotabPage.Controls.Add(this.txtNguoiKy);
            this.VBNoiBotabPage.Controls.Add(this.txtNguoiNhan);
            this.VBNoiBotabPage.Controls.Add(this.label17);
            this.VBNoiBotabPage.Controls.Add(this.label16);
            this.VBNoiBotabPage.Controls.Add(this.label15);
            this.VBNoiBotabPage.Controls.Add(this.panel9);
            this.VBNoiBotabPage.Controls.Add(this.panel8);
            this.VBNoiBotabPage.Controls.Add(this.panel7);
            this.VBNoiBotabPage.Controls.Add(this.panel6);
            this.VBNoiBotabPage.Controls.Add(this.dateNgayBanHanh);
            this.VBNoiBotabPage.Controls.Add(this.cmbPhongBanNhan);
            this.VBNoiBotabPage.Controls.Add(this.cmbPhongBanHanh);
            this.VBNoiBotabPage.Controls.Add(this.cmbLoaiBanHanh);
            this.VBNoiBotabPage.Controls.Add(this.txtTenVanBan);
            this.VBNoiBotabPage.Controls.Add(this.txtSoKyHieu);
            this.VBNoiBotabPage.Controls.Add(this.label11);
            this.VBNoiBotabPage.Controls.Add(this.label10);
            this.VBNoiBotabPage.Controls.Add(this.label9);
            this.VBNoiBotabPage.Controls.Add(this.label8);
            this.VBNoiBotabPage.Controls.Add(this.label7);
            this.VBNoiBotabPage.Controls.Add(this.label6);
            this.VBNoiBotabPage.Location = new System.Drawing.Point(4, 34);
            this.VBNoiBotabPage.Name = "VBNoiBotabPage";
            this.VBNoiBotabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VBNoiBotabPage.Size = new System.Drawing.Size(1912, 1018);
            this.VBNoiBotabPage.TabIndex = 1;
            this.VBNoiBotabPage.Text = "Văn bản nội bộ";
            this.VBNoiBotabPage.UseVisualStyleBackColor = true;
            // 
            // btnXoaFile
            // 
            this.btnXoaFile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaFile.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnXoaFile.Location = new System.Drawing.Point(1308, 768);
            this.btnXoaFile.Name = "btnXoaFile";
            this.btnXoaFile.Size = new System.Drawing.Size(126, 35);
            this.btnXoaFile.TabIndex = 25;
            this.btnXoaFile.Text = "Xóa file";
            this.btnXoaFile.UseVisualStyleBackColor = true;
            this.btnXoaFile.Click += new System.EventHandler(this.btnXoaFile_Click);
            // 
            // btnDocFile
            // 
            this.btnDocFile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocFile.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnDocFile.Location = new System.Drawing.Point(1308, 706);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(126, 37);
            this.btnDocFile.TabIndex = 24;
            this.btnDocFile.Text = "Đọc file";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // btnDinhKem
            // 
            this.btnDinhKem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinhKem.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnDinhKem.Location = new System.Drawing.Point(1308, 649);
            this.btnDinhKem.Name = "btnDinhKem";
            this.btnDinhKem.Size = new System.Drawing.Size(126, 38);
            this.btnDinhKem.TabIndex = 23;
            this.btnDinhKem.Text = "Đính kèm";
            this.btnDinhKem.UseVisualStyleBackColor = true;
            this.btnDinhKem.Click += new System.EventHandler(this.btnDinhKem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1273, 781);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 8);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtNguoiDuyet
            // 
            this.txtNguoiDuyet.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiDuyet.Location = new System.Drawing.Point(1265, 219);
            this.txtNguoiDuyet.Name = "txtNguoiDuyet";
            this.txtNguoiDuyet.Size = new System.Drawing.Size(228, 31);
            this.txtNguoiDuyet.TabIndex = 21;
            // 
            // txtNguoiKy
            // 
            this.txtNguoiKy.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiKy.Location = new System.Drawing.Point(1265, 143);
            this.txtNguoiKy.Name = "txtNguoiKy";
            this.txtNguoiKy.Size = new System.Drawing.Size(228, 31);
            this.txtNguoiKy.TabIndex = 20;
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguoiNhan.Location = new System.Drawing.Point(1265, 82);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(228, 31);
            this.txtNguoiNhan.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label17.Location = new System.Drawing.Point(1099, 217);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(157, 33);
            this.label17.TabIndex = 18;
            this.label17.Text = "Người duyệt";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label16.Location = new System.Drawing.Point(1099, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 35);
            this.label16.TabIndex = 17;
            this.label16.Text = "Người ký";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label15.Location = new System.Drawing.Point(1099, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 34);
            this.label15.TabIndex = 16;
            this.label15.Text = "Người nhận";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.SeaShell;
            this.panel9.Controls.Add(this.LuuVBNB);
            this.panel9.Controls.Add(this.ThemVBNB);
            this.panel9.Location = new System.Drawing.Point(3, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1581, 50);
            this.panel9.TabIndex = 15;
            // 
            // LuuVBNB
            // 
            this.LuuVBNB.BackColor = System.Drawing.Color.LightYellow;
            this.LuuVBNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LuuVBNB.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.encrypted;
            this.LuuVBNB.Location = new System.Drawing.Point(63, 3);
            this.LuuVBNB.Name = "LuuVBNB";
            this.LuuVBNB.Size = new System.Drawing.Size(47, 44);
            this.LuuVBNB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LuuVBNB.TabIndex = 7;
            this.LuuVBNB.TabStop = false;
            this.LuuVBNB.Click += new System.EventHandler(this.LuuVBNB_Click);
            // 
            // ThemVBNB
            // 
            this.ThemVBNB.BackColor = System.Drawing.Color.LightYellow;
            this.ThemVBNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThemVBNB.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.insert;
            this.ThemVBNB.Location = new System.Drawing.Point(4, 3);
            this.ThemVBNB.Name = "ThemVBNB";
            this.ThemVBNB.Size = new System.Drawing.Size(47, 47);
            this.ThemVBNB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemVBNB.TabIndex = 0;
            this.ThemVBNB.TabStop = false;
            this.ThemVBNB.Click += new System.EventHandler(this.ThemVBNB_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel8.Controls.Add(this.dataGridViewTaiLieu);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(66, 633);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1215, 201);
            this.panel8.TabIndex = 14;
            // 
            // dataGridViewTaiLieu
            // 
            this.dataGridViewTaiLieu.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewTaiLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaiLieu.Location = new System.Drawing.Point(16, 47);
            this.dataGridViewTaiLieu.Name = "dataGridViewTaiLieu";
            this.dataGridViewTaiLieu.RowHeadersWidth = 51;
            this.dataGridViewTaiLieu.RowTemplate.Height = 24;
            this.dataGridViewTaiLieu.Size = new System.Drawing.Size(1071, 134);
            this.dataGridViewTaiLieu.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(3, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 28);
            this.label14.TabIndex = 15;
            this.label14.Text = "Đính kèm file";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel7.Controls.Add(this.txtNoiDung);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(66, 475);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1427, 137);
            this.panel7.TabIndex = 13;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(28, 35);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(1387, 85);
            this.txtNoiDung.TabIndex = 15;
            this.txtNoiDung.Text = "";
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(13, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 28);
            this.label13.TabIndex = 14;
            this.label13.Text = "Nội dung";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.txtTrichYeu);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(66, 307);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1427, 149);
            this.panel6.TabIndex = 12;
            this.panel6.Tag = "";
            // 
            // txtTrichYeu
            // 
            this.txtTrichYeu.Location = new System.Drawing.Point(25, 37);
            this.txtTrichYeu.Name = "txtTrichYeu";
            this.txtTrichYeu.Size = new System.Drawing.Size(1390, 92);
            this.txtTrichYeu.TabIndex = 14;
            this.txtTrichYeu.Text = "";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(13, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 31);
            this.label12.TabIndex = 13;
            this.label12.Text = "Trích yếu";
            // 
            // dateNgayBanHanh
            // 
            this.dateNgayBanHanh.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgayBanHanh.Location = new System.Drawing.Point(240, 219);
            this.dateNgayBanHanh.Name = "dateNgayBanHanh";
            this.dateNgayBanHanh.Size = new System.Drawing.Size(252, 31);
            this.dateNgayBanHanh.TabIndex = 11;
            // 
            // cmbPhongBanNhan
            // 
            this.cmbPhongBanNhan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhongBanNhan.FormattingEnabled = true;
            this.cmbPhongBanNhan.Location = new System.Drawing.Point(763, 214);
            this.cmbPhongBanNhan.Name = "cmbPhongBanNhan";
            this.cmbPhongBanNhan.Size = new System.Drawing.Size(260, 33);
            this.cmbPhongBanNhan.TabIndex = 10;
            // 
            // cmbPhongBanHanh
            // 
            this.cmbPhongBanHanh.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhongBanHanh.FormattingEnabled = true;
            this.cmbPhongBanHanh.Location = new System.Drawing.Point(763, 145);
            this.cmbPhongBanHanh.Name = "cmbPhongBanHanh";
            this.cmbPhongBanHanh.Size = new System.Drawing.Size(260, 33);
            this.cmbPhongBanHanh.TabIndex = 9;
            // 
            // cmbLoaiBanHanh
            // 
            this.cmbLoaiBanHanh.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiBanHanh.FormattingEnabled = true;
            this.cmbLoaiBanHanh.Location = new System.Drawing.Point(763, 86);
            this.cmbLoaiBanHanh.Name = "cmbLoaiBanHanh";
            this.cmbLoaiBanHanh.Size = new System.Drawing.Size(260, 33);
            this.cmbLoaiBanHanh.TabIndex = 8;
            // 
            // txtTenVanBan
            // 
            this.txtTenVanBan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenVanBan.Location = new System.Drawing.Point(240, 143);
            this.txtTenVanBan.Name = "txtTenVanBan";
            this.txtTenVanBan.Size = new System.Drawing.Size(245, 31);
            this.txtTenVanBan.TabIndex = 7;
            // 
            // txtSoKyHieu
            // 
            this.txtSoKyHieu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoKyHieu.Location = new System.Drawing.Point(240, 82);
            this.txtSoKyHieu.Name = "txtSoKyHieu";
            this.txtSoKyHieu.Size = new System.Drawing.Size(245, 31);
            this.txtSoKyHieu.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label11.Location = new System.Drawing.Point(569, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "Phòng ban nhận";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label10.Location = new System.Drawing.Point(569, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 31);
            this.label10.TabIndex = 4;
            this.label10.Text = "Phòng ban hành";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label9.Location = new System.Drawing.Point(569, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 22);
            this.label9.TabIndex = 3;
            this.label9.Text = "Loại ban hành";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label8.Location = new System.Drawing.Point(61, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 31);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ngày ban hành";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label7.Location = new System.Drawing.Point(61, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 27);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tên văn bản";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label6.Location = new System.Drawing.Point(61, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số ký hiệu";
            // 
            // tabPageDSVBNoiBo
            // 
            this.tabPageDSVBNoiBo.Controls.Add(this.label21);
            this.tabPageDSVBNoiBo.Controls.Add(this.panel11);
            this.tabPageDSVBNoiBo.Controls.Add(this.panel10);
            this.tabPageDSVBNoiBo.Controls.Add(this.dataGridViewVBNB);
            this.tabPageDSVBNoiBo.Location = new System.Drawing.Point(4, 34);
            this.tabPageDSVBNoiBo.Name = "tabPageDSVBNoiBo";
            this.tabPageDSVBNoiBo.Size = new System.Drawing.Size(1912, 1018);
            this.tabPageDSVBNoiBo.TabIndex = 2;
            this.tabPageDSVBNoiBo.Text = "Danh sách văn bản nội bộ";
            this.tabPageDSVBNoiBo.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label21.Location = new System.Drawing.Point(36, 233);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(279, 25);
            this.label21.TabIndex = 14;
            this.label21.Text = "Bảng danh sách văn bản nội bộ";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label20);
            this.panel11.Controls.Add(this.label19);
            this.panel11.Controls.Add(this.dateTimePicker2);
            this.panel11.Controls.Add(this.dateTimePicker1);
            this.panel11.Controls.Add(this.comboBox1);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Location = new System.Drawing.Point(33, 67);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1546, 141);
            this.panel11.TabIndex = 9;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label20.Location = new System.Drawing.Point(968, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 25);
            this.label20.TabIndex = 13;
            this.label20.Text = "đến ngày";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label19.Location = new System.Drawing.Point(499, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(82, 25);
            this.label19.TabIndex = 12;
            this.label19.Text = "Từ ngày";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(1151, 72);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(306, 31);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(637, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(275, 31);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Hôm nay",
            "Tuần này",
            "Tháng này",
            "Năm nay",
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12",
            "Năm trước"});
            this.comboBox1.Location = new System.Drawing.Point(154, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 33);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label18.Location = new System.Drawing.Point(43, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 25);
            this.label18.TabIndex = 8;
            this.label18.Text = "Chọn lọc thời gian";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.SeaShell;
            this.panel10.Controls.Add(this.pictureBox4);
            this.panel10.Controls.Add(this.btnXoaVBNB);
            this.panel10.Controls.Add(this.btnSuaVBNB);
            this.panel10.Controls.Add(this.btnThemVBNB);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1576, 49);
            this.panel10.TabIndex = 7;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightYellow;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.ex;
            this.pictureBox4.Location = new System.Drawing.Point(212, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 46);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // btnXoaVBNB
            // 
            this.btnXoaVBNB.BackColor = System.Drawing.Color.LightYellow;
            this.btnXoaVBNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnXoaVBNB.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.trash;
            this.btnXoaVBNB.Location = new System.Drawing.Point(145, 3);
            this.btnXoaVBNB.Name = "btnXoaVBNB";
            this.btnXoaVBNB.Size = new System.Drawing.Size(47, 46);
            this.btnXoaVBNB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnXoaVBNB.TabIndex = 7;
            this.btnXoaVBNB.TabStop = false;
            this.btnXoaVBNB.Click += new System.EventHandler(this.btnXoaVBNB_Click);
            // 
            // btnSuaVBNB
            // 
            this.btnSuaVBNB.BackColor = System.Drawing.Color.LightYellow;
            this.btnSuaVBNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSuaVBNB.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.service;
            this.btnSuaVBNB.Location = new System.Drawing.Point(78, 3);
            this.btnSuaVBNB.Name = "btnSuaVBNB";
            this.btnSuaVBNB.Size = new System.Drawing.Size(47, 46);
            this.btnSuaVBNB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSuaVBNB.TabIndex = 2;
            this.btnSuaVBNB.TabStop = false;
            this.btnSuaVBNB.Click += new System.EventHandler(this.btnSuaVBNB_Click);
            // 
            // btnThemVBNB
            // 
            this.btnThemVBNB.BackColor = System.Drawing.Color.LightYellow;
            this.btnThemVBNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnThemVBNB.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.insert;
            this.btnThemVBNB.Location = new System.Drawing.Point(4, 3);
            this.btnThemVBNB.Name = "btnThemVBNB";
            this.btnThemVBNB.Size = new System.Drawing.Size(47, 46);
            this.btnThemVBNB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnThemVBNB.TabIndex = 0;
            this.btnThemVBNB.TabStop = false;
            this.btnThemVBNB.Click += new System.EventHandler(this.btnThemVBNB_Click);
            // 
            // dataGridViewVBNB
            // 
            this.dataGridViewVBNB.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVBNB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVBNB.Location = new System.Drawing.Point(17, 279);
            this.dataGridViewVBNB.Name = "dataGridViewVBNB";
            this.dataGridViewVBNB.RowHeadersWidth = 51;
            this.dataGridViewVBNB.RowTemplate.Height = 24;
            this.dataGridViewVBNB.Size = new System.Drawing.Size(1562, 616);
            this.dataGridViewVBNB.TabIndex = 0;
            this.dataGridViewVBNB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewVBNB_MouseClick);
            // 
            // tabPageTimKiem
            // 
            this.tabPageTimKiem.Controls.Add(this.tabControl4);
            this.tabPageTimKiem.Location = new System.Drawing.Point(4, 34);
            this.tabPageTimKiem.Name = "tabPageTimKiem";
            this.tabPageTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimKiem.Size = new System.Drawing.Size(1912, 1018);
            this.tabPageTimKiem.TabIndex = 2;
            this.tabPageTimKiem.Text = "Tìm kiếm thống kê";
            this.tabPageTimKiem.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage7);
            this.tabControl4.Controls.Add(this.tabPage8);
            this.tabControl4.Controls.Add(this.tabPage9);
            this.tabControl4.Location = new System.Drawing.Point(6, 12);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(1578, 968);
            this.tabControl4.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1570, 930);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Thống kê văn bản đi";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1570, 930);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Thống kê văn bản đến";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel13);
            this.tabPage9.Controls.Add(this.panel12);
            this.tabPage9.Controls.Add(this.label22);
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1570, 930);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Thống kê văn bản nội bộ";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.dataGridViewVBNB1);
            this.panel13.Controls.Add(this.label32);
            this.panel13.Location = new System.Drawing.Point(34, 352);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1540, 588);
            this.panel13.TabIndex = 3;
            // 
            // dataGridViewVBNB1
            // 
            this.dataGridViewVBNB1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewVBNB1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVBNB1.Location = new System.Drawing.Point(28, 77);
            this.dataGridViewVBNB1.Name = "dataGridViewVBNB1";
            this.dataGridViewVBNB1.RowHeadersWidth = 51;
            this.dataGridViewVBNB1.RowTemplate.Height = 24;
            this.dataGridViewVBNB1.Size = new System.Drawing.Size(1512, 461);
            this.dataGridViewVBNB1.TabIndex = 19;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label32.Location = new System.Drawing.Point(23, 31);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(333, 25);
            this.label32.TabIndex = 18;
            this.label32.Text = "BẢNG DANH SÁCH VĂN BẢN NỘI BỘ";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnTimKiem);
            this.panel12.Controls.Add(this.btnInbaocao);
            this.panel12.Controls.Add(this.btnXuatExcel);
            this.panel12.Controls.Add(this.btnXemChiTiet);
            this.panel12.Controls.Add(this.ThoiGianTimKiem);
            this.panel12.Controls.Add(this.nhapTrichYeu);
            this.panel12.Controls.Add(this.nhapTenVanBan);
            this.panel12.Controls.Add(this.nhapSoKyHieu);
            this.panel12.Controls.Add(this.dateTimePicker4);
            this.panel12.Controls.Add(this.dateTimePicker3);
            this.panel12.Controls.Add(this.label31);
            this.panel12.Controls.Add(this.label30);
            this.panel12.Controls.Add(this.label29);
            this.panel12.Controls.Add(this.label28);
            this.panel12.Controls.Add(this.label27);
            this.panel12.Controls.Add(this.ChonCmbPhongBanNhan);
            this.panel12.Controls.Add(this.chonCmbPhongBanHanh);
            this.panel12.Controls.Add(this.chonCmbLoaiBanHanh);
            this.panel12.Controls.Add(this.label26);
            this.panel12.Controls.Add(this.label25);
            this.panel12.Controls.Add(this.label24);
            this.panel12.Controls.Add(this.label23);
            this.panel12.Location = new System.Drawing.Point(17, 54);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1557, 263);
            this.panel12.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnTimKiem.Location = new System.Drawing.Point(1304, 21);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(146, 43);
            this.btnTimKiem.TabIndex = 23;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnInbaocao
            // 
            this.btnInbaocao.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInbaocao.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnInbaocao.Location = new System.Drawing.Point(1304, 191);
            this.btnInbaocao.Name = "btnInbaocao";
            this.btnInbaocao.Size = new System.Drawing.Size(146, 47);
            this.btnInbaocao.TabIndex = 22;
            this.btnInbaocao.Text = "In báo cáo";
            this.btnInbaocao.UseVisualStyleBackColor = true;
            this.btnInbaocao.Click += new System.EventHandler(this.btnInbaocao_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnXuatExcel.Location = new System.Drawing.Point(1304, 132);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(146, 46);
            this.btnXuatExcel.TabIndex = 21;
            this.btnXuatExcel.Text = "Xuất file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.btnXemChiTiet.Location = new System.Drawing.Point(1304, 82);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(146, 44);
            this.btnXemChiTiet.TabIndex = 20;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // ThoiGianTimKiem
            // 
            this.ThoiGianTimKiem.FormattingEnabled = true;
            this.ThoiGianTimKiem.Items.AddRange(new object[] {
            "Hôm nay",
            "Tuần này",
            "Tháng này",
            "Năm nay",
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12",
            "Năm trước"});
            this.ThoiGianTimKiem.Location = new System.Drawing.Point(212, 32);
            this.ThoiGianTimKiem.Name = "ThoiGianTimKiem";
            this.ThoiGianTimKiem.Size = new System.Drawing.Size(220, 33);
            this.ThoiGianTimKiem.TabIndex = 18;
            this.ThoiGianTimKiem.SelectedIndexChanged += new System.EventHandler(this.ThoiGianTimKiem_SelectedIndexChanged);
            // 
            // nhapTrichYeu
            // 
            this.nhapTrichYeu.Location = new System.Drawing.Point(1015, 119);
            this.nhapTrichYeu.Name = "nhapTrichYeu";
            this.nhapTrichYeu.Size = new System.Drawing.Size(263, 96);
            this.nhapTrichYeu.TabIndex = 17;
            this.nhapTrichYeu.Text = "";
            // 
            // nhapTenVanBan
            // 
            this.nhapTenVanBan.Location = new System.Drawing.Point(606, 182);
            this.nhapTenVanBan.Name = "nhapTenVanBan";
            this.nhapTenVanBan.Size = new System.Drawing.Size(255, 31);
            this.nhapTenVanBan.TabIndex = 16;
            // 
            // nhapSoKyHieu
            // 
            this.nhapSoKyHieu.Location = new System.Drawing.Point(606, 103);
            this.nhapSoKyHieu.Name = "nhapSoKyHieu";
            this.nhapSoKyHieu.Size = new System.Drawing.Size(255, 31);
            this.nhapSoKyHieu.TabIndex = 15;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CalendarFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Location = new System.Drawing.Point(1015, 31);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(249, 31);
            this.dateTimePicker4.TabIndex = 14;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Location = new System.Drawing.Point(606, 31);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(255, 31);
            this.dateTimePicker3.TabIndex = 13;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label31.Location = new System.Drawing.Point(902, 107);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(90, 25);
            this.label31.TabIndex = 12;
            this.label31.Text = "Trích yếu";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label30.Location = new System.Drawing.Point(896, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 25);
            this.label30.TabIndex = 11;
            this.label30.Text = "đến ngày";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label29.Location = new System.Drawing.Point(469, 172);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(115, 25);
            this.label29.TabIndex = 10;
            this.label29.Text = "Tên văn bản";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label28.Location = new System.Drawing.Point(469, 97);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 25);
            this.label28.TabIndex = 9;
            this.label28.Text = "Số ký hiệu";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label27.Location = new System.Drawing.Point(469, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(82, 25);
            this.label27.TabIndex = 8;
            this.label27.Text = "Từ ngày";
            // 
            // ChonCmbPhongBanNhan
            // 
            this.ChonCmbPhongBanNhan.FormattingEnabled = true;
            this.ChonCmbPhongBanNhan.Location = new System.Drawing.Point(212, 184);
            this.ChonCmbPhongBanNhan.Name = "ChonCmbPhongBanNhan";
            this.ChonCmbPhongBanNhan.Size = new System.Drawing.Size(220, 33);
            this.ChonCmbPhongBanNhan.TabIndex = 7;
            // 
            // chonCmbPhongBanHanh
            // 
            this.chonCmbPhongBanHanh.FormattingEnabled = true;
            this.chonCmbPhongBanHanh.Location = new System.Drawing.Point(212, 133);
            this.chonCmbPhongBanHanh.Name = "chonCmbPhongBanHanh";
            this.chonCmbPhongBanHanh.Size = new System.Drawing.Size(220, 33);
            this.chonCmbPhongBanHanh.TabIndex = 6;
            // 
            // chonCmbLoaiBanHanh
            // 
            this.chonCmbLoaiBanHanh.FormattingEnabled = true;
            this.chonCmbLoaiBanHanh.Location = new System.Drawing.Point(212, 79);
            this.chonCmbLoaiBanHanh.Name = "chonCmbLoaiBanHanh";
            this.chonCmbLoaiBanHanh.Size = new System.Drawing.Size(220, 33);
            this.chonCmbLoaiBanHanh.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label26.Location = new System.Drawing.Point(23, 192);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(152, 25);
            this.label26.TabIndex = 3;
            this.label26.Text = "Phòng ban nhận";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label25.Location = new System.Drawing.Point(23, 141);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(152, 25);
            this.label25.TabIndex = 2;
            this.label25.Text = "Phòng ban hành";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label24.Location = new System.Drawing.Point(23, 79);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 25);
            this.label24.TabIndex = 1;
            this.label24.Text = "Loại ban hành";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label23.Location = new System.Drawing.Point(23, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(137, 25);
            this.label23.TabIndex = 0;
            this.label23.Text = "Chọn thời gian";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label22.Location = new System.Drawing.Point(480, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(324, 31);
            this.label22.TabIndex = 1;
            this.label22.Text = "THỐNG KÊ VĂN BẢN NỘI BỘ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(3, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 1005);
            this.panel3.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(21, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 485);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hệ thống";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(19, 216);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(294, 49);
            this.button7.TabIndex = 2;
            this.button7.Text = "Thông tin người ký duyệt";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(19, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(294, 49);
            this.button6.TabIndex = 1;
            this.button6.Text = "Phân quyền nhân viên";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(19, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(294, 49);
            this.button5.TabIndex = 0;
            this.button5.Text = "Quản lý người dùng";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.button14);
            this.tabPage2.Controls.Add(this.button13);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(360, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Văn bản";
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button14.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(29, 380);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(283, 41);
            this.button14.TabIndex = 6;
            this.button14.Text = "Danh sách văn bản đi";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button13.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(29, 319);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(283, 41);
            this.button13.TabIndex = 5;
            this.button13.Text = "Danh sách văn bản đến";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button12.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(29, 259);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(283, 41);
            this.button12.TabIndex = 4;
            this.button12.Text = "Văn bản đi";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(29, 197);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(283, 41);
            this.button11.TabIndex = 3;
            this.button11.Text = "Văn bản đến";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(29, 133);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(283, 41);
            this.button10.TabIndex = 2;
            this.button10.Text = "Nơi ban hành";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(29, 77);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(283, 41);
            this.button9.TabIndex = 1;
            this.button9.Text = "Loại văn bản";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.button8.Location = new System.Drawing.Point(29, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(283, 41);
            this.button8.TabIndex = 0;
            this.button8.Text = "Số văn bản";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button17);
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button15);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(360, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Văn bản nội bộ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button17.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(30, 220);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(283, 50);
            this.button17.TabIndex = 2;
            this.button17.Text = "Danh sách văn bản nội bộ";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button16.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(30, 121);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(283, 50);
            this.button16.TabIndex = 1;
            this.button16.Text = "Văn bản nội bộ";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(30, 28);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(283, 50);
            this.button15.TabIndex = 0;
            this.button15.Text = "Phòng ban";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button20);
            this.tabPage4.Controls.Add(this.button19);
            this.tabPage4.Controls.Add(this.button18);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(360, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tìm kiếm - Thống kê";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button20.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(14, 203);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(299, 49);
            this.button20.TabIndex = 2;
            this.button20.Text = "Thống kê văn bản nội bộ";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button19.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(14, 113);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(299, 49);
            this.button19.TabIndex = 1;
            this.button19.Text = "Thống kê văn bản đến";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button18.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(14, 28);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(299, 49);
            this.button18.TabIndex = 0;
            this.button18.Text = "Thống kê văn bản đi";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.Controls.Add(this.btnTimKiemThongKe);
            this.panel4.Controls.Add(this.btnQuanLyVbNoiBo);
            this.panel4.Controls.Add(this.btnQuanLyVanBan);
            this.panel4.Controls.Add(this.btnHeThong);
            this.panel4.Location = new System.Drawing.Point(21, 496);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(364, 363);
            this.panel4.TabIndex = 2;
            // 
            // btnTimKiemThongKe
            // 
            this.btnTimKiemThongKe.BackColor = System.Drawing.Color.Wheat;
            this.btnTimKiemThongKe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemThongKe.Location = new System.Drawing.Point(34, 235);
            this.btnTimKiemThongKe.Name = "btnTimKiemThongKe";
            this.btnTimKiemThongKe.Size = new System.Drawing.Size(283, 43);
            this.btnTimKiemThongKe.TabIndex = 3;
            this.btnTimKiemThongKe.Text = "Tìm kiếm - Thống kê";
            this.btnTimKiemThongKe.UseVisualStyleBackColor = false;
            this.btnTimKiemThongKe.Click += new System.EventHandler(this.btnTimKiemThongKe_Click);
            // 
            // btnQuanLyVbNoiBo
            // 
            this.btnQuanLyVbNoiBo.BackColor = System.Drawing.Color.Wheat;
            this.btnQuanLyVbNoiBo.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyVbNoiBo.Location = new System.Drawing.Point(34, 167);
            this.btnQuanLyVbNoiBo.Name = "btnQuanLyVbNoiBo";
            this.btnQuanLyVbNoiBo.Size = new System.Drawing.Size(283, 41);
            this.btnQuanLyVbNoiBo.TabIndex = 2;
            this.btnQuanLyVbNoiBo.Text = "Quản lý văn bản nội bộ";
            this.btnQuanLyVbNoiBo.UseVisualStyleBackColor = false;
            this.btnQuanLyVbNoiBo.Click += new System.EventHandler(this.btnQuanLyVbNoiBo_Click);
            // 
            // btnQuanLyVanBan
            // 
            this.btnQuanLyVanBan.BackColor = System.Drawing.Color.Wheat;
            this.btnQuanLyVanBan.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyVanBan.Location = new System.Drawing.Point(34, 93);
            this.btnQuanLyVanBan.Name = "btnQuanLyVanBan";
            this.btnQuanLyVanBan.Size = new System.Drawing.Size(283, 39);
            this.btnQuanLyVanBan.TabIndex = 1;
            this.btnQuanLyVanBan.Text = "Quản lý văn bản";
            this.btnQuanLyVanBan.UseVisualStyleBackColor = false;
            this.btnQuanLyVanBan.Click += new System.EventHandler(this.btnQuanLyVanBan_Click);
            // 
            // btnHeThong
            // 
            this.btnHeThong.BackColor = System.Drawing.Color.Wheat;
            this.btnHeThong.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeThong.Location = new System.Drawing.Point(34, 25);
            this.btnHeThong.Name = "btnHeThong";
            this.btnHeThong.Size = new System.Drawing.Size(283, 41);
            this.btnHeThong.TabIndex = 0;
            this.btnHeThong.Text = "Hệ thống";
            this.btnHeThong.UseVisualStyleBackColor = false;
            this.btnHeThong.Click += new System.EventHandler(this.btnHeThong_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Honeydew;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 46);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1864, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngNhậpLạiToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 76);
            // 
            // đăngNhậpLạiToolStripMenuItem
            // 
            this.đăngNhậpLạiToolStripMenuItem.Name = "đăngNhậpLạiToolStripMenuItem";
            this.đăngNhậpLạiToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.đăngNhậpLạiToolStripMenuItem.Text = "Đăng nhập lại";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaThôngTinNgườiDùngToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(223, 28);
            // 
            // sửaThôngTinNgườiDùngToolStripMenuItem
            // 
            this.sửaThôngTinNgườiDùngToolStripMenuItem.Name = "sửaThôngTinNgườiDùngToolStripMenuItem";
            this.sửaThôngTinNgườiDùngToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.sửaThôngTinNgườiDùngToolStripMenuItem.Text = "Sửa thông tin cá nhân";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1920, 1051);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HỆ THỐNG QUẢN LÝ VĂN BẢN - CÔNG VĂN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrangChu_FormClosing);
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabPageVanBanNoiBo.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPagePhongBan.ResumeLayout(false);
            this.tabPagePhongBan.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XuatExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLuu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhongBan)).EndInit();
            this.VBNoiBotabPage.ResumeLayout(false);
            this.VBNoiBotabPage.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LuuVBNB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemVBNB)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaiLieu)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPageDSVBNoiBo.ResumeLayout(false);
            this.tabPageDSVBNoiBo.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaVBNB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSuaVBNB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemVBNB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVBNB)).EndInit();
            this.tabPageTimKiem.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVBNB1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnTimKiemThongKe;
        private System.Windows.Forms.Button btnQuanLyVbNoiBo;
        private System.Windows.Forms.Button btnQuanLyVanBan;
        private System.Windows.Forms.Button btnHeThong;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem đăngNhậpLạiToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem sửaThôngTinNgườiDùngToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TabControl tabControl2;
        private TabPage tabPage5;
        private PictureBox pictureBox3;
        private TabPage tabPageVanBanNoiBo;
        private TabControl tabControl3;
        private TabPage tabPagePhongBan;
        private Panel panel5;
        private PictureBox picLuu;
        private PictureBox picXoa;
        private PictureBox picThemPhongBan;
        private Label label5;
        private DataGridView dataGridViewPhongBan;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage VBNoiBotabPage;
        private TabPage tabPageDSVBNoiBo;
        private Panel panel6;
        private DateTimePicker dateNgayBanHanh;
        private ComboBox cmbPhongBanNhan;
        private ComboBox cmbPhongBanHanh;
        private ComboBox cmbLoaiBanHanh;
        private TextBox txtTenVanBan;
        private TextBox txtSoKyHieu;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Panel panel9;
        private PictureBox LuuVBNB;
        private PictureBox ThemVBNB;
        private Panel panel8;
        private DataGridView dataGridViewTaiLieu;
        private Label label14;
        private Panel panel7;
        private Label label13;
        private Label label12;
        private DataGridView dataGridViewVBNB;
        private RichTextBox txtNoiDung;
        private RichTextBox txtTrichYeu;
        private TextBox txtNguoiDuyet;
        private TextBox txtNguoiKy;
        private TextBox txtNguoiNhan;
        private Label label17;
        private Label label16;
        private Label label15;
        private Button btnXoaFile;
        private Button btnDocFile;
        private Button btnDinhKem;
        private Button button2;
        private Panel panel10;
        private PictureBox btnXoaVBNB;
        private PictureBox btnSuaVBNB;
        private PictureBox btnThemVBNB;
        private Panel panel11;
        private Label label20;
        private Label label19;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label18;
        private Label label21;
        private TabPage tabPageTimKiem;
        private TabControl tabControl4;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private Panel panel12;
        private RichTextBox nhapTrichYeu;
        private TextBox nhapTenVanBan;
        private TextBox nhapSoKyHieu;
        private DateTimePicker dateTimePicker4;
        private DateTimePicker dateTimePicker3;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private ComboBox ChonCmbPhongBanNhan;
        private ComboBox chonCmbPhongBanHanh;
        private ComboBox chonCmbLoaiBanHanh;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Panel panel13;
        private DataGridView dataGridViewVBNB1;
        private Label label32;
        private ComboBox ThoiGianTimKiem;
        private ComboBox comboBox1;
        private PictureBox XuatExcel;
        private PictureBox pictureBox4;
        private Button btnInbaocao;
        private Button btnXuatExcel;
        private Button btnXemChiTiet;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Button btnTimKiem;
    }
}

