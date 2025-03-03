namespace FileReaderParserLibrary.Tests;

using System;
using System.IO;
using Xunit;

/// <summary>
/// Test cases to validate the behavior of the <see cref="FileReader"/> class.
/// </summary>
public class FileReaderTests
{
    /// <summary>
    /// Verifies that <see cref="FileReader.ReadFile"/> correctly reads and returns the file content.
    /// </summary>
    [Fact]
    public void ReadFile_ShouldReturnExpectedContent()
    {
        // Arrange: Create a test file with predefined content
        var expectedContent = "Hello, world!";
        var testFilePath = "test_document.txt";
        File.WriteAllText(testFilePath, expectedContent);

        var fileReader = new FileReader();

        // Act: Read the file using FileReader
        var actualContent = fileReader.ReadFile(testFilePath);

        // Assert: Validate that the content matches the expected value
        Assert.Equal(expectedContent, actualContent);

        // Cleanup: Remove the test file after execution
        File.Delete(testFilePath);
    }

    /// <summary>
    /// Ensures <see cref="FileReader.ReadFile"/> throws a <see cref="FileNotFoundException"/> when attempting to read a nonexistent file.
    /// </summary>
    [Fact]
    public void ReadFile_ShouldThrowException_WhenFileNotFound()
    {
        // Arrange: Define an invalid file path
        var missingFilePath = "invalid_file.txt";
        var fileReader = new FileReader();

        // Act & Assert: Confirm that an exception is thrown for a missing file
        Assert.Throws<FileNotFoundException>(() => fileReader.ReadFile(missingFilePath));
    }
}

