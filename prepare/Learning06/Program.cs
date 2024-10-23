using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        
        shapes.Add(new Square("Red", 8));
        shapes.Add(new Rectangle("Blue", 2, 1));
        shapes.Add(new Circle("Green", 6));

        
        foreach (var shape in shapes)
        {
            Console.WriteLine($"The shape with {shape.GetColor()} color has an area of: {shape.GetArea()}");
        }
    }
}