using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyserTest
{
    class Program
    {
        /// <summary>
        /// This class checks the 
        /// test Case in console application
        /// to check sum condition.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CsvMerge cmr = new CsvMerge();
            cmr.Test();
            StateCensusAnalyser st = new StateCensusAnalyser();
            st.Write_Csv_to_json(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\MergeData.csv", @"D:\Imran\CensusAnalyser\CensusAnalyserTest\IndianCensusData.json");
            st.Write_Csv_to_json(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\USCensusData.csv", @"D:\Imran\CensusAnalyser\CensusAnalyserTest\US_Census_Json_Data.json");
        }
    }

}

