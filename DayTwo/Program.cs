using System;
using System.Linq;

namespace DayTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 99; i++)
            {
                int noun = i;

                for (int j = 0; j < 99; j++)
                {
                    int verb = j;
                    string opCodeString = "1,"
                        + noun +
                        ","
                        + verb + ",3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,19,6,23,2,6,23,27,2,27,9,31,1,5,31,35,1,35,10,39,2,39,9,43,1,5,43,47,2,47,10,51,1,51,6,55,1,5,55,59,2,6,59,63,2,63,6,67,1,5,67,71,1,71,9,75,2,75,10,79,1,79,5,83,1,10,83,87,1,5,87,91,2,13,91,95,1,95,10,99,2,99,13,103,1,103,5,107,1,107,13,111,2,111,9,115,1,6,115,119,2,119,6,123,1,123,6,127,1,127,9,131,1,6,131,135,1,135,2,139,1,139,10,0,99,2,0,14,0";

                    string[] opCodeArrayString = opCodeString.Split(",");
                    int[] opCodeArray = new int[opCodeArrayString.Length];

                    for (int a = 0; a < opCodeArrayString.Length; a++)
                    {
                        opCodeArray[a] = Convert.ToInt32(opCodeArrayString[a]);
                    }

                    for (int k = 0; k < opCodeArray.Length; k += 4)
                    {
                        int opCode = opCodeArray[k];

                        if (opCode == 99)
                        { break; }

                        int inputOnePosition = opCodeArray[k + 1];
                        int inputTwoPosition = opCodeArray[k + 2];
                        int outputPosition =opCodeArray[k + 3];

                        int inputOneValue = opCodeArray[inputOnePosition];
                        int inputTwoValue = opCodeArray[inputTwoPosition];

                        if (opCode == 1) { opCodeArray[outputPosition] = (inputOneValue + inputTwoValue); }
                        else if (opCode == 2) { opCodeArray[outputPosition] = (inputOneValue * inputTwoValue); }
                    }

                    if (opCodeArray[0] == 19690720)
                    { Console.WriteLine(100 * noun + verb); }

                }
            }
        }
    }
}
