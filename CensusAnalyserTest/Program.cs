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
            int a = at.LoadStateData(path, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            Console.WriteLine("Total record in StateCensusData :" + a);
            int b = new CSVState().LoadStateData(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv");
            Console.WriteLine("Total record in StateCode :" + b);
            int m = CsvBuilderDesign.BuilderMethod(new CSVState(), @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv", ',', "SrNo,State,Name,TIN,StateCode");
            Console.WriteLine("Total record in StateCode by using builder class :" + m);
        }
    }
}
