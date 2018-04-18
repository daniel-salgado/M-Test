using System;

namespace EmployeePaySlipCore.TaxRateDatabase
{
    public class TaxRateDTO
    {

        public double MinIncome { get; set; }
        public double MaxIncome { get; set; }
        public double TaxIncome { get; set; }
        public double AddTaxEachDollar { get; set; }
        public double PreviousBase { get; set; }

    }
}
