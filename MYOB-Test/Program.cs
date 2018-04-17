using System;
using System.Text;
using EmployeePaySlipCore;
using EmployeePaySlipCore.Business;

namespace MYOBTest
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            string fileName = "usersSalary.csv";

            try
            {

                Processing processing = new Processing
                {
                    FileName = fileName
                };

                processing.Process();

                Console.WriteLine(processing.GetemployeePaySlipsInfo());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
