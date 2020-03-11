using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    public delegate int DelegateBuilderMethod(ICSVBuilder isvr, string _path, char _delimiter, string _header);
    public class CsvBuilderDesign
    {

        static int value;
        public static int BuilderMethod(ICSVBuilder isvr, string _path, char _delimiter, string _header)
        {
            try
            {
                value = isvr.LoadStateData( _path, _delimiter, _header);
            }
            catch (CensusAnalyserException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }
    }
}
