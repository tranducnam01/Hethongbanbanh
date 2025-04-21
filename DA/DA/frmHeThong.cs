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
    public partial class frmHeThong : Form
    {
        public frmHeThong()
        {
            InitializeComponent();
        }

        private Form curentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if(curentFormChild != null)
            {
                curentFormChild.Close();
            }
            curentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }    
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrangChu());
            label1.Text = btnTrangChu.Text;
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLHD());
            label1.Text = btnQLHD.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (curentFormChild != null)
            {
                curentFormChild.Close();
            }
            label1.Text = "Home";
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
            //OpenChildForm(new frmThoat());
            //label1.Text = btnDangXuat.Text;
        }

        private void btnQLNV_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLNV());
            label1.Text = btnQLNV.Text;
       
        }

        private void btnQLHH_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLHH());
            label1.Text = btnQLHH.Text;
        }

        private void btnQLND_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLND());
            label1.Text = btnQLND.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLK());
            label1.Text = button1.Text;
        }

        private void panel_Body_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
