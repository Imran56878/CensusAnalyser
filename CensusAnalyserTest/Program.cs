using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

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
            /* Console.WriteLine("Welcome Census Analyser");
             string path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
             StateCensusAnalyser at = new StateCensusAnalyser();
             int a = at.LoadStateData(path, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
             Console.WriteLine("Total record in StateCensusData :" + a);
             int b = new CSVState().LoadStateData(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv", ',', "SrNo,State,Name,TIN,StateCode");
             Console.WriteLine("Total record in StateCode :" + b);
             int m = CsvBuilderDesign.BuilderMethod(new CSVState(), @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv", ',', "SrNo,State,Name,TIN,StateCode");
             Console.WriteLine("Total record in StateCode by using builder class :" + m);*/
            /*CSVState st = new CSVState();
            int s = st.LoadStateData(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv", ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            Console.WriteLine("Count is :" + s);*/
            StateCensusAnalyser st = new StateCensusAnalyser();
            st.SortJson_File("DensityPerSqKm", @"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedStateCensus.json");
        }
    }
}
