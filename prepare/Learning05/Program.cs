using System;

class Program
{
    static void Main(string[] args)
    {
        // a list of each kind of shape
        List<Shape> shapes = new List<Shape>
        {
            new Square("Blue", 0.1),
            new Circle("Yellow", 0.24),
            new Rectangle("Orange", 0.2, 0.5)
        };

        // have each shape list its color and area
        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}