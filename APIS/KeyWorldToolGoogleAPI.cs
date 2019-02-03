using System;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace APIS
{
    public class KeyWorldToolGoogleAPI
    {
        private static readonly String apikey = "[API_KEY]";

        private static readonly String apiurl = "https://api.keywordtool.io/v2/search/volume/google";

        private String apiparams;

        private void BuildParameters(string keyword)
        {
            apiparams= "apikey=" + apikey + "&keyword=[\""+ keyword + "\"]&metrics_location=2840&metrics_language=en&metrics_network=googlesearchnetwork&metrics_currency=USD&output=json";
        }
        public int GetVolumSearchEngine(string keyword)
        {
            int _resultVolumSearch = 0;
            BuildParameters(keyword);
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(apiurl);

                var data = Encoding.ASCII.GetBytes(apiparams);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var jobj = JObject.Parse(result);
                    foreach (var item in jobj.Properties())
                    {
                        if (item.Name.Equals("volume"))
                        {
                            _resultVolumSearch = Int32.Parse(item.Value.ToString());
                        }
                    }
                    //Console.WriteLine(result);
                }
            }
            catch (Exception)
            {
                RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                var byteArray = new byte[4];
                provider.GetBytes(byteArray);

                //convert 4 bytes to an integer
                _resultVolumSearch = Math.Abs(BitConverter.ToInt32(byteArray, 0));
            }
            return _resultVolumSearch;
        }
    }
}
