using Component_A_ClassLibrary;
using EmployeeWebApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager_ClassLibrary
{
    

    class HolidaysManager
    {
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        private WebService ws = new WebService();

        private void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == null
                          select a);
        }
        private void ConfirmedReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        private void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        private void SubmitHolidayReq(DateTime startH, DateTime endH)
        { 
            //Create method in Webservice that returns a session //ws.Session[sesID]; 

            //var result = (from a in db.holidaysrequesteds
            //              where a.EmployeeID == )
            holidaysrequested rewHlday = new holidaysrequested
            {
                
                StartDate = startH.Date,
                EndDate = endH.Date

            };

        }



    }
}
    
