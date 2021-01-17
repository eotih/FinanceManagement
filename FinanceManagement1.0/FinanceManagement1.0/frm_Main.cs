using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FinanceManagement1._0
{
    public partial class picProfile : Form
    {
        //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        //private static extern IntPtr CreateRoundRectRgn
        //  (
        //      int nLeftRect,     // x-coordinate of upper-left corner
        //      int nTopRect,      // y-coordinate of upper-left corner
        //      int nRightRect,    // x-coordinate of lower-right corner
        //      int nBottomRect,   // y-coordinate of lower-right corner
        //      int nWidthEllipse, // height of ellipse
        //      int nHeightEllipse // width of ellipse
        //    );
        public picProfile()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            customizeDesing();
            SlidePanel.Height = btnHome.Height;
            SlidePanel.Top = btnHome.Top;
            homeMenu1.BringToFront();
            groupbox2.BringToFront();
        }
       
        private void customizeDesing()
        {
            panelToolSubMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelToolSubMenu.Visible == true)
                panelToolSubMenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnHome.Height;
            SlidePanel.Top = btnHome.Top;
            homeMenu1.BringToFront();
            groupbox2.BringToFront();

        }

        
        private void btnAcc_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnAcc.Height;
            SlidePanel.Top = btnAcc.Top;
            account1.BringToFront();
            //frm_Account frm = new frm_Account();
            //frm.Show();
            
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnLimit.Height;
            SlidePanel.Top = btnLimit.Top;
            hanMucChi1.BringToFront();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnReport.Height;
            SlidePanel.Top = btnReport.Top;
            rpTotal1.BringToFront();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            SlidePanel.Height = btnTool.Height;
            SlidePanel.Top = btnTool.Top;
            TienIch.Exchange a = new TienIch.Exchange();
            a.Show();
            //showSubMenu(panelToolSubMenu);
        }
        

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/Admin.Tuhal");
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
    }
}
