using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Windows.Forms;
using HolidayManager_ClassLibrary;

namespace EmployeeWebApp
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        public int dateCount = 0;
        

        
        HolidayManager_ClassLibrary.Functionality_A.HolidayManagerWeb hm = new HolidayManager_ClassLibrary.Functionality_A.HolidayManagerWeb();
        ConstrainsComponent cc = new ConstrainsComponent();
        long holidaysLeft;

        protected void Page_Load(object sender, EventArgs e)
        {
            holidaysLeft = cc.HolidaysLeft((long)Session["sesID"]);


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

            txtbxHolidayStart.Text = Calendar1.SelectedDate.ToString("d");
            Calendar1.Visible = false;
        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtbxHolidayEnd.Text = Calendar2.SelectedDate.ToString("d");
            Calendar2.Visible = false;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         DateTime start = Calendar1.SelectedDate;
         DateTime end = Calendar2.SelectedDate;

        MessageBox.Show("holidays from: " + start.ToString("d"), "To: " + end);
            if (end <start || start<DateTime.Today || end<DateTime.Today)
            {
                Response.Write("<script>alert('" +"The end date of your Holiday can not be before the start date, or before today"+ "');</script>");
            }
            else if (cc.IsValidHolidayRequest(start, end, ((long)(Session["sesID"]))))
            {
                if (hm.SubmitHolidayReq(start, end, ((long)(Session["sesID"]))))
                {
                    MessageBox.Show("Booking Completed from: " + start.ToString("d"), "To: " + end.ToString("d"));
                }
                else
                {
                    MessageBox.Show("We couldn't completer yor request this time, please try later");
                }
            }

        }

        protected void btnReturn_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            Calendar2.Visible = true;
        }

        protected void btnPersonalDet_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('" + "Identification Number: "+ Session["staffID"].ToString() + "\\r\\n" + "Name: " + Session["name"].ToString() + "\\r\\n" + "Surname " + Session["surname"].ToString() + "\\r\\n"  + "Holidays Remainig: "+holidaysLeft + "');</script>");
        }
    }
}//dsgtsd