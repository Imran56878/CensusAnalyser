using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyserTest
{
   public class CSVState
    {
        int totalRecord = 0;
        public int LoadStateData(string path, char delimiter = ',', string header = "SrNo,State,Name,TIN,StateCode")
        {
            try
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
                ///<summary>
                ///  It will iterate
                ///  the csv file 
                ///</summary>>
                IEnumerable<string> enumerable = str;
                foreach (string line in enumerable)
                {
                    totalRecord++;
                }
                return totalRecord;
            }

            catch (Exception e)
            {
                throw;
            }
        }
    }
}
