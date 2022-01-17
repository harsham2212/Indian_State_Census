using Indian_State_Census.POCO;
using Indian_State_Census.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static Indian_State_Census.CensusAnalyser;
using Indian_State_Census;

namespace CensusAnalyserTestCase
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State,Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"E:\BridgeLAbz\demo\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\harsh\IndiaStateCensusData.csv";
        static string wrongHeaderStateCodeFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\harsh\IndiaStateCensusData\.csv";
        static string wrongIndianStateCensusFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\harsh\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\IndiaStateCode.csv";
        static string delimeterIndianStateCodeFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\DelimeterIndiaStateCode.csv";
        static string delimeterIndiaCensusFilePath = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\harsh\IndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"E:\BridgeLAbz\Git\Indian_State_Census\CensusAnalyserTestCase\CSVfiles\harsh\IndiaStateCensusData\.csv";

        Indian_State_Census.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new Indian_State_Census.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_shouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath,Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29,totalRecord.Count);
            Assert.AreEqual(29, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_shouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath,Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_shouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenDelimeterNotProper_shouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimeterIndiaCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimeterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenHeaderNotProper_shouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
    }
}