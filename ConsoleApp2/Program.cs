using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4HomeWorkConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows;
            int numColums;
            int[,] matricaA, matricaB, matricaSum;

            while (true)
            {
                Console.WriteLine("Введите число строк матрицы : ");
                string strNum = Console.ReadLine();
                if (int.TryParse(strNum, out numRows))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Ошибка ввода : {strNum} - не целое число");
                }
            }
            while (true)
            {
                Console.WriteLine("\nВведите число столбцов матрицы : ");
                string strNum = Console.ReadLine();
                if (int.TryParse(strNum, out numColums))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Ошибка ввода : {strNum} - не целое число");
                }
            }

            matricaA = new int[numRows, numColums];
            matricaB = new int[numRows, numColums];
            matricaSum = new int[numRows, numColums];
            Random r = new Random();
            int i, j;

            Console.WriteLine("\nМатрица А\n");

            for (i = 0; i < numRows; i++)
            {
                for (j = 0; j < numColums; j++)
                {
                    matricaA[i, j] = r.Next(1, 11);
                    matricaB[i, j] = r.Next(1, 11);
                    matricaSum[i, j] = matricaA[i, j] + matricaB[i, j];

                    Console.Write($"{matricaA[i, j], 3} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nМатрица B\n");

            for (i = 0; i < numRows; i++)
            {
                for (j = 0; j < numColums; j++)
                {
                    Console.Write($"{matricaB[i, j], 3} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nМатрица сумм элементов A + B\n");

            for (i = 0; i < numRows; i++)
            {
                for (j = 0; j < numColums; j++)
                {
                    Console.Write($"{matricaSum[i, j], 3} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения ...");
            Console.ReadKey();
        }
    }
}
