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
        string State_Code_Extension = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\StateCode.csev";
        string Census_Data_header = "State,Population,AreaInSqKm,DensityPerSqKm";
       // CsvStateDelegat csvdlegate = new CsvStateDelegat(new CSVState().LoadStateData);
        DelegateFactory delegateInstance = new DelegateFactory(CsvsStateFactory.GetInstance);
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
            var a = delegateInstance("StateCensusAnalyser");
            int match = a.LoadStateData(state_census_path,',',Census_Data_header);
            Assert.AreEqual(30, match);
        }
        /// <summary>
        /// Wrongs the file path.
        /// file is not Exist
        /// TestCase1.2
        /// </summary>
        [Test]
        public void WrongFilePath_CsvStateCensus_StateCensusData()
        {
            var a = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => a.LoadStateData(wrong_path, ',', Census_Data_header));
            Assert.AreEqual("File_Not_Exist", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the file extension.
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void WrongFileExtension_CsvStateCensus_StateCensusData()
        {
            var a = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => a.LoadStateData(wrong_file_Extension, ',', Census_Data_header));
            Assert.AreEqual("Wrong_File_Extension", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the delimeter.
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void WrongDelimeter_CsvStateCensus_StateCensusData()
        {
            var a = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => a.LoadStateData(state_census_path, '.', Census_Data_header));
            Assert.AreEqual("Wrong_Delimiter", val.GetMessage);
        }
        /// <summary>
        /// Headers the test.
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void HeaderTest_CsvStateCensus_StateCensusData()
        {
            var a = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => a.LoadStateData(state_census_path, ',', "State,Phopulation,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("No_Header", val.GetMessage);
        }
        /// <summary>
        /// Test Case 2.1 
        /// Records the compare count match CSV state state code.
        /// </summary>
        [Test]
        public void Record_Compare_Count_Match_CSVState_StateCode()
        {
            var a = delegateInstance("StateCensusAnalyser");
            var b = delegateInstance("CSVState");
            int actual = a.LoadStateData(state_code_path );
            int expected = b.LoadStateData(state_code_path);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TestCase 2.2
        /// Wrongs the state of the file path compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Path_Compare_CSV_State()
        {
            var b = delegateInstance("CSVState");
            var csv_state = Assert.Throws<CensusAnalyserException>(() => b.LoadStateData(wrong_path));
            Assert.AreEqual("File_Not_Exist", csv_state.GetMessage);
        }
        /// <summary>
        /// TestCase 2.3
        /// Wrongs the state of the file extension compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Extension_Compare_CSV_State()
        {
            var b = delegateInstance("CSVState");
           var actual= Assert.Throws<CensusAnalyserException>(() => b.LoadStateData(State_Code_Extension));
            Assert.AreEqual("Wrong_File_Extension",actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.4
        /// Wrongs the state of the delimiter compare CSV.
        /// </summary>
        [Test]
        public void Wrong_Delimiter_Compare_CSV_State()
        {
            var b = delegateInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => b.LoadStateData(state_code_path, '.'));
            Assert.AreEqual("Wrong_Delimiter", actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.5
        /// Wrongs the state of the header compare CSV.
        /// </summary>
        [Test]
        public void wrong_header_Compare_csv_state()
        {
            var b = delegateInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() =>b.LoadStateData(state_code_path, ',', "SrNo,State,Name"));
            Assert.AreEqual("No_Header", actual.GetMessage);
        }
    }
}