using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace CensusAnalyserTest
{
    public class StateCensusAnalyser
    {
        int totalRecord = 0;
        public int LoadStateData(string path, char delimiter = ',')
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
                  //  totalRecord++;
                    string[] csvline = line.Split(delimiter);
                    if(csvline.Length !=4 && csvline.Length != 2)
                    {
                        throw new CensusAnalyserException("Wrong_Delimiter");
                    }

                }
                if (str[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CensusAnalyserException("Wrong paramter ");
                }
                totalRecord = str.Length;
            return totalRecord;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }
    }
}