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
            this.tabPageDSVBNoiBo = new System.Windows.Forms.TabPage();
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
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabPageVanBanNoiBo.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPagePhongBan.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhongBan)).BeginInit();
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
            this.tabControl2.Location = new System.Drawing.Point(419, 47);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1920, 1056);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pictureBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1912, 1027);
            this.tabPage5.TabIndex = 0;
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
            this.tabPageVanBanNoiBo.Location = new System.Drawing.Point(4, 25);
            this.tabPageVanBanNoiBo.Name = "tabPageVanBanNoiBo";
            this.tabPageVanBanNoiBo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVanBanNoiBo.Size = new System.Drawing.Size(1912, 1027);
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
            this.tabPagePhongBan.Location = new System.Drawing.Point(4, 25);
            this.tabPagePhongBan.Name = "tabPagePhongBan";
            this.tabPagePhongBan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhongBan.Size = new System.Drawing.Size(1912, 1027);
            this.tabPagePhongBan.TabIndex = 0;
            this.tabPagePhongBan.Text = "Phòng ban";
            this.tabPagePhongBan.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.picLuu);
            this.panel5.Controls.Add(this.picXoa);
            this.panel5.Controls.Add(this.picThemPhongBan);
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1410, 43);
            this.panel5.TabIndex = 6;
            // 
            // picLuu
            // 
            this.picLuu.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.encrypted;
            this.picLuu.Location = new System.Drawing.Point(145, 3);
            this.picLuu.Name = "picLuu";
            this.picLuu.Size = new System.Drawing.Size(47, 37);
            this.picLuu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLuu.TabIndex = 7;
            this.picLuu.TabStop = false;
            this.picLuu.Click += new System.EventHandler(this.picLuu_Click);
            // 
            // picXoa
            // 
            this.picXoa.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.trash;
            this.picXoa.Location = new System.Drawing.Point(78, 3);
            this.picXoa.Name = "picXoa";
            this.picXoa.Size = new System.Drawing.Size(47, 37);
            this.picXoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picXoa.TabIndex = 2;
            this.picXoa.TabStop = false;
            // 
            // picThemPhongBan
            // 
            this.picThemPhongBan.Image = global::HeThongQuanLyVanBanCongVan.Properties.Resources.insert;
            this.picThemPhongBan.Location = new System.Drawing.Point(4, 3);
            this.picThemPhongBan.Name = "picThemPhongBan";
            this.picThemPhongBan.Size = new System.Drawing.Size(47, 37);
            this.picThemPhongBan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picThemPhongBan.TabIndex = 0;
            this.picThemPhongBan.TabStop = false;
            this.picThemPhongBan.Click += new System.EventHandler(this.picThemPhongBan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "BẢNG DỮ LIỆU PHÒNG BAN";
            // 
            // dataGridViewPhongBan
            // 
            this.dataGridViewPhongBan.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewPhongBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhongBan.Location = new System.Drawing.Point(126, 235);
            this.dataGridViewPhongBan.Name = "dataGridViewPhongBan";
            this.dataGridViewPhongBan.RowHeadersWidth = 51;
            this.dataGridViewPhongBan.RowTemplate.Height = 24;
            this.dataGridViewPhongBan.Size = new System.Drawing.Size(1364, 555);
            this.dataGridViewPhongBan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(497, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phòng ban hành: Khởi tạo/gửi tài liệu, quyết định, thông tin nội bộ hoặc ra bên n" +
    "goài.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phòng ban nhận: Tiếp nhận tài liệu, thông tin hoặc công việc từ các phòng ban khá" +
    "c.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng ban có: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN PHÒNG BAN";
            // 
            // VBNoiBotabPage
            // 
            this.VBNoiBotabPage.Location = new System.Drawing.Point(4, 25);
            this.VBNoiBotabPage.Name = "VBNoiBotabPage";
            this.VBNoiBotabPage.Padding = new System.Windows.Forms.Padding(3);
            this.VBNoiBotabPage.Size = new System.Drawing.Size(1912, 1027);
            this.VBNoiBotabPage.TabIndex = 1;
            this.VBNoiBotabPage.Text = "Văn bản nội bộ";
            this.VBNoiBotabPage.UseVisualStyleBackColor = true;
            // 
            // tabPageDSVBNoiBo
            // 
            this.tabPageDSVBNoiBo.Location = new System.Drawing.Point(4, 25);
            this.tabPageDSVBNoiBo.Name = "tabPageDSVBNoiBo";
            this.tabPageDSVBNoiBo.Size = new System.Drawing.Size(1912, 1027);
            this.tabPageDSVBNoiBo.TabIndex = 2;
            this.tabPageDSVBNoiBo.Text = "Danh sách văn bản nội bộ";
            this.tabPageDSVBNoiBo.UseVisualStyleBackColor = true;
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
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(360, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hệ thống";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(360, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Văn bản";
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(360, 449);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Văn bản nội bộ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button17.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(30, 220);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(283, 50);
            this.button17.TabIndex = 2;
            this.button17.Text = "Danh sách văn bản nội bộ";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(30, 121);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(283, 50);
            this.button16.TabIndex = 1;
            this.button16.Text = "Văn bản nội bộ";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(30, 28);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(283, 50);
            this.button15.TabIndex = 0;
            this.button15.Text = "Phòng ban";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button20);
            this.tabPage4.Controls.Add(this.button19);
            this.tabPage4.Controls.Add(this.button18);
            this.tabPage4.Location = new System.Drawing.Point(4, 32);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(360, 449);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tìm kiếm - Thống kê";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button20.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(14, 203);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(299, 49);
            this.button20.TabIndex = 2;
            this.button20.Text = "Thống kê văn bản nội bộ";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button19.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(14, 113);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(299, 49);
            this.button19.TabIndex = 1;
            this.button19.Text = "Thống kê văn bản đến";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button18.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(14, 28);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(299, 49);
            this.button18.TabIndex = 0;
            this.button18.Text = "Thống kê văn bản đi";
            this.button18.UseVisualStyleBackColor = false;
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
            this.btnTimKiemThongKe.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnQuanLyVbNoiBo.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnQuanLyVanBan.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnHeThong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            ((System.ComponentModel.ISupportInitialize)(this.picLuu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picXoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThemPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhongBan)).EndInit();
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
        private TabPage VBNoiBotabPage;
        private TabPage tabPageDSVBNoiBo;
        private Label label1;
        private Label label5;
        private DataGridView dataGridViewPhongBan;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel5;
        private PictureBox picThemPhongBan;
        private PictureBox picXoa;
        private PictureBox picLuu;
    }
}

