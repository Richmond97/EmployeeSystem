using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeWebApp.HolidayManager;
using System.Windows.Forms;

namespace EmployeeWebApp
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        
        public static List<DateTime> bkinDate = new List<DateTime>();
        public static List<DateTime> newBbkinDate = new List<DateTime>();
        HolidaysManager hm = new HolidaysManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["sesID"]);
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
            }

           
        }


        protected void btnCalender_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            { 
                    Calendar1.Visible = false;
            }
            Calendar1.Visible = true;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
            if (e.Day.IsOtherMonth || e.Day.IsWeekend || e.Day.IsToday )
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
            }

           

            if (e.Day.IsSelected == true )
            {
                
                bkinDate.Add(e.Day.Date);
                e.Cell.BackColor = System.Drawing.Color.ForestGreen;
                //e.Day.IsSelectable = false;
            }
            Session["SelectedDates"] = bkinDate;

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {

                newBbkinDate = (List<DateTime>)Session["SelectedDates"];

                foreach (DateTime dt in newBbkinDate)
                {
                    Ltrl.Text += (System.Environment.NewLine + " : " + dt.ToShortDateString());
                    Calendar1.SelectedDates.Add(dt);
                    

                }
                //Dates = (List<DateTime>)Session["SelectedDates"];
                //newBbkinDate.Clear();
                bkinDate.Clear();
                //Calendar1.SelectedDates.Clear();
                //if (bkinDate.Count == 1)
                //{
                //    txtbxHolidayStart.Text = bkinDate[0].ToString("d");
                //}
                //else if (bkinDate.Count == 2)
                //{
                //    Calendar1.Visible = false;
                //    txtbxHolidayEnd.Text = bkinDate[1].ToString("d");
                //}
                //else
                //    bkinDate.Clear();
                //txtbxHolidayEnd.Text = " ";
                //txtbxHolidayStart.Text = " ";
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            DateTime startH = newBbkinDate[0];
            DateTime endH = newBbkinDate[newBbkinDate.Count - 1];
            MessageBox.Show("Test: " + startH.ToString("d"), "To: " + endH);
            if (hm.SubmitHolidayReq(startH, endH, ((long)(Session["sesID"]))))
            {
                MessageBox.Show("Booking Completed from: " + newBbkinDate[0].ToString("d"), "To: " + newBbkinDate[newBbkinDate.Count - 1].ToString("d"));
            }

            else
            {
                MessageBox.Show("error");
            }

        }
    }
}