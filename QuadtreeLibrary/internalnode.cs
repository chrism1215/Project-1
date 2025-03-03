namespace Quadtree;

/// <summary>
/// Represents an internal node in the quadtree, responsible for managing child nodes and splitting when necessary.
/// </summary>
public class InternalNode : Node
{
    /// <summary>
    /// Collection of child nodes contained within this internal node.
    /// </summary>
    public List<Node> Children { get; set; }

    private int splitThreshold;

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalNode"/> class.
    /// </summary>
    /// <param name="minX">Minimum x-boundary.</param>
    /// <param name="minY">Minimum y-boundary.</param>
    /// <param name="maxX">Maximum x-boundary.</param>
    /// <param name="maxY">Maximum y-boundary.</param>
    /// <param name="threshold">Maximum number of rectangles before splitting.</param>
    public InternalNode(int minX, int minY, int maxX, int maxY, int threshold) 
        : base(minX, minY, maxX, maxY)
    {
        splitThreshold = threshold;
        Children = new List<Node>();
    }

    /// <summary>
    /// Inserts a rectangle into this node or its children.
    /// </summary>
    /// <param name="rect">Rectangle to insert.</param>
    public override void Insert(Rectangle rect)
    {
        if (Rectangles.Count < splitThreshold)
        {
            Rectangles.Add(rect);
        }
        else
        {
            Split();
            AssignToChild(rect);
        }
    }

    /// <summary>
    /// Splits this node into four quadrants when the threshold is exceeded.
    /// </summary>
    private void Split()
    {
        int midX = (xMin + xMax) / 2;
        int midY = (yMin + yMax) / 2;

        Children = new List<Node>
        {
            new LeafNode(splitThreshold, new Rectangle(xMin, midY, midX, yMax)),
            new LeafNode(splitThreshold, new Rectangle(midX, midY, xMax, yMax)),
            new LeafNode(splitThreshold, new Rectangle(xMin, yMin, midX, midY)),
            new LeafNode(splitThreshold, new Rectangle(midX, yMin, xMax, midY))
        };

        foreach (var rect in Rectangles)
        {
            AssignToChild(rect);
        }

        Rectangles.Clear();
    }

    /// <summary>
    /// Assigns a rectangle to the appropriate child node.
    /// </summary>
    private void AssignToChild(Rectangle rect)
    {
        foreach (var child in Children)
        {
            if (child.Contains(rect))
            {
                child.Insert(rect);
                return;
            }
        }
    }

    /// <summary>
    /// Deletes a rectangle by its coordinates.
    /// </summary>
    public override void Delete(int x, int y)
    {
        foreach (var child in Children)
        {
            child.Delete(x, y);
        }
    }

    /// <summary>
    /// Finds a rectangle by its coordinates.
    /// </summary>
    public override Rectangle? Find(int x, int y)
    {
        foreach (var child in Children)
        {
            var rect = child.Find(x, y);
            if (rect != null)
                return rect;
        }
        return null;
    }

    /// <summary>
    /// Updates the dimensions of a rectangle in this node.
    /// </summary>
    public override void Update(int x, int y, int length, int width)
    {
        foreach (var child in Children)
        {
            child.Update(x, y, length, width);
        }
    }

    /// <summary>
    /// Outputs the structure of the quadtree for debugging.
    /// </summary>
    public override void Dump(int level)
    {
        Console.WriteLine(new string('\t', level) + $"Internal Node [{xMin},{yMin}] to [{xMax},{yMax}]");
        foreach (var child in Children)
        {
            child.Dump(level + 1);
        }
    }
}
