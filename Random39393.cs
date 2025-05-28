using System;

public class Point
{
    private double x;
    private double y;

    // Constructors
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Point other)
    {
        this.x = other.x;
        this.y = other.y;
    }

    // Getters
    public double GetX()
    {
        return x;
    }

    public double GetY()
    {
        return y;
    }

    // Setters
    public void SetX(double num)
    {
        x = num;
    }

    public void SetY(double num)
    {
        y = num;
    }

    // ToString override
    public override string ToString()
    {
        return "(" + x + "," + y + ")";
    }

    // Equals method
    public bool Equals(Point other)
    {
        return this.x == other.x && this.y == other.y;
    }

    // IsAbove
    public bool IsAbove(Point other)
    {
        return this.y > other.y;
    }

    // IsUnder
    public bool IsUnder(Point other)
    {
        return this.y < other.y;
    }

    // IsLeft
    public bool IsLeft(Point other)
    {
        return this.x < other.x;
    }

    // IsRight
    public bool IsRight(Point other)
    {
        return this.x > other.x;
    }

    // WhichQuadrant
    public int WhichQuadrant()
    {
        if (x > 0 && y > 0) return 1;
        if (x < 0 && y > 0) return 2;
        if (x < 0 && y < 0) return 3;
        if (x > 0 && y < 0) return 4;
        return 0; // on axis
    }

    // Distance
    public double Distance(Point other)
    {
        double dx = this.x - other.x;
        double dy = this.y - other.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    // Move
    public void Move(double dx, double dy)
    {
        this.x += dx;
        this.y += dy;
    }

    // MirrorPoint
    public Point MirrorPoint()
    {
        return new Point(-x, -y);
    }
}