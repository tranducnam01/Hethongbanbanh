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
    public partial class frmQLK : Form
    {
        public frmQLK()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmQLK_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNL.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            int r = e.RowIndex;
            if(r >= 0)
            {
                txtMaNL.Text = dataGridView1.Rows[r].Cells["MaNhienLieu"].Value.ToString();

                txtTenNL.Text = dataGridView1.Rows[r].Cells["TenNhienLieu"].Value.ToString();

                txtXuatXu.Text = dataGridView1.Rows[r].Cells["XuatXu"].Value.ToString();

                txtSoLuong.Text = dataGridView1.Rows[r].Cells["SoLuong"].Value.ToString();

                dateNgayNhap.Text = dataGridView1.Rows[r].Cells["NgayNap"].Value.ToString();

                dateNgayXuat.Text = dataGridView1.Rows[r].Cells["NgayXuat"].Value.ToString();

            }
        }
        public void getData()
        {
            string query = "select * from QLK";
            DataTable tb = kn.LayDuLieu(query);
            dataGridView1.DataSource = tb;
        }
        public void clearText()
        {
            txtMaNL.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNL.Text = "";
            txtMaNV.Text = "";
            txtSoLuong.Text = "";
            txtTenNL.Text = "";
            txtTimKiemNL.Text = "";
            txtXuatXu.Text = "";
            dateNgayNhap.Text = "";
            dateNgayXuat.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "insert into QLK values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')",
                txtMaNL.Text,
                txtTenNL.Text,
                txtXuatXu.Text,
                txtSoLuong.Text,
                dateNgayNhap.Text,
                dateNgayXuat.Text,
                 txtMaNV.Text
                );

            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show(" Thêm Thành Công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show(" Thêm Thất bại ","Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "Update QLK set TenNguyenLieu =N'{1}',XuatXu =N'{2}',SoLuong =N'{3}',NgayNhap =N'{4}',NgayXuat =N'{5}',MaNhanVien =N'{6}' where MaNhienLieu = N'{0}'",
                   txtMaNL.Text,
                    txtTenNL.Text,
                    txtXuatXu.Text,
                    txtSoLuong.Text,
                    dateNgayNhap.Text,
                    dateNgayXuat.Text,
                    txtMaNV.Text
            );

            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show(" Sửa Thành Công");
                btnLamMoi.PerformClick();

            }
            else
            {
                MessageBox.Show(" Sửa Thất bại ", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "delete from QLK where MaNhienLieu = N'{0}'",
                 txtMaNL.Text,
                    txtTenNL.Text,
                    txtXuatXu.Text,
                    txtSoLuong.Text,
                    dateNgayNhap.Text,
                    dateNgayXuat.Text,
                    txtMaNV.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show(" Xoas Thành Công");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show(" Xoas Thất bại ", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            getData();
            clearText();
        }
    }
}
