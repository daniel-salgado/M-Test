using System;
using EmployeePaySlipCore.Business;

namespace MYOBTest
{
    class MainClass
    {

        public static void Main(string[] args)
        {

            string fileName;
            string appName = System.AppDomain.CurrentDomain.FriendlyName;

			Console.WriteLine(String.Format("Hello! Welcome to {0}", appName));

            if (args.Length != 1)
            {

                Console.WriteLine("Instructions:");
                Console.WriteLine("1) Prepare and use a CSV file as input, with the same format as in the requirements");
                Console.WriteLine("   * first name, last name, annual salary, super rate (%), payment start date");
                Console.WriteLine("   * David,Rudd,60050,9%,01 March – 31 March");
                Console.WriteLine("2) Execute this program informing the file name and path");
                Console.WriteLine(String.Format("   * Example: {0} {1}", appName, @"C:\Temp\inputFile.csv"));
                Console.WriteLine("Inform the CSV file to process");
                Console.WriteLine(@"Example: MYOB-Test.exe c:\tem\usersSalary.csv");

            }
            else
            {

                fileName = args[0];

                try
                {

                    ProcessIncomeTax procTax = new ProcessIncomeTax { FileName = fileName };

                    procTax.ReadFile();

                    Console.WriteLine(String.Format("{0} records will be processed...", procTax.Count));

                    procTax.Process();

                    if (procTax.Status)
                    {
                        Console.WriteLine("Output file:");
                        Console.WriteLine(procTax.GetemployeePaySlipsInfo());
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.ReadLine();

        }
    }
}
