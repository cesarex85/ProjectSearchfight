using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchVolumMetricServices;

namespace SearchEngineHelper
{
    public class SearchEngine
    {
        private List<Keyword> listKeyWords;
        public SearchEngine(string[] strKeywords)
        {
            listKeyWords = new List<Keyword>();
            for (int i = 0; i < strKeywords.Length; i++)
            {
                Keyword objKeyWord = new Keyword(strKeywords[i]);
                listKeyWords.Add(objKeyWord);
            }
        }
        public List<Keyword>  GetListKeyWords()
        {
            return listKeyWords;
        }

        public Keyword GetKeywordMostPopular()
        {
            Keyword mostPopularKeyword = listKeyWords.First();
            foreach (Keyword word in listKeyWords)
            {
                if (mostPopularKeyword.TotalMetricSearchEngine < word.TotalMetricSearchEngine)
                {
                    mostPopularKeyword = word;
                }
            }
            return mostPopularKeyword;
        }

        public Keyword GetMostPopularByService(string _strServiceName)
        {
            Keyword popularKey =listKeyWords.First();
            int _majorMetric = 0;
            foreach (SearchVolumMetricService service in popularKey.ListOfVolumMetricSearchEngine)
            {
                string _strFirstServiceName = service.getServiceName();
                if (_strFirstServiceName.Equals(_strServiceName))
                {
                    _majorMetric = service.Metric;
                }
            }
            foreach (Keyword keyword in listKeyWords)
            {
                foreach (SearchVolumMetricService _servSerchEng in keyword.ListOfVolumMetricSearchEngine)
                {
                    if (_servSerchEng.getServiceName().Equals(_strServiceName)&& _majorMetric< _servSerchEng.Metric)
                    {
                        popularKey = keyword;
                        _majorMetric = _servSerchEng.Metric;
                    }
                }
            }

            return popularKey;
        }
        
    }
}
