using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

using Newtonsoft.Json; 

public class akash
{
    [JsonProperty("id")] 
    public int Id { get; set; } // User ID

    [JsonProperty("name")] 
    public string Name { get; set; } // User name

    [JsonProperty("username")] 
    public string Username { get; set; } // User username

    [JsonProperty("email")] 
    public string Email { get; set; } // User email

    [JsonProperty("address")] 
    public Address Address { get; set; } // User address

    [JsonProperty("phone")] 
    public string Phone { get; set; } // User phone

    [JsonProperty("website")] 
    public string Website { get; set; } // User website

    [JsonProperty("company")] 
    public Company Company { get; set; } // User company
}

public class Address
{
    [JsonProperty("street")]
    public string Street { get; set; } // Address street

    [JsonProperty("suite")] 
    public string Suite { get; set; } // Address suite

    [JsonProperty("city")] 
    public string City { get; set; } // Address city

    [JsonProperty("zipcode")] 
    public string Zipcode { get; set; } // Address zipcode

    [JsonProperty("geo")] 
    public Geo Geo { get; set; } // Address geographic coordinates
}

public class Geo
{
    [JsonProperty("lat")] 
    public string Lat { get; set; } // Latitude

    [JsonProperty("lng")] 
    public string Lng { get; set; } // Longitude
}

public class Company
{
    [JsonProperty("name")] 
    public string Name { get; set; } // Company name

    [JsonProperty("catchPhrase")] 
    public string CatchPhrase { get; set; } // Company catchphrase

    [JsonProperty("bs")] 
    public string Bs { get; set; } // Company business strategy
}