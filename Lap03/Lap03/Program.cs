using System;

public class Figure
{
    public string Name { get; set; }

    public Figure(string name)
    {
        this.Name = name;
    }

    // Make the Area method virtual so it can be overridden in derived classes
    public virtual double Area()
    {
        return 0;
    }
}

public class Triangle : Figure
{
    public double A { get; set; }
    public double H { get; set; }

    public Triangle(string name, double a, double h) : base(name)
    {
        this.A = a;
        this.H = h;
    }

    // Override Area method for Triangle
    public override double Area()
    {
        return 0.5 * A * H;
    }
}

public class Circle : Figure
{
    public double R { get; set; }

    public Circle(string name, double r) : base(name)
    {
        this.R = r;
    }

    // Override Area method for Circle
    public override double Area()
    {
        return Math.PI * R * R;
    }
}

public class Rectangle : Figure
{
    public double D { get; set; }
    public double R { get; set; }

    public Rectangle(string name, double d, double r) : base(name)
    {
        this.D = d;
        this.R = r;
    }

    // Override Area method for Rectangle
    public override double Area()
    {
        return D * R;
    }
}

public class Program
{
    public static void Main()
    {
        
        Figure triangle = new Triangle("Triangle", 3, 4);
        Console.WriteLine($"{triangle.Name} Area: {triangle.Area()}");

        Figure circle = new Circle("Circle", 5);
        Console.WriteLine($"{circle.Name} Area: {circle.Area()}");

        Figure rectangle = new Rectangle("Rectangle", 5, 6);
        Console.WriteLine($"{rectangle.Name} Area: {rectangle.Area()}");
    }
}
