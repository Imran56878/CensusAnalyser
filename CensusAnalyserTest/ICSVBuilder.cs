using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    /// <summary>
    /// This is a interface 
    /// that are implemented in CsvState,
    /// csvStateCensus and censusAnalyser
    /// </summary>
    public interface ICSVBuilder
    {
        public int LoadStateData(string path, char delimiter, string header);
    }
}
