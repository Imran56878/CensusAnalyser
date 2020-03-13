using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using ChoETL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CensusAnalyserTest
{
    /// <summary>
    /// This class is used for checking the record 
    /// or file path or given csv extension is not found  
    /// </summary>
    public class StateCensusAnalyser : ICSVBuilder
    {
        string state_census_path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\SortedStateCensusData.csv";
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
        /// first it will sort the data
        /// and then convert it to
        /// Sorted  json file.
        /// </summary>
        public void SortingCsVInJsonFile()
        {
            string[] lines = File.ReadAllLines(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv");
            List<string> amn = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                amn.Add(lines[i]);

            }
            amn.Sort();
            amn.Insert(0, lines[0]);
            File.WriteAllLines(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\SortedStateCensusData.csv", amn);
            var textline = File.ReadAllText(state_census_path);
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(textline).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb)) w.Write(p);
            }
            File.WriteAllText(@"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedStateCensus.json", sb.ToString());

        }
        /// <summary>
        /// Accesses the key value.
        /// </summary>
        /// <param name="_index">The index.</param>
        /// <param name="name">The name.</param>
        /// <param name="_path">The path.</param>
        /// <returns></returns>
        public string Access_Key_Value(int _index, string name, string _path)
        {
            var mj = File.ReadAllText(_path);
            JArray a = JArray.Parse(mj);
            var value = a[_index][name];
            return value.ToString(); ;
        }
        /// <summary>
        /// Jsons the file count.
        /// </summary>
        /// <param name="_json_file_path">The json file path.</param>
        /// <returns></returns>
        public int Json_file_count(string _json_file_path)
        {
            var mj = File.ReadAllText(_json_file_path);
            JArray a = JArray.Parse(mj);
            return a.Count;
        }
    }
}