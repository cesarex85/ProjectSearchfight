using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIS;

namespace SearchVolumMetricServices
{
    public class GoogleVolumMetricService : SearchVolumMetricService
    {
        public override string getServiceName()
        {
            return "Google";
        }
        public override void requestMetric(string strWord)
        {
            KeyWorldToolGoogleAPI _googleApi = new KeyWorldToolGoogleAPI();
            base.Metric = _googleApi.GetVolumSearchEngine(strWord);
        }
    }
}
