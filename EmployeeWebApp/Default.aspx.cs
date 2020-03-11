using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeWebApp.HolidayManager;
using EmployeeWebApp.WebServiceReference;
namespace EmployeeWebApp
{
    public partial class _Default : Page
    {
        readonly HolidaysManager hm = new HolidaysManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (hm.Verification(Int32.Parse(txtID.Text), txtPassword.Text))
            {
                Session["sesID"] = hm.GetID(Int32.Parse(txtID.Text));
                Response.Redirect("ManageAccount.aspx");
                

            }
            else
            {

            }
        }
    }
}