﻿using System;
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
            List<double> studentMarks = new List<double>() { 80, 88, 65, 69, 74, 92, 46, 99, 49 };
            IEnumerable<int> n ;
            double standarddeviation = StandardDeviation(studentMarks);
            Console.WriteLine("The Standard deviation: " + standarddeviation);
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
                            Console.WriteLine("Standard Deviation of a Students Marks:");
                            Console.WriteLine(StandardDeviation(studentMarks));
                            break;

                        case 2:
                            
                            n = PrimeNumbers();
                            Console.WriteLine("Prime Numbers are: ");
                            foreach (var pn in n)
                            {
                                Console.WriteLine(pn);
                            }
                            //Console.Write(n);
                            break;

                        case 3:
                            Console.WriteLine("Odd or Even Number");
                            break;
                        case 4:
                            Console.WriteLine("Fibonacci Series");
                            break;
                        case 5:
                            Console.WriteLine("Factorial of a Number");
                            break;
                        case 6:

                            userinput = 'n';
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
                        //userContinue = true;
                    }
                
                }
                



            catch
            {
                Console.WriteLine("Please enter any number between 1 and 5");

            }
        }
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
