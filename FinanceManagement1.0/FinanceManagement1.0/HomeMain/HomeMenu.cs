using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinanceManagement1._0.HomeMain
{
    public partial class HomeMenu : UserControl
    {
        public static string FmName = "";
        SqlConnection con = ConnectionString.con;
        public HomeMenu()
        {
            InitializeComponent();
        }

        private void btn_Out_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn Có Muốn Thoát Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                System.Windows.Forms.Application.ExitThread();
            }
        }

        private void HomeMenu_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"Select FmUser,FmName from FmAccount where FmUser = '" + frm_Login.FmUser + "'";
            cmd.Connection = con;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblTop.Text = rdr.GetString(1);
                FmName = rdr.GetString(1);
               
            }
            con.Close();
        }
    }
}
