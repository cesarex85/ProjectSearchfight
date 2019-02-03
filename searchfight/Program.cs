using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngineHelper;
using SearchVolumMetricServices;

namespace searchfight
{
    class Program
    {

        static void Main(string[] args)
        {
            string _resultvalidatParameters = Helper.Instance.ValidateMinimunParameters(args);
            if (_resultvalidatParameters is null)
            {
                SearchEngine _objSearchEngine = new SearchEngine(args);
                PrintPopularityInternetServiceByKeyWord(_objSearchEngine);
                PrintWinnerPopularityByInternetService(_objSearchEngine);
                PrintKeywordWinnerPopularity(_objSearchEngine);
             
            }
            else { Console.WriteLine(_resultvalidatParameters); }
            
        }
        public static void PrintPopularityInternetServiceByKeyWord(SearchEngine _pSearchEngine)
        {
            List<Keyword> lKeywords = _pSearchEngine.GetListKeyWords();
            foreach (Keyword word in lKeywords)
            {
                string _resultado = null;
                foreach (SearchVolumMetricService service in word.ListOfVolumMetricSearchEngine)
                {
                    _resultado= _resultado + ""+ word.Word + " "+service.getServiceName()+":"+service.Metric.ToString()+" ";
                }
                Console.WriteLine(_resultado);
            }
        }
        public static void PrintKeywordWinnerPopularity(SearchEngine _pSearchEngine)
        {
            Keyword keywordPopular = _pSearchEngine.GetKeywordMostPopular();
            Console.WriteLine("Total winner: "+ keywordPopular.Word);
        }
        public static void PrintWinnerPopularityByInternetService(SearchEngine _pSearchEngine)
        {
            List<Keyword> lKeywords = _pSearchEngine.GetListKeyWords();
            Keyword _keyWord = lKeywords.First();
            //List<SearchVolumMetricService> _listOfService = _keyWord.ListOfVolumMetricSearchEngine();
            foreach (SearchVolumMetricService service in _keyWord.ListOfVolumMetricSearchEngine)
            {
                Keyword _popularKeyWord = _pSearchEngine.GetMostPopularByService(service.getServiceName());
                Console.WriteLine(service.getServiceName()+" "+"winner:"+" "+_popularKeyWord.Word);
            }
        }

    }
}
