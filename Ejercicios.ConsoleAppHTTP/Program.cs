using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Dynamic;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicios.ConsoleAppHTTP
{
    internal class Program
    {
        private static HttpClient http = new HttpClient();
        static void Main(string[] args)
        {
            //ConsultarCodigoPostal();
            //ConsultarCodigoPostal2();
            ConsultarIP();
            ConsultarIP2();

        }

        // Método GET
        // URL: api.zippopotam.us/es/11540

        static void ConsultarCodigoPostal()
        {
            Console.Clear();
            Console.Write("Escribe un Código Postal: ");
            string code = Console.ReadLine();

            http.BaseAddress = new Uri($"https://api.zippopotam.us/es/{code}");
            HttpResponseMessage response = http.GetAsync("").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var obj = JsonConvert.DeserializeObject<dynamic>(responseBodyText);

                Console.WriteLine("");
                Console.WriteLine("Datos:");
                Console.WriteLine("==============================================");
                Console.WriteLine($"CP: {obj["post code"]}");
                Console.WriteLine($"País: {obj["country"]}");
                Console.WriteLine($"");
                foreach (var item in obj["places"])
                {
                    Console.WriteLine($"Ciudad: {item["place name"]}");
                    Console.WriteLine($"Comunidad Autónoma: {item["state"]}");
                    Console.WriteLine($"Longitud: {item["longitude"]}");
                    Console.WriteLine($"Latitud: {item["latitude"]}");
                    Console.WriteLine($"");
                }
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void ConsultarCodigoPostal2()    // Una vez hechas las 2 clases después, puede hacerse así:
        {
            Console.Clear();
            Console.Write("Escribe un Código Postal: ");
            string code = Console.ReadLine();

            http.BaseAddress = new Uri($"https://api.zippopotam.us/es/{code}");
            HttpResponseMessage response = http.GetAsync("").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var obj = JsonConvert.DeserializeObject<PostalCodeInfo>(responseBodyText);

                Console.WriteLine("");
                Console.WriteLine("Datos:");
                Console.WriteLine("==============================================");
                Console.WriteLine($"CP: {obj.PostCode}");
                Console.WriteLine($"País: {obj.Country}");
                Console.WriteLine($"PaísAbreviado: {obj.CountryAbbreviation}");
                Console.WriteLine($"");
                foreach (var item in obj.Places)
                {
                    Console.WriteLine($"Ciudad: {item.PlaceName}");
                    Console.WriteLine($"Comunidad Autónoma: {item.State}");
                    Console.WriteLine($"Comunidad Autónoma Abreviado: {item.StateCode}");
                    Console.WriteLine($"Longitud: {item.Longitude}");
                    Console.WriteLine($"Latitud: {item.Longitude}");
                    Console.WriteLine($"");
                }
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void ConsultarCodigoPostal3()    // Una vez hechas las 2 clases después, puede hacerse así:
        {
            Console.Clear();
            Console.Write("Escribe un Código Postal: ");
            string code = Console.ReadLine();

            try
            {
                var data = http.GetFromJsonAsync<PostalCodeInfo>($"https://api.zippopotam.us/es/{code}").Result;
                Console.WriteLine($"CP: {data.PostCode}");

                foreach (var place in data.Places)
                    Console.WriteLine($" -> {place.PlaceName} - {place.State} ({place.StateCode}) ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
        static void ConsultarIP()    // Una vez hechas las 2 clases después, puede hacerse así:
        {
            Console.Write("Escribe la IP: ");
            string code2 = Console.ReadLine();

            http.BaseAddress = new Uri($"http://ip-api.com/json/{code2}");
            HttpResponseMessage response = http.GetAsync("").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseBodyText = response.Content.ReadAsStringAsync().Result;

                var data2 = JsonConvert.DeserializeObject<IP>(responseBodyText);

                Console.WriteLine($"");
                Console.WriteLine($"Método 1:");
                Console.WriteLine($"");
                Console.WriteLine($" -> {data2.city}, {data2.regionName} ({data2.country}) - {data2.org}, {data2.nombre} - LAT: {data2.lat}, LON: {data2.lon}");
                Console.WriteLine();
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }
        static void ConsultarIP2()    // Una vez hechas las 2 clases después, puede hacerse así:
        {
            Console.Write("Escribe la IP: ");
            string code3 = Console.ReadLine();
            try
            {
                var data3 = http.GetFromJsonAsync<IP>($"http://ip-api.com/json/{code3}").Result;
                Console.WriteLine($"");
                Console.WriteLine($"Método 2:");
                Console.WriteLine($"");
                Console.WriteLine($"IP: {data3.query}");

                Console.WriteLine($" -> {data3.city}, {data3.regionName} ({data3.country}) - {data3.org}, {data3.nombre} - LAT: {data3.lat}, LON: {data3.lon}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }


        public class PostalCodeInfo
        {
            [JsonProperty("post code")] // Los JSON estos lo que hacen es decir "lo del objeto PostCode me lo vuelcas en (post code), por si sale null
            [JsonPropertyName("post code")] // Este es para el Consultar3
            public string PostCode { get; set; }
            public string Country { get; set; }

            [JsonProperty("country abbreviation")]
            [JsonPropertyName("country abbreviation")]
            public string CountryAbbreviation { get; set; }
            public List<PostalCodePlace> Places { get; set; }
        }

        public class PostalCodePlace
        {
            [JsonProperty("place name")]
            [JsonPropertyName("place name")]
            public string PlaceName { get; set; }
            public string Longitude { get; set; }
            public string Latitude { get; set; }
            public string State { get; set; }
            [JsonProperty("state abbreviation")]
            [JsonPropertyName("state abbreviation")]
            public string StateCode { get; set; }
        }

        public class IP
        {
            public string status { get; set; }
            public string city { get; set; }
            public string region { get; set; }
            public string regionName { get; set; }
            public string country { get; set; }
            public string countryCode { get; set; }
            public string zip { get; set; }
            public decimal lat { get; set; }
            public decimal lon { get; set; }
            public string timezone { get; set; }
            public string isp { get; set; }
            public string org { get; set; }
            public string query { get; set; }
            [JsonProperty("as")]
            [JsonPropertyName("as")]
            public string nombre { get; set; }
        }
    }
}