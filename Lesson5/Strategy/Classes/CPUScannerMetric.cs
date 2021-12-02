using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Interfaces;

namespace Strategy.Classes
{
    public sealed class CPUScannerMetric : IScanMetricStrategy
    {
        public void NotifyStrategy()
        {
            Console.WriteLine("CPUMetricStrategy was used!");
        }
    }
}
