using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchVolumMetricServices;
using System.Reflection;

namespace SearchEngineHelper
{
    public class Keyword
    {
        private string word;
        private int totalMetricSearchEngine;
        private List<SearchVolumMetricService> listofVolumMetricsSearch;

        public Keyword(string p_word)
        {
            word = p_word;
            CalculateTotalMetricSearchEngine();
        }
        public string Word { get => word; set => word = value; }
        public int TotalMetricSearchEngine { get => totalMetricSearchEngine; set => totalMetricSearchEngine = value; }

        public List<SearchVolumMetricService> ListOfVolumMetricSearchEngine { get => listofVolumMetricsSearch; }
        private void CalculateTotalMetricSearchEngine()
        {
            List<SearchVolumMetricService> lSearchObjectsService = new List<SearchVolumMetricService>();
            int total = 0;
            Assembly mscorlib = Assembly.LoadFrom("SearchVolumMetricServices.dll");
            foreach (Type type in mscorlib.GetTypes())
            {
                if (!type.FullName.Equals("SearchVolumMetricServices.SearchVolumMetricService"))
                {
                    SearchVolumMetricService objectMetricService = null;
                    switch (type.FullName)
                    {
                        case "SearchVolumMetricServices.GoogleVolumMetricService":
                            objectMetricService = new GoogleVolumMetricService();
                            break;
                        case "SearchVolumMetricServices.BingVolumMetricService":
                            objectMetricService = new BingVolumMetricService();
                            break;
                        default:
                            objectMetricService = new GoogleVolumMetricService();
                            break;
                    }
                    objectMetricService.requestMetric(this.word);
                    total = total + objectMetricService.Metric;
                    lSearchObjectsService.Add(objectMetricService);
                } 
            }
            totalMetricSearchEngine = total;
            listofVolumMetricsSearch=lSearchObjectsService;
        }
        
    }
}
