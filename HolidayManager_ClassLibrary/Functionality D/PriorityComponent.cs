using Component_A_ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayManager_ClassLibrary.Functionality_D
{

    public partial class PriorityComponent : Component
    {
        private static readonly DataClasses1DataContext dbc = new DataClasses1DataContext();
        HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent pk = new HolidayManager_ClassLibrary.Functionality_C.PeakTimeComponent();
        public PriorityComponent()
        {
            InitializeComponent();
        }

      //  public List<holidaysrequested> Holidays1 { get; set; } = new List<holidaysrequested>();


        public PriorityComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Formula(holidaysrequested holi)
        {
            var query = (from a in dbc.holidaysrequesteds
                         where holi.RequestID == a.RequestID
                         select a).Single();
        }



        private void BubbleSort(string[] args)
        {
            int[] a = { 30, 20, 50, 40, 10 };
            int t;
            Console.WriteLine("The Array is : ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            for (int j = 0; j <= a.Length - 2; j++)
            {
                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        t = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = t;
                    }
                }
            }
            Console.WriteLine("The Sorted Array :");
            foreach (int aray in a)
                Console.Write(aray + " ");
            Console.ReadLine();
        }

        public List<holidaysrequested> sortPeak()
        {
            var query = (from a in dbc.holidaysrequesteds
                         where a.Status == "Pending"
                         select a);
            List<holidaysrequested> peakHolidays = new List<holidaysrequested>();
            List<holidaysrequested> Holidays = new List<holidaysrequested>();

            foreach (var h in query)
            {
                int peakValue = pk.IsPeakTime(h.StartDate, h.EndDate);
                if (peakValue != 0)
                {
                    peakHolidays.Add(h);
                }
                else
                {
                    Holidays.Add(h);
                }

                //Bubble Sort
                holidaysrequested t;
                for (int j = 0; j <= peakHolidays.Count - 3; j++)
                {
                    for (int i = 0; i <= peakHolidays.Count - 3; i++)
                    {
                        if (alg(peakHolidays[i]) > alg(peakHolidays[i+1]))
                        {
                            t = peakHolidays[i + 1];
                            peakHolidays[i + 1] = peakHolidays[i];
                            peakHolidays[i] = t;
                        }
                    }
                } 
            }
            Holidays.AddRange(peakHolidays);


            return Holidays;
        }


        private int alg(holidaysrequested holi)
        {
            var totHol = (from a in db.holidaysrequesteds
                          where holi.EmployeeID == a.EmployeeID && a.Status == "Approved"
                          select a).ToList().Count();


            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimeXmas"
                         select a).Single();

            var summerQ = (from a in db.peaktimes
                           where a.PeaktimesName == "peakTimeSummer"
                           select a).Single();

            DateTime easter = EasterSunday(DateTime.Today.Year);
            DateTime startEaster = easter.AddDays(-7);
            DateTime endEaster = easter.AddDays(7);

            var totPeak = (from a in db.holidaysrequesteds
                           where (holi.EmployeeID == a.EmployeeID && a.Status == "Approved") && ((startEaster < a.EndDate && a.StartDate < endEaster)
                           || (xmasQ.StartDate < a.EndDate && a.StartDate < xmasQ.EndDate)
                           || (summerQ.StartDate < a.EndDate && a.StartDate < summerQ.EndDate))
                           select a).ToList().Count();

            return (totHol / 30) + (totPeak / 30);

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

    }



}
