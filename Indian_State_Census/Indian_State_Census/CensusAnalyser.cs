using Indian_State_Census.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census
{
    public enum Country
    {
        INDIA, US, BRAZIL
    }
    public class CensusAnalyser 
    {
        public static int a = 10;
       
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            //CensusAnalyser obj = new CensusAnalyser();
            //Console.WriteLine(obj.a);
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
