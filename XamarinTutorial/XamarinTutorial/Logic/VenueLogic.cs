using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinTutorial.Models;

namespace XamarinTutorial.Logic
{
    public class VenueLogic
    {
        public VenueLogic()
        {
        }

        public static async Task<Places> GetVenues(double lattitude, double longitude)
        {
            Places venues = new Places();

            var url = Places.GenerateSearchURL(lattitude, longitude);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri( url);
                client.DefaultRequestHeaders.Add("hello", "d");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "fsq3ej5Xu9fN8N8Uju6S0/5JUTAGaSgeSg3SJvqDzxmr3J8=");

                Console.WriteLine("Sending request");

                var response = await client.GetAsync(url);

                Console.WriteLine("Request returned");

                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Resule {result}");

                venues = JsonConvert.DeserializeObject<Places>(result);
            }
            
            
            return venues; 
        }
    }
}

