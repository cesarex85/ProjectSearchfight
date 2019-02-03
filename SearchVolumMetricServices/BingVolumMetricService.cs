using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIS;

namespace SearchVolumMetricServices
{
    public class BingVolumMetricService : SearchVolumMetricService
    {
        public override string getServiceName()
        {
            return "Bing";
        }
        public override void requestMetric(string strWord)
        {
            KeyWorldToolBingAPI _bingApi = new KeyWorldToolBingAPI();
            base.Metric= _bingApi.GetVolumSearchEngine(strWord);
        }
    }
}
