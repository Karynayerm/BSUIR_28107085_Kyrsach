using System;

namespace LinearEquationSolver
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Запросить у пользователя размерности матрицы
            Console.WriteLine("Vvedite razmernost matritsy:");
            int n = int.Parse(Console.ReadLine());
            // Запросить у пользователя элементы матрицы
            double[,] a = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Vvedite koeffitcienty yravneniya {0}", i + 1);
                for (int j = 0; j <= n; j++)
                {
                    Console.Write("a[{0},{1}] = ", i, j);
                    a[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Решить СЛАУ методом прогонки
            double[] x = new double[n];
            double[] alpha = new double[n];
            double[] beta = new double[n];
            alpha[0] = -a[0, 1] / a[0, 0];
            beta[0] = a[0, n] / a[0, 0];
            for (int i = 1; i < n; i++)
            {
                alpha[i] = -a[i, i + 1] / (a[i, i] + a[i, i - 1] * alpha[i - 1]);
                beta[i] = (a[i, n] - a[i, i - 1] * beta[i - 1]) / (a[i, i] + a[i, i - 1] * alpha[i - 1]);
            }
            x[n - 1] = beta[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                x[i] = alpha[i] * x[i + 1] + beta[i];
            }

            // Вывести решение
            Console.WriteLine("Reshenie SLAY:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("x[{0}] = {1}", i, x[i]);
            }

            // Ожидать нажатия любой клавиши
            Console.WriteLine("Push any button to the end... :)))");
            Console.ReadKey();
        }
    }
}