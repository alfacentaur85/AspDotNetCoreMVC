using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson7.Dictionaries
{
    public static class HoursOfWorking
    {
        public static Dictionary<string, string> hoursOfWorking = new Dictionary<string, string>
        {
            { "OrdinaryDays", "9 - 18" },
            { "Sunday", "Holyday" },
            { "Friday", "9 - 17"},
            { "Saturday", "10 - 16"}
        };
    }
}
