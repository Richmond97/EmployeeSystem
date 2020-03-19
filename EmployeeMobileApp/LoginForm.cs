using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeMobileApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            arrangelPanels();
        }
        HolidayReference.BookinFunctionalitySoapClient soap = new HolidayReference.BookinFunctionalitySoapClient();
        long staffID = 0;

        //Arange buttons 

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Fields can not be empty");
            }
            else if (soap.VerificationLogin(Int32.Parse(txtID.Text), txtPassword.Text))
            {
                pnlLogin.Hide();
                pnlHolidayReq.Show();
                staffID = (long)Int32.Parse(txtID.Text);
                showButtons();
            }
        }

        //Arange buttons and Panels
        public void arrangelPanels()
        {
            pnlHolidayReq.Size = new Size(348, 616);
            pnlLogin.Size = new Size(348, 616);
            pnlView.Size = new Size(348, 616);


            pnlHolidayReq.Location = new Point(0, 0);
            pnlLogin.Location = new Point(0, 0);
            pnlView.Location = new Point(0, 0);

            btnHome.Hide();
            btnLogout.Hide();
            btnView.Hide();

            monthCalendar1.Visible = false;
            monthCalendar2.Visible = false;

            //setting DataGridView for Holidays requested
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Request ID";
            dataGridView1.Columns[1].Name = "Start Date";
            dataGridView1.Columns[2].Name = "End Date";
            dataGridView1.Columns[3].Name = "Status";
        }

        private void showButtons()
        {
            btnHome.Show();
            btnView.Show();
            btnLogout.Show();
        }
        private void hideButtons()
        {
            btnHome.Hide();
            btnView.Hide();
            btnLogout.Hide();
        }

        private void BtnLogout_Click_1(object sender, EventArgs e)
        {
            pnlHolidayReq.Hide();
            pnlView.Hide();
            pnlLogin.Show();
            hideButtons();
            

        }

        private void BtnHome_Click_1(object sender, EventArgs e)
        {
            pnlHolidayReq.Show();
            pnlView.Hide();
            pnlLogin.Hide();
            dataGridView1.DataSource = soap.ViewHolidayReqStatus(staffID);
        }

        private void BtnView_Click_1(object sender, EventArgs e)
        {
            pnlHolidayReq.Hide();
            pnlLogin.Hide();

            List<string> holis = soap.ViewHolidayReqStatus(staffID);
            try
            {
               
                foreach (var item in holis)
                {
                    string[] indivudal = item.Split('*');
                    dataGridView1.Rows.Add(indivudal);
                }
                //dataGridView1.DataSource = soap.ViewHolidayReqStatus(staffID);
                dataGridView1.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
            {
                monthCalendar1.Visible = false;
            }
            monthCalendar1.Visible = true;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (monthCalendar2.Visible)
            {
                monthCalendar2.Visible = false;
            }
            monthCalendar2.Visible = true;

        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            txtStart.Text = monthCalendar1.SelectionRange.Start.ToString("d");
        }

        private void MonthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.Visible = false;
            txtEnd.Text = monthCalendar2.SelectionRange.Start.ToString("d");

        }

        private void BtnReqHoli_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("from " + monthCalendar1.SelectionRange.Start.ToString("d") + "To" + monthCalendar1.SelectionRange.Start.ToString("d"));
                if(soap.SubmitHolidayReq(monthCalendar1.SelectionRange.Start, monthCalendar2.SelectionRange.Start, staffID))
                {
                    MessageBox.Show("Holiday Booking Completed sucesfully");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

          
