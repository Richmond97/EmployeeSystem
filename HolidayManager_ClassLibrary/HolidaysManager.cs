using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HolidayManager_ClassLibrary
{
    //• View a list of outstanding holiday requests
    //• Accept/reject a request
    //• View a list of all holiday bookings and filter them by employee
    //• Select a date and show all employees working that day and those
    //on leave that day.

  public  class HolidaysManager
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        List<object> OffDutyResult;

        //• View a list of outstanding holiday requests
        public void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Pending"
                          select a);
        }
        public void ConfirmedReq()
        {
            var result = (from a in db.holidaystakens
                          select a);
        }

        public void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        public void acceptReq(long EmployID)
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null && a.EmployeeID == EmployID
                          select a).ToList();
            foreach(var s in result)
            {
              s.Status = "Approved";
            }
        }

        public void EmployeeHolidayrejectReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }
        public void EmployeeOnDuty(DateTime selectedDate, DataGridView table)
        {
                var OnDutyResult = (from a in db.employees
                                    join b in db.holidaysrequesteds on a.EmployeeID equals b.EmployeeID
                                    where selectedDate.Date >= b.StartDate && selectedDate.Date < b.EndDate && b.Status == "Pending"


                                    //join b in db.employees on a.EmployeeID equals b.EmployeeID
                                    select new 
                                    {
                                        a.StaffID,
                                        a.FirstName,
                                        a.LastName
                                    }).ToList();
            //from c1 in existingItems
            //join c2 in newItemsLarger
            //on new { c1.CellId, c1.Content } equals new { c2.CellId, c2.Content }
            //select c1;

            if (OnDutyResult.Any())
                {
                    table.DataSource = OnDutyResult;
                    table.Refresh();
                    MessageBox.Show("Employee working on selcted date found");
                }
                else
                {
                    table.DataSource = "";
                    MessageBox.Show("Employee working on selcted date NOT found");
                }

        }
        public void EmployeeOffDuty(DateTime selectedDate, DataGridView table)
        {
            var OffDutyResult = (from a in db.holidaysrequesteds
                                 join b in  db.employees on new { a.EmployeeID } equals new { b.EmployeeID }
                                 select new
                                 {
                                     a.employee.StaffID,
                                     a.employee.FirstName,
                                     a.employee.LastName
                                 }).ToList();
 

            if (OffDutyResult.Any())
            {
                table.DataSource = OffDutyResult;
                table.Refresh();
                MessageBox.Show("Employee not working on selcted date found");
            }
            else
            {
                table.DataSource = "";
                MessageBox.Show("Employee not working on selcted date NOT found");
            }
        }
    }
}
            
            
     
    
