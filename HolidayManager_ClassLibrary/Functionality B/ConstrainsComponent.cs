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
       
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        int holidaysLeft = 30;
        int taken;
        public ConstrainsComponent()
        {
            InitializeComponent();
        }

        public ConstrainsComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

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
            int bonus = (zeroTime + span).Year - 1;


            var holidaysTaken = (from a in db.holidaysrequesteds
                                 where ((a.EmployeeID == EmployeeID && a.Status == "Approved") 
                                 && (a.StartDate.Year == DateTime.Today.Year))
                                 select a).ToList();

            foreach (var date in holidaysTaken)
            {
                taken = (date.EndDate - date.StartDate).Days;
                taken = +taken;
            }
            return  holidaysLeft = (holidaysLeft + bonus) - taken;

        }
        public bool IsValidHolidayRequest(long ID, DateTime start, DateTime end)
        {
           int daysLeft = HolidaysLeft(ID);
           int daysRequested = (end - start).Days;
            if (daysLeft - daysRequested<0)
            {
                MessageBox.Show("Sorry, not enough holidays left to procced with you request, you only have " + daysLeft + "left");
                return true;
            }
            return false;
        }
    }
}
