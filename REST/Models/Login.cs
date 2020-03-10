using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Component_A_ClassLibrary;
namespace REST.Models

{
    public class Login
    {
        public int ID { get; set; }
        public String Password { get; set; }

        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
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
                    //Session["sesID"] = GetID(StaffID);
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
                        System.Diagnostics.Debug.WriteLine("User Exists in DB, Wrong Password");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("User Does Not Exist in DB");
                        //MessageBox.Show("User Does Not Exist, Please contact Admin");
                        return false;
                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}