using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeWebApp
{
    public partial class _Default : Page
    {
        WebService ws = new WebService();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ws.Verification(Int32.Parse(txtID.Text), txtPassword.Text))
            {
                Response.Redirect("ManageAccount.aspx");
                
            }
            else
            {

            }
        }
    }
}