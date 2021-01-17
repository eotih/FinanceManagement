using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceManagement1._0.TienIch
{
    public partial class TienIch : UserControl
    {
        public TienIch()
        {
            InitializeComponent();
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            Exchange frm = new Exchange();
            frm.Show();
        }
    }
}
