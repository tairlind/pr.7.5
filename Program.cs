using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
//практическая номер 7
//5. Дан файл вещественных чисел. В конце файла сохраните максимальное из этих чисел.

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("numbers.txt");

        List<double> numberList = new List<double>();
        foreach (string line in lines)
        {
            if (double.TryParse(line, out double number))
            {
                numberList.Add(number);
            }
            else
            {
                Console.WriteLine($"Невозможно преобразовать строку '{line}' в число.");
            }
        }

        double[] numbers = numberList.ToArray();

        if (numbers.Length > 0)
        {
            double maxValue = numbers.Max();
            Console.WriteLine($"Максимальное число: {maxValue}");

            // добавление максимального числа в конец файла 
            File.AppendAllText("numbers.txt", maxValue.ToString() + Environment.NewLine);
        }
        else
        {
            Console.WriteLine("Массив чисел пуст. Невозможно найти максимальное число.");
        }
    }
}