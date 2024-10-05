using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class FileSorter
{
    public IEnumerable<FileInfo> SortByName(IEnumerable<FileInfo> files, bool ascending = true)
    {
        return ascending ? files.OrderBy(f => f.Name) : files.OrderByDescending(f => f.Name);
    }

    public IEnumerable<FileInfo> SortBySize(IEnumerable<FileInfo> files, bool ascending = true)
    {
        return ascending ? files.OrderBy(f => f.Length) : files.OrderByDescending(f => f.Length);
    }

    public IEnumerable<FileInfo> SortByDate(IEnumerable<FileInfo> files, bool ascending = true)
    {
        return ascending ? files.OrderBy(f => f.LastWriteTime) : files.OrderByDescending(f => f.LastWriteTime);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a Directory Path: ");
        string directoryPath = Console.ReadLine();

        try
        {
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.EnumerateFiles(directoryPath).Select(f => new FileInfo(f));

                Console.WriteLine("Sort files by:");
                Console.WriteLine("1 - Name");
                Console.WriteLine("2 - File Size");
                Console.WriteLine("3 - Date Modified");
                Console.Write("Enter your choice (1-3): ");
                string sortOption = Console.ReadLine();

                Console.Write("Sort in ascending order? (y/n): ");
                bool ascending = Console.ReadLine().ToLower() == "y";

                FileSorter sorter = new FileSorter();
                FileManager fileManager = new FileManager();

                IEnumerable<FileInfo> sortedFiles = sortOption switch
                {
                    "1" => sorter.SortByName(files, ascending),
                    "2" => sorter.SortBySize(files, ascending),
                    "3" => sorter.SortByDate(files, ascending),
                    _ => files // If invalid input, keep the original order
                };

                Console.WriteLine("Files: {0}", sortedFiles.Count());
                Console.WriteLine("List of Files");

                foreach (var fileInfo in sortedFiles)
                {
                    string fileName = fileInfo.Name;
                    long fileSizeInBytes = fileInfo.Length;
                    string fileDate = fileInfo.LastWriteTime.ToString();

                    Console.Write($"File: {fileName}");

                    if (fileSizeInBytes > 1024)
                    {
                        long fileSizeInKB = fileSizeInBytes / 1024;
                        Console.WriteLine($" - Size: {fileSizeInKB} KB - Last Modified: {fileDate}");
                    }
                    else
                    {
                        Console.WriteLine($" - Size: {fileSizeInBytes} bytes - Last Modified: {fileDate}");
                    }
                }

                // If sorting by size, ask if they want to delete the biggest file
                if (sortOption == "2")
                {
                    FileInfo largestFile = sortedFiles.OrderByDescending(f => f.Length).FirstOrDefault();
                    if (largestFile != null)
                    {
                        fileManager.PromptForLargestFileDeletion(largestFile);
                    }
                }

                // If sorting by date, ask if they want to delete the oldest file
                if (sortOption == "3")
                {
                    FileInfo oldestFile = sortedFiles.OrderBy(f => f.LastWriteTime).FirstOrDefault();
                    if (oldestFile != null)
                    {
                        fileManager.PromptForOldestFileDeletion(oldestFile);
                    }
                }
            }
            else
            {
                Console.WriteLine("The directory does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

public class FileManager
{
    //Delete the largest file
    public void PromptForLargestFileDeletion(FileInfo largestFile)
    {
        Console.WriteLine($"The largest file is {largestFile.Name} with size {largestFile.Length / 1024} KB.");
        Console.Write("Would you like to delete it to free up space? (y/n): ");
        string input = Console.ReadLine().ToLower();

        if (input == "y")
        {
            try
            {
                largestFile.Delete();
                Console.WriteLine($"{largestFile.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {largestFile.Name}: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"{largestFile.Name} was not deleted.");
        }
    }

    // Delete the oldest file
    public void PromptForOldestFileDeletion(FileInfo oldestFile)
    {
        Console.WriteLine($"The oldest file is {oldestFile.Name}, last modified on {oldestFile.LastWriteTime}.");
        Console.Write("Would you like to delete it? (y/n): ");
        string input = Console.ReadLine().ToLower();

        if (input == "y")
        {
            try
            {
                oldestFile.Delete();
                Console.WriteLine($"{oldestFile.Name} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to delete {oldestFile.Name}: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"{oldestFile.Name} was not deleted.");
        }
    }
}