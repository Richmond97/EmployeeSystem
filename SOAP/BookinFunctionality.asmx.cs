using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace SOAP
{
    /// <summary>
    /// Summary description for BookinFunctionality
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookinFunctionality : System.Web.Services.WebService
    {

        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        private int iD;
        private string password;


        [WebMethod]
        public bool VerificationLogin(int StaffID, string Password)
        {
            int valid = 0;
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
                    //If user entered details correctly call auth method
                     //Session["sesID"] = GetID(StaffID);
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
                return false;
                
            }
        }

        [WebMethod]
        public long GetID(long StaffID)
        {
            var verQuery = (from a in db.employees
                            where a.StaffID == StaffID
                            select a.StaffID);
            var quer = verQuery.ToList();
            long ID = quer[0];
            return ID;

        }
        [WebMethod]
        public List<string> ViewHolidayReqStatus(long staffID)
        {
            List<string> Request = new List<string>();

            var result = (from a in db.holidaysrequesteds
                          where a.employee.StaffID == staffID
                          select a).ToList();


            foreach (var item in result)
            {
                string holiday = item.RequestID + "*" +item.StartDate.ToShortDateString() + "*" + item.EndDate.ToShortDateString() + "*" + item.Status;
                Request.Add(holiday);
            }
            return Request;

        }

        [WebMethod]
        public string GetEmployee(long StaffID)
        {
            string Person ="";
            var role = (from a in db.roles
                        where a.employee.StaffID == StaffID
                        select a).ToList();

            foreach (var p in role)
            {
                Person = "StaffID: " + p.employee.StaffID + "*" + "Name: " + p.employee.FirstName + "*" + "Surname: " + p.employee.LastName + "*" + "Department: " + p.department.DeptName + "*" + "Role: " + p.RoleType;
            }
            return Person;
        }


        [WebMethod]
        public bool SubmitHolidayReq(DateTime startH, DateTime endH, long StaffID)
        {
            try
            {
               
                holidaysrequested rewHlday = new holidaysrequested
                {
                    EmployeeID = StaffID,
                    StartDate = Convert.ToDateTime(startH.ToShortDateString()),
                    EndDate = Convert.ToDateTime(endH.ToShortDateString()),
                    Status = "Pending"

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
        }
    }
}
