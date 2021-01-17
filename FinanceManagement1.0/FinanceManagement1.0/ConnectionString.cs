using System.Data;
using System.Data.SqlClient;

namespace FinanceManagement1._0
{
    class ConnectionString
    {
       public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SP1FLTT;Initial Catalog=QLFinance;MultipleActiveResultSets=True;Integrated Security=True");
    
    public void dongketnoi()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
    public DataTable bangdulieu = new DataTable();
    public DataTable laybang(string caulenh)
    {
        try
        {
            con.Open();
            SqlDataAdapter Adapter = new SqlDataAdapter(caulenh, con);
            DataSet ds = new DataSet();

            Adapter.Fill(bangdulieu);
        }
        catch (System.Exception)
        {
            bangdulieu = null;
        }
        finally
        {
            dongketnoi();
        }

        return bangdulieu;
    }
    public int xulydulieu(string caulenhsql)
    {
        int kq = 0;
        try
        {
            con.Open();
            SqlCommand lenh = new SqlCommand(caulenhsql, con);
            kq = lenh.ExecuteNonQuery();
        }

        catch
        {
        }

        finally
        {
            dongketnoi();
        }
        return kq;
    }

}
}
