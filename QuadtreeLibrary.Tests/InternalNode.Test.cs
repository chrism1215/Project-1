using System;
using Xunit;
using System.Collections.Generic;

namespace Quadtree.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="InternalNode"/> class, ensuring correct spatial partitioning behavior.
    /// </summary>
    public class InternalNodeTests
    {
        [Fact]
        public void Insert_ShouldStoreInLeafOrTriggerSplit()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);
            var rect1 = new Rectangle(15, 15, 8, 8);
            var rect2 = new Rectangle(25, 25, 6, 6);
            var rect3 = new Rectangle(35, 35, 7, 7); // Should cause a node split

            // Act
            root.Insert(rect1);
            root.Insert(rect2);
            root.Insert(rect3);

            // Assert
            Assert.NotNull(root.Children);
            Assert.Equal(4, root.Children.Count);
        }

        [Fact]
        public void Find_ShouldReturnExistingRectangle()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);
            var rect = new Rectangle(30, 30, 7, 7);
            root.Insert(rect);

            // Act
            var found = root.Find(30, 30);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(rect.x, found.x);
            Assert.Equal(rect.y, found.y);
        }

        [Fact]
        public void Find_ShouldReturnNull_WhenRectangleNotExists()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);

            // Act
            var found = root.Find(60, 60);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Delete_ShouldRemoveExistingRectangle()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);
            var rect = new Rectangle(28, 28, 6, 6);
            root.Insert(rect);

            // Act
            root.Delete(28, 28);
            var found = root.Find(28, 28);

            // Assert
            Assert.Null(found);
        }

        [Fact]
        public void Update_ShouldModifyRectangleSize()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);
            var rect = new Rectangle(45, 45, 6, 6);
            root.Insert(rect);

            // Act
            root.Update(45, 45, 12, 12);
            var updated = root.Find(45, 45);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(12, updated.length);
            Assert.Equal(12, updated.width);
        }

        [Fact]
        public void Dump_ShouldOutputQuadtreeStructure()
        {
            // Arrange
            var root = new InternalNode(-10, -10, 120, 120, 3);
            root.Insert(new Rectangle(12, 12, 7, 7));
            root.Insert(new Rectangle(24, 24, 8, 8));
            root.Insert(new Rectangle(36, 36, 9, 9)); // Causes a node split

            // Act
            var writer = new System.IO.StringWriter();
            Console.SetOut(writer);
            root.Dump(0);
            string output = writer.ToString();

            // Assert
            Assert.Contains("Internal Node", output);
            Assert.Contains("LeafNode", output);
        }
    }
}
