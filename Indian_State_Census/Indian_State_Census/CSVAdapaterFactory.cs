using Indian_State_Census.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census
{
    class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                //case (CensusAnalyser.Country.US):
                //    return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
