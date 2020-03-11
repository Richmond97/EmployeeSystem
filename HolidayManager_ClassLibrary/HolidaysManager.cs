using Component_A_ClassLibrary;
using EmployeeWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager_ClassLibrary
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
        public void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == null
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
                          select a).SingleOrDefault();

            holidaystaken hd = new holidaystaken
            {
                EmployeeID = result.EmployeeID,
                StartDate= result.StartDate,
                EndDate = result.EndDate
            };
        }

        public void EmployeeHolidayrejectReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }
        public void EmployeeOnDuty(DateTime selectedDate)
        {

            var result = (from a in db.holidaysrequesteds
                          where selectedDate >= a.StartDate && selectedDate < a.EndDate
                          select a);
        }
        public void EmployeeOffDuty()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }
    }
}
    
