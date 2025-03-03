namespace Quadtree;

/// <summary>
/// Implements a Quadtree structure for efficient spatial partitioning.
/// This tree recursively subdivides a two-dimensional space into four quadrants,
/// optimizing spatial queries and object management.
/// </summary>
public class Quadtree
{
    /// <summary>
    /// The root node of the Quadtree, represented by either an <see cref="InternalNode"/> or <see cref="LeafNode"/>.
    /// </summary>
    private Node root;

    /// <summary>
    /// The maximum number of rectangles a node can hold before it splits.
    /// </summary>
    private int maxCapacity;

    /// <summary>
    /// Initializes a new instance of the <see cref="Quadtree"/> class.
    /// </summary>
    /// <param name="minX">The minimum x-coordinate of the quadtree.</param>
    /// <param name="minY">The minimum y-coordinate of the quadtree.</param>
    /// <param name="maxX">The maximum x-coordinate of the quadtree.</param>
    /// <param name="maxY">The maximum y-coordinate of the quadtree.</param>
    /// <param name="capacity">The threshold for node splitting.</param>
    public Quadtree(int minX, int minY, int maxX, int maxY, int capacity)
    {
        maxCapacity = capacity;
        root = new InternalNode(minX, minY, maxX, maxY, capacity);
    }

    /// <summary>
    /// Adds a rectangle into the quadtree.
    /// </summary>
    /// <param name="rectangle">The rectangle to insert.</param>
    public void Insert(Rectangle rectangle)
    {
        root.Insert(rectangle);
    }

    /// <summary>
    /// Removes a rectangle from the quadtree using its coordinates.
    /// </summary>
    /// <param name="x">X-coordinate of the rectangle.</param>
    /// <param name="y">Y-coordinate of the rectangle.</param>
    public void Delete(int x, int y)
    {
        root.Delete(x, y);
    }

    /// <summary>
    /// Searches for a rectangle in the quadtree based on coordinates.
    /// </summary>
    /// <param name="x">X-coordinate to search for.</param>
    /// <param name="y">Y-coordinate to search for.</param>
    /// <returns>The located rectangle, or <c>null</c> if not found.</returns>
    public Rectangle Find(int x, int y)
    {
        return root.Find(x, y);
    }

    /// <summary>
    /// Updates the dimensions of a rectangle stored in the quadtree.
    /// </summary>
    /// <param name="x">X-coordinate of the rectangle.</param>
    /// <param name="y">Y-coordinate of the rectangle.</param>
    /// <param name="newLength">New length of the rectangle.</param>
    /// <param name="newWidth">New width of the rectangle.</param>
    public void Update(int x, int y, int newLength, int newWidth)
    {
        root.Update(x, y, newLength, newWidth);
    }

    /// <summary>
    /// Prints the structure of the quadtree for debugging purposes.
    /// </summary>
    public void Dump()
    {
        root.Dump(0);
    }
}

