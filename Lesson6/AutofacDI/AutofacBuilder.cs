using Autofac;
using Strategy.Interfaces;
using Strategy.Abstract;
using Use_Strategy.Classes;
using Strategy.Classes;

namespace AutofacDI
{
    public sealed class AutofacBuilder
    {
        public static IContainer Container { get; private set; }

        public AutofacBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SaveMetric>().As<ISaverMetric>().SingleInstance();
            builder.RegisterType<CPUScanner>().As<ICPUScanner>().SingleInstance();
            builder.RegisterType<RAMScanner>().As<IRAMScanner>().SingleInstance();
            builder.RegisterType<ScannerFactory>().As<IScannerFactory>().SingleInstance(); 
            builder.RegisterType<RamCpuScannerMetric>().As<IScanMetricStrategy>().SingleInstance();

            Container = builder.Build();

        }
    }
}
