using System;
using System.Collections.Generic;
using System.Text;
namespace CensusAnalyserTest
{
    /// <summary>
    /// This is builder design deligate 
    /// uses in refactor 4
    /// </summary>
    /// <param name="isvr">The isvr.</param>
    /// <param name="_path">The path.</param>
    /// <param name="_delimiter">The delimiter.</param>
    /// <param name="_header">The header.</param>
    /// <returns></returns>
    public delegate int DelegateBuilderMethod(ICSVBuilder isvr, string _path, char _delimiter, string _header);
    public class CsvBuilderDesign
    {
        /// <summary>
        /// It will return the the count or 
        /// exception to calling class
        /// </summary>
        static int value;
        /// <summary>
        /// Builders the method.
        /// </summary>
        /// <param name="isvr">The isvr.</param>
        /// <param name="_path">The path.</param>
        /// <param name="_delimiter">The delimiter.</param>
        /// <param name="_header">The header.</param>
        /// <returns></returns>
        public static int BuilderMethod(ICSVBuilder isvr, string _path, char _delimiter, string _header)
        {
            try
            {
                value = isvr.LoadStateData(_path, _delimiter, _header);
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
