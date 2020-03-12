using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    public interface ICSVBuilder
    {
        public int LoadStateData(string path, char delimiter, string header);
    }
}
