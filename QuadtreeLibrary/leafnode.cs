namespace Quadtree;

/// <summary>
/// Represents a leaf node in the quadtree that stores rectangles.
/// If the threshold is exceeded, the node should transition to an internal node.
/// </summary>
public class LeafNode : Node
{
    /// <summary>
    /// Maximum number of rectangles this node can store before splitting.
    /// </summary>
    private int maxCapacity;

    /// <summary>
    /// Initializes a new instance of the <see cref="LeafNode"/> class.
    /// </summary>
    /// <param name="capacity">Maximum number of rectangles allowed.</param>
    /// <param name="bounds">Defines the spatial region of the node.</param>
    public LeafNode(int capacity, Rectangle bounds) 
        : base(bounds.X, bounds.Y, bounds.X + bounds.Height, bounds.Y + bounds.Width)
    {
        maxCapacity = capacity;
        Rectangles = new List<Rectangle>();
    }

    /// <summary>
    /// Inserts a rectangle into this node. Throws an error if the capacity is exceeded.
    /// </summary>
    /// <param name="rectangle">The rectangle to insert.</param>
    public override void Insert(Rectangle rectangle)
    {
        if (Rectangles.Count >= maxCapacity)
        {
            throw new InvalidOperationException("Leaf node at capacity. Splitting required.");
        }
        Rectangles.Add(rectangle);
    }

    /// <summary>
    /// Removes a rectangle from the node using its coordinates.
    /// </summary>
    public override void Delete(int x, int y)
    {
        var rect = Rectangles.FirstOrDefault(r => r.X == x && r.Y == y);
        if (rect != null)
        {
            Rectangles.Remove(rect);
            Console.WriteLine($"Rectangle at ({x}, {y}) removed.");
        }
        else
        {
            Console.WriteLine($"No rectangle found at ({x}, {y}) to delete.");
        }
    }

    /// <summary>
    /// Deletes a specified rectangle from the node.
    /// </summary>
    public void Delete(Rectangle rectangle)
    {
        Delete(rectangle.X, rectangle.Y);
    }

    /// <summary>
    /// Displays all rectangles stored in this node.
    /// </summary>
    public override void Dump(int level)
    {
        Console.WriteLine(new string('\t', level) + $"Leaf Node [{xMin},{yMin}] to [{xMax},{yMax}]");
        foreach (var rect in Rectangles)
        {
            Console.WriteLine(new string('\t', level) + $"Rectangle at {rect.X}, {rect.Y}: {rect.Width}x{rect.Height}");
        }
    }

    /// <summary>
    /// Modifies the dimensions of a rectangle stored in this node.
    /// </summary>
    public override void Update(int x, int y, int newHeight, int newWidth)
    {
        var rect = Rectangles.FirstOrDefault(r => r.X == x && r.Y == y);
        if (rect != null)
        {
            rect.Height = newHeight;
            rect.Width = newWidth;
            Console.WriteLine($"Updated rectangle at ({x}, {y}) to {newHeight}x{newWidth}.");
        }
        else
        {
            Console.WriteLine($"No rectangle found at ({x}, {y}) to update.");
        }
    }

    /// <summary>
    /// Finds and retrieves a rectangle by its coordinates.
    /// </summary>
    public override Rectangle? Find(int x, int y)
    {
        return Rectangles.FirstOrDefault(rect => rect.X == x && rect.Y == y);
    }
}

