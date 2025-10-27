using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Чтение данных из файла
            string[] lines = File.ReadAllLines("input.txt");

            // Чтение размерности
            int N = int.Parse(lines[0]);

            // Чтение матрицы G
            double[,] G = new double[N, N];
            int lineIndex = 1;

            for (int i = 0; i < N; i++)
            {
                string[] row = lines[lineIndex].Split(' ');
                for (int j = 0; j < N; j++)
                {
                    G[i, j] = double.Parse(row[j]);
                }
                lineIndex++;
            }

            // Чтение вектора x
            double[] x = new double[N];
            string[] vectorValues = lines[lineIndex].Split(' ');
            for (int i = 0; i < N; i++)
            {
                x[i] = double.Parse(vectorValues[i]);
            }

            // Проверка симметричности матрицы G
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (G[i, j] != G[j, i])
                    {
                        Console.WriteLine("Ошибка: Матрица G не симметрична");
                        return;
                    }
                }
            }

            // Вычисление x * G
            double[] temp = new double[N];
            for (int j = 0; j < N; j++)
            {
                temp[j] = 0;
                for (int k = 0; k < N; k++)
                {
                    temp[j] += x[k] * G[k, j];
                }
            }

            // Вычисление temp * x^T (скалярное произведение)
            double scalar = 0;
            for (int i = 0; i < N; i++)
            {
                scalar += temp[i] * x[i];
            }

            // Вычисление длины вектора
            double length = Math.Sqrt(scalar);

            // Вывод результата
            Console.WriteLine($"Длина вектора: {length:F6}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}