using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager_ClassLibrary.Functionality_E
{
    public partial class calenderHighlight : System.Windows.Forms.MonthCalendar
    {
        public calenderHighlight()
        {
            InitializeComponent();
        }

        public calenderHighlight(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public DateTime[] highlightBook(DateTime start, DateTime end)
        {
            DateTime[] absentDates = { start, end };
            SelectionRange = new System.Windows.Forms.SelectionRange(start, end);
            this.BoldedDates = absentDates;
            return  absentDates;
            
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.AliceBlue;
        }
    }
}
