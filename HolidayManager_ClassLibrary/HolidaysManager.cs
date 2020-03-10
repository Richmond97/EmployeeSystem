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
        private void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == null
                          select a);
        }
        private void ConfirmedReq()
        {
            var result = (from a in db.holidaystakens
                          select a);
        }

        private void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        private void acceptReq(long EmployID)
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

        private void EmployeeHolrejectReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }
    }
}
    
