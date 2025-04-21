using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace DA
{
    internal class KetNoi
    {
        private string conStr = @"Data Source=NAM;Initial Catalog=QLBBN;Persist Security Info=True;User ID=sa;Password=123456789;Encrypt=False;";

   //     private string conStr = "Data Source=NAM;Initial Catalog=QLBBN;Persist Security Info=True;User ID=sa;Password=123456789;Encrypt=True;Trust Server Certificate=True";
        private SqlConnection conn;

        public KetNoi()
        {
            conn = new SqlConnection(conStr);
        }

        public DataTable LayDuLieu(string truy_van)
        {
            SqlDataAdapter da = new SqlDataAdapter(truy_van, conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public bool ThucThi(string truy_van)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(truy_van, conn);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
                return r > 0;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi để kiểm tra
                MessageBox.Show($"Lỗi khi thực thi câu lệnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return false;
            }
        }
    }
}
