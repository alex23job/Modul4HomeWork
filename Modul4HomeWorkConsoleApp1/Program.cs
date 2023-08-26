using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4HomeWorkConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numRows;
            int numColums;
            int[,] matrica;

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

            matrica = new int[numRows, numColums];
            Random r = new Random();
            int sum = 0;

            Console.WriteLine();

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColums; j++)
                {
                    matrica[i, j] = r.Next(1, 11);
                    sum += matrica[i, j];
                    Console.Write($"{matrica[i, j], 2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nСумма всех элементов матрицы : {sum}");

            Console.WriteLine("\nНажмите любую клавишу для продолжения ...");
            Console.ReadKey();
        }
    }
}
