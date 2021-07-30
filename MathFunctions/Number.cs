using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MathFunctions
{
    public class Number
    {
        public int number;
        public DateTime userDate;
        public IEnumerable<Invoice> userData;
        public double mean;
        public void Factorial()
        {
            bool x = true;
            while (x)
            {

                try
                {
                    Console.Write("Please enter a number to find a Factorial: ");

                    number = int.Parse(Console.ReadLine());
                    int factorial = number;
                    for (int i = factorial - 1; i >= 1; i--)
                    {
                        factorial = factorial * i;
                    }
                    Console.WriteLine("Factorial of "+number+" is: "+factorial);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter only the numbers..");
                    continue;
                }
                x = false;
            }

        }

        public void OddEven()
        {
             bool x = true;
            while (x)
            {
                try
                {
                    Console.Write("Please enter a number to find Odd or Even number: ");

                    number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    Console.WriteLine($"The number {number} is even.");

                }
                else
                {
                    Console.WriteLine($"The number {number} is odd.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter only the numbers..");
                continue;
            }
            x = false;
        }
      }

        
        public void PrimeNumbers()
        {
            List<int> primeNumbers = new List<int>();
            //bool IsPrime = true;
            
            bool x = true;
            while (x) {
                try
                {
                   // bool y = true;
                    //while (y)
                    //{
                        Console.WriteLine("Please enter a first number : ");
                        int firstNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter a last number: ");
                        int lastNumber = int.Parse(Console.ReadLine());
                        if (firstNumber > lastNumber )
                        {
                            for(int i = lastNumber; i <= firstNumber; i++)
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
                                if (counter == 0 && i != 1 && i!=0)
                                {
                                    {
                                        // Console.Write(i);
                                        primeNumbers.Add(i);
                                    }

                                }
                            }
                        }

                        
                        else
                        {
                            for (int i = firstNumber; i <= lastNumber; i++)
                            {
                                int counter = 0;
                                for (int j = 2; j <= i / 2; j++)
                                {
                                    if (i % j == 0)
                                    {
                                        counter++;
                                        break;
                                    }
                                  
                                }
                                if (counter == 0 && i != 1 && i != 0)
                                {
                                    {
                                        // Console.Write(i);
                                        primeNumbers.Add(i);
                                    }

                                }
                            }
                        }


                        Console.WriteLine("Prime numbers between " + firstNumber + " and " + lastNumber + " are: ");
                        //Console.WriteLine("Prime Numbers are: ");
                        foreach (var pn in primeNumbers)
                        {
                            Console.Write(pn + " ");
                        }
                        Console.WriteLine();
                        //y = false;
                    }

               // }

                catch
                {
                    Console.WriteLine("Please enter only the numbers..");
                    continue;

                }
            x = false;
        }
            
            //return primeNumbers;

        }


        public DateTime invoiceUsagestartDate(List<Invoice> invoices)
        {
            //asking user which month to compare with standard deviation
            DateTime dt;
           

            Console.WriteLine("Enter the Date of the Utility bill to compare the SD: ");
            Console.WriteLine("Please enter the date in mm/1/yy format and Please choose any of the following dates: ");
            Console.WriteLine("1. 8/1/19,9/1/19, 10/1/19, 11/1/19, 12/1/19  ");
            Console.WriteLine("2. 1/1/20, 2/1/20, 3/1/20, 4/1/20, 5/1/20, 6/1/20");
            Console.WriteLine("3. 7/1/20, 8/1/20, 9/1/20, 10/1/20, 11/1/20, 12/1/20");
            Console.WriteLine("2. 1/1/21, 2/1/21, 3/1/21, 4/1/21, 5/1/21, 6/1/21, 7/1/21");
            userDate = DateTime.Parse(Console.ReadLine());
                

            //dt = new DateTime(2017, 7, 20);
            dt = userDate.AddMonths(-12);
                //Console.WriteLine(dt.ToString());

                //Console.WriteLine("user date is: " + dt.ToString());
                
            
            return dt;

        }
        public double StandardDeviationInvoice(DateTime stDate, List<Invoice> invoices)
        {

            //linq query 
            DateTime endDate = stDate.AddMonths(12);
            var eD = endDate.ToString();
            var userData = (from inv in invoices where inv.Month == stDate select inv);
            
            var invoiceData = (from inv in invoices
                               where inv.Month >= stDate && inv.Month < endDate
                               select inv);
           // Console.WriteLine("userData: " );
            // Console.WriteLine("Linq query data:  ");
            // foreach (var ud in userData)
            //{
             // Console.WriteLine(ud.Usage);
//            }
            double  sum = 0;
            double sd = 0,total;
            total = TotalInvoice(invoiceData);

            //Average(Mean) calculation

            //Console.WriteLine(" ");
            foreach (var invoice in invoiceData)
            {
                //Console.WriteLine("invoice usage " + invoice.Usage);

                sum = sum + Math.Pow((invoice.Usage - dataMean(total, invoiceData)), 2);

            }
            Console.WriteLine("Sum of Invoice data: " + sum);

            sd = Math.Sqrt((sum) / (invoiceData.Count() - 1));
            Console.WriteLine("Standard deviation: " + sd);
            




            //data varianc = diference in deviation and usage / standard deviation* 100;
            //Ceiling = avg(x) + 1.96 * StDev(x)//
            //b.Floor = avg(x) – 1.96 * StDev(x)

            return sd;

        }
         public void validData(double ceiling, double floor,List<Invoice> invoices)
        {
            userData = (from inv in invoices where inv.Month == userDate select inv);


            //Console.WriteLine("userData: ");
            // Console.WriteLine("Linq query data:  ");
            foreach (var ud in userData)
            {
                Console.WriteLine("userData: "+ud.Usage);
                if(ceiling >= ud.Usage && floor<= ud.Usage)
                {
                    Console.WriteLine("The data usage "+ ud.Usage
                    + " for the userdate is valid data");
                }
                else
                {
                    Console.WriteLine("The data usage " + ud.Usage
                    + " for the userdate is not valid data");
                }
            }
            //	If the data is within the floor and the ceiling, it is considered valid and the test is passed
            // Floor <= current data point <= Ceiling
            //If the data is outside the floor or the ceiling, the test fails, and is reflected in the open tests
            //Current data point<floor or Current data point > ceiling

        }
        public double dataMean(double total, IEnumerable<Invoice> invoiceData)
        {
            mean = total / invoiceData.Count();
            //Console.WriteLine("Mean : " + mean);
            return mean;
        }
        
        public double Ceilingvalue(double mean,double sd)
        {
            double ceiling;
            ceiling = mean + 1.96 * sd;
            
            Console.WriteLine("Ceiling: " + ceiling);
            //Console.WriteLine("Floor value:  " + floor);
            
            return ceiling;


        }
        public double Floorvalue(double mean, double sd)
        {
            double  floor;
            //ceiling = mean + 1.96 * sd;
            floor = mean - 1.96 * sd;
           // Console.WriteLine("Ceiling: " + ceiling);
            Console.WriteLine("Floor value:  " + floor);
            //	If the data is within the floor and the ceiling, it is considered valid and the test is passed
            // Floor <= current data point <= Ceiling
            //If the data is outside the floor or the ceiling, the test fails, and is reflected in the open tests
            //Current data point<floor or Current data point > ceiling

            return floor;

        }
        public double TotalInvoice(IEnumerable<Invoice> invoiceData)
        {
            var totalInvoice = 0;
            foreach (var invoice in invoiceData)
            {
                // calculate sum of invoice usage

                totalInvoice = totalInvoice + invoice.Usage;

            }
            Console.WriteLine("Totalinvoice sum: " + totalInvoice);
            return totalInvoice;
        }
        public void Fibonacci()
        {
            int n1 = 0, n2 = 1;
             bool x = true;
            while (x)
            {
                try
                {
                    Console.Write("Please enter how many numbers do you want in the series? ");

                    int numberSeries = int.Parse(Console.ReadLine());
                    
                    Console.Write("Fibonacci series: "+n1 + " " + n2 + " ");
                    for (int i = 0; i <= numberSeries; i++)
                    {
                        int resultSeries = n1 + n2;
                       
                            n1 = n2;
                            n2 = resultSeries;
                            Console.Write(resultSeries + " ");
                       
                    }
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter only the numbers..");
                    continue;
                }
                x = false;
            }
}



        public List<Invoice> DeserializeInvoices(string fileName)
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
