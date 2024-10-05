using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a Directory Path: ");

        string directoryPath = Console.ReadLine();

        try
        {
            // Check if the directory exists
            if (Directory.Exists(directoryPath))
            {
                // Get a list of all files in the directory
                var files = Directory.EnumerateFiles(directoryPath);

                // Display the count and list of files
                Console.WriteLine("Files: {0}", files.Count());
                Console.WriteLine("List of Files");

                foreach (var file in files)
                {
                    // Create a FileInfo object for each file
                    FileInfo fileInfo = new FileInfo(file);

                    long fileSizeInBytes = fileInfo.Length;

                    string fileName = Path.GetFileName(file);

                    // Print file name and file size
                    Console.Write($"File: {fileName}");
                    if (fileSizeInBytes > 1024)
                    {
                        double fileSizeInKB = fileSizeInBytes/1024;
                        Console.WriteLine($" - Size: {fileSizeInKB} KB");
                    }
                    else if (fileSizeInBytes > 1024 * 1024)
                    {
                        double fileSizeInMB = fileSizeInBytes/(1024*1024);
                        Console.WriteLine($" - Size: {fileSizeInMB} MB");
                    }
                    else
                    {
                        Console.WriteLine($" - Size: {fileSizeInBytes} bytes");
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
            // Handle any exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
