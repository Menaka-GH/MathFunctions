using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathFunctions
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //reading invoice data file
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "invoice_data.json");
            //Creating object for the class "Number"
            Number num = new Number();
            var invoices =num.DeserializeInvoices(fileName);
           // StandardDeviationInvoice(invoices);           
            
           //Master Loop
               
            char userinput = 'y';
            while (userinput == 'y')
            {
                try
                {
                    Console.WriteLine("                                        MATHEMATICAL FUNCTIONS");
                    Console.WriteLine("                                       ************************");
                    Console.WriteLine("Please enter any number between 1 and 5 ");
                    Console.WriteLine("******************************************");


                    Console.WriteLine("1. Standard Deviation");
                    Console.WriteLine("2. Prime Numbers");
                    Console.WriteLine("3. Odd or Even");
                    Console.WriteLine("4. Fibonacci Series");
                    Console.WriteLine("5. Factorial of a Number");
                    Console.WriteLine("6. Quit");
                    Console.Write("Please enter your choice: ");
                    int userChoice = int.Parse(Console.ReadLine());


                    switch (userChoice)
                    {

                        case 1:
                            Console.WriteLine("Standard Deviation of a Utility bill:");
                            Console.WriteLine("*************************************");
                            DateTime startDate =num.invoiceUsagestartDate(invoices);
                            Console.WriteLine("userdate minus 12 days: "+startDate);
                            var sd = num.StandardDeviationInvoice(startDate, invoices);
                            Console.WriteLine("Standard Deviation: "+sd);
                            validData(mean,sd);
                            break;

                        case 2:
                            
                            var primeNumbers = num.PrimeNumbers();
                            Console.WriteLine("Prime Numbers are: ");
                            foreach (var pn in primeNumbers)
                            {
                                Console.Write(pn + " ");
                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine("Odd or Even Number");
                            num.OddEven();

                            break;
                        case 4:
                            Console.WriteLine("Fibonacci Series: ");
                            num.Fibonacci();
                            break;
                        case 5:
                            Console.WriteLine("Factorial of a Number");
                            
                            num.Factorial();
                            break;
                        case 6:

                            userinput = 'n';
                            Console.ReadKey();
                            
                            break;


                        default:
                            Console.WriteLine("No match found");
                            break;

                    }

                    try
                    {
                        if (userChoice == 6)
                        {
                            break;

                        }
                        else
                        {
                            Console.WriteLine("Do you want to continue? y/n: ");
                            char userYN = char.Parse(Console.ReadLine());
                            if (userYN == 'y')
                            {
                                continue;
                            }

                            else
                            {
                                break;
                            }

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter y or n.");
                        
                    }
                
                }
                



            catch
            {
                Console.WriteLine("Please enter any number between 1 and 5");

            }
        }
        }

        


    }
}
