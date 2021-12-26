using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService.Enum;
using ReportService.Models;

namespace ReportService.Interfaces
{
    public interface IReportService
    {
        public List<Counter> RamCounter { get; }
        public List<Counter> CpuCounter { get; }
        public void AddCounter(float value, CounterType counterType);
        public void GenerateReport(string output);
    }
}
