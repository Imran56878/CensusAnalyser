using System;

namespace CensusAnalyserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Census Analyser");
            string path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
            StateCensusAnalyser at = new StateCensusAnalyser();
            int a = at.LoadStateCensusData(path);
            Console.WriteLine("Total record :" + a);
            CSVState csvstate = new CSVState();
            int b = CSVState.LoadStateCsvData(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv");
            Console.WriteLine("b :" + b);
        }
    }
}
