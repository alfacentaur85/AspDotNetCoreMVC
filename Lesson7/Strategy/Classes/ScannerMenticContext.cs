using System;
using System.Collections.Generic;
using System.Text;
using Strategy.Interfaces;

namespace Strategy.Classes
{
    public sealed class ScannerMenticContext
    {
        private readonly IScannerMetric _scannerMetric;

        private readonly ISaverMetric _saverMetric;

        private IScanMetricStrategy _currentStrategy;

        public ScannerMenticContext(IScannerMetric scannerMetric, ISaverMetric saverMetric)
        {
            _scannerMetric = scannerMetric;
            _saverMetric = saverMetric;
        }

        public void SetupScanMetricStrategy(IScanMetricStrategy strategy)
        {
            _currentStrategy = strategy;
        }

        public void Execute(string outputFileName = "")
        {
            if (_scannerMetric is null)
            {
                throw new ArgumentNullException("Scanner can not be null");
            }
            if (_currentStrategy is null)
            {
                throw new ArgumentNullException("Current scan strategy can not be null");
            }
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                outputFileName = Guid.NewGuid().ToString();
            }
            _currentStrategy.ScanAndSave(_scannerMetric, _saverMetric, outputFileName);
        }
    }
}
