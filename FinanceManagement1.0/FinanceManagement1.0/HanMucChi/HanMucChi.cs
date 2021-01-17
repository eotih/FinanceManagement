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

namespace FinanceManagement1._0.HanMucChi
{
    public partial class HanMucChi : UserControl
    {
        SqlConnection con = ConnectionString.con;
        public static string thanh = "";
        public HanMucChi()
        {
            InitializeComponent();
        }
        void load()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from FmBudget where FmUser ='" + frm_Login.FmUser + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dtgvLimit.DataSource = dt;
            //SqlDataAdapter adapt;
            // if (con.State == ConnectionState.Closed)
            // {
            //     con.Open();
            // }
            // DataTable dt = new DataTable();
            // adapt = new SqlDataAdapter("select * from FmBudget  where FmUser ='" + frm_Login.FmUser + "'", con);
            // adapt.Fill(dt);
            // dtgvLimit.DataSource = dt;
            // dtgvLimit.Update();
            // dtgvLimit.Refresh();
            // con.Close();
        }
        
        private void HanMucChi_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dtgvLimit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLimit.Rows[e.RowIndex];
                cmbLimitCate.Text = row.Cells["FmCatalogyName"].Value.ToString();
                txtTen.Text = row.Cells["FmBName"].Value.ToString();
                txtVND.Text = row.Cells["FmVND"].Value.ToString();
                CreatedDate.Text = row.Cells["FmStart"].Value.ToString();
            }
            con.Close();
        }

       

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            thanh = CreatedDate.Value.Date.ToString("dd-MM-yyyy");
            con.Open();
            if (txtVND.Text != "" || cmbLimitCate.Text != "" || txtTen.Text != "" || CreatedDate.Text != "")
            {
                SqlCommand cmd = new SqlCommand("UPDATE FmBudget SET FmStart ='"+ thanh + "', FmVND ='" + txtVND.Text + "',FmBName = '" + txtTen.Text + "' where FmUser = '" + frm_Login.FmUser + "'", con);
               cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công");
                con.Close();
                load();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
            
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTen.Text = cmbLimitCate.Text = txtVND.Text = CreatedDate.Text = lsbLaplai.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn Có Muốn Xóa Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                ConnectionString con = new ConnectionString();
                int kq = con.xulydulieu("DELETE FROM FmBudget WHERE FmUser like '" + frm_Login.FmUser+ "'");

                if (kq > 0)
                {
                    MessageBox.Show("Xóa Thành Công");
                    load();
                }
                else
                {
                    MessageBox.Show("Thất Bại");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            thanh = CreatedDate.Value.Date.ToString("dd-MM-yyyy");
            con.Open();
            if (cmbLimitCate.Text != "" || txtTen.Text != "" || txtVND.Text != "")
            {
                SqlCommand cmd = new SqlCommand("insert into FmBudget(FmUser,FmCatalogyName,FmVND,FmBName,FmStart) values('" + frm_Login.FmUser + "',N'" + cmbLimitCate.Text + "', '" + txtVND.Text + "','" + txtTen.Text + "',N'" + thanh + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thành công !");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void dtgvLimit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Lưu lại dòng dữ liệu vừa kích chọn
                DataGridViewRow row = this.dtgvLimit.Rows[e.RowIndex];
                //Đưa dữ liệu vào textbox
                cmbLimitCate.Text = row.Cells[0].Value.ToString();
                txtVND.Text = row.Cells[1].Value.ToString();
                txtTen.Text = row.Cells[2].Value.ToString();
                CreatedDate.Text = row.Cells[3].Value.ToString();
            }
        }



        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (radioten.Checked)
            {
                ConnectionString kn = new ConnectionString();
                DataTable dt = new DataTable();
                dt = kn.laybang("SELECT * FROM FmBudget WHERE FmCatalogyName like  '%" + txtserach.Text + "%' and FmUser ='" + frm_Login.FmUser + "'");
                dtgvLimit.DataSource = dt;
            }
            if (radiongay.Checked)
            {
                thanh = dtpPui.Value.Date.ToString("MM-dd-yyyy HH:mm");
                ConnectionString kn = new ConnectionString();
                DataTable dt = new DataTable();
                dt = kn.laybang("SELECT * FROM FmBudget WHERE FmStart = '"+thanh+"' and FmUser ='" + frm_Login.FmUser+"'");
                //cmd.Parameters.Add("@datDepartDate", SqlDbType.DateTime).Value = dtpPui;
                dtgvLimit.DataSource = dt;
                
            }
        }
       
    }
}
