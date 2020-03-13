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
        public int dateCount = 0;
        public DateTime start;
        public DateTime end;

        HolidaysManager hm = new HolidaysManager();
        ConstrainsComponent cc = new ConstrainsComponent();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["sesID"]);

            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }


        }


        protected void calenderGo_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            Calendar1.Visible = true;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
            if (e.Day.IsOtherMonth || e.Day.IsToday )
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
            }

           
            if (e.Day.IsSelected == true )
            {
                e.Cell.BackColor = System.Drawing.Color.ForestGreen;
                //Session["SelectedDates"] = bkinDate;
            }
        }
        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.IsOtherMonth || e.Day.IsToday)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DimGray;
            }


            if (e.Day.IsSelected == true)
            {
                e.Cell.BackColor = System.Drawing.Color.ForestGreen;
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            start = Calendar1.SelectedDate;
            txtbxHolidayStart.Text = start.ToString("d");
            Calendar1.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            end = Calendar2.SelectedDate;
            txtbxHolidayEnd.Text = end.ToString("d");
            Calendar2.Visible = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("holiday from: " + start.ToString("d"), "To: " + end);
            //if ()
            //{
                if (hm.SubmitHolidayReq(start, end, ((long)(Session["sesID"]))))
                {
                    MessageBox.Show("Booking Completed from: " + start.ToString("d"), "To: " + end.ToString("d"));
                }

                else
                {
                    MessageBox.Show("error");
                }
            //}
          

        }

        protected void btnReturn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            Calendar2.Visible = true;
        }
    }
}//dsgtsd