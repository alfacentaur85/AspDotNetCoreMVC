using Strategy.Abstract;
using Autofac;


namespace Use_Strategy.Classes
{
    public sealed class ScannerFactory : IScannerFactory
    {
        public ICPUScanner CreateCpuScanner(IContainer container)
        {
            return new CPUScanner(container);
        }

        public IRAMScanner CreateRamScanner(IContainer container)
        {
            return new RAMScanner(container);
        }
    }
}
