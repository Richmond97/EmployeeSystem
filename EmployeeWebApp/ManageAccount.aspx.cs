using System;
using System.Collections.Generic;
using System.Globalization;
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
        HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent pt = new HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent();
        ConstrainsComponent cc = new ConstrainsComponent();
        

        long holidaysLeft;

        protected void Page_Load(object sender, EventArgs e)
        {
            holidaysLeft = cc.HolidaysLeft((long)Session["sesID"]);
            

            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
               // GridViewrRequest.Visible = false;
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
            CultureInfo ci = CultureInfo.InvariantCulture;

            //Perio where no constrants is valid 
             DateTime startH = DateTime.ParseExact( "22/12/2020", "dd/MM/yyyy", ci);
             DateTime endH = DateTime.ParseExact("03/01/2021","dd/MM/yyyy", ci);

            int peakValue = pt.IsPeakTime(start, end);

            if (end < start || start < DateTime.Today || end < DateTime.Today)
            {
                Response.Write("<script>alert('" + "The end date of your Holiday can not be before the start date, or before today" + "');</script>");
            }
            else if (startH < end && start < endH)
            {
                Response.Write("<script>alert('" + "Pleas be aware that the the period from 22nd of December to the 3rd of January, the company is closed, SELECT NEW DATE" + "');</script>");
            }

            else if (cc.IsValidHolidayRequest(start, end, ((long)(Session["sesID"]))))
            {
                if (peakValue != 0)
                {
                    List<DateTime> newdates = new List<DateTime>();
                    if (peakValue == 1)
                    {
                        newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.EndPeak);
                    }
                    else if (peakValue == 2)
                    {
                        newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.EndPeak);
                    }
                    else if (peakValue == 3)
                    {
                        newdates = pt.newSuggestion(start, end, pt.StarPeak, pt.EndPeak);
                    }
                    if (MessageBox.Show("Your request happends to be on " + pt.Holiday + " holiday we suggest " + newdates[0].ToString("d") + "  To  " + newdates[1].ToString("d"),"Accept suggestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (cc.IsValidHolidayRequest(newdates[0], newdates[1], ((long)(Session["sesID"]))))
                        {
                            if (hm.SubmitHolidayReq(newdates[0], newdates[1], ((long)(Session["sesID"]))))
                            {
                                MessageBox.Show("Booking from: " + newdates[0].ToString("d") + "\n" + "To: " + newdates[1].ToString("d"), "New Suggestion");
                            }
                            else
                            {
                                MessageBox.Show("We couldn't completer yor request this time, please try later");
                            }
                        }
                    }
                    else
                    {
                        if (cc.IsValidHolidayRequest(start, end, ((long)(Session["sesID"]))))
                        {
                            if (hm.SubmitHolidayReq(start, end, ((long)(Session["sesID"]))))
                            {
                                MessageBox.Show("Booking from: " + start.ToString("d") + "\n" + "To: " + end.ToString("d"), "BOOKING");
                            }
                            else
                            {
                                MessageBox.Show("We couldn't completer yor request this time, please try later");
                            }
                        }
                    }
                }
                else
                {
                    if (hm.SubmitHolidayReq(start, end, ((long)(Session["sesID"]))))
                    {
                        MessageBox.Show("Booking from: " + start.ToString("d") + "\n" + "To: " + end.ToString("d"), "BOOKING");
                    }
                    else
                    {
                        MessageBox.Show("We couldn't completer yor request this time, please try later");
                    }
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
        protected void btnViewReq_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewrRequest.DataSource = hm.ViewHolidayReqStatus((long)Session["sesID"]);
               // GridViewrRequest.Columns[1].Visible = false;
                GridViewrRequest.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (GridViewrRequest.Visible)
            {
               GridViewrRequest.Visible = false;
            }
            GridViewrRequest.Visible = true;

            
        }
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}//dsgtsd