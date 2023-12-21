using System;

class Program
{
    /// <summary>
    /// Точка входа
    /// </summary>
    /// <param name="args">параметры вызова исполняемого файла</param>
    static void Main(string[] args)
    {
        int[,] array = new int[,] { { 1, 2, 3, 4, 5 },
                                    { 6, 7, 8, 9, 10 },
                                    { 11, 12, 13, 14, 15 },
                                    { 16, 17, 18, 19, 20 } };

        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        // Находим середину массива
        int middle = cols / 2;

        // Меняем местами строки, симметричные относительно середины массива
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < middle; j++)
            {
                int temp = array[i, j];
                array[i, j] = array[i, cols - 1 - j];
                array[i, cols - 1 - j] = temp;
            }
        }

        // Выводим измененный массив
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}