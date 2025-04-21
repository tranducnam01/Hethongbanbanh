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
    public partial class frmQLHH : Form
    {
        public frmQLHH()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();

        private void frmQLHH_Load(object sender, EventArgs e)
        {
            getData();
            getMaLoaiSP();
        }
        public void getData()
        {
            string query = "select * from SanPham";
            DataTable tb = kn.LayDuLieu(query);
            dgvSanPham.DataSource = tb;
        }
        public void getMaLoaiSP()
        {
            string query = "select * from LoaiSanPham";
            DataTable tb = kn.LayDuLieu(query);
            cmbMaLoaiSanPham.DataSource = tb;
            cmbMaLoaiSanPham.DisplayMember = "TenLoaiSP";
            cmbMaLoaiSanPham.ValueMember = "MaLoaiSP";
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "select * from SanPham inner join LoaiSanPham on SanPham.MaLoaiSP = LoaiSanPham.MaLoaiSP where TenLoaiSP like N'%{0}%'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvSanPham.DataSource = tb;
        }
        public void clearText()
        {
            txtMaSanPham.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtMoTa.Text = "";
            txtGiaTien.Text = "";
            cmbMaLoaiSanPham.SelectedValue = "";
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clearText();
            getData();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into SanPham values (N'{0}', N'{1}', '{2}', N'{3}', '{4}')",
                txtMaSanPham.Text,
                txtTenSanPham.Text,
                txtGiaTien.Text,
                txtMoTa.Text,
                cmbMaLoaiSanPham.SelectedValue
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
                "update SanPham set TenSanPham = N'{1}', GiaTien = '{2}', MoTa = N'{3}', MaLoaiSP = '{4}' where MaSanPham = N'{0}'",
                txtMaSanPham.Text,
                txtTenSanPham.Text,
                txtGiaTien.Text,
                txtMoTa.Text,
                cmbMaLoaiSanPham.SelectedValue
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
                "delete from SanPham where MaSanPham = N'{0}'",
                txtMaSanPham.Text,
                txtTenSanPham.Text,
                txtGiaTien.Text,
                txtMoTa.Text,
                cmbMaLoaiSanPham.SelectedValue
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

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaSanPham.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtMaSanPham.Text = dgvSanPham.Rows[r].Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = dgvSanPham.Rows[r].Cells["TenSanPham"].Value.ToString();
                txtGiaTien.Text = dgvSanPham.Rows[r].Cells["GiaTien"].Value.ToString();
                txtMoTa.Text = dgvSanPham.Rows[r].Cells["MoTa"].Value.ToString();
                cmbMaLoaiSanPham.SelectedValue = dgvSanPham.Rows[r].Cells["MaLoaiSP"].Value.ToString();
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
