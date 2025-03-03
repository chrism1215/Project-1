namespace Quadtree;

/// <summary>
/// Defines a rectangle with position and dimensions.
/// </summary>
public class Rectangle
{
    /// <summary>
    /// The x-coordinate of the rectangle's top-left corner.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// The y-coordinate of the rectangle's top-left corner.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// The height of the rectangle.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The width of the rectangle.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rectangle"/> class.
    /// </summary>
    /// <param name="x">X-coordinate of the top-left corner.</param>
    /// <param name="y">Y-coordinate of the top-left corner.</param>
    /// <param name="height">Height of the rectangle.</param>
    /// <param name="width">Width of the rectangle.</param>
    public Rectangle(int x, int y, int height, int width)
    {
        X = x;
        Y = y;
        Height = height;
        Width = width;
    }

    /// <summary>
    /// Computes the area of the rectangle.
    /// </summary>
    /// <returns>The calculated area.</returns>
    public int GetArea() => Height * Width;

    /// <summary>
    /// Computes the perimeter of the rectangle.
    /// </summary>
    /// <returns>The calculated perimeter.</returns>
    public int GetPerimeter() => 2 * (Height + Width);

    /// <summary>
    /// Checks if a given point is inside the rectangle.
    /// </summary>
    /// <param name="px">X-coordinate of the point.</param>
    /// <param name="py">Y-coordinate of the point.</param>
    /// <returns>True if the point is inside, otherwise false.</returns>
    public bool ContainsPoint(int px, int py) => px >= X && px <= X + Width && py >= Y && py <= Y + Height;

    /// <summary>
    /// Checks if another rectangle is equal to this one.
    /// </summary>
    public override bool Equals(object? obj) => obj is Rectangle other && X == other.X && Y == other.Y && Height == other.Height && Width == other.Width;

    /// <summary>
    /// Generates a hash code for the rectangle.
    /// </summary>
    public override int GetHashCode() => HashCode.Combine(X, Y, Height, Width);

    /// <summary>
    /// Returns a string representation of the rectangle.
    /// </summary>
    public override string ToString() => $"Rectangle({X}, {Y}, {Width}x{Height})";
}
