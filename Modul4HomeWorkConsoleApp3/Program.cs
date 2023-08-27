using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4HomeWorkConsoleApp3
{
    public class LifeSimulation
    {
        private int _heigth;
        private int _width;
        private bool[,] cells;
        private int[,] numsOfAlive;

        /// <summary>
        /// Создаем новую игру
        /// </summary>
        /// <param name="Heigth">Высота поля.</param>
        /// <param name="Width">Ширина поля.</param>

        public LifeSimulation(int Heigth, int Width)
        {
            _heigth = Heigth;
            _width = Width;
            cells = new bool[Heigth, Width];
            numsOfAlive = new int[Heigth, Width];
            GenerateField();
        }

        /// <summary>
        /// Перейти к следующему поколению и вывести результат на консоль.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Двигаем состояние на одно вперед, по установленным правилам
        /// </summary>

        private void Grow()
        {
            int i, j;
            for (i = 0; i < _heigth; i++)
            {
                for (j = 0; j < _width; j++)
                {
                    numsOfAlive[i, j] = GetNeighbors(i, j);
                }
            }

            for (i = 0; i < _heigth; i++)
            {
                for (j = 0; j < _width; j++)
                {
                    if (cells[i, j])
                    {
                        if ((numsOfAlive[i, j] < 2) || (numsOfAlive[i, j] > 3))
                        {
                            cells[i, j] = false;
                        }

                        if ((i == j) || (i == (_width - j - 1)))
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        //if ((numsOfAlive[i, j] % 2) == 1)
                        if ((numsOfAlive[i, j] == 3) || (numsOfAlive[i, j] == 1))
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }

            #region old
            /*for (i = 0; i < _heigth; i++)
            {
                for (j = 0; j < _width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }

                        if ((i == j) || (i == (_width - j - 1)))
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        //if ((numOfAliveNeighbors == 1) || (numOfAliveNeighbors == 3) || (numOfAliveNeighbors == 5) || (numOfAliveNeighbors == 7))
                        if ((numOfAliveNeighbors % 2) == 1)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }*/
            #endregion
        }

        /// <summary>
        /// Смотрим сколько живых соседий вокруг клетки.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число живых клеток.</returns>

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == true) NumOfAliveNeighbors++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        /// <summary>
        /// Нарисовать Игру в консоле
        /// </summary>

        private void DrawGame()
        {
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(cells[i, j] ? "*" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Инициализируем случайными значениями
        /// </summary>

        private void GenerateField()
        {
            //cells[_heigth / 2, _width / 2] = true;
            //return;
            Random generator = new Random();
            int number;
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }

    internal class Program
    {

        // Ограничения игры
        private const int Heigth = 20;
        private const int Width = 20;
        private const uint MaxRuns = 500;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Дадим пользователю шанс увидеть, что происходит, немного ждем
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}

