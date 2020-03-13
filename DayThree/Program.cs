using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DayThree
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\extern\testInput1.txt";
            string[] puzzleInput = File.ReadAllLines(path);

            Console.WriteLine(puzzleInput[0]);
            Console.WriteLine(puzzleInput[1]);
            
            var taxicabDirections = puzzleInput[0].Split(",");
            var points1 = AddPointsToList(taxicabDirections);

            taxicabDirections = puzzleInput[1].Split(",");
            var points2 = AddPointsToList(taxicabDirections);

            var intersectionList = new List<Point>();

            var stepList1 = new List<int>();

            int counter1 = 0;
            int counter2 = 0;

            foreach (var point1 in points1)
            {
                counter1 += 1;
                counter2 = 0;
                foreach (var point2 in points2)
                {
                    counter2 += 1;

                    if (point1.x == point2.x && point1.y == point2.y)
                    {
                        intersectionList.Add(point1);

                        stepList1.Add(counter1 + counter2);
                    }
                }
            }

            var stepList2 = new List<int>();
            counter2 = 0;
            foreach (var point2 in points2)
            {
                counter2 += 1;
                counter1 = 0;
                foreach (var point1 in points1)
                {
                    counter1 += 1;

                    if (point1.x == point2.x && point1.y == point2.y)
                    {
                        intersectionList.Add(point1);

                        stepList2.Add(counter1 + counter2);
                    }
                }
            }

            var distanceList = new List<int>();

            foreach(var intersection in intersectionList)
            {
                int distance = Convert.ToInt32(Math.Abs(intersection.x) + Math.Abs(intersection.y));
                Console.Write(distance);
                distanceList.Add(distance);
            }

            var orderedDistance = distanceList.OrderBy(x => x).ToList();

            Console.WriteLine(orderedDistance[0]);
            Console.WriteLine(stepList1[0]);
            Console.WriteLine(stepList2[0]);
        }

        private static List<Point> AddPointsToList(string[] taxicabDirections)
        {
            Point lastPoint = new Point(0, 0);
            List<Point> points = new List<Point>() { };

            foreach (string direction in taxicabDirections)
            {
                string directionChar = direction.ToCharArray()[0].ToString();

                int directionValue = Convert.ToInt32(direction.Substring(1));

                List<Point> nextPoints = PointsFromDirection(directionChar, directionValue, lastPoint);

                points.AddRange(nextPoints);

                lastPoint = nextPoints[nextPoints.Count - 1];
            }

            return points;
        }

        private static List<Point> PointsFromDirection(string directionChar, int directionValue, Point lastPoint)
        {
            List<Point> newPoints = new List<Point>();

            for (int i = 1; i <= directionValue; i++)
            {
                switch (directionChar)
                {
                    case "R":
                        newPoints.Add(new Point(lastPoint.x + i, lastPoint.y));
                        break;

                    case "L":
                        newPoints.Add(new Point(lastPoint.x - i, lastPoint.y));
                        break;

                    case "D":
                        newPoints.Add(new Point(lastPoint.x, lastPoint.y - i));
                        break;

                    case "U":
                        newPoints.Add(new Point(lastPoint.x, lastPoint.y + directionValue));
                        break;

                    default:
                        throw new Exception("invalid direction char");
                }
            }

            return newPoints;
        }
    }
}
