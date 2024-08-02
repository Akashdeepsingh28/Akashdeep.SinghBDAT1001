using System; 
using System.IO; 
using System.Linq; 
using Newtonsoft.Json.Linq; // Namespace for JSON handling using Newtonsoft.Json

namespace FileReadingApp
{
    public class JsonFileReader : FileReaderBase
    {
        public static void ReadJsonFile(string filePath)
        {
            Console.WriteLine("========= Read JSON file =============="); 
            var jsonString = File.ReadAllText(filePath); // Read the entire JSON file content into a string
            var bookstore = JObject.Parse(jsonString)["bookstore"]["book"]; 

            var books = bookstore.Select(book => new Book
            {
                Category = book["category"].ToString(), // Get the category from JSON
                Title = book["title"]["text"].ToString(), // Get the title from JSON
                Author = book["author"].ToString(), // Get the author from JSON
                Year = book["year"].ToString(), // Get the year from JSON
                Price = book["price"].ToString() // Get the price from JSON
            });

            PrintTable(books); // Print the books data in table format
        }
    }
}