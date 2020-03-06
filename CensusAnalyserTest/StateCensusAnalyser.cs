using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace CensusAnalyserTest
{
    /// <summary>
    /// This class is used for checking the record 
    /// or file path or given csv extension is not found  
    /// </summary>
    public class StateCensusAnalyser
    {
        int totalRecord = 0;
        public int LoadStateData(string path, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
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
                    if(csvline.Length !=4 && csvline.Length != 2)
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
                ///</summary>
                IEnumerable<string> enumerable = str;
                foreach (string line in enumerable )
                {
                    totalRecord++;
                }
            return totalRecord;
            }

            catch (Exception e)
            {
                throw ;
            }
        }
    }
}