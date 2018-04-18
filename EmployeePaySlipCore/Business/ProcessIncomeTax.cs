using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using EmployeePaySlipCore.TaxRateDatabase;
using System.Linq;

namespace EmployeePaySlipCore.Business
{

    public class ProcessIncomeTax
    {

        public string FileName { get; set; }
        public int Count { get; private set; }
        public bool Status { get; private set; }

        private List<EmployeePaySlip> employeePaySlips = new List<EmployeePaySlip>();

        public void ReadFile()
        {

            try
            {

                InputFile file = new InputFile(this.FileName);

                if (file.FileExists)
                {
                    employeePaySlips = file.ProcessFile();
                    this.Count = employeePaySlips.Count;
                }
                else
                {
                    throw new Exception("File doesn't exist ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Process()
        {

            try
            {

                if (this.Count > 0)
                    Calculate();
                else
                    throw new Exception("No employee to process");

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Calculate()
        {

            Parallel.ForEach(employeePaySlips, (item) =>
            {

                try
                {

                    item.GrossIncome = CalculateGrossIncome(item.AnnualSalary);
                    item.IncomeTax = CalculateIncomeTax(item.AnnualSalary);
                    item.NetIncome = CalculateNetIncome(item.GrossIncome, item.IncomeTax);
                    item.Super = CalculateSuper(item.GrossIncome, item.SuperRate);

                    item.StatusDescription = "OK";

                }
                catch (Exception ex)
                {
                    item.StatusDescription = ex.Message;
                }

                this.Status = true;

            });

        }

        public string GetemployeePaySlipsInfo()
        {

            StringBuilder info = new StringBuilder();

            foreach (var item in employeePaySlips)
            {

                string formatedText = "{0} {1},{2},{3},{4},{5},{6}";

                if (item.StatusDescription != "OK")
                    formatedText += ",{7}";

                info.AppendFormat(formatedText
                                  , item.FirstName
                                  , item.LastName
                                  , item.PaymentSartDate
                                  , item.GrossIncome
                                  , item.IncomeTax
                                  , item.NetIncome
                                  , item.Super
                                  , item.StatusDescription);

                info.AppendLine();

            }

            return info.ToString();

        }

        private double CalculateGrossIncome(double annualSalary)
        {

            try
            {
                return Math.Round(annualSalary / 12, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private double CalculateIncomeTax(double annualSalary)
        {

            double incomeTax = 0;
            double taxIncome = 0;
            double addTaxEachDollar = 0;
            double previousBase = 0;

            try
            {

                TaxRatesDAO taxRatesDB = new TaxRatesDAO();

                var resLinQ = (from item in taxRatesDB.TaxRates
                               where annualSalary >= item.MinIncome && annualSalary <= item.MaxIncome
                               select item).ToList();

                if (resLinQ.Count != 1)
                    throw new Exception("Number of rules to calculate the TaxIncome is zero or more than one");

                var resObj = resLinQ[0];

                taxIncome = resObj.TaxIncome;
                previousBase = resObj.PreviousBase;
                addTaxEachDollar = resObj.AddTaxEachDollar;

                incomeTax = (taxIncome + (annualSalary - previousBase) * addTaxEachDollar) / 12;

                incomeTax = Math.Round(incomeTax, 0);

                return incomeTax;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private double CalculateNetIncome(double grossIncome, double incomeTax)
        {

            double netIncome;

            try
            {
                netIncome = Math.Round(grossIncome - incomeTax, 0);
                return netIncome;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private double CalculateSuper(double grossIncome, double superRate)
        {

            double super;

            try
            {
                super = Math.Round(grossIncome * (superRate / 100));
                return super;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }

}
