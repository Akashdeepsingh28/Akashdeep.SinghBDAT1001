using System.Collections.Generic; 
using System.Net.Http;
using System.Threading.Tasks; 
using Newtonsoft.Json; // Namespace for JSON handling using Newtonsoft.Json

public static class JsonSerializationDeserialization
{
    public static async Task<List<akash>> FetchUsersAsync(string url)
    {
        using (HttpClient client = new HttpClient()) // Create a new HttpClient instance
        {
            var response = await client.GetStringAsync(url); // Fetch the JSON data from the URL asynchronously
            return JsonConvert.DeserializeObject<List<akash>>(response);
        }
    }
}