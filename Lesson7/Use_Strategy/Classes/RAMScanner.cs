using System.IO;
using Strategy.Interfaces;
using System.Diagnostics;
using System.Threading;
using Strategy.Abstract;
using ReportService.Interfaces;
using ReportService.Classes;
using Autofac;

namespace Use_Strategy.Classes
{
    public sealed class RAMScanner : IRAMScanner
    {
        private int _countScansByTimes;

        private int _periodScansByMillisecs;

        private IReportService _report;

        public RAMScanner(IContainer container, int countScansByTimes = 10, int periodScansByMillisecs = 1000)
        {
            _countScansByTimes = countScansByTimes;
            _periodScansByMillisecs = periodScansByMillisecs;
            _report = container.Resolve<IReportService>();
        }
        public Stream ScanMetric()
        {
            float value;
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            try
            {
                var ramCounter = new PerformanceCounter("Memory", "Available MBytes");


                for (int i = 1; i <= _countScansByTimes; i++)
                {
                    value = ramCounter.NextValue();
                    _report.AddCounter(value, ReportService.Enum.CounterType.Ram);
                    writer.Write($"RAM Avaible MBytes: {value}\n");
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
