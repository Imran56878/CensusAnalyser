using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    /// <summary>
    /// Thbis class is used for creating an 
    /// object to return it
    /// to calling an object
    /// </summary>
    public class CsvsStateFactory
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
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
            else if (str == "StateCensusAnalyser")
            {
                obj = new StateCensusAnalyser();
            }
            return obj;
        }


    }
}
