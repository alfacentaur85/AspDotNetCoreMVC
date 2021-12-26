using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportService.Models;
using ReportService.Enum;
using ReportService.Interfaces;
using TemplateEngine.Docx;
using System.IO;

namespace ReportService.Classes
{
    public class Report : IReportService
    {
        private List<Counter> _ramCounter;
        private List<Counter> _cpuCounter;

        public List<Counter> RamCounter
        {
            get
            {
                return _ramCounter;
            }

        }

        public List<Counter> CpuCounter
        {
            get
            {
                return _cpuCounter;
            }

        }

        public Report()
        {
            _ramCounter = new List<Counter>();
            _cpuCounter = new List<Counter>();
        }

        public void AddCounter(float value, CounterType counterType)
        {
            Counter counter = new Counter();
            counter.datetime = DateTime.Now;
            counter.value = value;

            switch (counterType)
            {
                case CounterType.Ram:
                    RamCounter.Add(counter);
                    break;
                case CounterType.Cpu:
                    CpuCounter.Add(counter);
                    break;
            }

        }

        public void GenerateReport(string output = "")
        {
            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), "MyReport.docx");
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }

            File.Copy(Path.Combine(Directory.GetCurrentDirectory(), "template.docx"), output);

            List<TableRowContent> ramRows = new List<TableRowContent>();
            List<TableRowContent> cpuRows = new List<TableRowContent>();

            foreach (Counter order in _cpuCounter)
            {
                cpuRows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("CpuValue", order.value.ToString()),
                    new FieldContent("CpuDate", order.datetime.ToShortDateString()),
             
                }));
            }

            foreach (Counter order in _ramCounter)
            {
                ramRows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("RamValue", order.value.ToString()),
                    new FieldContent("RamDate", order.datetime.ToShortDateString()),

                }));
            }

            var valuesToFill = new Content(
                new FieldContent("ReportName", "Metrics monitoring"),
                new FieldContent("RamMetrics", "RamMetrics report"),
                new FieldContent("CpuMetrics", "CpuMetrics report"),
                 TableContent.Create("RamTable", ramRows),
                 TableContent.Create("CpuTable", cpuRows)
            ); ;

            using (var outputDocument =
                new TemplateProcessor(output)
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }

}
