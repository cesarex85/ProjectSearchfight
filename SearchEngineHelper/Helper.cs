using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineHelper
{
    public class Helper
    {
        private Helper()
        { }
        private static Helper instance = null;

        public static Helper Instance {
            get
            {
                if (instance == null)
                {
                    instance = new Helper();
                }
                return instance;
            }

        }

        public string ValidateMinimunParameters(string[] strQueryString)
        {
            string result = null;
            if (strQueryString.Length <= 1)
            {
                result = "You need 2 parameters to compare";
            }
            return result;
        }
    }
}
