using System;

class Rectangle
{
    private Point topLeft = new Point();
    private Point bottomRight = new Point();

    public Point TopLeft
    {
        get { return topLeft;}
        set { topLeft = value;}
    }

    public Point BottomRight
    {
        get { return bottomRight;}
        set {bottomRight = value;}
    }

    public void DisplayStats()
    {
        Console.WriteLine("TopLeft: {0}, {1}, {2}]", topLeft.X, topLeft.Y, topLeft.Color);
        Console.WriteLine("[BottomRight: {0}, {1}, {2}]", bottomRight.X, bottomRight.Y, bottomRight.Color);
    }
}