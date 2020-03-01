using System;
using System.Collections.Generic;

namespace Locator.Models
{
    public partial class DailyHours
    {
        public string HoursMonOpen { get; set; }
        public string HoursMonClose { get; set; }
        public string HoursTueOpen { get; set; }
        public string HoursTueClose { get; set; }
        public string HoursWedOpen { get; set; }
        public string HoursWedClose { get; set; }
        public string HoursThuOpen { get; set; }
        public string HoursThuClose { get; set; }
        public string HoursFriOpen { get; set; }
        public string HoursFriClose { get; set; }
        public string HoursSatOpen { get; set; }
        public string HoursSatClose { get; set; }
        public string HoursSunOpen { get; set; }
        public string HoursSunClose { get; set; }
        public string HoursDtmonOpen { get; set; }
        public string HoursDtmonClose { get; set; }
        public string HoursDttueOpen { get; set; }
        public string HoursDttueClose { get; set; }
        public string HoursDtwedOpen { get; set; }
        public string HoursDtwedClose { get; set; }
        public string HoursDtthuOpen { get; set; }
        public string HoursDtthuClose { get; set; }
        public string HoursDtfriOpen { get; set; }
        public string HoursDtfriClose { get; set; }
        public string HoursDtsatOpen { get; set; }
        public string HoursDtsatClose { get; set; }
        public string HoursDtsunOpen { get; set; }
        public string HoursDtsunClose { get; set; }

        public virtual Locations Location { get; set; }
        public string LocationID { get; set; }

    }
}
