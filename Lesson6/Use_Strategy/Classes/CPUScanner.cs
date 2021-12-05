﻿using System.IO;
using Strategy.Interfaces;
using System.Diagnostics;
using System.Threading;
using Strategy.Abstract;

namespace Use_Strategy.Classes
{
    public sealed class CPUScanner : ICPUScanner
    {
        private int _countScansByTimes;

        private int _periodScansByMillisecs;
        public CPUScanner(int countScansByTimes = 5, int periodScansByMillisecs = 2000)
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
                var cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                for (int i = 1; i <= _countScansByTimes; i++)
                {
                    writer.Write($"CPU Usage %: {cpuCounter.NextValue()}\n");
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
