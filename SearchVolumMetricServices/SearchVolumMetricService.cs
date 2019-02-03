using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchVolumMetricServices
{
    public abstract class SearchVolumMetricService
    {
        private int metric;
        public int Metric { get => metric; set => metric = value; }
        public abstract string getServiceName();
        public virtual void requestMetric(string strWord) { this.metric = 0; }
    }
}
