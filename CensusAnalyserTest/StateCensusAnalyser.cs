using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using ChoETL;
using Newtonsoft.Json;

namespace CensusAnalyserTest
{
    /// <summary>
    /// This class is used for checking the record 
    /// or file path or given csv extension is not found  
    /// </summary>
    public class StateCensusAnalyser : ICSVBuilder
    {
        string state_census_path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
        int totalRecord = 0;
        /// <summary>
        /// Loads the state data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        public int LoadStateData(string path, char delimiter, string header)
        {
            string[] str = File.ReadAllLines(path);
            totalRecord = str.Length;
            return totalRecord;


        }
        /// <summary>
        /// Sortings the csv in json file.
        /// </summary>
        public void SortingCsVInJsonFile()
        {
            var lines = File.ReadAllText(state_census_path);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(lines).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb)) w.Write(p);
            }
            File.WriteAllText(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\jsconfig1.json", sb.ToString());

            Console.WriteLine(sb.ToString());

        }
    }
}