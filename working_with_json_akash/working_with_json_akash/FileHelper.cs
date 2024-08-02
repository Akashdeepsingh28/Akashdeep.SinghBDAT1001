using System; 
using System.Collections.Generic; 
using OfficeOpenXml; // Namespace for working with Excel files using EPPlus library
using System.IO; 

public static class FileHelper
{
    public static void CreateUsersExcelFile(string filePath, List<akash> users)
    {
        // Set the license context to non-commercial
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the EPPlus library license context

        FileInfo file = new FileInfo(filePath); 
        if (file.Exists) // Check if the file already exists
        {
            file.Delete(); // Delete the existing file
            file = new FileInfo(filePath); // Recreate the FileInfo object
        }

        using (var package = new ExcelPackage(file)) // Create a new Excel package
        {
            var worksheet = package.Workbook.Worksheets.Add("Users"); // Add a new worksheet named "Users"

            // Add headers
            worksheet.Cells[1, 1].Value = "ID"; // Add header for ID
            worksheet.Cells[1, 2].Value = "Name"; // Add header for Name
            worksheet.Cells[1, 3].Value = "Username"; // Add header for Username
            worksheet.Cells[1, 4].Value = "Email"; // Add header for Email
            worksheet.Cells[1, 5].Value = "Address"; // Add header for Address
            worksheet.Cells[1, 6].Value = "Phone"; // Add header for Phone
            worksheet.Cells[1, 7].Value = "Website"; // Add header for Website
            worksheet.Cells[1, 8].Value = "Company"; // Add header for Company

            // Add user data
            for (int i = 0; i < users.Count; i++) // Iterate through the list of users
            {
                var user = users[i]; // Get the current user
                worksheet.Cells[i + 2, 1].Value = user.Id; // Add user ID
                worksheet.Cells[i + 2, 2].Value = user.Name; // Add user Name
                worksheet.Cells[i + 2, 3].Value = user.Username; // Add user Username
                worksheet.Cells[i + 2, 4].Value = user.Email; // Add user Email
                worksheet.Cells[i + 2, 5].Value = $"{user.Address.Street}, {user.Address.Suite}, {user.Address.City}, {user.Address.Zipcode}"; // Add user Address
                worksheet.Cells[i + 2, 6].Value = user.Phone; // Add user Phone
                worksheet.Cells[i + 2, 7].Value = user.Website; // Add user Website
                worksheet.Cells[i + 2, 8].Value = user.Company.Name; // Add user Company Name
            }

            package.Save(); // Save the Excel package
        }

      
        Console.WriteLine("{0,-25} {1,-30} {2,-20} {3,-40}", "Name", "Email", "Phone", "Address"); // Print the headers in a formatted manner
        Console.WriteLine(new string('=', 115)); 

        foreach (var user in users) // Iterate through the list of users
        {
            string address = $"{user.Address.Street}, {user.Address.Suite}, {user.Address.City}, {user.Address.Zipcode}"; // Format the address
            Console.WriteLine("{0,-25} {1,-30} {2,-20} {3,-40}", user.Name, user.Email, user.Phone, address); // Print the user details in a formatted manner
        }
    }
}