using System;
namespace EmployeePaySlipCore.Business
{
    public class EmployeePaySlip
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double AnnualSalary { get; set; }
        public double SuperRate { get; set; }
        public string PaymentSartDate { get; set; }

        public string PayPeriod { get; set; }
        public double GrossIncome { get; set; }
        public double IncomeTax { get; set; }
        public double NetIncome { get; set; }
        public double Super { get; set; }

        public EmployeePaySlip()
        {
        }
    }
}
