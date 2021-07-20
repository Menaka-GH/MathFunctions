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
        public void Factorial()
        {
            Console.Write("Please enter a number to find a Factorial: ");
            number = int.Parse(Console.ReadLine());
            int factorial = number;
            for (int i = factorial - 1; i >= 1; i--)
            {
                factorial = factorial * i;
            }
            Console.WriteLine(factorial);

        }

        public void OddEven()
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

        static void variance(double sd)
        {
            //data varianc = diference in deviation and usage / standard deviation* 100;
            //var variant = 
        }
        public List<int> PrimeNumbers()
        {
            List<int> primeNumbers = new List<int>();
            //bool IsPrime = true;
            Console.WriteLine("Please enter a first number to find the prime numbers");

            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a last number to find the prime numbers");
            int lastNumber = int.Parse(Console.ReadLine());
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
                    //else 
                }
                if (counter == 0 && i != 1)
                {
                    {
                        // Console.Write(i);
                        primeNumbers.Add(i);
                    }

                }
            }

            return primeNumbers;
        }


        public DateTime invoiceUsagestartDate(List<Invoice> invoices)
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
        public double StandardDeviationInvoice(DateTime stDate, List<Invoice> invoices)
        {

            //linq query 
            DateTime endDate = stDate.AddMonths(12);
            var eD = endDate.ToString();
            var invoiceData = (from inv in invoices
                               where inv.Month >= stDate && inv.Month < endDate
                               select inv);

            Console.WriteLine("Linq query data:  ");
            foreach (var invoice in invoiceData)
            {
                Console.WriteLine(invoice.Usage);

            }
            double mean, sum = 0;
            double sd = 0,total;
            total = TotalInvoice(invoiceData);

            //Average(Mean) calculation
            
            
            foreach (var invoice in invoiceData)
            {
                //Console.WriteLine("invoice usage " + invoice.Usage);

                sum = sum + Math.Pow((invoice.Usage - dataMean(total, invoiceData)), 2);

            }
            Console.WriteLine("Sum Ex: " + sum);

            sd = Math.Sqrt((sum) / (invoiceData.Count() - 1));
            Console.WriteLine("Standard deviation: " + sd);
            




            //data varianc = diference in deviation and usage / standard deviation* 100;
            //Ceiling = avg(x) + 1.96 * StDev(x)//
            //b.Floor = avg(x) – 1.96 * StDev(x)

            return sd;

        }
        double dataMean(double total, IEnumerable<Invoice> invoiceData)
        {
            double mean = total / invoiceData.Count();
            Console.WriteLine("Mean : " + mean);
            return mean;
        }
        
        void validData(double mean,double sd)
        {
            double ceiling, floor;
            ceiling = mean + 1.96 * sd;
            floor = mean - 1.96 * sd;
            Console.WriteLine("Ceiling: " + ceiling);
            Console.WriteLine("Floor value:  " + floor);

        }
        double TotalInvoice(IEnumerable<Invoice> invoiceData)
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
            Console.Write("Please enter how many numbers do you want in the series? ");

            int numberSeries = int.Parse(Console.ReadLine());
            Console.Write(n1 + " " + n2 + " ");
            for (int i = 0; i <= numberSeries; i++)
            {
                int resultSeries = n1 + n2;
                n1 = n2;
                n2 = resultSeries;
                Console.Write(resultSeries + " ");
            }
            Console.WriteLine();

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
