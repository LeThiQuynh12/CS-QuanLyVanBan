using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyVanBanCongVan
{
    public partial class TrangCho : Form
    {
        public TrangCho()
        {
            InitializeComponent();
        }

        private async Task UpdateProgressBarAsync()
        {
            for (int i = progressLoad.Minimum; i <= progressLoad.Maximum; i++)
            {
                progressLoad.Value = i;
                await Task.Delay(50); // Thay thế Thread.Sleep bằng Task.Delay để tránh chặn giao diện
                if (i == progressLoad.Maximum)
                {
                    TrangChu dangnhap = new TrangChu();
                    dangnhap.Show();
                    this.Hide();
                }
            }
        }

        private async void TrangCho_Load(object sender, EventArgs e)
        {
            progressLoad.Minimum = 1;
            progressLoad.Maximum = 100;
            progressLoad.Step = 1;

            await UpdateProgressBarAsync();
        }

        private void TrangCho_FormClosing(object sender, FormClosingEventArgs e)
        {
         Application.Exit();
        }
    }
}
