using System;
using Use_Strategy.Classes;
using Strategy.Classes;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var testRamScanner = new RamScanner();
            var testRamSaver = new SaveMetric();
            var testRamScannerStrategy = new RAMScannerMetric();
            var testRAMScannerMetricContext = new ScannerMenticContext(testRamScanner, testRamSaver);
            testRAMScannerMetricContext.SetupScanMetricStrategy(testRamScannerStrategy);
            testRAMScannerMetricContext.Execute("RAM_metric.txt");

            var testCpuScanner = new CPUScanner();
            var testCpuSaver = new SaveMetric();
            var testCpuScannerStrategy = new CPUScannerMetric();
            var testCPUScannerMetricContext = new ScannerMenticContext(testCpuScanner, testCpuSaver);
            testCPUScannerMetricContext.SetupScanMetricStrategy(testCpuScannerStrategy);
            testCPUScannerMetricContext.Execute("CPU_metric.txt");
        }
    }
}
