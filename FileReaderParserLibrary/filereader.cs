namespace FileReaderParserLibrary;

using System;
using System.IO;

/// <summary>
/// Provides functionality for reading text content from files.
/// </summary>
public class FileReader
{
    /// <summary>
    /// Retrieves the full content of a specified file as a string.
    /// </summary>
    /// <param name="filePath">Path to the file being read.</param>
    /// <returns>Contents of the file as a string.</returns>
    /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    public string ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Error: File not found.", filePath);
        }

        return File.ReadAllText(filePath);
    }
}

