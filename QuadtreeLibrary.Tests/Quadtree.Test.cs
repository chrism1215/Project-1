namespace Quadtree.Tests;

using Xunit;

/// <summary>
/// Unit tests for the <see cref="Quadtree"/> class.
/// </summary>
public class QuadtreeTests
{
    [Fact]
    public void Insert_ShouldAllowFindingRectangle()
    {
        // Arrange
        var quadtree = new Quadtree(-20, -20, 120, 120, 5);
        var rect = new Rectangle(15, 15, 6, 6);

        // Act
        quadtree.Insert(rect);
        var foundRect = quadtree.Find(15, 15);

        // Assert
        Assert.NotNull(foundRect);
        Assert.Equal(rect, foundRect);
    }

    [Fact]
    public void Delete_ShouldRemoveRectangle()
    {
        // Arrange
        var quadtree = new Quadtree(-20, -20, 120, 120, 5);
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
}

