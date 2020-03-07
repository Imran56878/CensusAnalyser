using NUnit.Framework;
using CensusAnalyserTest;
namespace NUnitTestProject1
{
    /// <summary>
    /// This class is for testing purpose.
    /// </summary>
    public class Tests
    {
        string path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
        string state_path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv";
        string wrong_path = @"D:\Imran\CensusAnalyser\CSVFile\StateCensusData.csv";
        string wrong_file_Extension = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csveg";
        StateCensusAnalyser stateanalyser = new StateCensusAnalyser();
        CSVState csvstate = new CSVState();
        /// <summary>
        /// The csvstatecensus
        /// </summary>
        CsvStateCensus csvstatecensus = new CsvStateCensus();
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// States the census analyser test record.
        /// It will check the total record  .
        /// TestCase1.1
        /// </summary>
        [Test]
        public void StateCensusAnalyserTestRecord()
        {
            int match = stateanalyser.LoadStateData(path);
            Assert.AreEqual(30, match);
        }
        /// <summary>
        /// Wrongs the file path.
        /// file is not Exist
        /// TestCase1.2
        /// </summary>
        [Test]
        public void WrongFilePath()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(wrong_path));
            Assert.AreEqual("File_Not_Exist", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the file extension.
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void WrongFileExtension()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(wrong_file_Extension));
            Assert.AreEqual("Wrong_File_Extension", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the delimeter.
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void WrongDelimeter()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(path, '.'));
            Assert.AreEqual("Wrong_Delimiter", val.GetMessage);
        }
        /// <summary>
        /// Headers the test.
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void HeaderTest()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(path, ',',"State,Phopulation,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("No_Header", val.GetMessage);
        }
        /// <summary>
        /// Records the ord matchof StateCode.csv
       /// </summary>
        [Test]
        public void RecOrdMatch()
        {

            int match = stateanalyser.LoadStateData(state_path);
            int match1 = csvstate.LoadStateData(state_path );
            Assert.AreEqual(match, match1);
        }
    }
}