using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FinanceManagement1._0
{
    public partial class frm_Reg : Form
    {
        SqlConnection con = ConnectionString.con;
        public static string FmUser = "";
        public frm_Reg()
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

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txt_Name.Text == "" || txt_Phone.Text == ""  || txt_User.Text == "" || txt_Pass.Text == "" || txt_rePass.Text == "")
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
            else if (txt_Pass.Text != txt_rePass.Text)
                MessageBox.Show("Password nhập lại không đúng !");
            else
            {
                txt_User.Text = FmUser;
                con.Open();
                SqlCommand cmd1 = new SqlCommand(@"INSERT INTO FmAccount(FmUser,FmPass,FmPhone,FmName) VALUES('" + txt_User.Text + "','" + txt_Pass.Text + "','" + txt_Phone.Text + "',N'" + txt_Name.Text  + "')", con);
                SqlCommand cmd2 = new SqlCommand(@"INSERT INTO FmWallet(FmUser,FmWName,FmBudget,FmWNote) VALUES('" + frm_Reg.FmUser + "',N'Cash','9999',N'Please Update Full Info',N'')", con);
                SqlCommand cmd3 = new SqlCommand(@"INSERT INTO FmWallet(FmUser,FmWName,FmBudget,FmWNote) VALUES('" + frm_Reg.FmUser + "',N'ATM','9999',N'Please Update Full Info',N'')", con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thành công !");
                MessageBox.Show("Vui lòng vào phân tài khoản và chỉnh sửa thông tin ví ! Xin cám ơn !");
                //Thiết lập các thuộc tính cho đối tượng Command
                Clear();
                con.Close();
            }
        }
        void Clear()
        {
            txt_Name.Text = txt_Pass.Text = txt_Phone.Text = txt_rePass.Text = "";
        }
        void CheckThongTin()
        {
            if (txt_Name.Text == "")
            {
               // ErrorProvider err = new ErrorProvider();
                errorProvider1.SetError(txt_Name, "Bạn Chưa Nhập Họ Và Tên");
            }
            if (txt_Phone.Text == "")
            {
                errorProvider1.SetError(txt_Phone, "Bạn Chưa Nhập Số Điện Thoại");
            }
           if (txt_User.Text == "")
            {
                errorProvider1.SetError(txt_User, "Bạn Chưa Nhập Tài Khoản");
            }
            if (txt_Pass.Text == "")
            {
                errorProvider1.SetError(txt_Pass, "Bạn Chưa Nhập Mật Khẩu");
            }
            if (txt_rePass.Text == "")
            {
                errorProvider1.SetError(txt_rePass, "Bạn Chưa Lại Nhập Mật Khẩu");
            }
        }
    }
}
