using System;
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
        //public static DateTime EasterSunday(int year)
        //{
        //    int day = 0;
        //    int month = 0;

        //    int g = year % 19;
        //    int c = year / 100;
        //    int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
        //    int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

        //    day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
        //    month = 3;

        //    if (day > 31)
        //    {
        //        month++;
        //        day -= 31;
        //    }

        //    return new DateTime(year, month, day);
        //}

        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        int holidaysLeft = 0;
        int taken;
        int bonus = 0;
        string roles = "";
        string department = "";

        public string Roles { get => roles; set => roles = value; }
        public string Department { get => department; set => department = value; }

        public ConstrainsComponent()
        {
            InitializeComponent();
            Roles = GetConstraint().AvailableRoles;
            Department = GetConstraint().AvailableDepartments;
            
        }

        public ConstrainsComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        public constraint GetConstraint()
        {
            var constraint = (from a in db.constraints
                              select a).Single();
            return constraint;
        }
        
        public int HolidaysLeft(long EmployeeID)
        {
          //  holidaysLeft = GetConstraint().HolidayEntitlement;


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
                        where a.employee.StaffID == StaffID
                        select a).Single();

            return role;
        }

        public holidaysrequested GetHoliday(long holiID)
        {
            var holiday = (from a in db.holidaysrequesteds
                        where a.RequestID == holiID
                           select a).Single();

            return holiday;
        }

        public bool managerReq( role role, holidaysrequested holi)
        {
            //return if the manager request pass the constrains, false if not
            bool validReq = true;
            string myRole = "";
            string roleType = role.RoleType.ToString();
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
                default:
                    Console.WriteLine("Default case");
                    break;
        
            }
            string departmentName = role.department.DeptName.ToString();
            var holidays = (from b in db.holidaysrequesteds
                                where ((b.Status == "Approved") && (role.RoleType == myRole) 
                                && (role.department.DeptName == departmentName))
                                select b).ToList();

            holidaysrequested currHoliday = GetHoliday(holi.RequestID);
            foreach (var h in holidays)
            {
               
                if(currHoliday.StartDate < h.EndDate && h.StartDate> currHoliday.EndDate)
                {
                     validReq = false;
                }
            }

            return validReq;
        }
    }
}
