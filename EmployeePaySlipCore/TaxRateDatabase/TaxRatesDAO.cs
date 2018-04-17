using System;
using System.Collections.Generic;

namespace EmployeePaySlipCore.TaxRateDatabase
{
    public class TaxRatesDAO
    {
        
        public List<TaxRateDTO> TaxRates = new List<TaxRateDTO>();
       
        public TaxRatesDAO()
        {
            LoadDummyData();
        }

        private void LoadDummyData()
        {

            TaxRates.Add(new TaxRateDTO
            {
                MinIncome = 0,
                MaxIncome = 18200,
                AddTaxEachDollar = 0,
                PreviousBase = 0,
                TaxIncome = 0,
            });

            TaxRates.Add(new TaxRateDTO
            {
                MinIncome = 18201,
                MaxIncome = 37000,
                AddTaxEachDollar = 0.19,
                PreviousBase = 18200,
                TaxIncome = 0,
            });

            TaxRates.Add(new TaxRateDTO
            {
                MinIncome = 37001,
                MaxIncome = 87000,
                AddTaxEachDollar = 0.352,
                PreviousBase = 37000,
                TaxIncome = 3572,
            });

            TaxRates.Add(new TaxRateDTO
            {
                MinIncome = 87001,
                MaxIncome = 180000,
                AddTaxEachDollar = 0.37,
                PreviousBase = 87000,
                TaxIncome = 19822,
            });

            TaxRates.Add(new TaxRateDTO
            {
                MinIncome = 180001,
                MaxIncome = 999999999,
                AddTaxEachDollar = 0.45,
                PreviousBase = 180000,
                TaxIncome = 54232,
            });


        }


    }
}
