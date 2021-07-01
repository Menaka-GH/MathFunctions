using System;
using System.Collections.Generic;
using System.Linq;

namespace MathFunctions
{
    public static
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // string userInput = Console.ReadLine();
            //while(userInput!="quit")
            List<double> studentMarks = new List<double>() {80,88,65,69,74,92,46,99,49};
            double standarddeviation = StandardDeviation(studentMarks);
            Console.WriteLine("The Standard deviation: " + standarddeviation);
        }
        static double StandardDeviation(List<double> sMarks)
        {
            double mean,sum, sd;
            mean = sMarks.Average();
            sum = sMarks.Sum(d => Math.Pow(d-mean,2));
            sd = Math.Sqrt((sum) / (sMarks.Count() - 1));
            return sd;
            
        }
        
    }
}
