
# M-Test

## Console application

I choose conlose application due to its simplicity to develop.

## Architecture

Although this is a small application, I separated in a way that could be easy to mantain.
The solution is composed by an excutable file and 2 DLLs

### MYOB-Test.exe

Will do the user interface. A console application might not be the most appropriated to some users, but it is possible to develop a UI and still will work properly.

### EmployeePaySlipCore.dll

This dll is responsible to:
* Read the CSV file
* Check if there is any data to process
* Calculate the income tax

And it is separated in 3 classes:
* InputFile.cs => Resposible for reading the input file and get values from it
* ProcessIncomeTax.cs => Responsible for the calculations
* EmployeePaySlip.cs => Class that is used as object model

### TaxRateDatabase.dll

I created this mock database in order to simulate retrieving the calculation rules from database.

* TaxRateDTO.cs => Class to hold an object model
* TaxRateDAO.cs => Class which is possible to add and retrieve the calculation rules

## Instructions
1.  Prepare and use a CSV file as input, with the same format as in the requirements
* first name, last name, annual salary, super rate (%), payment start date
* David,Rudd,60050,9%,01 March – 31 March
2. Execute this program informing the file name and path
* Example: MYOB-Test.exe c:\tmp\usersSalary.csv

## Considerations

### Numeric values

Although the numeric values on the requirements are integers, I developed using the datatype double so the Round(0) would be more accurate.

### Payment start date & pay period

Firtly I understood that the payment start date would be a given date and the period would be calculated somehow, however, I noticed that the both fields are the same in input and output. For that reason I kept the same value.

