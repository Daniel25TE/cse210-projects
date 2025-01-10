using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int numerales = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        int sum = 0;

        while (numerales != 0)
        {
           numbers.Add(numerales);
           Console.Write("Enter your number: ");
           numerales = int.Parse(Console.ReadLine());
        }

        foreach (int number in numbers)
        {
            
            Console.WriteLine(number);

        }

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers [0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        
        Console.WriteLine($"The larger number is: {max}");

    }
}