using Strategy.Abstract;
using Autofac;


namespace Use_Strategy.Classes
{
    public sealed class ScannerFactory : IScannerFactory
    {
        public ICPUScanner CreateCpuScanner()
        {
            return new CPUScanner();
        }

        public IRAMScanner CreateRamScanner()
        {
            return new RAMScanner();
        }
    }
}
