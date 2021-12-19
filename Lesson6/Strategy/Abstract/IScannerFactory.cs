using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Abstract
{
    public interface IScannerFactory
    {
        IRAMScanner CreateRamScanner();
        ICPUScanner CreateCpuScanner();
    }
}
