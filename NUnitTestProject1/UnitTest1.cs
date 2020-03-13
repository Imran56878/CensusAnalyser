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
        string sorted_census_csv = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\SortedStateCensusData.csv";
        string json_census = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedStateCensus.json";
        string sorted_state_ = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\CSVFile\SortedStateCodeData.csv";
        string json_state_data = @"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedState_code.json";
        StateCensusAnalyser stateanalyser = new StateCensusAnalyser();
        DelegateBuilderMethod delegatebulder = new DelegateBuilderMethod(CsvBuilderDesign.BuilderMethod);

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
            var obj1 = CsvsStateFactory.GetInstance("StateCensusAnalyser");
            var obj2 = CsvsStateFactory.GetInstance("CsvStateCensus");
            int expected = delegatebulder(obj1, state_census_path, ',', Census_Data_header);
            int actual = delegatebulder(obj2, state_census_path, ',', Census_Data_header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Wrongs the file path.
        /// file is not Exist
        /// TestCase1.2
        /// </summary>
        [Test]
        public void WrongFilePath_CsvStateCensus_StateCensusData()
        {
            var obj = CsvsStateFactory.GetInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, wrong_path, ',', Census_Data_header));
            Assert.AreEqual("File_Not_Exist", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the file extension.
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void WrongFileExtension_CsvStateCensus_StateCensusData()
        {
            var obj = CsvsStateFactory.GetInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, wrong_file_Extension, ',', Census_Data_header));
            Assert.AreEqual("Wrong_File_Extension", val.GetMessage);
        }
        /// <summary>
        /// Wrongs the delimeter.
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void WrongDelimeter_CsvStateCensus_StateCensusData()
        {
            var obj = CsvsStateFactory.GetInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, state_census_path, '.', Census_Data_header));
            Assert.AreEqual("Wrong_Delimiter", val.GetMessage);
        }
        /// <summary>
        /// Headers the test.
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void WrongHeader_CsvStateCensus_StateCensusData()
        {
            var obj = CsvsStateFactory.GetInstance("CsvStateCensus");
            var val = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, state_census_path, ',', "State,Phopulation,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("No_Header", val.GetMessage);
        }
        /// <summary>
        /// Test Case 2.1 
        /// Records the compare count match CSV state state code.
        /// </summary>
        [Test]
        public void Record_Compare_Count_Match_CSVState_StateCode()
        {
            var obj1 = CsvsStateFactory.GetInstance("StateCensusAnalyser");
            var obj2 = CsvsStateFactory.GetInstance("CSVState");
            int actual = delegatebulder(obj1, state_code_path, ',', State_code_header);
            int expected = delegatebulder(obj2, state_code_path, ',', State_code_header);
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// TestCase 2.2
        /// Wrongs the state of the file path compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Path_Compare_CSV_State()
        {
            var obj = CsvsStateFactory.GetInstance("CSVState");
            var csv_state = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, wrong_path, ',', State_code_header));
            Assert.AreEqual("File_Not_Exist", csv_state.GetMessage);
        }
        /// <summary>
        /// TestCase 2.3
        /// Wrongs the state of the file extension compare CSV.
        /// </summary>
        [Test]
        public void Wrong_File_Extension_Compare_CSV_State()
        {
            var obj = CsvsStateFactory.GetInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, State_Code_Extension, ',', State_code_header));
            Assert.AreEqual("Wrong_File_Extension", actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.4
        /// Wrongs the state of the delimiter compare CSV.
        /// </summary>
        [Test]
        public void Wrong_Delimiter_Compare_CSV_State()
        {
            var obj = CsvsStateFactory.GetInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, state_code_path, '.', State_code_header));
            Assert.AreEqual("Wrong_Delimiter", actual.GetMessage);
        }
        /// <summary>
        /// TestCase 2.5
        /// Wrongs the state of the header compare CSV.
        /// </summary>
        [Test]
        public void wrong_header_Compare_csv_state()
        {
            var obj = CsvsStateFactory.GetInstance("CSVState");
            var actual = Assert.Throws<CensusAnalyserException>(() => delegatebulder(obj, state_code_path, ',', "SrNo,State,Name"));
            Assert.AreEqual("No_Header", actual.GetMessage);
        }
        /// <summary>
        /// CSVs the first state of the state census code data.
        /// </summary>
        [Test]
        public void Csv_state_census_firstState()
        {
            stateanalyser.SortingCsVInJsonFile();
            var value = stateanalyser.Access_Key_Value(0, "State", @"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedStateCensus.json");
            Assert.AreEqual("Andhra Pradesh", value);
        }
        /// <summary>
        /// CSVs the last state of the state census code data .
        /// </summary>
        [Test]
        public void Csv_state_census_lastState()
        {
            var obj1 = CsvsStateFactory.GetInstance("StateCensusAnalyser");
            stateanalyser.SortingCsVInJsonFile();
            int a = stateanalyser.Json_file_count(json_census);
            var value = stateanalyser.Access_Key_Value(a-1, "State", @"D:\Imran\CensusAnalyser\CensusAnalyserTest\SortedStateCensus.json");
            Assert.AreEqual("West Bengal", value);

        }
    }
}