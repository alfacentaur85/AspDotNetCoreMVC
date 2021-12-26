using System.IO;
using Strategy.Interfaces;
using System.Diagnostics;
using System.Threading;
using Strategy.Abstract;
using ReportService.Classes;
using ReportService.Interfaces;
using Autofac;

namespace Use_Strategy.Classes
{
    public sealed class CPUScanner : ICPUScanner
    {
        private int _countScansByTimes;

        private int _periodScansByMillisecs;

        private IReportService _report;

        public CPUScanner(IContainer container, int countScansByTimes = 5, int periodScansByMillisecs = 2000)
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
                var cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                for (int i = 1; i <= _countScansByTimes; i++)
                {
                    value = cpuCounter.NextValue();
                    _report.AddCounter(value, ReportService.Enum.CounterType.Cpu);
                    writer.Write($"CPU Usage %: {value}\n");
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
