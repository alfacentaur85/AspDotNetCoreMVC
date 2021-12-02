using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Strategy.Interfaces
{
    public interface ISaverMetric
    {
        public void SaveMetric(Stream metricData, string outputFile)
        {
            using (var fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                metricData.CopyTo(fileStream);
            }
        }

    }
}
