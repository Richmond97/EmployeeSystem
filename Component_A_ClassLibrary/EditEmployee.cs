using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace Component_A_ClassLibrary
{
    public partial class EditEmployee : Component 
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        

        public EditEmployee()
        {
            InitializeComponent();            
        }

        public EditEmployee(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void SearchEmployee(DataGridView table, TextBox searchQ, RadioButton searchName)
        {
            try
            {
                // Search based on whether the name radio button has been selected  
                if (searchName.Checked)
                {
                    var varQueryName = (from a in db.employees
                                        where String.IsNullOrWhiteSpace(searchQ.Text) && a.FirstName != "admin"
                                        || a.FirstName.Contains(searchQ.Text.Trim()) && a.FirstName != "admin"
                                        join c in db.roles on a.EmployeeID equals c.EmployeeID
                                        select new
                                        {
                                            a.StaffID,
                                            a.FirstName,
                                            a.LastName,
                                            Department = c.department.DeptName,
                                            Role = c.RoleType,
                                            a.DateJoined,
                                            a.Password,
                                            a.Address,
                                            a.EmailAddress,
                                            a.Telephone
                                        }).ToList();

                    table.DataSource = varQueryName;
                }
                else
                {
                    var varQueryID = (from a in db.employees
                                      where String.IsNullOrWhiteSpace(searchQ.Text) && a.StaffID != 111111
                                      || a.StaffID.ToString().Contains(searchQ.Text.Trim()) && a.StaffID != 111111
                                      join c in db.roles on a.EmployeeID equals c.EmployeeID
                                      select new
                                      {
                                          a.StaffID,
                                          a.FirstName,
                                          a.LastName,
                                          Department = c.department.DeptName,
                                          Role = c.RoleType,
                                          a.DateJoined,
                                          a.Password,
                                          a.Address,
                                          a.EmailAddress,
                                          a.Telephone
                                      }).ToList();

                    table.DataSource = varQueryID;
                }
                // Remove unneeded columns
                table.Columns["Password"].Visible = false;
                table.Columns["Address"].Visible = false;
                table.Columns["EmailAddress"].Visible = false;
                table.Columns["Telephone"].Visible = false;
                table.Columns["Department"].Visible = false;
                table.Columns["Role"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }


        public void EditDetails(DataGridView table, TextBox firstNa, TextBox lastNa,
                                TextBox telnumber, TextBox email, TextBox password, TextBox street, 
                                TextBox city, TextBox county, TextBox postcode,
                                ComboBox dept, ComboBox roletext)
        {
            // Change details for a selected emolyee
            var Selected = table[0, table.SelectedRows[0].Index].Value.ToString();

            try
            {
                var result = (from a in db.employees
                               where a.StaffID == Convert.ToInt64(Selected)
                               join b in db.roles on a.EmployeeID equals b.EmployeeID
                               select b);

                Console.WriteLine(result.Single().employee.FirstName);

                //save change to the database
                if (MessageBox.Show("Save changes", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (var field in result)
                    {
                        field.RoleType = roletext.Text;

                        field.department.DeptName = dept.Text;

                        field.employee.FirstName = firstNa.Text;
                        field.employee.LastName = lastNa.Text;
                        field.employee.Telephone = telnumber.Text;
                        field.employee.EmailAddress = email.Text;
                        field.employee.Address = (street.Text + "-" + city.Text + "-" + county.Text + "-" + postcode.Text);
                        field.employee.Password = password.Text;
                    }
                                       
                    db.SubmitChanges();

                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
                                  
        }


    }
}
