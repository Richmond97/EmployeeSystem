using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace EmployeeWebApp
{
    public partial class ManageAccount : System.Web.UI.Page
    {
        
        public static List<DateTime> bkinDate = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Calendar1.Visible = false;
            }

           
        }


        protected void btnCalender_Click(object sender, ImageClickEventArgs e)
        {
            Console.WriteLine(" Hello World ");
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
                if (bkinDate.Contains(e.Day.Date))
                {
                    MessageBox.Show(" Holyday already added");
                }
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
                List<DateTime> newBbkinDate = (List<DateTime>)Session["SelectedDates"];

                foreach (DateTime dt in newBbkinDate)
                {
                    Calendar1.SelectedDates.Add(dt);
                    Ltrl.Text = (System.Environment.NewLine + " : " + dt.ToString("d"));

                }
                
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
    }
}