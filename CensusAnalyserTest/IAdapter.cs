using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserTest
{
    public interface IAdapter
    {
        public int SortJson_File(string name, string read_path, string write_path);
        public void Test();
    }
}
