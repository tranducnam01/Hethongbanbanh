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
    public partial class frmQLNV : Form
    {
        public frmQLNV()
        {
            InitializeComponent();
        }

        KetNoi kn = new KetNoi();
        
        private void frmQLNV_Load(object sender, EventArgs e)
        {
            getData();
            getTenDangNhap();
        }
        public void getTenDangNhap()
        {
            string query = "select * from TaiKhoan";
            DataTable tb = kn.LayDuLieu(query);
            cmbTenDangNhap.DataSource = tb;
            cmbTenDangNhap.DisplayMember = "TenDangNhap";
            cmbTenDangNhap.ValueMember = "TenDangNhap";
        }
        public void getData()
        {
            string query = "select * from NhanVien";
            DataTable tb = kn.LayDuLieu(query);
            dgvNhanVien.DataSource = tb;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
            clearText();
        }
        public void clearText()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            cmbTenDangNhap.Text = "";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                //"select * from NhanVien inner join TaiKhoan on NhanVien.TenDangNhap = TaiKhoan.TenDangNhap where MaNhanVien = N'{0}' or TenNhanVien = N'{0}' or GioiTinh = N'{0}' or NgaySinh = '{0}' or SoDienThoai = '{0}' or DiaChi = N'{0}' or Email = N'{0}'",
                //"select * from NhanVien inner join TaiKhoan on NhanVien.TenDangNhap = TaiKhoan.TenDangNhap where TaiKhoan.TenDangNhap like N'%{0}%'",
                "select * from NhanVien inner join TaiKhoan on NhanVien.TenDangNhap = TaiKhoan.TenDangNhap where TaiKhoan.TenDangNhap = N'{0}'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvNhanVien.DataSource = tb;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into NhanVien values (N'{0}', N'{1}', N'{2}', '{3}', N'4', N'5', N'6', N'7')",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                txtGioiTinh.Text,
                dtpNgaySinh.Text,
                txtSoDienThoai.Text,
                txtDiaChi.Text,
                txtEmail.Text,
                cmbTenDangNhap.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Them moi thanh cong!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Them moi that bai!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update NhanVien set MaNhanVien = N'{0}', TenNhanVien = N'{1}', GioiTinh = N'{2}', NgaySinh = '{3}', SoDienThoai = N'4', DiaChi = N'5', Email = N'6', TenDangNhap = N'7')",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                txtGioiTinh.Text,
                dtpNgaySinh.Text,
                txtSoDienThoai.Text,
                txtDiaChi.Text,
                txtEmail.Text,
                cmbTenDangNhap.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Sua thanh cong!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sua that bai!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from NhanVien where MaNhanVien = N'{0}'",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                txtGioiTinh.Text,
                dtpNgaySinh.Text,
                txtSoDienThoai.Text,
                txtDiaChi.Text,
                txtEmail.Text,
                cmbTenDangNhap.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Xoa thanh cong!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xoa that bai!");
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaNhanVien.Text = dgvNhanVien.Rows[r].Cells["MaNhanVien"].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.Rows[r].Cells["TenNhanVien"].Value.ToString();
                txtGioiTinh.Text = dgvNhanVien.Rows[r].Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Text = dgvNhanVien.Rows[r].Cells["NgaySinh"].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[r].Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[r].Cells["DiaChi"].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[r].Cells["Email"].Value.ToString();
                cmbTenDangNhap.Text = dgvNhanVien.Rows[r].Cells["TenDangNhap"].Value.ToString();
            }
        }
    }
}
