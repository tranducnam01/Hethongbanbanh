using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    internal class KetNoi
    {
        private string conStr = "Data Source=DESKTOP-HA0KK9P;Initial Catalog=QLBanHang;Integrated Security=True";
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
            catch
            {
                return false;
            }
        }
    }
}
