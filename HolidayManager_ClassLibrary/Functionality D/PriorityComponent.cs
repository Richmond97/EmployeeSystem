﻿using Component_A_ClassLibrary;
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
        int validHolidayCount = 0;

        public int ValidHolidayCount { get => validHolidayCount; set => validHolidayCount = value; }

        public PriorityComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
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
               //the method IsPeakTime return zero if the holiday is in peak period
               //otherwise it returns 1,2, and 3 each rapressenting a peak time 
                int peakValue = pk.IsPeakTime(h.StartDate, h.EndDate);
                //we popolare the the acording lists
                if (peakValue != 0)
                {
                    peakHolidays.Add(h);
                }
                else
                {
                    Holidays.Add(h);
                }     
            }
            //the value of the lenth of the list of the holidays that brake any constrain will be used
            //to create a visualixation of the sorted list
            ValidHolidayCount = Holidays.Count - 1;

            //Bubble Sort
            //
            holidaysrequested t;
            for (int j = 0; j <= peakHolidays.Count - 3; j++)
            {
                for (int i = 0; i <= peakHolidays.Count - 3; i++)
                {
                    if (alg(peakHolidays[i]) > alg(peakHolidays[i + 1]))
                    {
                        t = peakHolidays[i + 1];
                        peakHolidays[i + 1] = peakHolidays[i];
                        peakHolidays[i] = t;
                    }
                }
            }
            Holidays.AddRange(peakHolidays);


            return Holidays;
        }

        private double alg(holidaysrequested holi)
        {
            //find the total number of Holidays taken
            var totHol = (from a in db.holidaysrequesteds
                          where holi.EmployeeID == a.EmployeeID && a.Status == "Approved"
                          select a).ToList().Count();

            //getting peaktime dates from database
            var xmasQ = (from a in db.peaktimes
                         where a.PeaktimesName == "peakTimeXmas"
                         select a).Single();

            var summerQ = (from a in db.peaktimes
                           where a.PeaktimesName == "peakTimeSummer"
                           select a).Single();

            DateTime easter = EasterSunday(DateTime.Today.Year);
            DateTime startEaster = easter.AddDays(-7);
            DateTime endEaster = easter.AddDays(7);

            //Find the total number fo holidays requested in peakTime
            var totPeak = (from a in db.holidaysrequesteds
                           where (holi.EmployeeID == a.EmployeeID && a.Status == "Approved") && ((startEaster < a.EndDate && a.StartDate < endEaster)
                           || (xmasQ.StartDate < a.EndDate && a.StartDate < xmasQ.EndDate)
                           || (summerQ.StartDate < a.EndDate && a.StartDate < summerQ.EndDate))
                           select a).ToList().Count();

            // devide the total number of holidays taken   by the max holidays aavailable [ bonus holidays not taken in consderation ]
            // devide the total number of holidays taken in Peak period  by the max holidays aavailable [ bonus holidays not taken in consderation ]
            //add the two numbes toghter 
            // 1.3 is used aa a  weight to balance, the weght is applied on the total number
            //of holidays because a higher scsore means the person comes befor on the list 
            return (1.35 * ((double)totHol / 30.0)) + ((double)totPeak / 30.0);

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


        /***************************************************************************************
        *    Title: <Easter Sunday>
        *    Author: <author(s) names>
        *    Date: <13/03/20>
        *    Code version: <code version>
        *    Availability: https://www.codeproject.com/Articles/10860/Calculating-Christian-Holidays
        *
        ***************************************************************************************/


    }



}
