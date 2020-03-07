﻿using CsvHelper;
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
        public int LoadStateData(string path )
        {
            try
            {
               
                string[] str = File.ReadAllLines(path);
                ///<summary>
                ///  It will iterate
                ///  the csv file 
                ///</summary>
                IEnumerable<string> enumerable = str;
                foreach (string line in enumerable )
                {
                    totalRecord++;
                    Console.WriteLine(line );
                }
            return totalRecord;
            }

            catch (Exception )
            {
                throw ;
            }
        }
    }
}