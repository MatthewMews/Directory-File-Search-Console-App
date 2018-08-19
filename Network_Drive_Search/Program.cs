using System;
using System.Collections.Generic;
using System.IO;

namespace Network_Drive_Search
{
    public class Program
    {
        private static List<string> foundFiles = new List<string>();
        private static List<string> foundDirectories = new List<string>();

        public static void Main(string[] args)
        {
            Console.Title = "Network Drive Search";

            string path = @"Network Path Here";

            RemovePreviousFiles();

            PerformSearch(path);

            WriteInformationToFile(foundDirectories, foundFiles);

            CleanUp();

            Console.ReadKey();
        }

        private static void RemovePreviousFiles()
        {
            string directoryTextFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/Network_Directory_Search.txt";
            string fileTextFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/Network_File_Search.txt";

            if (File.Exists(directoryTextFile))
            {
                File.Delete(directoryTextFile);
                Console.WriteLine("The previous network_directory_search text document was deleted succesfully.");
            }
            else
            {
                Console.WriteLine("Unable to locate previous directory search result file for deletion.");
            }

            if (File.Exists(fileTextFile))
            {
                File.Delete(fileTextFile);
                Console.WriteLine("The previous network_file_search text document was deleted succesfully.\n");
            }
            else
            {
                Console.WriteLine("Unable to locate previous file search result file for deletion.\n");
            }
        }

        private static void PerformSearch(string directoryPath)
        {
            Console.WriteLine("Please Note: This process can take up to one hour to complete.");

            Console.WriteLine("Searching for directories...");

            string[] directorySearch = Directory.GetDirectories(directoryPath, "*", SearchOption.AllDirectories);

            Console.WriteLine("Searching for files...");

            string[] fileSearch = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

            foreach (string directory in directorySearch)
            {
                Console.WriteLine("Directory Found: " + directory);
                foundDirectories.Add(directory);
            }
            foreach (string file in fileSearch)
            {
                Console.WriteLine("File Found: " + file);
                foundFiles.Add(file);
            }
        }

        private static void WriteInformationToFile(List<string> foundDirectories, List<string> foundFiles)
        {
            Console.WriteLine("Writing directory information to the text file...");

            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/Network__Directory_Search.txt", true))
            {
                foreach (string directory in foundDirectories)
                {
                    sw.WriteLine(directory);
                }
            }

            Console.WriteLine("Finished writing directory information.");

            Console.WriteLine("Writing file information to the text file...");

            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"/Network_File_Search.txt", true))
            {
                foreach (string file in foundFiles)
                {
                    sw.WriteLine(file);
                }
            }

            Console.WriteLine("Finshing writing file information.");

            Console.WriteLine("Task completed successfully.");
        }

        private static void CleanUp()
        {
            foundFiles.Clear();
            foundDirectories.Clear();
        }
    }
}