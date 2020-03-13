using System;
using System.Collections.Generic;

namespace DayFour
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputStart = 246540;
            int inputEnd = 787419;


            int passwordCounter = 0;

            for (int i = inputStart; i <= inputEnd; i++)
            {
                List<int> intArray = new List<int>();

                foreach (char intString in i.ToString().ToCharArray())
                {
                    intArray.Add(Convert.ToInt32(intString.ToString()));
                }

                int lastNumber = intArray[0];

                bool doubleCheck = false;
                bool increasing = true;

                for (int j = 1; j < intArray.Count; j++)
                {
                    if (lastNumber == intArray[j])
                    {
                        var intCounter = 0;

                        foreach(int check in intArray)
                        {
                            if (check == intArray[j])
                            {
                                intCounter += 1;
                            }
                        }

                        if (intCounter == 2) { doubleCheck = true; }
                    };

                    if (lastNumber > intArray[j]) { increasing = false; }

                    lastNumber = intArray[j];
                }

                if (doubleCheck && increasing)
                {
                    passwordCounter += 1;
                }
            }

            Console.WriteLine(passwordCounter);
        }
    }
}
