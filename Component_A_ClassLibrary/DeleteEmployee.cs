using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Component_A_ClassLibrary
{
    
    public partial class DeleteEmployee : Component
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();

        
        public DeleteEmployee()
        {
            InitializeComponent();
        }

        public DeleteEmployee(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public int deleteCount = 0;

        //public void DeleteStaff(DataGridView table)
        public void DeleteStaff(string targetID)
        {
           

            //if (table.SelectedRows.Count > 0)
            //{
            //string deletedID = table[0, table.SelectedRows[0].Index].Value.ToString();
            string deletedID = targetID;

                if (MessageBox.Show("Delete Employee", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Delete department entity
                try
                {
                    var varQueryDelete = (from a in db.employees
                                          where a.StaffID == Convert.ToInt64(deletedID)
                                          join b in db.roles on a.EmployeeID equals b.EmployeeID
                                          join c in db.departments on b.DepartmentID equals c.DepartmentID
                                          select c);

                    db.departments.DeleteAllOnSubmit(varQueryDelete);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

                    // Delete employee entity and cascade delete roles, requests and taken
                    try
                    {
                        var varQueryDelete = (from a in db.employees
                                              where a.StaffID == Convert.ToInt64(deletedID)
                                              select a);
                        
                        db.employees.DeleteAllOnSubmit(varQueryDelete);

                        db.SubmitChanges();

                        deleteCount++;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                }

            //}
                                                                               
        }

    }
}
