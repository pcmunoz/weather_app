using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace weather_app
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string baseUrl = "http://api.weatherstack.com/";
        static string current_weather = "current";
        static string API_KEY = "71bdf82fe8638ebc42c36082ecbce882";
        static async Task<ResponseModel> GetResultAsync(string path)
        {
            ResponseModel result = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var stringResp = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ResponseModel>(stringResp);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter zipcode/state/location: ");
            string zipCode = Console.ReadLine();

            if (string.IsNullOrEmpty(zipCode) || string.IsNullOrWhiteSpace(zipCode))
            {
                Console.WriteLine("No zipcode input.");
            }
            else
            {
                RunAsync(zipCode).GetAwaiter().GetResult();
            }

            Console.Write($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey(true);
        }

        static async Task RunAsync(string zipCode)
        {
            client.BaseAddress = new Uri(baseUrl + current_weather);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string path = "?access_key=" + API_KEY + "&query=" + zipCode;

            ResponseModel dataObject = await GetResultAsync(path);
            // codes with light, moderate, heavy rain
            int[] rainWeatherCodes = { 389, 386, 359, 356, 353, 314, 311, 308, 305, 302, 299, 296, 293, 266, 263, 176 };
            if (dataObject.Current != null)
            {
                bool rainCheck = rainWeatherCodes.Contains(dataObject.Current.WeatherCode);
                bool sunscreenCheck = dataObject.Current.UVIndex > 3;
                bool kiteFlightCheck = dataObject.Current.WindSpeed > 15 && !rainCheck;

                Console.WriteLine("Should I go outside? {0}", rainCheck ? "No" : "Yes");
                Console.WriteLine("Should I wear sunscreen? {0}", sunscreenCheck ? "Yes" : "No");
                Console.WriteLine("Can I fly my kite? {0}", kiteFlightCheck ? "Yes" : "No");
            }
        }
    }
}
