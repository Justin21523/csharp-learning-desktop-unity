using System;

// 定義 Rectangle 結構
struct Rectangle
{
    public double Width;
    public double Height;
    public double Area => Width * Height;
    public Rectangle(double w, double h) => (Width, Height) = (w, h);
}

class Program
{
    static void Main()
    {
        // 建立原始 Rectangle
        Rectangle r1 = new Rectangle(4.0, 2.5);
        Console.WriteLine($"r1: Width={r1.Width}, Height={r1.Height}, Area={r1.Area}");

        // 傳值複製
        Rectangle r2 = r1;
        r2.Width = 10.0;  // 只修改 r2，不影響 r1

        Console.WriteLine($"\nAfter modifying r2.Width = 10.0:");
        Console.WriteLine($"r1.Width = {r1.Width}, r1.Area = {r1.Area}");
        Console.WriteLine($"r2.Width = {r2.Width}, r2.Area = {r2.Area}");
    }
}
