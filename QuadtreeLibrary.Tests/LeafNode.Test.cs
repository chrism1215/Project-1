using Xunit;

namespace Quadtree.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="LeafNode"/> class.
    /// </summary>
    public class LeafNodeTests
    {
        [Fact]
        public void Insert_ShouldAllowFindingRectangle()
        {
            // Arrange
            var space = new Rectangle(-40, -40, 90, 90);
            var leafNode = new LeafNode(4, space);
            var rect = new Rectangle(12, 12, 18, 18);

            // Act
            leafNode.Insert(rect);
            var found = leafNode.Find(12, 12);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(12, found.x);
            Assert.Equal(12, found.y);
        }

        [Fact]
        public void Find_ShouldReturnNull_WhenRectangleDoesNotExist()
        {
            // Arrange
            var space = new Rectangle(-40, -40, 90, 90);
            var leafNode = new LeafNode(4, space);

            // Act
            var found = leafNode.Find(35, 35);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Delete_ShouldRemoveInsertedRectangle()
        {
            // Arrange
            var space = new Rectangle(-40, -40, 90, 90);
            var leafNode = new LeafNode(4, space);
            var rect = new Rectangle(14, 14, 22, 22);
            leafNode.Insert(rect);

            // Act
            leafNode.Delete(14, 14);
            var found = leafNode.Find(14, 14);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Update_ShouldModifyRectangleSize()
        {
            // Arrange
            var space = new Rectangle(-40, -40, 90, 90);
            var leafNode = new LeafNode(4, space);
            var rect = new Rectangle(18, 18, 24, 24);
            leafNode.Insert(rect);

            // Act
            leafNode.Update(18, 18, 50, 50);
            var updatedRect = leafNode.Find(18, 18);

            // Assert
            Assert.NotNull(updatedRect);
            Assert.Equal(50, updatedRect.length);
            Assert.Equal(50, updatedRect.width);
        }

        [Fact]
        public void Insert_WhenExceedingThreshold_ShouldThrowException()
        {
            // Arrange
            var space = new Rectangle(-40, -40, 90, 90);
            var leafNode = new LeafNode(2, space); // Small threshold for testing

            // Insert multiple rectangles to exceed threshold
            leafNode.Insert(new Rectangle(6, 6, 12, 12));
            leafNode.Insert(new Rectangle(-6, -6, 14, 14));

            // Assert
            Assert.Throws<InvalidOperationException>(() => leafNode.Insert(new Rectangle(16, 16, 10, 10)));
        }
    }
}

