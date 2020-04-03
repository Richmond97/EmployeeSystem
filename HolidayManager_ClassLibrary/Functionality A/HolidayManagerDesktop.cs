﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        {//In Order to add versatility, the variable type is added
         //When type == Priority, is used for the sorted datagrid of request
         //Otherwise is used to fill --> validRequest Datagrid and nonValid request datagrid


         //Get all outstanding requests
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
            {   //two List  valid and none valid holiday request 
                List<holidaysrequested> validReq = new List<holidaysrequested>();
                List<holidaysrequested> notValidReq = new List<holidaysrequested>();

                foreach (var holiday in result)
                {
                    if (cc.validHolidayReqManagerHead(holiday.RequestID, holiday.EmployeeID) && (cc.enoughStaff(holiday.EmployeeID ,holiday.RequestID) == 0))
                    {
                        validReq.Add(holiday);
                    }
                    else
                    {
                        notValidReq.Add(holiday);
                    }
                }

                validDG.DataSource = validReq;
                validDG.DefaultCellStyle.BackColor = Color.GreenYellow;
                validDG.Columns["employee"].Visible = false;
                validDG.Columns["Status"].Visible = false;

                inValidDG.DataSource = notValidReq;
                inValidDG.DefaultCellStyle.BackColor = Color.PeachPuff;
                inValidDG.Columns["employee"].Visible = false;
                inValidDG.Columns["Status"].Visible = false;
            }
        }
        public void TypeConstrainBroken(long reqID)
        {
            string message = "";
            var result = (from a in db.holidaysrequesteds
                          where a.Status == "Pending" && reqID == a.RequestID
                          select a
                          ).Single();

            if (cc.enoughStaff(result.EmployeeID, result.RequestID) == 1)
            {
                message = " Constraint broken [ %40 of staff requireed for department ] ";
                if (cc.validHolidayReqManagerHead(result.RequestID, result.EmployeeID) == false)
                {
                    message += "  And  Constraint broken [ Either Head, Head Deputy or Manager,  Senior member must be on duty ]";
                }
                MessageBox.Show(message);
            }
            else if (cc.enoughStaff(result.EmployeeID, result.RequestID) == 2)
            {
                message = " Constraint broken [ %60 of statt requireed for department ] ";
                if (cc.validHolidayReqManagerHead(result.RequestID, result.EmployeeID) == false)
                {
                    message += "  And Constraint broken [ Either Head Deputy or Manager or Senior member must be on duty ] ";
                }
                MessageBox.Show(message);
            }
            else if (cc.validHolidayReqManagerHead(result.RequestID, result.EmployeeID) == false)
            {
                message = "Constraint broken [ Either Head, Head Deputy or Manager,  Senior member must be on duty ]";
                if (cc.enoughStaff(result.EmployeeID, result.RequestID) == 1)
                {
                    message += "  Constraint broken [ %40 of staff requireed for department ] ";
                }
                else if (cc.enoughStaff(result.EmployeeID, result.RequestID) == 2)
                {
                    message += "  Constraint broken [ %40 of staff requireed for department ] ";
                }

                MessageBox.Show(message);
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
                    MessageBox.Show("No Employee will be on Leave on selcted date");
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
                    MessageBox.Show("No Employee will be on live on selected date");
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

        public constraint getConstraints()
        {
            var Qconstraint = (from a in db.constraints
                              select a).Single();
            return Qconstraint;
        }
        public peaktime getXmasPeakT()
        {
            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimeXmas"
                         select a).Single();
            return xmasQ;
        }
        public peaktime getSummerPeakT()
        {
            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimeSummer"
                         select a).Single();
            return xmasQ;
        }
        public void SettingsChanges(DateTime dtpStartXmas, DateTime dtpEndXmas, DateTime dtpStartSummer, DateTime dtpSummerEnd, ComboBox cmbBXRoles, ComboBox cmbBXDepartment, NumericUpDown numDaysEnt, NumericUpDown numRelaxed, NumericUpDown numStaffReq,ComboBox cmbxMonths)
        {
            peaktime Xpeak = getXmasPeakT();
            peaktime Speak = getSummerPeakT();
            constraint constraints = getConstraints();

            if (MessageBox.Show("Save changes", "Please Confirm Your Action", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Xpeak.StartDate = dtpStartXmas;
                Xpeak.EndDate = dtpEndXmas;
                Speak.StartDate = dtpStartSummer;
                Speak.EndDate = dtpSummerEnd;
                constraints.AvailableRoles = cmbBXRoles.ToString();
                constraints.AvailableDepartments = cmbBXDepartment.ToString();
                constraints.HolidayEntitlement = (int)numDaysEnt.Value;
                constraints.MinimumWorkingStaffRelaxed = (int)numRelaxed.Value;
                constraints.MinimumWorkingStaff = (int)numStaffReq.Value;
                constraints.RelaxedMonth = cmbxMonths.SelectedIndex;

                db.SubmitChanges();

            }
        }
      
    }
}
