using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Makers_of_Denmark.Controllers
{
    public class FeedController : Controller
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndPoint { get; set; }
        public FeedController() 
        {
            // Set the port to whatever the API port is once you've started it once. Shouldn't change on restarts.
            BaseEndPoint = new Uri("https://makersofdenmark.azurewebsites.net");
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> IndexAsync()
        {
            // use HTTP client to read data from API. Move on once the headers have been read. Errors are caught slightly quicker this way.
            var response = await _httpClient.GetAsync(BaseEndPoint + "/MakerSpace", HttpCompletionOption.ResponseHeadersRead);
            // Make sure that we got a success status code in the headers. Returns an exception (and 500 status code) if not successful
            response.EnsureSuccessStatusCode();
            // Turn the response body into a string
            var data = await response.Content.ReadAsStringAsync();
            // Treat the response body string as JSON, and deserialize it into a list of flights

            //return View(JsonConvert.DeserializeObject<List<Makerspace>>(data));
            return View();
        }
    }
}
