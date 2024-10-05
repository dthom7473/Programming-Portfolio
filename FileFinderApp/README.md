# Overview

As an aspiring computer engineer, I developed a program in the C# language in order to better understand how to navigate through files, accessing important information and potentially helping a user better manage these files. This program will prompt the user for a file path. This could be any file path on a windows computer found from the file explorer application. The user can then choose how they want these files displayed to them; alphebetically, by date modified, or file size. After selecting this, they can then choose whether or not the files will be presented in ascending or descending order based on the sorting type they chose. Sorting the file by name will display every file (Excluding folders) in the directory just as it apprears in the file explorer. Things are a little bit different when you choose to sort by date or file size. This allows an easy visualization of what is taking up the most space in that folder, or what has been in the folder for the longest and may not be relevent anymore. The program will then ask if you would like to delete the oldest or largest file in the folder to help clean up space and organize it better (Please note: the program WILL DELETE THE FILE if you choose to. Please don't do this unless you know what you're doing).

[Software Demo Video] -  https://youtu.be/sHeKJZ5hqJ8

# Development Environment

A lot of research went into making this program. I was previously unfamiliar with how to access files given a directory, but was eventually able to figure it out. I'd estimate a good 2/3 of the time making the program was used durring the research portion, and the rest was mostly troubleshooting the program to make it work as expected.

I used the following libraries:
 - System.IO - this allowed me to make the directory class and the FileInfo class. It allowed me to access attributes such as the length of the file and the last modification date, as well as the name.
 - System - allows for Console.WriteLine() and Console.ReadLine(). It also lets me use Exception handeling in my if-else statements.
 - System.Linq - used for sorting and filtering the files. This was what the FileSorter class relyed on primarily.
 - System.Collections.Generic - this provided an interface that can represent a collection of files that can be looped through. This is how I was able to convert the file types to a string.

# Useful Websites

{Make a list of websites that you found helpful in this project}

- Stack Overflow: https://stackoverflow.com/questions/4254339/how-to-loop-through-all-the-files-in-a-directory-in-c-net
- Microsoft Learn: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.delete?view=net-8.0
- GeeksForGeeks: https://www.geeksforgeeks.org/how-to-sort-list-in-c-sharp-set-1/


# Future Work

- Allow all file types to be converted to a string
- Add an option to view folders as will as files, as represented by strings
- Allow the user to delete more than one file at a time (as determined by the user)
- Allow the file to be opened directly from the program (better user interface)