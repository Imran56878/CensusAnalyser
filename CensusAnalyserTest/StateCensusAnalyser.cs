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
            //  To ignore header lines count -1 is added.
            return totalRecord-1;

        }
        /// <summary>
        /// first it will sort the data
        /// and then convert it to
        /// Sorted  json file.
        /// </summary>
        public void Sorting_CsV_File(string _read_csv_path, string _write_csv_path)
        {
            string[] lines = File.ReadAllLines(_read_csv_path );
            List<string> amn = new List<string>();

            for (int i = 1; i < lines.Length; i++)
            {
                amn.Add(lines[i]);

            }
            amn.Sort();
            amn.Insert(0, lines[0]);
            File.WriteAllLines(_write_csv_path , amn);  
        }
        /// <summary>
        /// Writes the CSV to JSV.
        /// </summary>
        /// <param name="_readcsv_path">The readcsv path.</param>
        /// <param name="_write_json_path">The write json path.</param>
        public void Write_Csv_to_json(string _readcsv_path, string _write_json_path)
        {
            var textline = File.ReadAllText(_readcsv_path );
            StringBuilder sb = new StringBuilder();
            using (var p = ChoCSVReader.LoadText(textline).WithFirstLineHeader())
            {
                using (var w = new ChoJSONWriter(sb)) w.Write(p);
            }
            File.WriteAllText(_write_json_path , sb.ToString());

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
        /// <summary>
        /// Sorts the json file
        /// in any order 
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="_path">The path.</param>
        public int SortJson_File(string name, string read_path, string write_path)
        {
            int count = 0;
            var mj = File.ReadAllText(read_path);
            JArray a = JArray.Parse(mj);
            for (int i=0; i<a.Count; i++ )
            {
               
                for (int j = 0; j < a.Count - 1; j++)
                {
                    var value = a[i][name].CastTo<int>();
                    var value1 = a[j][name].CastTo<int>();
                    if (value > value1)
                    {
                        count++;
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }  
                
            }
            File.WriteAllText(write_path , a.ToString());
            return count;
            
        }
    }
}