﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Component_A_ClassLibrary;

namespace HolidayManager_ClassLibrary
{
    //• Holiday entitlement
            //No employee can exceed the number of days of holiday entitlement
    //• Minimum number of staff levels with particular skills
            //• Either the head or the deputy head of the department must be on duty
            //• At least one manager and one senior staff member must be on duty
            //• At least 60% of a department must be on duty
    //• Peak time balancing
            //• 15th of July to 31st of August
            //• 15th of December to 22nd of December
            //• The week before and after Easter, which changes each year as Easter
            //falls on a different day each year


    //none of these constraints apply
    //between the 23rd of December to the 3rd January of every year.

    //  You should extend the system by including a component which applies
    //  constraint checking.
    //  When an employee submits a holiday request, the system should use the
    //  component to automatically check whether all constraints are satisfied.
    //  The list of outstanding requests shown to the admin user should be split
    //  into two, those which don’t break any of the constraints and those which
    //  do and can't be accepted.
    //  For requests which break constraints, the system should specify which
    //  constraint is being broken. There could be more than one, in which case
    //  they should all be listed.

    public partial class ConstrainsComponent : Component
    {
       

        private static readonly DataClasses1DataContext db = new DataClasses1DataContext();
        int holidaysLeft = (int)GetConstraint().HolidayEntitlement;
        int taken;
        int bonus = 0;
        string Roles = GetConstraint().AvailableRoles;
        string Departement = GetConstraint().AvailableDepartments;

        public  string Roles1 { get => Roles; set => Roles = value; }
        public string Departement1 { get => Departement; set => Departement = value; }

        public ConstrainsComponent()
        {
            InitializeComponent();

        }

        public ConstrainsComponent(IContainer container)
        {
            container.Add(this);
        }

        public static constraint GetConstraint()
        {
            var Qconstraint = (from a in db.constraints
                               select a).Single();
            return Qconstraint;
        }

        public int HolidaysLeft(long EmployeeID)
        {


            var daysEntiled = (from a in db.employees
                               where a.EmployeeID == EmployeeID
                               select a.DateJoined).Single();


            //calculate holidays bonus based on year joined 
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime today = DateTime.Now;
            DateTime dateJoined = daysEntiled.Date;
            TimeSpan span = today - dateJoined;
            int years = (zeroTime + span).Year - 1;

            var holidaysTaken = (from a in db.holidaysrequesteds
                                 where ((a.EmployeeID == EmployeeID && a.Status == "Approved") 
                                 && (a.StartDate.Year == DateTime.Today.Year))
                                 select a).ToList();
            int count=0;
            
            //for evry five years add one to bonus 
            for (int i = 0; i < years; i++)
            {
                if (count==5)
                {
                    count = 0;
                    bonus += 1;
                }
                count += 1;
            }
            foreach (var date in holidaysTaken)
            {
                taken = (date.EndDate - date.StartDate).Days;
                taken = +taken;
            }
            return  holidaysLeft = (holidaysLeft + bonus) - taken;

        }
        public bool IsValidHolidayRequest(DateTime start, DateTime end, long EmployeeID)
        {
           int daysLeft = HolidaysLeft(EmployeeID);
           int daysRequested = (end - start).Days;
            if (daysLeft - daysRequested<0)
            {
                MessageBox.Show("Sorry, not enough holidays left to procced with you request");
                return false;
            }
            return true;
        }

        public role GetRole(long StaffID)
        {
            var role = (from a in db.roles
                        where a.employee.EmployeeID == StaffID
                        select a).Single();
            return role;
        }

        public holidaysrequested GetHoliday(long holiID)
        {
            var holiday = (from a in db.holidaysrequesteds
                           where a.RequestID == holiID && a.Status == "Pending"
                           select a).Single();
            return holiday;
        }

        public bool validHolidayReqManagerHead( long requestID, long StaffID)
        {
            role person = GetRole(StaffID);
            holidaysrequested holiday = GetHoliday(requestID);
            //return if the manager request pass the constrains, false if not
            bool validReq = false;
            string myRole = "";
            string roleType = person.RoleType.ToString();
            switch (roleType)
            {
                case "Head":
                   roleType = "Head";
                    break;
                case "Head Deputy":
                    roleType = "Head Deputy";
                    break;
                case "Manager":
                    roleType = "Manager";
                    break;
                case "Senior Member":
                    roleType = "Senior Member";
                    break;
        
            }
            string departmentName = person.department.DeptName.ToString();

            var holidays = (from b in db.holidaysrequesteds
                                where ((b.Status == "Approved") && (person.RoleType == myRole) 
                                && (person.department.DeptName == departmentName) /*&& b.EndDate  DateTime.Today*/ )
                                select b).ToList();

            foreach (var h in holidays)
            {
               //Chech if the holiday request overlaps with an existing holiday
                if(holiday.StartDate < h.EndDate && h.StartDate < holiday.EndDate)
                {
                    validReq = true;

                }
                else
                {
                    
                }
                
            }
            

            return validReq;
        }

        public static DateTime EasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        public bool IsEasterHoliday(long requestID)
        {
            DateTime start = GetHoliday(requestID).StartDate;
            DateTime end = GetHoliday(requestID).EndDate;
            DateTime easter = EasterSunday(DateTime.Today.Year);
            DateTime startEaster = easter.AddDays( - 7);
            DateTime endEaster = easter.AddDays(7);

            bool validReq;


            //• 15th of July to 31st of August
            //• 15th of December to 22nd of December
            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimesXmas"
                         select a).Single();

            var summerQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimesSummer"
                         select a).Single();

            if ((startEaster > end && start < endEaster) 
                || (xmasQ.StartDate > end && start < xmasQ.EndDate) 
                || (summerQ.StartDate> end && start < summerQ.EndDate))
            {
                validReq = false;
            }
            else
            {
                validReq = true;
            }
            return validReq;

        }

        public int enoughStaff(long StaffID, long holiID)
        {
            int valid = 0;
            role person = GetRole(StaffID);
            holidaysrequested holi = GetHoliday(holiID);

            //Returns a list people that have requested a holidays of the same department in the same period of the request
            var takenKHolidays = (from b in db.holidaysrequesteds
                                  join a in db.roles
                                  on b.EmployeeID equals a.EmployeeID
                                  where (b.Status == "Approved") && a.department.DeptName == person.department.DeptName
                                  && holi.StartDate < b.EndDate && b.StartDate < holi.EndDate
                                  select b).ToList();

            var totalEmployees = (from b in db.roles
                                  where b.department.DeptName == person.department.DeptName
                                  select b).ToList().Count();

            // for each person that has requested holidays in the same department on the same period
            // if the total number of employee of the same departments that have taken holidays is greater than 40 or 60 depends
            // the holiday can not be approved 

            foreach (var h in takenKHolidays)
            {
                int percentBooked = (int)Math.Round((double)(100 * takenKHolidays.Count()/ totalEmployees));
                int minWorkingStaff = 0;
                int relaxadeMonth = (int)GetConstraint().RelaxedMonth;
                if (holi.StartDate.Month == relaxadeMonth)
                {
                    //only 40% on duty required
                    minWorkingStaff = (int)GetConstraint().MinimumWorkingStaff;
                    valid = 1;
                }
                else
                {
                    //only 60% on duty required
                    minWorkingStaff = (int)GetConstraint().MinimumWorkingStaffRelaxed;
                }
                if (percentBooked < minWorkingStaff)
                {
                    valid = 2;
                }
            }
            return valid;

        }
    }
}
