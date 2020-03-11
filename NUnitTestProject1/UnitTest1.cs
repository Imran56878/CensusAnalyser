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
        string State_code_header = "SrNo,State,Name,TIN,StateCode";
        DelegateFactory delegateInstance = new DelegateFactory(CsvsStateFactory.GetInstance);
        DelegateBuilderMethod db = new DelegateBuilderMethod(CsvBuilderDesign.BuilderMethod);
        /// <summary>
        /// The csvstatecensus
        /// </summary>
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
            var obj1 = delegateInstance("StateCensusAnalyser");
            var obj2 = delegateInstance("CsvStateCensus");
            int expected = db(obj1,state_census_path, ',', Census_Data_header);
            int actual = db(obj2,state_census_path, ',', Census_Data_header);
            Assert.AreEqual(expected,actual);
        }
        /// <summary>
        /// Wrongs the file path.
        /// file is not Exist
        /// TestCase1.2
        /// </summary>
        [Test]
        public void WrongFilePath_CsvStateCensus_StateCensusData()
        {
            var obj = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => db(obj,wrong_path, ',', Census_Data_header));
            Assert.AreEqual("File_Not_Exist", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the file extension.
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void WrongFileExtension_CsvStateCensus_StateCensusData()
        {
            var obj = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => db(obj,wrong_file_Extension, ',', Census_Data_header));
            Assert.AreEqual("Wrong_File_Extension", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the delimeter.
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void WrongDelimeter_CsvStateCensus_StateCensusData()
        {
            var obj = delegateInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => db(obj,state_census_path, '.', Census_Data_header));
            Assert.AreEqual("Wrong_Delimiter", val.GetMessage);
        }
        /// <summary>
        /// Headers the test.
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void WrongHeader_CsvStateCensus_StateCensusData()
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
            var obj1 = delegateInstance("StateCensusAnalyser");
            var obj2 = delegateInstance("CSVState");
            int actual = db(obj1,state_code_path, ',', State_code_header);
            int expected = db(obj2,state_code_path, ',', State_code_header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TestCase 2.2
        /// Wrongs the state of the file path compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Path_Compare_CSV_State()
        {
            var obj = delegateInstance("CSVState");
            var csv_state = Assert.Throws<CensusAnalyserException>(() => db(obj,wrong_path, ',', State_code_header));
            Assert.AreEqual("File_Not_Exist", csv_state.GetMessage);
        }
        /// <summary>
        /// TestCase 2.3
        /// Wrongs the state of the file extension compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Extension_Compare_CSV_State()
        {
            var obj = delegateInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => db(obj,State_Code_Extension, ',', State_code_header));
            Assert.AreEqual("Wrong_File_Extension", actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.4
        /// Wrongs the state of the delimiter compare CSV.
        /// </summary>
        [Test]
        public void Wrong_Delimiter_Compare_CSV_State()
        {
            var obj = delegateInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => db(obj,state_code_path, '.', State_code_header));
            Assert.AreEqual("Wrong_Delimiter", actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.5
        /// Wrongs the state of the header compare CSV.
        /// </summary>
        [Test]
        public void wrong_header_Compare_csv_state()
        {
            var obj = delegateInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => db(obj, state_code_path, ',', "SrNo,State,Name"));
            Assert.AreEqual("No_Header", actual.GetMessage);
        }
    }
}