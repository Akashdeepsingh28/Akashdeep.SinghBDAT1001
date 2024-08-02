using System; 
using System.Globalization; 
using System.IO; 
using System.Linq; 
using CsvHelper; 
using CsvHelper.Configuration;

namespace FileReadingApp
{
    public class CsvFileReader : FileReaderBase
    {
        public static void ReadCsvFile(string filePath)
        {
            Console.WriteLine("========= Read CSV file =============="); 
            using (var reader = new StreamReader(filePath)) // Open the CSV file for reading
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture))) 
            {
                var records = csv.GetRecords<dynamic>().ToList(); // Read all records from the CSV file and convert them to a list of dynamic objects
                PrintDynamicTable(records); // Print the records in a table format
            }
        }
    }
}