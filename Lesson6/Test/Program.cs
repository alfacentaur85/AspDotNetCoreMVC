using Use_Strategy.Classes;
using Strategy.Classes;
using Strategy.Interfaces;
using AutofacDI;
using Autofac;
using Strategy.Abstract;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var autofacDI = new AutofacBuilder();

            var testMetricSaver = AutofacBuilder.Container.Resolve<ISaverMetric>();
            var testScannerFactory = AutofacBuilder.Container.Resolve<IScannerFactory>();
            var testRamScannerStrategy = AutofacBuilder.Container.Resolve<IScanMetricStrategy>();

            var testRamScanner = testScannerFactory.CreateRamScanner();
            var testRAMScannerMetricContext = new ScannerMenticContext(testRamScanner, testMetricSaver);
            testRAMScannerMetricContext.SetupScanMetricStrategy(testRamScannerStrategy);
            testRAMScannerMetricContext.Execute("RAM_metric.txt");

            var testCpuScanner = testScannerFactory.CreateCpuScanner();
            var testCpuScannerStrategy = new RamCpuScannerMetric();
            var testCPUScannerMetricContext = new ScannerMenticContext(testCpuScanner, testMetricSaver);
            testCPUScannerMetricContext.SetupScanMetricStrategy(testCpuScannerStrategy);
            testCPUScannerMetricContext.Execute("CPU_metric.txt");
        }
    }
}
