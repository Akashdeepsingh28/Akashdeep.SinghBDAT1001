using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace FileReadingApp
{
    public abstract class FileReaderBase
    {
        protected static void PrintTable(IEnumerable<Book> data)
        {
            var properties = typeof(Book).GetProperties(); 
            var columnNames = properties.Select(p => p.Name).ToArray(); // Get property names for column headers
            var rows = data.Select(item => properties.Select(p => p.GetValue(item, null)?.ToString()).ToArray()).ToList(); 

            PrintAlignedTable(columnNames, rows); // Print the table with aligned columns
        }

        protected static void PrintDynamicTable(IEnumerable<dynamic> data)
        {
            var rows = data.Select(row => ((IDictionary<string, object>)row).Values.Select(value => value?.ToString()).ToArray()).ToList(); // Convert dynamic data to a list of string arrays
            var columnNames = ((IDictionary<string, object>)data.First()).Keys.ToArray(); // Get column names from the first record

            PrintAlignedTable(columnNames, rows); // Print the table with aligned columns
        }

        private static void PrintAlignedTable(string[] columnNames, List<string[]> rows)
        {
            int[] columnWidths = new int[columnNames.Length]; // Array to hold the width of each column

            for (int i = 0; i < columnNames.Length; i++)
            {
                columnWidths[i] = columnNames[i].Length; // Initialize column widths with header lengths
            }

            foreach (var row in rows) // Iterate through each row
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i]?.Length > columnWidths[i])
                    {
                        columnWidths[i] = row[i].Length; // Update column width if data is wider
                    }
                }
            }

            PrintLine(columnNames, columnWidths); // Print the header row
            foreach (var row in rows) // Print each data row
            {
                PrintLine(row, columnWidths); // Print the row with aligned columns
            }
        }

        private static void PrintLine(string[] columns, int[] columnWidths)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                Console.Write(columns[i].PadRight(columnWidths[i] + 2)); // Print each column value with right padding
            }
            Console.WriteLine(); 
        }
    }
}