using System.Collections.Generic;

using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using CountryApp.Models;

namespace CountryApp.Services
{
    public static class GeonamesService
    {
        public async static Task<List<Country>> GetCountries()
        {
            string key = "icebeam";
            string url = $"http://api.geonames.org/countryInfoJSON?username={key}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                CountryInfo info = JsonConvert.DeserializeObject<CountryInfo>(json);
                return info.Geonames;
            }

            return new List<Country>();
        }
    }
}
