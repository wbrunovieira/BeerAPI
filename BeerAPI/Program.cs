using System;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var beerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beers/?key=c49e09828748e0a8939b88ef9aa442a3").Result;
            var beers = JsonConvert.DeserializeObject<BeerList>(beerResponse);
            

            foreach (var item in beers.data)
            {
                Console.WriteLine($"  Name: {item.name}");
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------");

            var randomBeerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beer/random/?key=c49e09828748e0a8939b88ef9aa442a3").Result;
            JToken rBeer = JToken.Parse(randomBeerResponse);
            var rBeerName = rBeer.SelectToken("data.name").ToString();

            Console.WriteLine("Random Beer: ");
            Console.WriteLine(rBeerName);
            Console.ReadLine();


        }
    }
}
