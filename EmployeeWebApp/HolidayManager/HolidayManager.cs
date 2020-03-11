using Component_A_ClassLibrary;
using EmployeeWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Windows.Forms;


namespace EmployeeWebApp.HolidayManager
{
    //• View a list of outstanding holiday requests
    //• Accept/reject a request
    //• View a list of all holiday bookings and filter them by employee
    //• Select a date and show all employees working that day and those
    //on leave that day.

    class HolidaysManager
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();

        //• View a list of outstanding holiday requests
        public bool Verification(int StaffID, string Password)
        {
            try
            {
                // Query to find matching staffid and password in DB

                var verQuery = from a in db.employees
                               where a.StaffID == StaffID && a.Password == Password
                               select a;


                var quer = verQuery.ToList();

                //create session for log in


                if (verQuery.Any())
                {

                    // If user entered details correctly call auth method
                    
                    // MessageBox.Show("User Exists in DB");
                    return true;
                }
                else
                {
                    // Check the Staffid exists
                    var userQuery = from b in db.employees
                                    where b.StaffID == StaffID
                                    select b;

                    if (userQuery.Any())
                    {
                        Console.WriteLine("User Exists in DB, Wrong Password");
                        // MessageBox.Show("Password Incorrect");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("User Does Not Exist in DB");
                        MessageBox.Show("User Does Not Exist, Please contact Admin");
                        return false;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        public long GetStaffID(long StaffID)
        {
            var verQuery = (from a in db.employees
                            where a.StaffID == StaffID
                            select a.EmployeeID);
            var quer = verQuery.ToList();
            long staffID = quer[0];
            return staffID;

        }

        public long GetID(long StaffID)
        {
            var verQuery = (from a in db.employees
                            where a.StaffID == StaffID
                            select a.EmployeeID);
            var quer = verQuery.ToList();
            long ID = quer[0];
            return ID;

        }

        public void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == null
                          select a);
        }
        public void ConfirmedReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        public void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }
        public void ViewHolidayReqStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        public bool SubmitHolidayReq(DateTime startH, DateTime endH, long ID)
        {
            try
            {
               
                holidaysrequested newHlday = new holidaysrequested
                {
                    EmployeeID = ID,
                    StartDate = Convert.ToDateTime(startH.ToShortDateString()),
                    EndDate = Convert.ToDateTime(endH.ToShortDateString()),
                    Status = "Pending"
                    

                };

                db.holidaysrequesteds.InsertOnSubmit(newHlday);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
                throw;

            }
        }
    }
}

