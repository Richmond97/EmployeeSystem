using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HolidayManager_ClassLibrary
{
    //• View a list of outstanding holiday requests done
    //• Accept/reject a request done
    //• View a list of all holiday bookings and filter them by employee
    //• Select a date and show all employees working that day and those
    //on leave that day.

  public  class HolidaysManager
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        List<object> OffDutyResult;

        //• View a list of outstanding holiday requests
        public void OutstandingReq(DataGridView table)
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Pending"
                          select new
                          {
                              a.RequestID,
                              a.employee.FirstName,
                              a.employee.LastName,
                              a.StartDate,
                              a.EndDate
                          }).ToList();
            table.DataSource = result;
        }
        public void ConfirmedReq(DataGridView table)
        {

            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Approved"
                          select new
                          {
                              a.employee.StaffID,
                              a.employee.FirstName,
                              a.employee.LastName,
                              a.StartDate,
                              a.EndDate
                          }).ToList();
            table.DataSource = result;
        }

        public void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        public void accept_OR_rejectReq(long holidayReqID, string decision)
        {
            var result = (from a in db.holidaysrequesteds
                          //where a.Status != null && a.EmployeeID == EmployID
                          where a.Status != null || a.Status == "Pending" && a.RequestID == holidayReqID
                          select a).ToList();
            foreach (var s in result)
            {
                s.Status = decision;
            }
            db.SubmitChanges();

        }

        
        public void EmployeeOnDuty(DateTime selectedDate, DataGridView table)
        {
                var OnDutyResult = (from a in db.holidaysrequesteds
                                    join b in db.employees on a.EmployeeID equals b.EmployeeID
                                    where (((a.Status != "Approved") || (a.StartDate > selectedDate) || (a.EndDate < selectedDate)) || (!b.EmployeeID.Equals(a.EmployeeID)))
                                    //where ((selectedDate.Date >= a.StartDate &&  selectedDate.Date <= a.EndDate)  && a.Status == "Pending") //|| db.holidaysrequesteds.Any(t => t.Status == list.EntityID)


                                    //join b in db.employees on a.EmployeeID equals b.EmployeeID
                                    select new 
                                    {
                                        b.StaffID,
                                        b.FirstName,
                                        b.LastName
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
        public void EmployeeOffDuty(DateTime selectedDate, DataGridView table )
        {
            var OffDutyResult = (from a in db.employees
                                join b in db.holidaysrequesteds on a.EmployeeID equals b.EmployeeID
                                where selectedDate.Date >= b.StartDate && selectedDate.Date <= b.EndDate && (b.Status == "Approved")
                                select new
                                {
                                    a.StaffID,
                                    a.FirstName,
                                    a.LastName
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

        // Test Method
        public void TESTONDUTY(DateTime selectedDate, DataGridView table, string choice)
        {

            var OnDutyResult = (from a in db.employees
                                join b in db.holidaysrequesteds on a.EmployeeID equals b.EmployeeID
                                where selectedDate.Date >= b.StartDate && selectedDate.Date <= b.EndDate && b.Status == choice
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

            //if (OnDutyResult.Any())
            //{
            //    table.DataSource = OnDutyResult;
            //    table.Refresh();
            //    MessageBox.Show("Employee working on selcted date found");
            //}
            //else
            //{
            //    table.DataSource = "";
            //    MessageBox.Show("Employee working on selcted date NOT found");
            //}

        }

        public void SearchEmployee(DataGridView table, TextBox searchQ, RadioButton searchName)
        {
            try
            {
                // Search based on whether the name radio button has been selected  
                if (searchName.Checked)
                {
                    var varQueryName = (from a in db.holidaysrequesteds
                                        where (String.IsNullOrWhiteSpace(searchQ.Text) && a.employee.FirstName != "admin")
                                        || (a.employee.FirstName.Contains(searchQ.Text.Trim())&& (a.employee.FirstName != "admin")) 
                                        &&( a.Status == "Approved")
                                        select new
                                        {
                                            a.employee.StaffID,
                                            a.employee.FirstName,
                                            a.employee.LastName,
                                            a.StartDate,
                                            a.EndDate
                                        }).ToList();
                    
                    table.DataSource = varQueryName;
                }
                else
                {
                    var varQueryID = (from a in db.holidaysrequesteds
                                      where String.IsNullOrWhiteSpace(searchQ.Text) && a.employee.StaffID != 111111
                                      || a.employee.StaffID.ToString().Contains(searchQ.Text.Trim()) && a.employee.StaffID != 111111
                                       && (a.Status == "Approved")
                                      select new
                                      {
                                          a.employee.StaffID,
                                          a.employee.FirstName,
                                          a.employee.LastName,
                                          a.StartDate,
                                          a.EndDate
                                      }).ToList();

                    table.DataSource = varQueryID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
            
            
     
    
