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
            //pliki .txt z tablicami znajdą się w folderze Moje Dokumenty
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var array = GenerateArray(rowsCount, colsCount);
            WriteArrayToFile(array, path+"/tablica.txt");
            var arrayFromFile = ReadArrayFromFile(rowsCount, colsCount, path+"/tablica.txt");
            var sortedArray=SortByColumnAveragedSum(arrayFromFile);
            WriteArrayToFile(sortedArray, path+"/tablica_posortowana.txt");
        }

        public static int[,] SortByColumnAveragedSum(int[,] unsortedArray)
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
                }
            }
            return sortedArray;
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
