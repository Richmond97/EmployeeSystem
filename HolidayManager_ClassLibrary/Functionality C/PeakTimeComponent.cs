using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;


//class bubblesort
//{
//    static void Main(string[] args)
//    {
//        int[] a = { 30, 20, 50, 40, 10 };
//        int t;
//        Console.WriteLine("The Array is : ");
//        for (int i = 0; i < a.Length; i++)
//        {
//            Console.WriteLine(a[i]);
//        }
//        for (int j = 0; j <= a.Length - 2; j++)
//        {
//            for (int i = 0; i <= a.Length - 2; i++)
//            {
//                if (a[i] > a[i + 1])
//                {
//                    t = a[i + 1];
//                    a[i + 1] = a[i];
//                    a[i] = t;
//                }
//            }
//        }
//        Console.WriteLine("The Sorted Array :");
//        foreach (int aray in a)
//            Console.Write(aray + " ");
//        Console.ReadLine();
//    }
//}

namespace HolidayManager_ClassLibrary.Functionality_C
{
    public partial class PeakTimeComponent : Component
    { 

        private readonly DataClasses1DataContext db = new DataClasses1DataContext();
        private readonly Page Page;
        DateTime starPeak;
        DateTime endPeak;
        string holiday = "";

        public DateTime StarPeak { get => starPeak; set => starPeak = value; }
        public DateTime EndPeak { get => endPeak; set => endPeak = value; }
        public string Holiday { get => holiday; set => holiday = value; }

        public PeakTimeComponent()
        {
            InitializeComponent();
        }

        public PeakTimeComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        public holidaysrequested GetHoliday(long holiID)
        {
            var holiday = (from a in db.holidaysrequesteds
                           where a.RequestID == holiID && a.Status == "Pending"
                           select a).Single();
            return holiday;
        }
        public static DateTime EasterSunday(int year)
        {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        public int IsPeakTime(DateTime start,DateTime end)
        {
           // DateTime start = GetHoliday(requestID).StartDate;
           // DateTime end = GetHoliday(requestID).EndDate;
            DateTime easter = EasterSunday(DateTime.Today.Year);
            DateTime startEaster = easter.AddDays(-7);
            DateTime endEaster = easter.AddDays(7);

            int peakValue = 0;


            //• 15th of July to 31st of August
            //• 15th of December to 22nd of December
            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimeXmas"
                         select a).Single();

            var summerQ = (from a in db.peaktimes
                           where a.PeaktimesName == "peakTimeSummer"
                           select a).Single();

            if (startEaster < end && start < endEaster)
            {
                Holiday = "Easter";
                peakValue = 1;
                StarPeak = startEaster;
                EndPeak = endEaster;               
            }
            else if (xmasQ.StartDate < end && start < xmasQ.EndDate)
            {
                peakValue = 2;
                Holiday = "Xmas";
                StarPeak = xmasQ.StartDate;
                EndPeak = xmasQ.EndDate;
            }
           else if (summerQ.StartDate < end && start < summerQ.EndDate)
            {
                peakValue = 3;
                Holiday = "Summer";
                StarPeak = summerQ.StartDate;
                EndPeak = summerQ.EndDate;
            }
            return peakValue;

        }
        public List<DateTime> newSuggestion(DateTime start, DateTime end,DateTime peakS, DateTime peakE)
        {
            int lengthH = (int)(end - start).TotalDays;
            if ((peakS - start).TotalDays < (end - peakS).TotalDays)
            {
               start = peakS.AddDays(lengthH);
               end = start.AddDays(lengthH);
            }
            start = peakE;
            end = start.AddDays(lengthH);

           // MsgBox("Your request happends to be on " + holiday + " holiday", this.Page, this); 

            List<DateTime> newDate = new List<DateTime>();
            newDate.Add(start);
            newDate.Add(end);
            return newDate;

            
        }
        //public void MsgBox(String ex, Page pg, Object obj)
        //{
        //    string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        //    Type cstype = obj.GetType();
        //    ClientScriptManager cs = pg.ClientScript;
        //    cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        //}

    }
}
