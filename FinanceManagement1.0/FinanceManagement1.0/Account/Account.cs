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

namespace FinanceManagement1._0.Account
{
    public partial class Account : UserControl
    {
        SqlConnection con = ConnectionString.con;
        public Account()
        {
            InitializeComponent();
        }

       
        private void picEdit_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd2 = new SqlCommand("Select * from FmWallet where FmUser= '" + frm_Login.FmUser + "'and FmWName = 'Cash'", con);
            SqlDataReader rdr = cmd2.ExecuteReader();
            if (rdr.Read())
            {
                txtName.Text = (rdr["FmWName"].ToString());
                txtNote.Text = (rdr["FmWNote"].ToString());
                txtVND.Text = (rdr["FmBudget"].ToString());
            }
            con.Close();

        }
        
        private void picAtmEdit_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd2 = new SqlCommand("Select * from FmWallet where FmUser= '" + frm_Login.FmUser + "' and FmWName = 'ATM'", con);
            SqlDataReader rdr = cmd2.ExecuteReader();
            if (rdr.Read())
            {
                txtName.Text = (rdr["FmWName"].ToString());
                txtNote.Text = (rdr["FmWNote"].ToString());
                txtVND.Text = (rdr["FmBudget"].ToString());
            }
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (txtName.Text =="Cash")
            {
                SqlCommand cmd3 = new SqlCommand(@"Update FmWallet set FmBudget = '" + txtVND.Text + "', FmWNote = '" + txtNote.Text + "' where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa thành công");
            }
            if(txtName.Text == "ATM")
            {
                SqlCommand cmd4 = new SqlCommand(@"Update FmWallet set FmBudget = '" + txtVND.Text + "', FmWNote = '" + txtNote.Text + "' where FmUser ='" + frm_Login.FmUser + "' and FmWName ='ATM'", con);
                cmd4.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa thành công");
            }
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVND.Text = txtNote.Text = txtName.Text = "";
        }
    }
}
