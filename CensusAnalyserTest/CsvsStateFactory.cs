using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    public delegate ICSVBuilder  DelegateFactory(string message);
    public class CsvsStateFactory
    {
        public static ICSVBuilder GetInstance(string str)
        {
            ICSVBuilder obj = null;
            if (str == "CsvStateCensus")
            {
                obj = new CsvStateCensus();
            }
            else if (str == "CSVState")
            {
                obj = new CSVState();
            }
            else if(str == "StateCensusAnalyser")
            {
                obj = new StateCensusAnalyser();
            }
            return obj;
        }


    }
}
