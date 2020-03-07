﻿using System;

namespace CensusAnalyserTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Census Analyser");
            string path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
            StateCensusAnalyser at = new StateCensusAnalyser();
           int a= at.LoadStateData(path);
            Console.WriteLine("Total record :"+a);
            CSVState csvstate = new CSVState();
            int b = csvstate.LoadStateData(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv");
            Console.WriteLine("b :"+b);
        }                       
    }
}
