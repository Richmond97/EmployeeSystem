﻿using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HolidayManager_ClassLibrary;

namespace LoginForm
{
    public partial class ManageForm : Form
    {

        private ManageForm()
        {
            InitializeComponent();
            ArrangePanels();
            ArrangeHolidaysPanel();
            BtnCreate_Click();
        }

        private static readonly object locker = new object();
        private static ManageForm instance = null;
        HolidaysManager hm = new HolidaysManager();


        public static ManageForm Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new ManageForm();
                    }
                    return instance;
                }
            }
        }


        #region Panel and toolbar button settings
        private void ArrangePanels()
        {
            createPanel.Location = new Point(0, 37);
            editPanel.Location = new Point(0, 37);
            mainPnlHM.Location = new Point(0, 37);

            createPanel.Size = new Size(1603, 939);
            editPanel.Size = new Size(1603, 939);
            mainPnlHM.Size = new Size(1603, 939);

            //Holiday Manager panels
            pnlHolidayBkd.Location = new Point(240, 110);
            pnlHolidayOnDuty.Location = new Point(240, 110);
            pnlHolidayReq.Location = new Point(240, 110);

            pnlHolidayBkd.Size = new Size(1232, 671);
            pnlHolidayOnDuty.Size = new Size(1232, 671);
            pnlHolidayReq.Size = new Size(1232, 671);




            // Set search to by name
            rdName.Checked = true;

            // Make combobox hold values of relevant enums
            cbxDept.DataSource = Enum.GetValues(typeof(DepartmentType));
            cbxEDept.DataSource = Enum.GetValues(typeof(DepartmentType));

            cbxRole.DataSource = Enum.GetValues(typeof(Roletype));
            cbxERole.DataSource = Enum.GetValues(typeof(Roletype));

            // Only allow delete/edit when an emply has been selected
            SwitchButtons();
            SetEditableFields(editPanel);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            BtnCreate_Click();
        }

        private void BtnCreate_Click()
        {

            createPanel.Visible = true;
            btnCreate.BackColor = Color.DarkGray;
            btnEdit.BackColor = Color.White;
            btnDelete.BackColor = Color.White;
            btnHolidays.BackColor = Color.White;

            editPanel.Visible = false;
            mainPnlHM.Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
            btnCreate.BackColor = Color.White;
            btnEdit.BackColor = Color.DarkGray;
            btnDelete.BackColor = Color.White;
            btnHolidays.BackColor = Color.White;

            createPanel.Visible = false;
            mainPnlHM.Visible = false;
            btnEditEmploy.Show();
            btnDeleteEmploy.Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
            btnCreate.BackColor = Color.White;
            btnEdit.BackColor = Color.White;
            btnDelete.BackColor = Color.DarkGray;
            btnHolidays.BackColor = Color.White;

            createPanel.Visible = false;
            mainPnlHM.Visible = false;
            btnEditEmploy.Hide();
            btnDeleteEmploy.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Log Out", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        private void BtnHolidays_Click(object sender, EventArgs e)
        {
            mainPnlHM.Visible = true;
            btnHolidays.BackColor = Color.Gray;
            btnCreate.BackColor = Color.White;
            btnEdit.BackColor = Color.White;
            btnDelete.BackColor = Color.White;

            createPanel.Visible = false;
            editPanel.Visible = false;
            btnAccept.Show();
            btnReject.Show();

        }
        #endregion



        #region Action Button Functions

        private void BtnCreateEmploy_Click(object sender, EventArgs e)
        {
            if (!FieldsEntered(createPanel))
            {
                MessageBox.Show("Please Enter All Fields");
            }
            else if (!createEmployee1.ValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid Email");
            }
            else
            {
                // Add to DB
                createEmployee1.AddToDB(txtName, txtSurname, txtNumber, txtEmail, txtStreet, txtCity, txtCounty, txtPostcode, cbxDept, cbxRole);

                // Clear fields to enter another employee
                ClearFields(createPanel);

            }

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            editEmployee1.SearchEmployee(dataGridView1, txtSearch, rdName);
        }

        private void BtnDeleteEmploy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string targetID = dataGridView1[0, dataGridView1.SelectedRows[0].Index].Value.ToString();
                //deleteEmployee1.DeleteStaff(dataGridView1);
                deleteEmployee1.DeleteStaff(targetID);
                dataGridView1.CurrentRow.Selected = false;


                ClearFields(editPanel);
                BtnSearch_Click(sender, e);
                hm.RefreshGrid(dataGridView1);
                SwitchButtons();
                SetEditableFields(editPanel);

            }


        }

        private void BtnEditEmploy_Click(object sender, EventArgs e)
        {
            editEmployee1.EditDetails(dataGridView1, txtEFirst, txtELast, txtETele, txtEEmail, txtEPassword, txtEStreet, txtECity, txtECounty, txtEPost, cbxEDept, cbxERole);
            dataGridView1.CurrentRow.Selected = false;

            ClearFields(editPanel);
            BtnSearch_Click(sender, e);
            hm.RefreshGrid(dataGridView1);
            SwitchButtons();
            SetEditableFields(editPanel);
        }


        #endregion



        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ignore header row and any column
                if (e.RowIndex == -1)
                {
                    return;
                }
                else if (dataGridView1.CurrentCell.Value != null)
                {
                    SetEditableFields(editPanel);
                    PopulateTxtBox(dataGridView1, e, txtEFirst, txtELast, txtETele, txtEEmail, txtEStreet, txtECity, txtECounty, txtEPost, cbxEDept, cbxERole, txtEPassword, txtEDateJoined);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                throw new ArgumentOutOfRangeException("Index parameter is out of range.", ex);
            }
        }

        public void PopulateTxtBox(DataGridView table, DataGridViewCellEventArgs e, TextBox firstNa, TextBox lastNa,
                                    TextBox telnumber, TextBox email, TextBox street, TextBox city, TextBox county,
                                    TextBox postcode, ComboBox dept, ComboBox role, TextBox password, TextBox dateJoined
                                    )
        {

            table.CurrentRow.Selected = true;


            firstNa.Text = table.Rows[e.RowIndex].Cells["FirstName"].FormattedValue.ToString();
            lastNa.Text = table.Rows[e.RowIndex].Cells["LastName"].FormattedValue.ToString();
            telnumber.Text = table.Rows[e.RowIndex].Cells["Telephone"].FormattedValue.ToString();
            email.Text = table.Rows[e.RowIndex].Cells["EmailAddress"].FormattedValue.ToString();
            street.Text = Split(table.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString(), 0);
            city.Text = Split(table.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString(), 1);
            county.Text = Split(table.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString(), 2);
            postcode.Text = Split(table.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString(), 3);

            dept.SelectedIndex = dept.FindString(table.Rows[e.RowIndex].Cells["Department"].FormattedValue.ToString());
            role.SelectedIndex = role.FindString(table.Rows[e.RowIndex].Cells["Role"].FormattedValue.ToString());

            password.Text = table.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();
            dateJoined.Text = table.Rows[e.RowIndex].Cells["DateJoined"].FormattedValue.ToString();

            btnEditEmploy.Enabled = true;
            btnEditEmploy.BackColor = Color.White;
            btnDeleteEmploy.Enabled = true;
            btnDeleteEmploy.BackColor = Color.White;
        }

        public string Split(string address, int index)
        {
            // Fomrat the address string into an array
            try
            {
                string[] words = address.Split('-');
                return words[index];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

        }

        public void ClearFields(Panel panel)
        {
            // Clear Panel fields
            foreach (Control x in panel.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = String.Empty;
                }
            }
        }

   

        public void SwitchButtons()
        {
            if (btnDeleteEmploy.Enabled == true)
            {
                btnEditEmploy.Enabled = false;
                btnEditEmploy.BackColor = Color.DarkGray;
                btnDeleteEmploy.Enabled = false;
                btnDeleteEmploy.BackColor = Color.DarkGray;
            }
            else
            {
                btnEditEmploy.Enabled = true;
                btnEditEmploy.BackColor = Color.White;
                btnDeleteEmploy.Enabled = true;
                btnDeleteEmploy.BackColor = Color.White;
            }
        }

        private void ChbxDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxDetails.Checked)
            {
                cbxEDept.Enabled = true;
                cbxEDept.ForeColor = Color.Red;
                label21.ForeColor = Color.Red;
                cbxERole.Enabled = true;
                cbxERole.ForeColor = Color.Red;
                label22.ForeColor = Color.Red;
                txtEPassword.Enabled = true;
                txtEPassword.ForeColor = Color.Red;
                label18.ForeColor = Color.Red;
            }
            else
            {
                cbxEDept.Enabled = false;
                cbxEDept.ForeColor = Color.Black;
                label21.ForeColor = Color.White;
                cbxERole.Enabled = false;
                cbxERole.ForeColor = Color.Black;
                label22.ForeColor = Color.White;
                txtEPassword.Enabled = false;
                txtEPassword.ForeColor = Color.Black;
                label18.ForeColor = Color.White;
            }
        }

        private bool FieldsEntered(Panel createPanel)
        {
            bool correctFields = true;
            foreach (Control x in createPanel.Controls)
            {
                if (x is TextBox && ((TextBox)x).Text == String.Empty)
                {
                    correctFields = false;
                }
                else
                {
                    correctFields = true;
                }
            }
            return correctFields;
        }

        private void SetEditableFields(Panel editPanel)
        {
            foreach (Control x in editPanel.Controls)
            {
                if (x is TextBox && x.Name != "txtEPassword")
                {
                    if (x.Enabled)
                    {
                        x.Enabled = false;
                    }
                    else
                    {
                        x.Enabled = true;
                    }
                }
            }

        }



        public void ArrangeHolidaysPanel()
        {
            monthCalendar.Size = new Size(380,280);
            rdbtnOnDuty.Checked = true;
            rdbtnID.Checked = true;

            hm.OutstandingReq(holidayReqGridView);
            hm.ConfirmedReq(dataGridViewBooked);


            pnlHolidayBkd.Show();
            pnlHolidayReq.Hide();
            pnlHolidayOnDuty.Hide();

            cmbxHM.Items.Add("HOLIDAYS BOOKED");
            cmbxHM.Items.Add("HOLIDAYS REQUESTS");
            cmbxHM.Items.Add("HOLIDAYS ON/OFF");
            cmbxHM.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void CmbxHM_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbxHM.SelectedIndex)
            {
                case 0:
                    pnlHolidayBkd.Show();
                    pnlHolidayReq.Hide();
                    pnlHolidayOnDuty.Hide();
                    break;
                case 1:
                    pnlHolidayBkd.Hide();
                    pnlHolidayReq.Show();
                    pnlHolidayOnDuty.Hide();
                    break;
                case 2:
                    pnlHolidayBkd.Hide();
                    pnlHolidayReq.Hide();
                    pnlHolidayOnDuty.Show();
                    break;

            }


        }


        private void BtnAccept_Click(object sender, EventArgs e)
        {
               
            try
            {
                string decision = "Approved";
                var Selected = (long)holidayReqGridView[0, holidayReqGridView.SelectedRows[0].Index].Value;
                hm.accept_OR_rejectReq(Selected, decision);
                hm.RefreshGrid(holidayReqGridView);
                hm.OutstandingReq(holidayReqGridView);
            }
            catch (Exception)
            {
                MessageBox.Show("Pleas selelct Holiday request");
            }
                

        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            try
            {
                holidayReqGridView.CurrentRow.Selected = true;
                string decision = "Declined";
                var Selected = (long)holidayReqGridView[0, holidayReqGridView.SelectedRows[0].Index].Value;
                hm.accept_OR_rejectReq(Selected,decision);
                hm.RefreshGrid(holidayReqGridView);
                hm.OutstandingReq(holidayReqGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pleas selelct Holiday request");
            }

        }

        private void HolidayReqGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                holidayReqGridView.CurrentRow.Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please elect a valid Holiday request");
            }
           
        }
        private void dataGridOnOffDuty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridOnOffDuty.CurrentRow.Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please elect a valid Holiday request");
            }

        }
        private void dataGridViewBooked_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridViewBooked.CurrentRow.Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please elect a valid table row");
            }
        }

        private void BtnSearchEmployee_Click(object sender, EventArgs e)
        {
            
            hm.SearchEmployee(dataGridViewBooked, txtEmployee, rdbtnName);
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.MaxSelectionCount = 1;
                hm.EmployeeOffOnDuty(monthCalendar.SelectionRange.Start, dataGridOnOffDuty, rdbtnOffDuty);
        }
    }
}
