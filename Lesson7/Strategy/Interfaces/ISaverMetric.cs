using System.IO;

namespace Strategy.Interfaces
{
    public interface ISaverMetric
    {
        public void SaveMetrics(Stream metricData, string outputFile);

    }
}
