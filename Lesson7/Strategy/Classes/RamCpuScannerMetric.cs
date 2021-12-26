using Strategy.Interfaces;

namespace Strategy.Classes
{
    public sealed class RamCpuScannerMetric : IScanMetricStrategy
    {
        public void ScanAndSave(IScannerMetric scannerMetric, ISaverMetric saverMetrics, string outputFile = "output.txt")
        {
            using (var metricData = scannerMetric.ScanMetric())
            {
                saverMetrics.SaveMetrics(metricData, outputFile);
            }
        }
    }
}
