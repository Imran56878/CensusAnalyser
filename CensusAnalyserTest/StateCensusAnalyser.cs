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
    public class StateCensusAnalyser :ICSVBuilder 
    {
        int totalRecord = 0;
        public int LoadStateData(string path,char delimiter=',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {

                string[] str = File.ReadAllLines(path);
                totalRecord = str.Length;
                return totalRecord;
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}