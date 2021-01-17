using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement1._0.TienIch
{
    public partial class Exchange : Form
    {
        public Exchange()
        {
            InitializeComponent();
        }
        private double DoiTien(double input)
        {
            double USD = 23280;
            double EUR = 28006;
            double JPY = 223;
            double KRW = 21;
            double SGD = 17327;
            double AUD = 16890;
            double CAN = 17928;
            double giaVND = 0;
            switch (cmbSelect.SelectedItem)
            {
                case "USD": giaVND = input / USD; break;
                case "EUR": giaVND = input / EUR; break;
                case "JPY": giaVND = input / JPY; break;
                case "KRW": giaVND = input / KRW; break;
                case "SGD": giaVND = input / SGD; break;
                case "AUD": giaVND = input / AUD; break;
                case "CAN": giaVND = input / CAN; break;
                default: return giaVND;
            }
            return giaVND;
        }

        private void btn_exChange_Click(object sender, EventArgs e)
        {
            txtResult.Text = DoiTien(double.Parse(txtInput.Text.ToString())).ToString();
        }
    }
}
