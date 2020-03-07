using NUnit.Framework;
using CensusAnalyserTest;
namespace NUnitTestProject1
{
    /// <summary>
    /// This class is for testing purpose.
    /// </summary>
    public class Tests
    {
        string state_census_path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csv";
        string state_code_path = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csv";
        string wrong_path = @"D:\Imran\CensusAnalyser\CSVFile\StateCensusData.csv";
        string wrong_file_Extension = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCensusData.csveg";
        string State_Code_Extension= @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csev";
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
            int match = stateanalyser.LoadStateData(state_census_path);
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
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(state_census_path, '.'));
            Assert.AreEqual("Wrong_Delimiter", val.GetMessage);
        }
        /// <summary>
        /// Headers the test.
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void HeaderTest()
        {
            var val = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(state_census_path, ',',"State,Phopulation,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("No_Header", val.GetMessage);
        }
        /// <summary>
        /// TestCase 2.1
        /// Records the ord matchof StateCode.csv
       /// </summary>
        [Test]
        public void RecOrdMatch()
        {

            int match = stateanalyser.LoadStateData(state_code_path);
            int match1 = csvstate.LoadStateData(state_code_path);
            Assert.AreEqual(match, match1);
        }
        /// <summary>
        /// TestCase 2.2
        /// Wrongs the state of the file path compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Path_Compare_CSV_State()
        {
            var csv_state_census = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(wrong_path));
            var csv_state = Assert.Throws<CensusAnalyserException>(() => csvstate.LoadStateData(wrong_path));
            Assert.AreEqual(csv_state_census.GetMessage , csv_state.GetMessage);
        }
        /// <summary>
        /// TestCase 2.3
        /// Wrongs the state of the file extension compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Extension_Compare_CSV_State()
        {
            var csv_state_census_Extension = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(wrong_file_Extension));
            var csv_state_Code_Extension = Assert.Throws<CensusAnalyserException>(() => csvstate.LoadStateData(State_Code_Extension));
            Assert.AreEqual(csv_state_Code_Extension.GetMessage ,csv_state_census_Extension.GetMessage);
        }
        /// <summary>
        /// TestCase 2.4
        /// Wrongs the state of the delimiter compare CSV.
        /// </summary>
        [Test]
        public void Wrong_Delimiter_Compare_CSV_State()
        {
            var csv_state_census_data_delimeter = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(state_census_path, '.'));
            var state_code_data_delimeter = Assert.Throws<CensusAnalyserException>(() => csvstate.LoadStateData(state_code_path, '.'));
            Assert.AreEqual(csv_state_census_data_delimeter.GetMessage, state_code_data_delimeter.GetMessage);
        }
        /// <summary>
        /// TestCase 2.5
        /// Wrongs the state of the header compare CSV.
        /// </summary>
        [Test]
        public void wrong_header_Compare_csv_state()
        {
            var csv_state_census_Header = Assert.Throws<CensusAnalyserException>(() => csvstatecensus.LoadStateData(state_census_path, ',', "State,Phopulation,AreaInSqKm,DensityPerSqKm"));
            var csv_state_Header = Assert.Throws<CensusAnalyserException>(() => csvstate.LoadStateData(state_code_path , ',', "SrNo,State,Name"));
            Assert.AreEqual(csv_state_census_Header.GetMessage, csv_state_Header.GetMessage);
        }
    }
}