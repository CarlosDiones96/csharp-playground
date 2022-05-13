using System;

namespace csharp_playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.TopLeft = new Point(10, 10);
            rect.BottomRight = new Point(500, 500);
            rect.DisplayStats();
            Console.ReadLine();
        }
    }
}
