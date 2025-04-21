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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ////Viết được truy vấn kiểm tra
            //string query = string.Format(
            //    "select * from TaiKhoan where TenDangNhap = '{0}' and MatKhau = '{1}'",
            //    txtTaiKhoan.Text,
            //    txtMatKhau.Text
            //);
            //DataTable tb = kn.LayDuLieu(query);     // tb: chứa dữ liệu được select về
            //if (tb.Rows.Count == 1)
            //{
            //    MessageBox.Show("Đăng nhập thành công!");
            //    frmHeThong frm = new frmHeThong();
            //    frm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Đăng nhập thất bại!");
            //}

            //----------------------------------------
            //string username = txtTaiKhoan.Text;
            //string password = txtMatKhau.Text;

            //string role = DetermineUserRole(username, password);

            //if (role != null)
            //{
            //    MessageBox.Show("Đăng nhập thành công!");

            //    Kiểm tra và chuyển hướng đến form tương ứng
            //    if (role == "admin")
            //    {
            //        frmHeThong frm = new frmHeThong();
            //        frm.Show();
            //    }
            //    else if (role == "nhanvien")
            //    {
            //        frmNhanVien frm = new frmNhanVien();
            //        frm.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vai trò không xác định!");
            //    }

            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Đăng nhập thất bại!");
            //}

            //----------------------------------------
            //Viết được truy vấn kiểm tra
            string query = string.Format(
                "select * from TAIKHOAN where TenDangNhap = '{0}' and MatKhau = '{1}'",
                txtTaiKhoan.Text,
                txtMatKhau.Text
            );
            DataTable tb = kn.LayDuLieu(query);
          
            if (tb.Rows.Count == 1)
            {
                DataRow row = tb.Rows[0];
                string username = row["TenDangNhap"].ToString();
                string password = row["MatKhau"].ToString();

                if (username == "ADMIN" && password == "123")
                {
                    MessageBox.Show("Đăng nhập thành công với quyền admin!");
                    // Logic bổ sung cho đăng nhập quyền admin
                    frmHeThong frm = new frmHeThong();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công với tài khoản nhân viên!");
                    // Logic bổ sung cho đăng nhập không phải admin
                    frmNhanVien frm = new frmNhanVien();  // Thay frmNhanVien bằng form thực tế cho nhân viên của bạn
                    frm.Show();
                    this.Hide();
                }
            }
            else if (tb.Rows.Count > 1)
            {
                // Xử lý trường hợp trả về nhiều hơn một hàng (bạn có thể muốn thêm logic bổ sung)
                MessageBox.Show("Có lỗi xảy ra. Vui lòng liên hệ quản trị viên.");
            }
            else
            {
                // Xử lý trường hợp không có hàng nào được trả về
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }

        }

        //private string DetermineUserRole(string username, string password)
        //{
        //    Thực hiện xác định vai trò dựa trên quy tắc cụ thể
        //    if (username == "admin" && password == "123")
        //    {
        //        return "admin";
        //    }
        //    else
        //    {
        //        return "nhanvien";
        //    }
        //}
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
