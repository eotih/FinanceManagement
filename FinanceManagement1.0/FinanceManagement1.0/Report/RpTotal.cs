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
using DevExpress.XtraEditors;
namespace FinanceManagement1._0.Report
{
    public partial class RpTotal : UserControl
    {
        SqlConnection con = ConnectionString.con;
        public static string FmIncome ="";
        public static string thanh = "";

        public RpTotal()
        {
            InitializeComponent();
        }
        void load()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from FmIncome where FmUser ='" + frm_Login.FmUser + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
        private void btnXuatthu_Click(object sender, EventArgs e)
        {
            load();
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select * from FmIncome where FmUser ='"+frm_Login.FmUser+"'", con);
            //cmd.ExecuteNonQuery();
            //SqlDataReader rdr = cmd.ExecuteReader();
            //while (rdr.Read())
            //{
            //    DataClasses1DataContext context = new DataClasses1DataContext();
            //    dataGridView1.DataSource = context.FmIncomes.ToList();
            //}
            //con.Close();
            
        }

        private void btnXuatchi_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from FmExpense where FmUser ='" + frm_Login.FmUser + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Update();
            dataGridView1.Refresh();
            //DataClasses1DataContext context = new DataClasses1DataContext();
            //dataGridView1.DataSource = context.FmExpenses.ToList();
        }

        private void btnLocrp_Click(object sender, EventArgs e)
        {
            if (radiotenthu.Checked)
            {
                ConnectionString kn = new ConnectionString();
                DataTable dt = new DataTable();
                dt = kn.laybang("SELECT * FROM [FmIncome] WHERE [FmWName] like  '%" + txtserachthu.Text + "%' and FmUser = '" + frm_Login.FmUser + "'");
                dataGridView1.DataSource = dt;
            }
            if (radiotenchi.Checked)
            {
                ConnectionString kn = new ConnectionString();
                DataTable dt = new DataTable();
                dt = kn.laybang("SELECT * FROM [FmExpense] WHERE [FmWName] like  N'%" + txtserachchi.Text + "%' and FmUser ='" + frm_Login.FmUser + "'");
                dataGridView1.DataSource = dt;
            }
            
        }
    }
} 

