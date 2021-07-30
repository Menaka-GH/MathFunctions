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
                    Console.WriteLine("                                       ************************");
                    Console.WriteLine("                                        MATHEMATICAL FUNCTIONS");
                    Console.WriteLine("                                       ************************");
                    Console.WriteLine("Please choose any number between 1 and 6 ");
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
                            Console.WriteLine("userdate minus 12 Months: "+startDate);
                           
                            var sd = num.StandardDeviationInvoice(startDate, invoices);
                            
                            var ceiling = num.Ceilingvalue(num.mean,sd);
                            var floor = num.Floorvalue(num.mean,sd);
                            num.validData(ceiling,floor, invoices);
                            break;

                        case 2:

                            Console.WriteLine("Prime Numbers");
                            Console.WriteLine("*************");
                            num.PrimeNumbers();
                            break;

                        case 3:
                            Console.WriteLine("Odd or Even Number");
                            Console.WriteLine("******************");
                            num.OddEven();
                            break;
                        case 4:
                            Console.WriteLine("Fibonacci Series: ");
                            Console.WriteLine("*****************");
                            num.Fibonacci();
                            break;
                        case 5:
                            Console.WriteLine("Factorial of a Number");
                            Console.WriteLine("*********************");

                            num.Factorial();
                            break;
                        case 6:

                            userinput = 'n';
                            Console.WriteLine("Thank you!!");
                            
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
                                Console.WriteLine("Thank you!!");
                                break;
                            }

                        }
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine("Please enter y or n.");
                        
                    }
                
                }
                



            catch
            {
                Console.WriteLine("Please enter any number between 1 and 6");

            }
        }
        }

        


    }
}
