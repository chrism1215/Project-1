namespace FileReaderParserLibrary;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Responsible for parsing a file and extracting command strings.
/// Commands are expected to be listed line by line.
/// </summary>
public class CommandParser
{
    /// <summary>
    /// Reads a file and retrieves a list of commands, ignoring empty or whitespace-only lines.
    /// </summary>
    /// <param name="filePath">Path to the file to be parsed.</param>
    /// <returns>A list of extracted command strings.</returns>
    public static List<string> ExtractCommands(string filePath)
    {
        var commandList = new List<string>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: The file '{filePath}' does not exist.");
            return commandList;
        }

        try
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string sanitizedLine = line.Trim().TrimEnd(';');
                    commandList.Add(sanitizedLine);
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Insufficient permissions to access the file.");
        }
        catch (IOException ioEx)
        {
            Console.WriteLine($"I/O Error: {ioEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error encountered: {ex.Message}");
        }

        return commandList;
    }
}

