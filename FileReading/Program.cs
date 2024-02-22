using System; // Importing the System namespace for basic functionalities
using System.IO; // Importing the System.IO namespace for file operations
using System.Text; // Importing the System.Text namespace for encoding

public static class FileReadingProgram
{
    public static void Main()
    {
        string inputFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\inputFile.txt";

        try
        {
            CreateFile();

            // Displaying a message to read the first line from a file
            Console.Write("\n\n Read the first line from a file  :\n");
            Console.Write("---------------------------------------\n");

            // Displaying the content of the file
            using (StreamReader sr = File.OpenText(inputFileName)) // Opening a StreamReader to read the content of the file
            {
                string s = "";
                Console.WriteLine(" Here is the content of the file: ");
                while ((s = sr.ReadLine()) != null) // Looping through each line until the end of the file
                {
                    Console.WriteLine(s); // Displaying each line in the console
                }
                Console.WriteLine("");
            }

            if (File.Exists(inputFileName)) // Checking if the file exists
            {
                string[] lines = File.ReadAllLines(inputFileName); // Reading all lines from the file

                string firstLine = lines[0];
                string lastLine = lines[lines.Length - 1];
                string secondLastLine = lines[lines.Length - 2];
                string secondLine = lines[1];

                string response = FirstLineChar(lines, firstLine, lastLine);
                string response1 = LastLineChar(lines, firstLine, lastLine);
                string response2 = SecondLastLineLastChar(lines, secondLastLine, secondLine);
                string Output = $"{response + "\n" + response1 + "\n" + response2}";
                WriteInFile(Output);
            }
            else
            {
                Console.Write("\n The File doesn't exists:\n");
            }
        }
        catch (Exception MyExcep) // Catching and handling exceptions
        {
            Console.WriteLine(MyExcep.ToString()); // Displaying exception details in case of error
        }
    }

    public static void WriteInFile(string result)
    {
        string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";

        using (var fs = File.Open(outFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine(result);
            }
        }
    }

    public static void CreateFile()
    {
        string outFileName = @"C:\Users\mhaseeb.malik\source\repos\FileReading\FileReading\outputResult.txt";

        try
        {
            // Check if file already exists. If yes, delete it.
            if (File.Exists(outFileName))
            {
                File.Delete(outFileName);
            }

            // Create a new file
            using (StreamWriter sw = File.CreateText(outFileName))
            {
                sw.WriteLine("New file created: {0}", DateTime.Now.ToString());
            }
        }
        catch (Exception MyExcep) // Catching and handling exceptions
        {
            Console.WriteLine(MyExcep.ToString()); // Displaying exception details in case of error
        }
    }

    public static string SecondLastLineLastChar(string[] lines, string secondLastLine, string secondLine)
    {
        string response = "";
        if (lines.Length >= 2)
        {
            // Get the last character of the second-last line
            char lastCharSecondLastLine = GetChar(secondLastLine, 1);
            //char firstCharSecondLine = secondLine.Skip(0).First();

            // Create the output string with the first character as the last character of the input
            response = lastCharSecondLastLine + secondLine.Substring(1);
        }
        else
        {
            Console.WriteLine("Not enough lines in the input.");
        }
        return response;
    }

    public static string FirstLineChar(string[] lines, string firstLine, string lastLine)
    {
        string lastLineOutput = "";
        if (lines.Length > 0)
        {
            // Check if the last line is not empty
            if (!string.IsNullOrEmpty(lastLine))
            {
                // Get the last character of the last line
                char lastChar = GetChar(lastLine, 1);
                char firstChar = firstLine.Skip(0).First();

                lastLineOutput = lastLine.Remove(lastLine.Length - 1) + firstChar;
                //Console.WriteLine(lastLineOutput);
                //WriteInFile(lastLineOutput);
                //WriteInFile(lastLineOutput);

                string firstLineOutput = lastChar + firstLine.Substring(1);
                //Console.WriteLine(firstLineOutput);
            }
            else
            {
                Console.WriteLine("The last line is empty.");
            }
        }
        else
        {
            Console.WriteLine("No input lines found.");
        }
        return lastLineOutput;
    }

    public static string LastLineChar(string[] lines, string firstLine, string lastLine)
    {
        string firstLineOutput = "";
        if (lines.Length > 0)
        {
            // Check if the last line is not empty
            if (!string.IsNullOrEmpty(lastLine))
            {
                // Get the last character of the last line
                char lastChar = GetChar(lastLine, 1);
                char firstChar = firstLine.Skip(0).First();

                firstLineOutput = lastChar + firstLine.Substring(1);
                //Console.WriteLine(firstLineOutput);
            }
            else
            {
                Console.WriteLine("The last line is empty.");
            }
        }
        else
        {
            Console.WriteLine("No input lines found.");
        }
        return firstLineOutput;
    }

    public static char GetChar(string line, int value)
    {
        if (!string.IsNullOrEmpty(line))
        {
            return line[line.Length - value];
        }
        else
        {
            // You might want to handle the case where the line is empty
            return '\0'; // Placeholder for an empty character
        }
    }
}
