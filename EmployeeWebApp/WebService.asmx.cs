using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EmployeeWebApp
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
    
        
        
        private readonly DataClasses1DataContext db = new DataClasses1DataContext();

        [WebMethod]
        public bool Verification(int StaffID, string Password)
        {
            try
            {
                // Query to find matching staffid and password in DB

                var verQuery = from a in db.employees
                               where a.StaffID == StaffID && a.Password == Password
                               select a;

                
               var quer = verQuery.ToList();

                //create session for log in


                if (verQuery.Any())
                {
                    // If user entered details correctly call auth method
                    Session["sesID"] = GetID(StaffID);
                    MessageBox.Show("User Exists in DB");
                    return true;
                }
                else
                {
                    // Check the Staffid exists
                    var userQuery = from b in db.employees
                                    where b.StaffID == StaffID
                                    select b;

                    if (userQuery.Any())
                    {
                        Console.WriteLine("User Exists in DB, Wrong Password");
                        MessageBox.Show("Password Incorrect");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("User Does Not Exist in DB");
                        MessageBox.Show("User Does Not Exist, Please contact Admin");
                        return false;
                    }
                }

            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
        [WebMethod]
        public long GetID(long StaffID)
        {
            var verQuery = (from a in db.employees
                           where a.StaffID == StaffID
                           select a.EmployeeID);
            var quer = verQuery.ToList();
            long ID = quer[0];
            return ID;

        }


        [WebMethod]
        public void OutstandingReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status == null
                          select a);
        }
        [WebMethod]
        public void ConfirmedReq()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        [WebMethod]
        public void EmployeeHolidayStatus()
        {
            var result = (from a in db.holidaysrequesteds
                          where a.Status != null
                          select a);
        }

        [WebMethod]
        public bool SubmitHolidayReq(DateTime startH, DateTime endH, long StaffID)
        {
            try
            {
                //var verQuery = from a in db.employees
                //               where a.StaffID == StaffID
                //               select a.EmployeeID;


                //var quer = verQuery.ToList();
                //long ID = quer[0];
                holidaysrequested rewHlday = new holidaysrequested
                {
                    EmployeeID = StaffID,
                    StartDate = Convert.ToDateTime(startH.ToShortDateString()),
                    EndDate = Convert.ToDateTime(endH.ToShortDateString()),
                    Status = true

                };

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
                throw;
                
            }
            //Create method in Webservice that returns a session //ws.Session[sesID]; 

            //var result = (from a in db.holidaysrequesteds
            //              where a.EmployeeID == )
            
        }
        internal void Verification(System.Web.UI.WebControls.TextBox txtID, System.Web.UI.WebControls.TextBox txtPassword)
        {
            throw new NotImplementedException();
        }
    }
}
