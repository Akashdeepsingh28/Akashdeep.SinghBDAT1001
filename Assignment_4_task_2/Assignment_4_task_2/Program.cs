using System;

namespace FileReadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = @"C:\Users\Akashdeep Singh\Desktop\information encoding\Assignment 3\Assignment_4_task_2\Books.xml"; // Path to the XML file
            string jsonFilePath = @"C:\Users\Akashdeep Singh\Desktop\information encoding\Assignment 3\Assignment_4_task_2\Books.json"; // Path to the JSON file
            string csvFilePath = @"C:\Users\Akashdeep Singh\Desktop\information encoding\Assignment 3\Assignment_4_task_2\Books.csv"; // Path to the CSV file

            XmlFileReader.ReadXmlFile(xmlFilePath); // Read and process the XML file
            Console.WriteLine(); // Print a blank line for separation

            JsonFileReader.ReadJsonFile(jsonFilePath); // Read and process the JSON file
            Console.WriteLine(); 

            CsvFileReader.ReadCsvFile(csvFilePath); // Read and process the CSV file
        }
    }
}