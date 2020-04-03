using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolidayManager_ClassLibrary;

namespace EmployeeWebApp
{
    public partial class _Default : Page
    {
        readonly HolidayManager_ClassLibrary.Functionality_A.HolidayManagerWeb hm = new HolidayManager_ClassLibrary.Functionality_A.HolidayManagerWeb();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if((txtID.Text) == "" || txtPassword.Text == "")
            {
                Response.Write("<script>alert('" + "Login fields can not be empty" + "');</script>");
            }
            
            else if(hm.Verification(Int32.Parse(txtID.Text), txtPassword.Text))
            {
                Session["sesID"] = hm.GetID(Int32.Parse(txtID.Text));
                Session["name"] = hm.GetEmployee(Int32.Parse(txtID.Text)).FirstName;
                Session["surname"] = hm.GetEmployee(Int32.Parse(txtID.Text)).LastName;
                Session["staffID"] = hm.GetEmployee(Int32.Parse(txtID.Text)).StaffID;
                Response.Redirect("ManageAccount.aspx");   
            }
            else
            {
                    Response.Write("<script>alert('" + "Wrong credentials, Try again" + "');</script>");
                }
        }
    }
}