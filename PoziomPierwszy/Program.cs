using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace PoziomPierwszy
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = 3;
            int colsCount = 7;
            var array = GenerateArray(rowsCount, colsCount);
            WriteArrayToFile(array, "D:/tablica.txt");
            var arrayFromFile = ReadArrayFromFile(rowsCount, colsCount, "D:/tablica.txt");
            SortByColumnAveragedSumAndWriteToFile(arrayFromFile, "D:/posortowana.txt");
        }

        public static void SortByColumnAveragedSumAndWriteToFile(int[,] unsortedArray, string fileLocation)
        {
            List<Tuple<int, double>> rowToAveragedValue = new List<Tuple<int, double>>();
            int[,] sortedArray = new int[unsortedArray.GetUpperBound(0)+1, unsortedArray.GetUpperBound(1)+1];
            for (int i = 0; i <= unsortedArray.GetUpperBound(1); i++)
            {
                int divider = 0;
                int sum = 0;
                for (int j = 0; j <= unsortedArray.GetUpperBound(0); j++)
                {
                    sum = sum + unsortedArray[j, i];
                    divider++;
                }
                rowToAveragedValue.Add(new Tuple<int,double>(i,sum/divider));
            }
            var orderedRowToAveragedValue=rowToAveragedValue.OrderByDescending(x => x.Item2);
            for (int i = 0; i <= unsortedArray.GetUpperBound(1); i++)
            {
                for (int j = 0; j <= unsortedArray.GetUpperBound(0); j++)
                {
                    sortedArray[j, i] = unsortedArray[j, orderedRowToAveragedValue.ElementAt(i).Item1];
                    Console.WriteLine("");
                }
            }
            WriteArrayToFile(sortedArray, fileLocation);
        }
        public static int[,] ReadArrayFromFile(int width, int height, string fileLocation)
        {
            int[,] array = new int[width, height];
            var content = File.ReadAllLines(fileLocation);
            for (int i=0; i<content.Count(); i++)
            {
                var row = content.ElementAt(i).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                for (int j=0; j<row.Count(); j++)
                {
                    array[i, j] = Convert.ToInt32(row[j]);
                }
            }
            return array;
        }

        public static void WriteArrayToFile(int[,] array, string fileLocation)
        {
            using (StreamWriter sw = new StreamWriter(fileLocation))
            {
                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= array.GetUpperBound(1); j++)
                    {
                        sw.Write(array[i, j]+"  ");
                    }
                    sw.WriteLine();
                }
            }
        }
        public static int[,] GenerateArray(int width, int height)
        {
            int[,] generatedArray = new int[width, height];
            Random rnd = new();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    generatedArray[i, j] = rnd.Next(100);
                }
            }
            return generatedArray;
        }

    }
}
