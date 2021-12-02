using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strategy.Interfaces;
using System.Diagnostics;
using System.Threading;

namespace Use_Strategy.Classes
{
    public sealed class RamScanner : IScannerMetric
    {
        private int _countScansByTimes;
        private int _periodScansByMillisecs;
        public RamScanner(int countScansByTimes = 10, int periodScansByMillisecs = 1000)
        {
            _countScansByTimes = countScansByTimes;
            _periodScansByMillisecs = periodScansByMillisecs;
        }
        public Stream ScanMetric()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            try
            {
                var ramCounter = new PerformanceCounter("Memory", "Available MBytes");


                for (int i = 1; i <= _countScansByTimes; i++)
                {
                    writer.Write($"RAM Avaible MBytes: {ramCounter.NextValue()}\n");
                    writer.Flush();
                    
                    Thread.Sleep(_periodScansByMillisecs);
                }
                stream.Position = 0;

            }
            catch
            {
                writer.Dispose();
                stream.Dispose();
            }

            return stream;
        }

    }
}
