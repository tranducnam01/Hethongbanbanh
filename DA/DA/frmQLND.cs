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
    public partial class frmQLND : Form
    {
        public frmQLND()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();
        private void frmQLND_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            string query = "select * from TaiKhoan";
            DataTable tb = kn.LayDuLieu(query);
            dgvTaiKhoan.DataSource = tb;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
            clearText();
        }
        public void clearText()
        {
            txtTenDangNhap.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtChucVu.Text = "";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "select * from TaiKhoan where TenDangNhap = N'{0}'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvTaiKhoan.DataSource = tb;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into TaiKhoan values (N'{0}', N'{1}', N'{2}')",
                txtTenDangNhap.Text,
                txtMatKhau.Text,
                txtChucVu.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Thêm mới thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update TaiKhoan set MatKhau = N'{1}', ChucVu = N'{2}' where TenDangNhap = N'{0}'",
                txtTenDangNhap.Text,
                txtMatKhau.Text,
                txtChucVu.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Sửa thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from TaiKhoan where TenDangNhap = N'{0}'",
                txtTenDangNhap.Text,
                txtMatKhau.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Xóa thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenDangNhap.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            int r = e.RowIndex;
            if (r >= 0)
            {
                txtTenDangNhap.Text = dgvTaiKhoan.Rows[r].Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = dgvTaiKhoan.Rows[r].Cells["MatKhau"].Value.ToString();
                txtChucVu.Text = dgvTaiKhoan.Rows[r].Cells["ChucVu"].Value.ToString();
            }
        }
    }
}
