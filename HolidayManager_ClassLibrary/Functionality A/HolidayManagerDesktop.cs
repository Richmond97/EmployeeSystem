using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Component_A_ClassLibrary;

namespace HolidayManager_ClassLibrary.Functionality_A
{
    public class HolidayManagerDesktop
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        ConstrainsComponent cc = new ConstrainsComponent();

        public void OutstandingReq(DataGridView validDG, DataGridView inValidDG, string type)
        {

            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Pending"
                          select a
                          ).ToList();
            if(type == "Priority")
            {
                validDG.DataSource = result;
                validDG.Columns["employee"].Visible = false;
                validDG.Columns["Status"].Visible = false;


            }
            else
            {
                List<holidaysrequested> validReq = new List<holidaysrequested>();
                List<holidaysrequested> notValidReq = new List<holidaysrequested>();

                foreach (var holiday in result)
                {
                    if (cc.validHolidayReqManagerHead(holiday.RequestID, holiday.EmployeeID))
                    {
                        validReq.Add(holiday);
                    }
                    else
                    {
                        notValidReq.Add(holiday);
                    }
                }

                validDG.DataSource = validReq;
                inValidDG.DataSource = notValidReq;
                validDG.Columns["employee"].Visible = false;
                validDG.Columns["Status"].Visible = false;
                inValidDG.Columns["employee"].Visible = false;
                inValidDG.Columns["Status"].Visible = false;
            }

            
        }
        public void ConfirmedReq(DataGridView table)
        {

            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Approved"
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
        public void accept_OR_rejectReq(long holidayReqID, string decision)
        {
            if (MessageBox.Show("Finalise Action", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var result = (from a in db.holidaysrequesteds
                                  where ((a.Status == "Pending") && (a.RequestID == holidayReqID))
                                  select a).ToList();

                    foreach (var s in result)
                    {
                        s.Status = decision;
                    }
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }


        }
        public void EmployeeOffOnDuty(DateTime selectedDate, DataGridView table, RadioButton off)
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

            var allEmployees = (from a in db.employees
                                where a.FirstName != "admin" && a.LastName != "admin"
                                select new
                                {
                                    a.StaffID,
                                    a.FirstName,
                                    a.LastName
                                }).ToList();

            foreach (var item in OffDutyResult)
            {
                if (!allEmployees.Contains(item))
                {
                    continue;
                }
                allEmployees.Remove(item);
            }
            if (off.Checked)
            {
                if (OffDutyResult.Any())
                {
                    table.DataSource = OffDutyResult.Distinct().ToList(); ;
                    table.Refresh();
                }
                else
                {
                    table.DataSource = "";
                    MessageBox.Show("Employee not working on selcted date NOT found");
                }
            }
            else
            {
                if (allEmployees.Any())
                {
                    table.DataSource = allEmployees.Distinct().ToList(); ;
                    table.Refresh();
                }
                else
                {
                    table.DataSource = "";
                    MessageBox.Show("Employee not working on selcted date NOT found");
                }
            }


        }
        public void SearchEmployee(DataGridView table, TextBox searchQ, RadioButton searchName)
        {
            try
            {
                // Search based on whether the name radio button has been selected  
                if (searchName.Checked)
                {
                    var varQueryName = (from a in db.holidaysrequesteds
                                        join c in db.employees on a.EmployeeID equals c.EmployeeID
                                        where (String.IsNullOrWhiteSpace(searchQ.Text) && c.FirstName != "admin") && (a.Status == "Approved")
                                        || (c.FirstName.Contains(searchQ.Text.Trim()) && (c.FirstName != "admin"))
                                        && (a.Status == "Approved")
                                        select new
                                        {
                                            a.RequestID,
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
                                      join c in db.employees on a.EmployeeID equals c.EmployeeID
                                      where (String.IsNullOrWhiteSpace(searchQ.Text) && (c.StaffID != 111111) && (a.Status == "Approved"))
                                      || ((c.StaffID.ToString().Contains(searchQ.Text.Trim())) && (c.StaffID != 111111)
                                       && (a.Status == "Approved"))
                                      select new
                                      {
                                          a.RequestID,
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
        public void RefreshGrid(DataGridView table)
        {
            table.DataSource = null;
            table.Update();
            table.Refresh();
        }
        public holidaysrequested HighlightBooked( long requestID)
        {
            var holiday = (from a in db.holidaysrequesteds
                           where  a.RequestID == requestID
                           select a).Single();
            return holiday;
        }

    }
}
