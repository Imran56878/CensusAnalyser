using NUnit.Framework;
using CensusAnalyserTest;
namespace NUnitTestProject1
{
    public class Tests
    {
        string path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
        string wrong_path = @"D:\Imran\CensusAnalyser\CSVFile\StateCensusData.csv";
        string wrong_file_Extension = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csveg";
        StateCensusAnalyser stateanalyser = new StateCensusAnalyser();
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// States the census analyser test record.
        /// It will check the total record  .
        /// </summary>
        [Test]
        public void StateCensusAnalyserTestRecord()
        {
          int match=  stateanalyser.LoadStateData(path);
            Assert.AreEqual(30,match);
        }
        /// <summary>
        /// Wrongs the file path.
        /// file is not Exist
        /// </summary>
        [Test]
        public void WrongFilePath()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => stateanalyser.LoadStateData(wrong_path));
            Assert.AreEqual("File_Not_Exist", val.GetMessage);
        }
    }
}