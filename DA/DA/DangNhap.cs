using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();
        private void btnDangNhap_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Viết được truy vấn kiểm tra
            string query = string.Format(
                "select * from TaiKhoan where TenDangNhap = '{0}' and MatKhau = '{1}'",
                txtTaiKhoan.Text,
                txtMatKhau.Text
            );
            DataTable tb = kn.LayDuLieu(query);     // tb: chứa dữ liệu được select về
            if (tb.Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công!");
                frmHeThong frm = new frmHeThong();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
