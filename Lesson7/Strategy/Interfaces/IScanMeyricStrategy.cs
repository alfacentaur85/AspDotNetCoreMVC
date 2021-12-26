using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy.Interfaces
{
    public interface IScanMetricStrategy
    {
        public void ScanAndSave(IScannerMetric scannerMetric, ISaverMetric saverMetrics, string outputFile = "output.txt");

    }
}
