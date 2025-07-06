using System;

public struct Circle
{
    public double Radius { get; set; }
    public double Area => Math.PI * Radius * Radius;
    public Circle(double r) => Radius = r;
}

class Program
{
    static void Main()
    {
        var c1 = new Circle(5);
        var c2 = c1;      // 值複製
        c2.Radius = 10;
        Console.WriteLine($"c1.Radius={c1.Radius}, Area={c1.Area}");
        Console.WriteLine($"c2.Radius={c2.Radius}, Area={c2.Area}");
    }
}
