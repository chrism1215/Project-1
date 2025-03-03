namespace Quadtree;

/// <summary>
/// Represents a node in the quadtree, which can either be an internal node (with children) or a leaf node (storing rectangles).
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Defines the boundary of the node in 2D space.
    /// </summary>
    public int MinX { get; set; }
    public int MinY { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }

    /// <summary>
    /// Stores rectangles in this node, mainly applicable to leaf nodes.
    /// </summary>
    public List<Rectangle> Rectangles { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class.
    /// </summary>
    /// <param name="minX">Minimum x-boundary of the node.</param>
    /// <param name="minY">Minimum y-boundary of the node.</param>
    /// <param name="maxX">Maximum x-boundary of the node.</param>
    /// <param name="maxY">Maximum y-boundary of the node.</param>
    public Node(int minX, int minY, int maxX, int maxY)
    {
        Rectangles = new List<Rectangle>();
        MinX = minX;
        MinY = minY;
        MaxX = maxX;
        MaxY = maxY;
    }

    /// <summary>
    /// Inserts a rectangle into this node.
    /// </summary>
    /// <param name="rectangle">Rectangle to insert.</param>
    public abstract void Insert(Rectangle rectangle);

    /// <summary>
    /// Removes a rectangle based on given coordinates.
    /// </summary>
    public abstract void Delete(int x, int y);

    /// <summary>
    /// Searches for a rectangle by its coordinates.
    /// </summary>
    public abstract Rectangle? Find(int x, int y);

    /// <summary>
    /// Modifies an existing rectangle's dimensions.
    /// </summary>
    public abstract void Update(int x, int y, int newHeight, int newWidth);

    /// <summary>
    /// Displays the node's structure for debugging.
    /// </summary>
    public abstract void Dump(int level);
}

