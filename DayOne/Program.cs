using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DayOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\extern\input.txt";
            string[] puzzleInput = File.ReadAllLines(path);

            List<double> calculatedValues = new List<double>();

            foreach(string input in puzzleInput)
            {
                double inputValue = Convert.ToDouble(input);
                double calculatedValue = FuelEquation(inputValue);

                while (calculatedValue > 0)
                {
                    calculatedValues.Add(calculatedValue);

                    calculatedValue = FuelEquation(calculatedValue);
                }
            }

            double fuelSum = calculatedValues.Sum();           

            Console.WriteLine(fuelSum);


        }

        private static double FuelEquation(double inputValue)
        {
            return Math.Floor(inputValue / 3) - 2;
        }
    }
}
