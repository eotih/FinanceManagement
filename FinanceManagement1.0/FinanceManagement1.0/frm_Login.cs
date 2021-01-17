using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinanceManagement1._0
{
    public partial class frm_Login : Form
    {
        public static string FmUser = "";
        SqlConnection con = ConnectionString.con;
        public frm_Login()
        {
            InitializeComponent();
        }

        private void pic_Close_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn Có Muốn Thoát Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lbl_Reg_Click(object sender, EventArgs e)
        {
            frm_Reg frm = new frm_Reg();
            frm.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            FmUser = txt_User.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from FmAccount where FmUser = '" + txt_User.Text + "' and FmPass ='" + txt_Pass.Text + "'", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }

            if (count == 1)
            {
                MessageBox.Show("Đăng Nhập Thành Công");
                picProfile frm = new picProfile();
                frm.Show();
                this.Hide();
            }

            else if (count > 0)
            {
                MessageBox.Show("Đăng Nhập Không Thành Công, Nhập Lại");
            }
            else
            {
                MessageBox.Show("Đăng Nhập Không Thành Công, Nhập Lại");
            }
            con.Close();
            txt_User.Clear();
            txt_Pass.Clear();
        }
        
    }
}
