using System; 
using System.Linq; 
using System.Xml.Linq; // Namespace for working with XML data
using OfficeOpenXml; // Namespace for working with Excel files using EPPlus library
using System.Collections.Generic; 
using System.IO;

namespace FileReadingApp
{
    public class XmlFileReader : FileReaderBase
    {
        public static void ReadXmlFile(string filePath)
        {
            Console.WriteLine("========= Read XML file =============="); 
            XDocument doc = XDocument.Load(filePath); // Load the XML document from the specified file path
            var books = from book in doc.Descendants("book") // Query XML to select "book" elements
                        select new Book
                        {
                            Category = book.Attribute("category").Value, // Get the category attribute value
                            Title = book.Element("title").Value, // Get the title element value
                            Author = book.Element("author").Value, // Get the author element value
                            Year = book.Element("year").Value, // Get the year element value
                            Price = book.Element("price").Value // Get the price element value
                        };

            PrintTable(books); // Print the books data in table format
            SaveToExcel(books.ToList(), @"C:\Users\Akashdeep Singh\Desktop\Books.xlsx"); // Save the books data to an Excel file
        }

        private static void SaveToExcel(List<Book> books, string filePath)
        {
            // Set the license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set EPPlus library license context to non-commercial

            using (var package = new ExcelPackage()) // Create a new Excel package
            {
                var worksheet = package.Workbook.Worksheets.Add("Books"); // Add a new worksheet named "Books"
                worksheet.Cells[1, 1].Value = "Category"; // Add header for Category
                worksheet.Cells[1, 2].Value = "Title"; // Add header for Title
                worksheet.Cells[1, 3].Value = "Author"; // Add header for Author
                worksheet.Cells[1, 4].Value = "Year"; // Add header for Year
                worksheet.Cells[1, 5].Value = "Price"; // Add header for Price

                for (int i = 0; i < books.Count; i++) // Iterate through the list of books
                {
                    worksheet.Cells[i + 2, 1].Value = books[i].Category; // Add book Category
                    worksheet.Cells[i + 2, 2].Value = books[i].Title; // Add book Title
                    worksheet.Cells[i + 2, 3].Value = books[i].Author; // Add book Author
                    worksheet.Cells[i + 2, 4].Value = books[i].Year; // Add book Year
                    worksheet.Cells[i + 2, 5].Value = books[i].Price; // Add book Price
                }

                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile); // Save the Excel package
                Console.WriteLine($"Excel file saved to: {excelFile.FullName}"); 
            }
        }
    }
}