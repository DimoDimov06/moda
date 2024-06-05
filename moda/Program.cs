using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете лист от числа, разделени с ' ':");
        string input = Console.ReadLine();
        List<double> numbers = input.Split(' ').Select(double.Parse).ToList();

        // Средно аритметично
        double average = numbers.Average();
        Console.WriteLine($"Средно аритметично: {average}");

        // Медиана
        numbers.Sort();
        double median;
        int n = numbers.Count;
        if (n % 2 == 0)
        {
            median = (numbers[n / 2 - 1] + numbers[n / 2]) / 2;
        }
        else
        {
            median = numbers[n / 2];
        }
        Console.WriteLine($"Медиана: {median}");

        // Мода
        var modeDict = new Dictionary<double, int>();
        foreach (var number in numbers)
        {
            if (modeDict.ContainsKey(number))
                modeDict[number]++;
            else
                modeDict[number] = 1;
        }

        int maxCount = modeDict.Values.Max();
        var modes = modeDict.Where(pair => pair.Value == maxCount).Select(pair => pair.Key).ToList();

        Console.WriteLine("Мода: " + string.Join(", ", modes));
    }
}