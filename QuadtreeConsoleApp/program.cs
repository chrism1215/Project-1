using System;
using System.Collections.Generic;
using FileReaderParserLibrary;
using Quadtree;

namespace QuadtreeCLI
{
    /// <summary>
    /// Command-line interface for processing spatial commands using a Quadtree.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point for the CLI application.
        /// </summary>
        /// <param name="args">Command-line arguments, expecting a file path.</param>
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: QuadtreeCLI <path_to_command_file>");
                return;
            }

            string filePath = args[0];
            var commands = CommandParser.ParseCommands(filePath);

            if (commands.Count == 0)
            {
                Console.WriteLine("No valid commands found in the file.");
                return;
            }

            var quadtree = new LeafNode(5, new Rectangle(-60, -60, 110, 110));

            foreach (var command in commands)
            {
                try
                {
                    ProcessCommand(command, quadtree);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing command '{command}': {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Parses and executes a command on the Quadtree.
        /// </summary>
        private static void ProcessCommand(string command, LeafNode quadtree)
        {
            var commandParts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commandParts.Length == 0) return;

            string action = commandParts[0].ToLower();

            switch (action)
            {
                case "insert":
                    ProcessInsert(commandParts, quadtree);
                    break;
                case "delete":
                    ProcessDelete(commandParts, quadtree);
                    break;
                case "find":
                    ProcessFind(commandParts, quadtree);
                    break;
                case "update":
                    ProcessUpdate(commandParts, quadtree);
                    break;
                case "dump":
                    quadtree.Dump(0);
                    break;
                default:
                    Console.WriteLine($"Unknown command: {action}");
                    break;
            }
        }

        private static void ProcessInsert(string[] parts, LeafNode quadtree)
        {
            if (parts.Length == 5 &&
                int.TryParse(parts[1], out int x) &&
                int.TryParse(parts[2], out int y) &&
                int.TryParse(parts[3], out int width) &&
                int.TryParse(parts[4], out int height))
            {
                quadtree.Insert(new Rectangle(x, y, width, height));
            }
            else
            {
                Console.WriteLine("Invalid Insert command format.");
            }
        }

        private static void ProcessDelete(string[] parts, LeafNode quadtree)
        {
            if (parts.Length == 3 &&
                int.TryParse(parts[1], out int x) &&
                int.TryParse(parts[2], out int y))
            {
                var rect = quadtree.Find(x, y);
                if (rect != null)
                {
                    quadtree.Delete(rect);
                }
                else
                {
                    Console.WriteLine($"No object found at {x}, {y} to delete.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Delete command format.");
            }
        }

        private static void ProcessFind(string[] parts, LeafNode quadtree)
        {
            if (parts.Length == 3 &&
                int.TryParse(parts[1], out int x) &&
                int.TryParse(parts[2], out int y))
            {
                var rect = quadtree.Find(x, y);
                Console.WriteLine(rect != null 
                    ? $"Found rectangle at {x}, {y}: {rect.width}x{rect.length}" 
                    : $"No object found at {x}, {y}.");
            }
            else
            {
                Console.WriteLine("Invalid Find command format.");
            }
        }

        private static void ProcessUpdate(string[] parts, LeafNode quadtree)
        {
            if (parts.Length == 5 &&
                int.TryParse(parts[1], out int x) &&
                int.TryParse(parts[2], out int y) &&
                int.TryParse(parts[3], out int newWidth) &&
                int.TryParse(parts[4], out int newHeight))
            {
                var rect = quadtree.Find(x, y);
                if (rect != null)
                {
                    quadtree.Update(x, y, newWidth, newHeight);
                }
                else
                {
                    Console.WriteLine($"No object found at {x}, {y} to update.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Update command format.");
            }
        }
    }
}
