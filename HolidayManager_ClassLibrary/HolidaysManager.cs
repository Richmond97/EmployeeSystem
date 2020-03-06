using Component_A_ClassLibrary;
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



    }
}
    
