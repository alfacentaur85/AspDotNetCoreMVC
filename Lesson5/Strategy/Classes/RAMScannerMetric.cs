using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Interfaces;

namespace Strategy.Classes
{
    public sealed class RAMScannerMetric : IScanMetricStrategy
    {
        public void NotifyStrategy()
        {
            Console.WriteLine("RAMMetricStrategy was used!");
        }
    }
}
