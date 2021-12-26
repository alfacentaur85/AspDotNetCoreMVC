using Use_Strategy.Classes;
using Strategy.Classes;
using Strategy.Interfaces;
using AutofacDI;
using Autofac;
using Strategy.Abstract;
using ReportService.Classes;
using ReportService.Interfaces;
using Autofac;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var autofacDI = new AutofacBuilder();

            var testReportService = autofacDI.Container.Resolve<IReportService>();
            var testMetricSaver = autofacDI.Container.Resolve<ISaverMetric>();
            var testScannerFactory = autofacDI.Container.Resolve<IScannerFactory>();
            var testRamScannerStrategy = autofacDI.Container.Resolve<IScanMetricStrategy>();
            
            var testRamScanner = testScannerFactory.CreateRamScanner(autofacDI.Container);
            var testRAMScannerMetricContext = new ScannerMenticContext(testRamScanner, testMetricSaver);
            testRAMScannerMetricContext.SetupScanMetricStrategy(testRamScannerStrategy);
            testRAMScannerMetricContext.Execute("RAM_metric.txt");

            var testCpuScanner = testScannerFactory.CreateCpuScanner(autofacDI.Container);
            var testCpuScannerStrategy = new RamCpuScannerMetric();
            var testCPUScannerMetricContext = new ScannerMenticContext(testCpuScanner, testMetricSaver);
            testCPUScannerMetricContext.SetupScanMetricStrategy(testCpuScannerStrategy);
            testCPUScannerMetricContext.Execute("CPU_metric.txt");

            testReportService.GenerateReport("");

        }
    }
}
