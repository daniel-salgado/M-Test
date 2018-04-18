using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeePaySlipCore.Business
{
    public class InputFile
    {

        public bool FileExists { get; private set; }
        public string FileName { get; private set; }

        public InputFile(string fileName)
        {

            this.FileExists = File.Exists(fileName);
            this.FileName = fileName;

        }

        public List<EmployeePaySlip> ProcessFile()
        {

            List<EmployeePaySlip> employeePaySlips = new List<EmployeePaySlip>();

            try
            {

                string[] lines = File.ReadAllLines(this.FileName);

                foreach (string line in lines)
                    if (ValidateLine(line))
                        employeePaySlips.Add(GetValuesFromString(line));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return employeePaySlips;

        }


        private EmployeePaySlip GetValuesFromString(string values)
        {

            EmployeePaySlip employeePaySlip = new EmployeePaySlip();

            try
            {

                string[] splitedValues = values.Split(',');

                employeePaySlip.FirstName = splitedValues[0];
                employeePaySlip.LastName = splitedValues[1];

                double.TryParse(splitedValues[2], out double annualSalary);
                employeePaySlip.AnnualSalary = annualSalary;

                double.TryParse(splitedValues[3].Replace("%", string.Empty), out double superRate);
                employeePaySlip.SuperRate = superRate;

                employeePaySlip.PaymentSartDate = splitedValues[4];

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return employeePaySlip;

        }


        private bool ValidateLine(string line)
        {

            bool validated = true;

            try
            {

                string[] splitedLine = line.Split(',');

                validated &= (splitedLine.Length == 5);
                validated &= (splitedLine[0] != string.Empty && splitedLine[1] != string.Empty && splitedLine[4] != string.Empty);
                validated &= (double.TryParse(splitedLine[2], out double n));
                validated &= (splitedLine[3] != string.Empty && splitedLine[3].Contains("%") && double.TryParse(splitedLine[3].Replace("%", ""), out double n2));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return validated;

        }


    }
}
