using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyserTest
{
    /// <summary>
    /// A Delegate  that holds the reference of LoadStateData of CSVState class 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="delimiter"></param>
    /// <param name="header"></param>
    /// <returns></returns>
    public delegate int CsvStateDelegat(string path, char delimiter, string header);
    /// <summary>
    /// It read StateCode csv file .
    /// </summary>
    public class CSVState : ICSVBuilder
    {
        int totalRecord = 0;
        /// <summary>
        /// Loads the state data.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="header">The header.</param>
        /// <returns></returns>
        /// <exception cref="CensusAnalyserException">
        /// Wrong_File_Extension
        /// or
        /// File_Not_Exist
        /// or
        /// Wrong_Delimiter
        /// or
        /// No_Header
        /// </exception>
        public int LoadStateData(string path, char delimiter, string header)
        {
            if (Path.GetExtension(path) != ".csv")
            {
                throw new CensusAnalyserException("Wrong_File_Extension");
            }

            else if (!File.Exists(path))
            {
                throw new CensusAnalyserException("File_Not_Exist");
            }
            string[] str = File.ReadAllLines(path);
            foreach (string line in str)
            {
                string[] csvline = line.Split(delimiter);
                if (csvline.Length != 4 && csvline.Length != 5)
                {
                    throw new CensusAnalyserException("Wrong_Delimiter");
                }
            }
            if (str[0] != header)
            {
                throw new CensusAnalyserException("No_Header");
            }
            string[] str1 = str[0].Split(',');
            // Here we are creating a Dictionay of string type key and
            // Dictionary type value
            var map = new Dictionary<int, Dictionary<string, string>>();
            int key = 1;
            for (int j = 1; j < str.Length; j++)
            {
                string[] mstr = str[j].Split(',');
                Dictionary<string, string> dic = new Dictionary<string, string>();
                //  Here we are creating a local Dictionay of string
                //  type key and string type value
                dic.Add(str1[0], mstr[0]); // str1[0]=>State and mstr[0]=>It's value
                dic.Add(str1[1], mstr[1]); // str1[1]=>Population and mstr[0]=>It's value
                dic.Add(str1[2], mstr[2]); // str1[2]=>AreaInSqKm and mstr[0]=>It's value
                dic.Add(str1[3], mstr[3]); // str1[3]=>DensityPerSqKm and mstr[0]=>It's value
                map.Add(key, dic);
                key++;
            }
            ///<summary>
            ///  It will add 
            ///  the csv file
            ///  in list
            ///</summary>>
            var l = new List<string>();
            foreach (string line in str)
            {
                l.Add(line);
            }
            totalRecord = l.Count;
            return map.Count; ;
        }
    }
}
