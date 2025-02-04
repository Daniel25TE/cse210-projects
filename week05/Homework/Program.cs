using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        Assignment primero = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(primero.GetSummary());
        
        MathAssignment segundo = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(segundo.GetSummary());
        Console.WriteLine(segundo.GetHomeworkList());

        WritingAssignment tercero = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II by Mary Waters");
        Console.WriteLine(tercero.GetSummary());
        Console.WriteLine(tercero.GetWritingInformation());
    }
}