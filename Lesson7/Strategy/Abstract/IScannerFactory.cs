using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Strategy.Abstract
{
    public interface IScannerFactory
    {
        IRAMScanner CreateRamScanner(IContainer container);
        ICPUScanner CreateCpuScanner(IContainer container);
    }
}
