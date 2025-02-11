using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Blue", 30);
        shapes.Add(square);
        Rectangle rectangle = new Rectangle("yellow", 10, 20);
        shapes.Add(rectangle);
        Circle circle = new Circle("Brown", 20);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            double area = shape.GetArea();
            Console.WriteLine($"{color} - {area}");
        }
        
    }
}