using System;
using System.Collections.Generic;

namespace DayFive
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
                    string opCodeString = "3,225,1,225,6,6,1100,1,238,225,104,0,1002,114,46,224,1001,224,-736,224,4,224,1002,223,8,223,1001,224,3,224,1,223,224,223,1,166,195,224,1001,224,-137,224,4,224,102,8,223,223,101,5,224,224,1,223,224,223,1001,169,83,224,1001,224,-90,224,4,224,102,8,223,223,1001,224,2,224,1,224,223,223,101,44,117,224,101,-131,224,224,4,224,1002,223,8,223,101,5,224,224,1,224,223,223,1101,80,17,225,1101,56,51,225,1101,78,89,225,1102,48,16,225,1101,87,78,225,1102,34,33,224,101,-1122,224,224,4,224,1002,223,8,223,101,7,224,224,1,223,224,223,1101,66,53,224,101,-119,224,224,4,224,102,8,223,223,1001,224,5,224,1,223,224,223,1102,51,49,225,1101,7,15,225,2,110,106,224,1001,224,-4539,224,4,224,102,8,223,223,101,3,224,224,1,223,224,223,1102,88,78,225,102,78,101,224,101,-6240,224,224,4,224,1002,223,8,223,101,5,224,224,1,224,223,223,4,223,99,0,0,0,677,0,0,0,0,0,0,0,0,0,0,0,1105,0,99999,1105,227,247,1105,1,99999,1005,227,99999,1005,0,256,1105,1,99999,1106,227,99999,1106,0,265,1105,1,99999,1006,0,99999,1006,227,274,1105,1,99999,1105,1,280,1105,1,99999,1,225,225,225,1101,294,0,0,105,1,0,1105,1,99999,1106,0,300,1105,1,99999,1,225,225,225,1101,314,0,0,106,0,0,1105,1,99999,1107,226,677,224,102,2,223,223,1006,224,329,101,1,223,223,1108,226,677,224,1002,223,2,223,1005,224,344,101,1,223,223,8,226,677,224,102,2,223,223,1006,224,359,1001,223,1,223,1007,226,677,224,1002,223,2,223,1005,224,374,101,1,223,223,1008,677,677,224,1002,223,2,223,1005,224,389,1001,223,1,223,1108,677,226,224,1002,223,2,223,1006,224,404,1001,223,1,223,1007,226,226,224,1002,223,2,223,1005,224,419,1001,223,1,223,1107,677,226,224,1002,223,2,223,1006,224,434,101,1,223,223,108,677,677,224,1002,223,2,223,1005,224,449,1001,223,1,223,1107,677,677,224,102,2,223,223,1005,224,464,1001,223,1,223,108,226,226,224,1002,223,2,223,1006,224,479,1001,223,1,223,1008,226,226,224,102,2,223,223,1005,224,494,101,1,223,223,108,677,226,224,102,2,223,223,1005,224,509,1001,223,1,223,8,677,226,224,1002,223,2,223,1006,224,524,101,1,223,223,7,226,677,224,1002,223,2,223,1006,224,539,101,1,223,223,7,677,226,224,102,2,223,223,1006,224,554,1001,223,1,223,7,226,226,224,1002,223,2,223,1006,224,569,101,1,223,223,107,677,677,224,102,2,223,223,1006,224,584,101,1,223,223,1108,677,677,224,102,2,223,223,1006,224,599,1001,223,1,223,1008,677,226,224,1002,223,2,223,1005,224,614,1001,223,1,223,8,677,677,224,1002,223,2,223,1006,224,629,1001,223,1,223,107,226,677,224,1002,223,2,223,1006,224,644,101,1,223,223,1007,677,677,224,102,2,223,223,1006,224,659,101,1,223,223,107,226,226,224,1002,223,2,223,1006,224,674,1001,223,1,223,4,223,99,226";

                    string[] opCodeArrayString = opCodeString.Split(",");
                    int[] opCodeArray = new int[opCodeArrayString.Length];

                    for (int a = 0; a < opCodeArrayString.Length; a++)
                    {
                        opCodeArray[a] = Convert.ToInt32(opCodeArrayString[a]);
                    }

                    List<int> instructionWriteLocations = new List<int>();

                    int pointerChange = 4;

                    for (int k = 0; k < opCodeArray.Length; k += pointerChange)
                    {
                        string instruction = opCodeArray[k].ToString();
                        int inLen = instruction.Length;

                        int opCode = Convert.ToInt32(instruction);

                        if (opCode == 99)
                        { break; }

                        int firstParameter = opCodeArray[k + 1];
                        int inputOneValue = 0;


                        int secondParameter = opCodeArray[k + 2];
                        int inputTwoValue = 0;

                        int thirdParameter = 0;
                        if (opCode !=3 && opCode != 4)
                        {
                            thirdParameter = opCodeArray[k + 3];
                        }

                        int firstParameterMode = 0;

                        if (inLen > 2)
                        {
                            opCode = Convert.ToInt32(instruction.Substring(inLen - 2, 2));
                            firstParameterMode = Convert.ToInt32(instruction.Substring(inLen - 3, 1));
                        }


                        if (opCode != 3 && opCode != 4)
                        {
                            int secondParameterMode = 0;

                            if (inLen > 2)
                            {
                                secondParameterMode = inLen > 3 ? Convert.ToInt32(instruction.Substring(inLen - 4, 1)) : 0;
                            }

                            if (opCode == 99)
                            { break; }

                            if (instructionWriteLocations.Contains(k + 1)) { firstParameterMode = 0; }
                            if (instructionWriteLocations.Contains(k + 2)) { secondParameterMode = 0; }

                            firstParameter = opCodeArray[k + 1];
                            inputOneValue = 0;

                            if (firstParameterMode == 0)
                            {
                                inputOneValue = opCodeArray[firstParameter];
                            }
                            else if (firstParameterMode == 1)
                            {
                                inputOneValue = firstParameter;
                            }

                            secondParameter = opCodeArray[k + 2];
                            inputTwoValue = 0;

                            if (secondParameterMode == 0)
                            {
                                inputTwoValue = opCodeArray[secondParameter];
                            }
                            else if (secondParameterMode == 1)
                            {
                                inputTwoValue = secondParameter;
                            }

                            pointerChange = 4;
                        }
                        else if(opCode == 1 || opCode == 2)
                        {
                            inputOneValue = opCodeArray[firstParameter];
                            inputTwoValue = opCodeArray[secondParameter];
                            pointerChange = 4;
                        }


                        if (opCode == 1)
                        {
                            opCodeArray[thirdParameter] = (inputOneValue + inputTwoValue);
                            instructionWriteLocations.Add(thirdParameter);
                        }
                        if (opCode == 2)
                        {
                            opCodeArray[thirdParameter] = (inputOneValue * inputTwoValue);
                            instructionWriteLocations.Add(thirdParameter);
                        }

                        if (opCode == 3)
                        {
                            pointerChange = 2;
                            opCodeArray[opCodeArray[k + 1]] = Convert.ToInt32(Console.ReadLine());
                            //instructionWriteLocations.Add(opCodeArray[k + 1]);
                        }
                        if (opCode == 4)
                        {
                            pointerChange = 2;

                            if(firstParameterMode == 0)
                            {
                                Console.WriteLine(opCodeArray[opCodeArray[k + 1]]);
                            }
                            else if(firstParameterMode == 1)
                            {
                                Console.WriteLine(opCodeArray[k + 1]);
                            }
                        }
                        if(opCode == 5)
                        {
                            if (inputOneValue != 0)
                            {
                                k = inputTwoValue;
                                pointerChange = 0;
                            }
                            else
                            {
                                pointerChange = 3;
                            }
                        }
                        if (opCode == 6)
                        {
                            if (inputOneValue == 0)
                            {
                                k = inputTwoValue;
                                pointerChange = 0;
                            }
                            else
                            {
                                pointerChange = 3;
                            }
                        }
                        if(opCode == 7)
                        {
                            if (inputOneValue < inputTwoValue) { opCodeArray[thirdParameter] = 1; }
                            else { opCodeArray[thirdParameter] = 0; }
                            //instructionWriteLocations.Add(thirdParameter);
                        }
                        if (opCode == 8)
                        {
                            if (inputOneValue == inputTwoValue) { opCodeArray[thirdParameter] = 1; }
                            else { opCodeArray[thirdParameter] = 0; }
                            //instructionWriteLocations.Add(thirdParameter);
                        }




                    }

                    if (opCodeArray[0] == 19690720)
                    { Console.WriteLine(100 * noun + verb); }

                }
            }
        }
    }
}
