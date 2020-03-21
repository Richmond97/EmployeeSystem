using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HolidayManager_ClassLibrary;

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
        HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent pt = new HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent();
        ConstrainsComponent cc = new ConstrainsComponent();
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

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            pnlHolidayReq.Hide();
            pnlView.Hide();
            pnlLogin.Show();
            hideButtons();
            

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            pnlHolidayReq.Show();
            pnlView.Hide();
            pnlLogin.Hide();
            //dataGridView1.DataSource = soap.ViewHolidayReqStatus(staffID);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            pnlView.Show();
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
                dataGridView1.RowHeadersVisible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
            DateTime start = monthCalendar1.SelectionRange.Start;
            DateTime end = monthCalendar2.SelectionRange.Start;
            try
            {
                int peakValue = pt.IsPeakTime(start, end);
                MessageBox.Show("holidays from: " + start.ToString("d") + "\n" + "To: " + end,"HOLIDAY REQUEST");
                if (end < start || start < DateTime.Today || end < DateTime.Today)
                {
                  MessageBox.Show( "The end date of your Holiday can not be before the start date, or before today");
                }
                else if (peakValue != 0)
                {
                    if (cc.IsValidHolidayRequest(start, end, staffID))
                    {
                        List<DateTime> newdates = new List<DateTime>();
                        if (peakValue == 1)
                        {
                            newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.StarPeak);
                        }
                        else if (peakValue == 2)
                        {
                            newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.StarPeak);
                        }
                        else if (peakValue == 3)
                        {
                            newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.StarPeak);
                        }
                        if (MessageBox.Show("Accept suggestion", "Your request happends to be on " + pt.Holiday + " holiday we suggest " + newdates[0].ToString("d") + "  To  " + newdates[1].ToString("d"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (soap.SubmitHolidayReq(newdates[0], newdates[1], staffID))
                            {
                                MessageBox.Show("Booking from: " + newdates[0].ToString("d") + "\n" + "To: " + end.ToString("d"), "New Suggestion");
                            }
                            else
                            {
                                MessageBox.Show("We couldn't completer yor request this time, please try later");
                            }
                        }
                        else
                        {
                            if (soap.SubmitHolidayReq(start, end, staffID))
                            {
                                MessageBox.Show("Booking from: " + start.ToString("d") + "\n" + "To: " + end.ToString("d"), "New Suggestion");
                            }
                            else
                            {
                                MessageBox.Show("We couldn't completer yor request this time, please try later");
                            }
                        }
                    }
                    
                }
                else
                {
                    if (soap.SubmitHolidayReq(start, end, staffID))
                    {
                        MessageBox.Show("Booking from: " + start.ToString("d") + "\n" + "To: " + end.ToString("d"), "BOOKING");
                    }
                    else
                    {
                        MessageBox.Show("We couldn't completer yor request this time, please try later");
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("WE are facinf some issues try again later" + ex.HelpLink);
            }
        }

        private void btnDateStart_Click(object sender, EventArgs e)
        {
            if (monthCalendar1.Visible)
            {
                monthCalendar1.Visible = false;
            }
            monthCalendar1.Visible = true;
        }

        private void BtnDateEnd_Click(object sender, EventArgs e)
        {
            if (monthCalendar2.Visible)
            {
                monthCalendar2.Visible = false;
            }
            monthCalendar2.Visible = true;
        }

        private void BtnPerDetails_Click(object sender, EventArgs e)
        {
            string text = soap.GetEmployee(staffID);
            text = text.Replace("*", "" + System.Environment.NewLine);
            MessageBox.Show(text,"MY DETAILS");
        }
    }
}

          
