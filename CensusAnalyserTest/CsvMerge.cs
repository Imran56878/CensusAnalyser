using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyserTest
{
    /// <summary>
    /// This class merges 
    /// the two csv file .
    /// </summary>
    public class CsvMerge
    {
        string path_code = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv";
        string path_census = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\SortedStateCensusData.csv";
        string merge_file = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\MergeData.csv";
        string header = "SrNo,State Name,TIN,StateCode,Population,AreaInSqKm,DensityPerSqKm";
        int count = 0;
        List<string> la = new List<string>();
        /// <summary>
        /// Tests this instance.
        /// It calls the merge function.
        /// </summary>
        public void Test()
        {
            la.Add(header);
            string[] code = File.ReadAllLines(path_code);
            string[] census = File.ReadAllLines(path_census);
            for (int i = 1; i < code.Length; i++)
            {
                count = 0;
                string[] lines_code = code[i].Split(',');

                for (int j = 1; j < census.Length; j++)
                {
                    string[] lines_census = census[j].Split(',');

                    merge(code[i], census[j], lines_code, lines_census);
                }

                if (count ==0)
                {
                    // It adds new State that is not common
                    // in both csv file;
                    string sa = String.Concat(code[i]);
                    la.Add(sa);
                    
                }
            }
            Console.WriteLine(" ");
        }
        /// <summary>
        /// It will merge the two csv file
        /// with state name
        /// Merges the specified code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="census">The census.</param>
        /// <param name="lines_code">The lines code.</param>
        /// <param name="lines_census">The lines census.</param>
        public void merge(string _code, string _census, string[] lines_code, string[] lines_census)
        {
            string sf;
            if (lines_code[1] == lines_census[0])
            {
                int a = _census.IndexOf(",");
                sf = _census.Substring(a);
                string s = String.Concat(_code, sf);
                la.Add(s);
                count = 1;
            }
            File.WriteAllLines(merge_file, la);
        }
    }
}
