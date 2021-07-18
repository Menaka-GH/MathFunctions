using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MathFunctions
{
    public static
    class Program
    {
        static void Main(string[] args)
        {
            //reading invoice data file
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "invoice_data.json");
            double ceiling, floor;
            //var fileContents = ReadInvoiceResults(fileName);
            var invoices = DeserializeInvoices(fileName);
           // StandardDeviationInvoice(invoices);
            Console.WriteLine("Electricity Usage");
            Console.WriteLine("*****************");
            foreach (var invoice in invoices)
            {
                Console.WriteLine(invoice.Cost);
            }
            





                //Standard Deviationn calculation
               
            char userinput = 'y';
            while (userinput == 'y')
            {
                try
                {

                    Console.WriteLine(" Please enter any number between 1 and 5 ");
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
                            DateTime startDate = invoiceUsagestartDate(invoices);
                            Console.WriteLine("userdate minus 12 days: "+startDate);
                            var sd = StandardDeviationInvoice(startDate, invoices);
                            Console.WriteLine("Standard Deviation: "+sd);
                            variance(sd);
                            break;

                        case 2:
                            
                            var primeNumbers = PrimeNumbers();
                            Console.WriteLine("Prime Numbers are: ");
                            foreach (var pn in primeNumbers)
                            {
                                Console.Write(pn + " ");
                            }
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine("Odd or Even Number");
                            OddEven();

                            break;
                        case 4:
                            Console.WriteLine("Fibonacci Series: ");
                            Fibonacci();
                            break;
                        case 5:
                            Console.WriteLine("Factorial of a Number");
                            
                            Factorial();
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

        public static void Factorial()
        {
            Console.Write("Please enter a number to find a Factorial: ");
            int number = int.Parse(Console.ReadLine());
            int factorial = number;
            for(int i=factorial - 1; i>=1;i--)
            {
                factorial = factorial * i;
            }
            Console.WriteLine(factorial);

        }

        static void OddEven()
        {
            Console.Write("Please enter a number to find Odd or Even number: ");
            int number = int.Parse(Console.ReadLine());
            if(number % 2 == 0)
            {
                Console.WriteLine($"The number {number} is even.");

            }
            else
            {
                Console.WriteLine($"The number {number} is odd.");
            }
              
        }

        static void variance( double sd)
        {
            //data varianc = diference in deviation and usage / standard deviation* 100;
            //var variant = 
        }
        static List<int> PrimeNumbers()
        {
             List<int> primeNumbers = new List<int>();
            //bool IsPrime = true;
            Console.WriteLine("Please enter a first number to find the prime numbers");

            int firstNumber =int.Parse( Console.ReadLine());
            Console.WriteLine("Please enter a last number to find the prime numbers");
            int lastNumber = int.Parse(Console.ReadLine());
            for(int i=firstNumber; i<=lastNumber;i++)
            {
                int counter = 0;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                        break;
                    }
                    //else 
                }
                if(counter == 0 && i!=1)
                    {
                    {
                       // Console.Write(i);
                        primeNumbers.Add(i);
                    }

                }
            }
            
           return primeNumbers;
        }

        
        public static DateTime invoiceUsagestartDate(List<Invoice> invoices)
        {
            //asking user which month to compare with standard deviation
            Console.WriteLine("Enter the Date of the Utility bill to compare the SD: ");
            Console.WriteLine("Please enter the date in mm/dd/yy format: ");
           // Console.WriteLine("Please enter the date: ");
            
            var userDate = DateTime.Parse(Console.ReadLine());
            //DateTime dt = new DateTime(2017, 7, 20);
            DateTime dt = userDate.AddMonths(-12);
            //Console.WriteLine(dt.ToString());

            Console.WriteLine("user date is: " + dt.ToString());
            return dt;
            
        }
        public static double StandardDeviationInvoice(DateTime stDate, List<Invoice> invoices)
        {

            //linq query 
            DateTime endDate = stDate.AddMonths(12);
            var eD = endDate.ToString();
            var invoiceData = (from inv in invoices where inv.Month>= stDate && inv.Month < endDate
                               select inv  );
            
            Console.WriteLine("Linq query data:  ");
            foreach (var invoice in invoiceData)
            {
                Console.WriteLine(invoice.Usage);

            }
                double mean, sum = 0;
            double sd = 0;
            var totalInvoice = 0;
            foreach (var invoice in invoiceData)
            {
                // calculate sum of invoice usage

                    totalInvoice = totalInvoice + invoice.Usage;
                  
               

            }

            //Average calculation
            Console.WriteLine("Totalinvoice sum: " + totalInvoice);
            mean = totalInvoice / invoiceData.Count();
            Console.WriteLine("Mean : "+mean);
            foreach (var invoice in invoiceData)
            {
                //Console.WriteLine("invoice usage " + invoice.Usage);

                sum = sum + Math.Pow((invoice.Usage - mean),2);

            }
            Console.WriteLine("Sum Ex: " + sum);

            sd = Math.Sqrt((sum) / (invoiceData.Count() - 1));
            Console.WriteLine("Standard deviation: " + sd);
            double ceiling, floor;
            ceiling = mean + 1.96 * sd;
            floor = mean - 1.96 * sd;
            Console.WriteLine("Ceiling: " + ceiling);
            Console.WriteLine("Floor value:  " + floor);





            //data varianc = diference in deviation and usage / standard deviation* 100;
            //Ceiling = avg(x) + 1.96 * StDev(x)//
            //b.Floor = avg(x) – 1.96 * StDev(x)

            return sd;
            
        }
        public static void Fibonacci()
        {
            int n1 = 0, n2 =1;
            Console.Write("Please enter how many numbers do you want in the series? ");
           
            int numberSeries = int.Parse(Console.ReadLine());
            Console.Write(n1 + " " + n2 + " ");
            for (int i=0; i<=numberSeries;i++)
            {
                int resultSeries = n1 + n2;
                n1 = n2;
                n2 = resultSeries;
                Console.Write(resultSeries +" ");
            }
            Console.WriteLine();

        }
        


        public static List<Invoice> DeserializeInvoices(string fileName)
        {

            var invoices = new List<Invoice>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                invoices = serializer.Deserialize<List<Invoice>>(jsonReader);
            }
            return invoices;
        }


    }
}
