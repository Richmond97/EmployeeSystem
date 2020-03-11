using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class ManageForm : Form
    {

        private ManageForm()
        {
            InitializeComponent();
            ArrangePanels();
            BtnCreate_Click();            
        }

        private static readonly object locker = new object();
        private static ManageForm instance = null;
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
            pnlHolidayBkd.Location = new Point(0, 37);

            createPanel.Size = new Size(851, 443);
            editPanel.Size = new Size(851, 443);
            pnlHolidayBkd.Size = new Size(851, 443);

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
            pnlHolidayBkd.Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            editPanel.Visible = true;
            btnCreate.BackColor = Color.White;
            btnEdit.BackColor = Color.DarkGray;
            btnDelete.BackColor = Color.White;
            btnHolidays.BackColor = Color.White;

            createPanel.Visible = false;
            pnlHolidayBkd.Visible = false;
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
            pnlHolidayBkd.Visible = false;
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
            rdbOutstanding.Checked = true;
            pnlHolidayBkd.Visible = true;
            btnHolidays.BackColor = Color.Gray;
            btnCreate.BackColor = Color.White;
            btnEdit.BackColor = Color.White;
            btnDelete.BackColor = Color.White;

            createPanel.Visible = false;
            editPanel.Visible = false;
            btnAccept.Hide();
            btnReject.Hide();

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
            editEmployee1.SearchEmployee(dataGridView1, txtSearch,rdName);
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
                RefreshGrid();
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
            RefreshGrid();
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
                    PopulateTxtBox(dataGridView1, e, txtEFirst, txtELast, txtETele, txtEEmail, txtEStreet, txtECity, txtECounty, txtEPost,cbxEDept, cbxERole, txtEPassword, txtEDateJoined);
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

        public void RefreshGrid()
        {
            dataGridView1.Update();
            dataGridView1.Refresh();
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

        private void BtnHolidaySrch_Click(object sender, EventArgs e)
        {
            if(rdbOutstanding.Checked)
            {
               btnAccept.Show();
               btnReject.Show();
            }
            else
            {
                btnAccept.Hide();
                btnReject.Hide();
            }

        }

        public void ArrangeHolidaysPanel()
        {
            pnlHolidayBkd.Hide();
            pnlHolidayReq.Hide();
            pnlHolidayOnDuty.Hide();
            
               
           
        }

     
    }
}
