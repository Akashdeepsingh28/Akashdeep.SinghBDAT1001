using System; // Namespace for basic functionalities
using System.Collections.Generic; 
using System.Threading.Tasks; 

class Program
{
    // Change this path to your desired directory
    private static string UsersFilePath = @"C:\Users\Akashdeep Singh\Desktop\information encoding\Assignment 3\Users.xlsx"; // Path to save the Excel file

    static async Task Main(string[] args)
    {
        Console.WriteLine("Fetching users..."); 
        List<akash> users = await JsonSerializationDeserialization.FetchUsersAsync("https://jsonplaceholder.typicode.com/users"); // Fetch users asynchronously from the URL
        Console.WriteLine("Users fetched successfully!"); 

        Console.WriteLine("Creating Users.xlsx..."); 
        FileHelper.CreateUsersExcelFile(UsersFilePath, users); // Create the Excel file with fetched users
        Console.WriteLine($"Users.xlsx created successfully at {UsersFilePath}!");
    }
}