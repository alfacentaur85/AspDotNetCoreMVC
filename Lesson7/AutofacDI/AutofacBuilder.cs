using Autofac;
using Strategy.Interfaces;
using Strategy.Abstract;
using Use_Strategy.Classes;
using Strategy.Classes;
using ReportService.Classes;
using ReportService.Interfaces;

namespace AutofacDI
{
    public sealed class AutofacBuilder
    {
        public IContainer Container { get; set; }

        public AutofacBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Report>().As<IReportService>().SingleInstance();
            builder.RegisterType<SaveMetric>().As<ISaverMetric>().SingleInstance();
            builder.RegisterType<CPUScanner>().As<ICPUScanner>().SingleInstance();
            builder.RegisterType<RAMScanner>().As<IRAMScanner>().SingleInstance();
            builder.RegisterType<ScannerFactory>().As<IScannerFactory>().SingleInstance(); 
            builder.RegisterType<RamCpuScannerMetric>().As<IScanMetricStrategy>().SingleInstance();
            Container = builder.Build();

        }
    }
}
