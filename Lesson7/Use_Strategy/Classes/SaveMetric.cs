using Strategy.Interfaces;
using System.IO;

namespace Use_Strategy.Classes
{
    public sealed class SaveMetric : ISaverMetric
    {
        public void SaveMetrics(Stream metricData, string outputFile)
        {
            using (var fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                metricData.CopyTo(fileStream);
            }
        }
    }
}
