using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        }

        public void getData()
        {
            string query = "select * from NhanVien";
            DataTable tb = kn.LayDuLieu(query);
            dgvNhanVien.DataSource = tb;
        }
        public void clearText()
        {
            txtMaNhanVien.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
            clearText();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                  "select * from nhanvien where MaNhanVien = N'{0}' or TenNhanVien = N'{0}'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvNhanVien.DataSource = tb;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {   
                string query = string.Format(
                    "insert into nhanvien  values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}', N'{6}')",
                    txtMaNhanVien.Text,
                    txtTenNhanVien.Text,
                    txtGioiTinh.Text,
                    dtpNgaySinh.Text,
                    txtSoDienThoai.Text,
                    txtDiaChi.Text,
                    txtEmail.Text
                );
               
                bool kt = kn.ThucThi(query);
                if (kt)
                {
                    MessageBox.Show("Thêm mới thành công!");
                    btnLamMoi.PerformClick();
                }
                else
                {
                    MessageBox.Show("Thêm mới thất bại! Không rõ nguyên nhân.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "update nhanvien set TenNhanVien = N'{1}', NgaySinh = '{2}', GioiTinh = N'{3}', DiaChi = N'{4}', SoDienThoai = N'{5}', Email = N'{6}' where MaNhanVien = N'{0}'",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                dtpNgaySinh.Text,
                txtGioiTinh.Text,
                txtDiaChi.Text,
                txtSoDienThoai.Text,
                txtEmail.Text
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
                "delete from nhanvien where MaNhanVien = N'{0}'",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                dtpNgaySinh.Text,
                txtGioiTinh.Text,
                txtDiaChi.Text,
                txtSoDienThoai.Text,
                txtEmail.Text
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

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

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
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
