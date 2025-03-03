namespace Quadtree.Tests;

using Xunit;

/// <summary>
/// Unit tests for the <see cref="Quadtree"/> class.
/// </summary>
public class QuadtreeTest
{
    [Fact]
    public void Insert_ShouldAllowFindingRectangle()
    {
        // Arrange
        var quadtree = new Quadtree(-10, -10, 120, 120, 5);
        var rect = new Rectangle(12, 12, 6, 6);

        // Act
        quadtree.Insert(rect);
        var foundRect = quadtree.Find(12, 12);

        // Assert
        Assert.NotNull(foundRect);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void Delete_ShouldRemoveRectangle()
    {
        // Arrange
        var quadtree = new Quadtree(-10, -10, 120, 120, 5);
        var rect = new Rectangle(18, 18, 7, 7);
        quadtree.Insert(rect);

        // Ensure it exists before deletion
        Assert.NotNull(quadtree.Find(18, 18));

        // Act
        quadtree.Delete(18, 18);
        var foundAfterDelete = quadtree.Find(18, 18);

        // Assert
        Assert.Null(foundAfterDelete);
    }

    [Fact]
    public void Insert_MultipleRectangles_ShouldAllowFindingEach()
    {
        // Arrange
        var quadtree = new Quadtree(-10, -10, 120, 120, 5);
        var rect1 = new Rectangle(14, 14, 6, 6);
        var rect2 = new Rectangle(26, 26, 10, 10);
        var rect3 = new Rectangle(38, 38, 5, 5);

        // Act
        quadtree.Insert(rect1);
        quadtree.Insert(rect2);
        quadtree.Insert(rect3);

        // Assert
        Assert.Equal(rect1, quadtree.Find(14, 14));
        Assert.Equal(rect2, quadtree.Find(26, 26));
        Assert.Equal(rect3, quadtree.Find(38, 38));
    }
}

