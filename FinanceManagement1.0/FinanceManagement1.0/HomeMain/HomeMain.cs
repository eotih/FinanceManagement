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
    public partial class HomeMain : UserControl
    {
        
        public static string lehieu = "";
        public static string FmName = "";
        public static string FmWName = "";
        public static string FmVND = "";

        public static string Thu = "";
        public static string Chi = "";
        public static int FmIncome;
        public static string FmExpense = "";
        public static int FmBudget;
        SqlConnection con = ConnectionString.con;
        public HomeMain()
        {
            InitializeComponent();
        }
        void LoadSoTien()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(@"Select b.FmUser,a.FmUser,a.FmName,b.FmBudget from FmAccount a,FmWallet b where a.FmUser ='" + frm_Login.FmUser + "' and b.FmUser ='" + frm_Login.FmUser + "' and b.FmWName ='Cash'",con);
            cmd.ExecuteNonQuery();
            
        }
        private void HomeMain_Load(object sender, EventArgs e)
        {
            timer.Start();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"Select b.FmUser,a.FmUser,a.FmName,b.FmBudget,c.FmBudget from FmAccount a, FmWallet b,FmWallet c where a.FmUser = '" + frm_Login.FmUser + "' and b.FmUser = '" + frm_Login.FmUser + "' and b.FmWName = 'Cash'  and c.FmWName = 'ATM'";
            cmd.Connection = con;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lblHello.Text = rdr.GetString(1);
                FmName = rdr.GetString(1);
                lblVND1.Text = rdr.GetInt32(3).ToString() + " VND";
                FmBudget = Convert.ToInt32(rdr.GetInt32(3).ToString());
                lblVND2.Text = rdr.GetInt32(4).ToString() + " VND";
                FmBudget = Convert.ToInt32(rdr.GetInt32(4).ToString());
                lblTotal.Text  = rdr.GetInt32(3).ToString() + " VND";
                FmBudget = Convert.ToInt32(rdr.GetInt32(3).ToString());
                }
            con.Close();
            tinhtongthu();
            tinhtongchi();

        }
        private double tinhtongchi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            double tong = 0;
            SqlCommand cm4 = new SqlCommand("SELECT FmExpense FROM FmExpense where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
            cm4.ExecuteNonQuery();
            SqlDataReader rdr2 = cm4.ExecuteReader();
            while (rdr2.Read())
            {
                var sotien = rdr2["FmExpense"];
                tong += Convert.ToDouble(sotien);

            }
            lblChi.Text = tong.ToString() + " VNĐ";
            lblCChi.Text = tong.ToString() +" VNĐ";
            return tong;

        }
        private double tinhtongthu()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            double tong = 0;
            SqlCommand cm4 = new SqlCommand("SELECT FmIncome FROM FmIncome where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
            cm4.ExecuteNonQuery();
            SqlDataReader rdr2 = cm4.ExecuteReader();
            while (rdr2.Read())
            {
                var sotien = rdr2["FmIncome"];
                tong += Convert.ToDouble(sotien);
                
            }
            lblThu.Text = tong.ToString() + " VNĐ";
            lblCThu.Text = tong.ToString() + " VNĐ";
            return tong;
           
        }
        void Clear()
        {
            txtVND.Text = txtNote.Text = cmbAcc.Text = label.Text = dtpThu.Text = "";
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVND.Text = txtNote.Text = cmbAcc.Text = label.Text = dtpThu.Text = "";
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            lehieu = dtpThu.Value.Date.ToString("dd-MM-yyyy HH:mm");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into FmIncome([FmUser]
              ,[FmIncome]
              ,[FmNote]
              ,[FmWName]
              ,[FmCatelogy],[FmCreatedDay]
              ) values('" + frm_Login.FmUser + "',N'" + txtVND.Text + "',N'" + txtNote.Text + "',N'" + cmbAcc.Text + "',N'" + cmbCate.Text + "',N'" + lehieu + "')", con);
            cmd.ExecuteNonQuery();
            if (cmbAcc.Text =="Cash")
            {
                SqlCommand cm4 = new SqlCommand("Select FmBudget From FmWallet where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
                cm4.ExecuteNonQuery();
                SqlDataReader rdr = cm4.ExecuteReader();
                while (rdr.Read())
                {
                    var sotien = rdr["FmBudget"];
                    FmBudget = Convert.ToInt32(sotien) + Convert.ToInt32(txtVND.Text);
                }
                SqlCommand cmd3 = new SqlCommand("Update FmWallet set FmBudget = '" + FmBudget + "'  where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Thành công !");
            }
            if (cmbAcc.Text == "ATM")
            {
                SqlCommand cm4 = new SqlCommand("Select FmBudget From FmWallet where FmUser ='" + frm_Login.FmUser + "'and FmWName ='ATM'", con);
                cm4.ExecuteNonQuery();
                SqlDataReader rdr = cm4.ExecuteReader();
                while (rdr.Read())
                {
                    var sotien = rdr["FmBudget"];
                    FmBudget = Convert.ToInt32(sotien) + Convert.ToInt32(txtVND.Text);
                }
                SqlCommand cmd5 = new SqlCommand("Update FmWallet set FmBudget = '" + FmBudget + "' where FmUser ='" + frm_Login.FmUser + "' and FmWName ='ATM'", con);
                cmd5.ExecuteNonQuery();
                MessageBox.Show("Thành công !");
            }
            
            Clear();
            con.Close();
        }

        private void btnCSave_Click(object sender, EventArgs e)
        {
            lehieu = dtpHieu.Value.Date.ToString("dd-MM-yyyy HH:mm");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"insert into FmExpense([FmUser]
              ,[FmExpense]
              ,[FmNote]
              ,[FmWName]
              ,[FmCatelogy]
              ,[FmCreatedDate]
              ) values('" + frm_Login.FmUser + "',N'" + txtCVND.Text + "',N'" + txtCNote.Text + "',N'" + cmbCACC.Text + "',N'" + cmbCCate.Text + "',N'" + lehieu + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Thành công !");
            if (cmbCACC.Text == "Cash")
            {
                SqlCommand cm4 = new SqlCommand("Select FmBudget From FmWallet where FmUser ='" + frm_Login.FmUser + "'and FmWName ='Cash'", con);
                cm4.ExecuteNonQuery();
                SqlDataReader rdr = cm4.ExecuteReader();
                while (rdr.Read())
                {
                    var sotien = rdr["FmBudget"];
                    FmBudget = Convert.ToInt32(sotien) - Convert.ToInt32(txtCVND.Text);
                }
                SqlCommand cmd3 = new SqlCommand("Update FmWallet set FmBudget = '" + FmBudget + "'  where FmUser ='" + frm_Login.FmUser + "' and FmWName ='Cash'", con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Thành công !");
                LoadSoTien();
            }
            if (cmbCACC.Text == "ATM")
            {
                SqlCommand cm4 = new SqlCommand("Select FmBudget From FmWallet where FmUser ='" + frm_Login.FmUser + "'and FmWName ='ATM'", con);
                cm4.ExecuteNonQuery();
                SqlDataReader rdr = cm4.ExecuteReader();
                while (rdr.Read())
                {
                    var sotien = rdr["FmBudget"];
                    FmBudget = Convert.ToInt32(sotien) - Convert.ToInt32(txtCVND.Text);
                }
                SqlCommand cmd3 = new SqlCommand("Update FmWallet set FmBudget = '" + FmBudget + "' where FmUser ='" + frm_Login.FmUser + "' and FmWName ='ATM'", con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("Thành công !");
                LoadSoTien();
            }
            Clear();
            con.Close();
        }
        void checkchi()
        {
            //con.Open();
            //SqlCommand cm4 = new SqlCommand("Select a.FmVND,b.FmExpense From FmBudget a,FmExpense b where a.FmUser ='" + frm_Login.FmUser + "' and b.FmUser ='" + frm_Login.FmUser + "' and a.FmCatalogyName = b.FmCatelogy", con);
            //cm4.ExecuteNonQuery();
            //SqlDataReader rdr = cm4.ExecuteReader();
            //while (rdr.Read())
            //{
            //    var HanMucChi = rdr["FmVND"];
            //    var TienChi = rdr["FmExpense"];
            //}


        }
        private void picReload_Click(object sender, EventArgs e)
        {
           
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
            lblSecond.Location = new Point(lblTime.Location.X + lblTime.Width - 5, lblSecond.Location.Y);
        }
    }
}
