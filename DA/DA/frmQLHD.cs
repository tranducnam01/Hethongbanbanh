using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public partial class frmQLHD : Form
    {
        public frmQLHD()
        {
            InitializeComponent();
        }
        KetNoi kn = new KetNoi();
        private void frmQLHD_Load(object sender, EventArgs e)
        {
            getDataHD();
            getMaNhanVien();
            getDataCTHD();
            getMaSanPham();
            double tongTienHoaDon = TinhTongTienHoaDon(txtMaHoaDon.Text);
            // Gắn sự kiện SelectionChanged cho DataGridView1
            //dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            //dgvCTHoaDon.SelectionChanged += dgvCTHoaDon_SelectionChanged;
        }
        public void getDataHD()
        {
            string query = "select * from HoaDon";
            DataTable tb = kn.LayDuLieu(query);
            dgvHoaDon.DataSource = tb;
        }
        public void getMaNhanVien()
        {
            string query = "select * from NhanVien";
            DataTable tb = kn.LayDuLieu(query);
            cmbMaNhanVien.DataSource = tb;
            cmbMaNhanVien.DisplayMember = "TenNhanVien";
            cmbMaNhanVien.ValueMember = "MaNhanVien";
        }
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string query = string.Format(
                "select * from HoaDon where MaHoaDon like N'%{0}%'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvHoaDon.DataSource = tb;
        }
        public void clearText()
        {
            txtMaHoaDon.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaHoaDon.Text = "";
            cmbMaNhanVien.SelectedValue = "";
            dtpNgayLap.Text = "";
            txtTongTien.Text = "";
        }
        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            getDataHD();
            clearText();
        }
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string query = string.Format(
                "INSERT INTO HoaDon VALUES (N'{0}', N'{1}', '{2}', '{3}')",
                    txtMaHoaDon.Text,
                    cmbMaNhanVien.SelectedValue,
                    dtpNgayLap.Text, 
                    txtTongTien.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Thêm hóa đơn thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!");
            }
        }
        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string query = string.Format(
                "UPDATE HoaDon SET MaNhanVien = '{1}', NgayLap = '{2}', TongTien = '{3}' WHERE MaHoaDon = N'{0}' ",
                txtMaHoaDon.Text,
                cmbMaNhanVien.SelectedValue,
                dtpNgayLap.Text, 
                txtTongTien.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Sửa hóa đơn thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa hóa đơn thất bại!");
            }
        }
        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string query = string.Format(
                "DELETE FROM HoaDon WHERE MaHoaDon = N'{0}'",
                txtMaHoaDon.Text,
                cmbMaNhanVien.SelectedValue,
                dtpNgayLap.Text,
                txtTongTien.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Xóa hóa đơn thành công!");
                btnLamMoi.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn thất bại!");
            }
        }
        private void dgvHoaDon_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHoaDon.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaHoaDon.Text = dgvHoaDon.Rows[r].Cells["MaHoaDon"].Value.ToString();
                cmbMaNhanVien.SelectedValue = dgvHoaDon.Rows[r].Cells["MaNhanVien"].Value.ToString();
                dtpNgayLap.Text = dgvHoaDon.Rows[r].Cells["NgayLap"].Value.ToString();
                txtTongTien.Text = dgvHoaDon.Rows[r].Cells["TongTien"].Value.ToString();
                txtMaHD.Text = dgvHoaDon.Rows[r].Cells["MaHoaDon"].Value.ToString();

                // Load dữ liệu chi tiết hóa đơn tương ứng với hóa đơn được chọn
                LoadDataCTHD(txtMaHoaDon.Text);
            }
        }

        // Hàm load dữ liệu chi tiết hóa đơn
        private void LoadDataCTHD(string maHoaDon)
        {
            string query = string.Format(
                "SELECT * FROM CTHoaDon WHERE MaHoaDon = '{0}'", 
                maHoaDon
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvCTHoaDon.DataSource = tb;
        }
       

        //CTHoaDon
        public void getDataCTHD()
        {
            string query = "select * from CTHoaDon";
            DataTable tb = kn.LayDuLieu(query);
            dgvCTHoaDon.DataSource = tb;
        }
        public void getMaSanPham()
        {
            string query = "select * from SanPham";
            DataTable tb = kn.LayDuLieu(query);
            cmbMaSanPham.DataSource = tb;
            cmbMaSanPham.DisplayMember = "TenSanPham";
            cmbMaSanPham.ValueMember = "MaSanPham";
        }
        private void btnTimCTHD_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "select * from CTHoaDon where MaHoaDon like N'%{0}%'",
                txtTimKiem.Text
            );
            DataTable tb = kn.LayDuLieu(query);
            dgvCTHoaDon.DataSource = tb;
        }
        public void clearTextCTHD()
        {
            txtMaHD.Enabled = true;
            cmbMaSanPham.Enabled = true;
            btnThemCTHD.Enabled = true;
            btnSuaCTHD.Enabled = false;
            btnXoaCTHD.Enabled = false;

            txtMaHD.Text = "";
            cmbMaSanPham.SelectedValue = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
        }
        private void btnLamMoiCTHD_Click(object sender, EventArgs e)
        {
            clearTextCTHD();
            getDataCTHD();
        }
        private void btnThemCTHD_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "INSERT INTO CTHoaDon VALUES (N'{0}', N'{1}', '{2}', '{3}', '{4}')",
                    txtMaHD.Text,
                    cmbMaSanPham.SelectedValue,
                    txtSoLuong.Text,
                    txtDonGia.Text,
                    txtThanhTien.Text
                );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Thêm mới thành công!");
                btnLamMoiCTHD.PerformClick();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }
        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "UPDATE CTHoaDon SET SoLuong = '{2}', DonGia = '{3}', ThanhTien = '{4}' WHERE MaHoaDon = N'{0}' and MaSanPham = N'{1}'",
                txtMaHD.Text,
                cmbMaSanPham.SelectedValue,
                txtSoLuong.Text,
                txtDonGia.Text,
                txtThanhTien.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Sửa hóa đơn thành công!");
                btnLamMoiCTHD.PerformClick();
            }
            else
            {
                MessageBox.Show("Sửa hóa đơn thất bại!");
            }
        }
        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "DELETE FROM CTHoaDon WHERE MaHoaDon = N'{0}'",
                txtMaHD.Text,
                cmbMaSanPham.SelectedValue,
                txtSoLuong.Text,
                txtDonGia.Text,
                txtThanhTien.Text
            );
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                MessageBox.Show("Xóa hóa đơn thành công!");
                btnLamMoiCTHD.PerformClick();
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn thất bại!");
            }
        }
        private void dgvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Enabled = false;
            cmbMaSanPham.Enabled = false;
            btnThemCTHD.Enabled = false;
            btnSuaCTHD.Enabled = true;
            btnXoaCTHD.Enabled = true;

            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaHD.Text = dgvCTHoaDon.Rows[r].Cells["MaHoaDon"].Value.ToString();
                cmbMaSanPham.SelectedValue = dgvCTHoaDon.Rows[r].Cells["MaSanPham"].Value.ToString();
                txtSoLuong.Text = dgvCTHoaDon.Rows[r].Cells["SoLuong"].Value.ToString();
                txtDonGia.Text = dgvCTHoaDon.Rows[r].Cells["DonGia"].Value.ToString();
                txtThanhTien.Text = dgvCTHoaDon.Rows[r].Cells["ThanhTien"].Value.ToString();

                // Lấy mã hóa đơn từ DataGridView
                string maHoaDon = txtMaHD.Text;

                // Lấy tổng tiền từ bảng hóa đơn dựa trên mã hóa đơn
                decimal tongTien = LayTongTienHoaDon(maHoaDon);
                txtTongTien.Text = tongTien.ToString();
            }
        }
        private decimal LayTongTienHoaDon(string maHoaDon)
        {
            //decimal: so thap pha
            decimal tongTienHoaDon = 0;

            // Thực hiện truy vấn để lấy tổng tiền từ bảng hóa đơn
            string query = string.Format(
                "SELECT TongTien FROM HoaDon WHERE MaHoaDon = '{0}'",
                maHoaDon
                );
            DataTable tb = kn.LayDuLieu(query);
            if (tb.Rows.Count > 0)
            {
                // Lấy giá trị tổng tiền từ dòng đầu tiên của DataTable
                tongTienHoaDon = Convert.ToDecimal(tb.Rows[0]["TongTien"]);
            }

            return tongTienHoaDon;
        }
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            // Kiểm tra xem giá trị trong các ô TextBox có hợp lệ hay không
            if (int.TryParse(txtSoLuong.Text, out int soLuong) && int.TryParse(txtDonGia.Text, out int donGia))
            {
                // Tính thanh tiền
                int thanhTien = soLuong * donGia;

                // Hiển thị kết quả trong ô TextBox "txtThanhTien"
                txtThanhTien.Text = thanhTien.ToString();

                // Tìm mã hóa đơn tương ứng với chi tiết hóa đơn
                string maHoaDon = txtMaHoaDon.Text; // Chỉnh sửa tên TextBox để phù hợp với mã hóa đơn

                // Tính lại tổng tiền cho hóa đơn
                double tongTienHoaDon = TinhTongTienHoaDon(maHoaDon);

                // Cập nhật tổng tiền của hóa đơn trong bảng Hóa Đơn
                CapNhatTongTienHoaDon(maHoaDon, tongTienHoaDon);
            }
            else
            {
                txtThanhTien.Text = "0"; // Nếu giá trị không hợp lệ, hiển thị 0 hoặc thông báo lỗi
            }
        }

        // Hàm tính tổng tiền cho hóa đơn dựa trên mã hóa đơn
        private double TinhTongTienHoaDon(string maHoaDon)
        {
            double tongTienHoaDon = 0;

            // Duyệt qua tất cả các chi tiết hóa đơn có cùng mã hóa đơn
            foreach (DataGridViewRow row in dgvCTHoaDon.Rows)
            {
                if (row.Cells["MaHoaDon"].Value != null && row.Cells["ThanhTien"].Value != null)
                {
                    if (row.Cells["MaHoaDon"].Value.ToString() == maHoaDon)
                    {
                        double thanhTien;

                        if (double.TryParse(row.Cells["ThanhTien"].Value.ToString(), out thanhTien))
                        {
                            tongTienHoaDon += thanhTien;
                        }
                    }
                }
            }

            return tongTienHoaDon;
        }

        // Hàm cập nhật tổng tiền của hóa đơn trong bảng Hóa Đơn
        private void CapNhatTongTienHoaDon(string maHoaDon, double tongTienHoaDon)
        {
            string query = string.Format("UPDATE HoaDon SET TongTien = '{0}' WHERE MaHoaDon = '{1}'", tongTienHoaDon, maHoaDon);
            bool kt = kn.ThucThi(query);
            if (kt)
            {
                btnLamMoi.PerformClick();
                // Cập nhật trong giao diện người dùng
                if (txtTongTien.Text != tongTienHoaDon.ToString())
                {
                    txtTongTien.Text = tongTienHoaDon.ToString();
                }
            }
            else
            {
                //MessageBox.Show("Cập nhật thất bại!");
            }
        }



        //private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvHoaDon.SelectedRows.Count > 0)
        //    {
        //        //string selectedMaHoaDon = dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();

        //        // Truy vấn và hiển thị chi tiết hóa đơn trong DataGridView2
        //        //string query = "SELECT * FROM CTHoaDon WHERE MaHoaDon = '" + selectedMaHoaDon + "'";
        //        string query = "SELECT * FROM CTHoaDon WHERE MaHoaDon = '{0}'";
        //        DataTable tb = kn.LayDuLieu(query);
        //        dgvCTHoaDon.DataSource = tb;
        //    }
        //}

        //private void dgvCTHoaDon_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvCTHoaDon.SelectedRows.Count > 0)
        //    {
        //        // Lấy thông tin từ hàng được chọn trong dgvCTHoaDon
        //        string selectedMaHoaDon = dgvCTHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();
        //        string selectedMaSanPham = dgvCTHoaDon.SelectedRows[0].Cells["MaSanPham"].Value.ToString();
        //        string selectedSoLuong = dgvCTHoaDon.SelectedRows[0].Cells["SoLuong"].Value.ToString();
        //        string selectedDonGia = dgvCTHoaDon.SelectedRows[0].Cells["DonGia"].Value.ToString();
        //        string selectedThanhTien = dgvCTHoaDon.SelectedRows[0].Cells["ThanhTien"].Value.ToString();

        //        // Hiển thị thông tin chi tiết hóa đơn trong các điều khiển giao diện người dùng
        //        cmbMaHoaDon.SelectedValue = selectedMaHoaDon;
        //        cmbMaSanPham.SelectedValue = selectedMaSanPham;
        //        txtSoLuong.Text = selectedSoLuong;
        //        txtDonGia.Text = selectedDonGia;
        //        txtThanhTien.Text = selectedThanhTien;
        //    }
        //}
    }
}
