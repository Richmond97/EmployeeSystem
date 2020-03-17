using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOAP;

namespace EmployeeMobileApp
{
    public partial class LoginForm : Form
    {
        WebServiceFuncionality ws = new WebServiceFuncionality();
        
        public LoginForm()
        {
            InitializeComponent();
            arrangelPanels();
        }

        //Arange buttons 

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (ws.Verification(int.Parse(txtID.Text),txtPassword.Text))
            {
                pnlLogin.Hide();
                pnlHolidayReq.Show();

            }
        }

        //Arange buttons and Panels
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            btnLogout.BackColor = System.Drawing.Color.SeaGreen;
            pnlHolidayReq.Hide();
            pnlLogin.Show();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = System.Drawing.Color.SeaGreen;
            pnlHolidayReq.Show();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            btnView.BackColor = System.Drawing.Color.SeaGreen;
            pnlHolidayReq.Hide();
                }
        public void arrangelPanels()
        {
            pnlHolidayReq.Size = new Size(348, 616);
            pnlLogin.Size = new Size(348, 616);
            pnlView.Size = new Size(348, 616);


            pnlHolidayReq.Location = new Point(0, 0);
            pnlLogin.Location = new Point(0, 0);
            pnlView.Location = new Point(0, 0);

            btnHome.Hide();
            btnReqHoli.Hide();
            btnLogout.Hide();
        }

        private void showButtons()
        {
            btnHome.Show();
            btnReqHoli.Show();
            btnLogout.Show();
        }
    }
}
