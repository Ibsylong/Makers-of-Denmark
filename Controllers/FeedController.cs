using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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

        private FeedData feedData;
        public FeedController() 
        {
            BaseEndPoint = new Uri("https://makersofdenmark.azurewebsites.net");
            _httpClient = new HttpClient();
            feedData = new FeedData();
        }
        public async Task<IActionResult> IndexAsync()
        {
            var response = await _httpClient.GetAsync(BaseEndPoint + "/MakerSpace", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            feedData.makerSpaces = JsonConvert.DeserializeObject<List<Makerspace>>(data);

            response = await _httpClient.GetAsync(BaseEndPoint + "/event", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            data = await response.Content.ReadAsStringAsync();
            feedData.events = JsonConvert.DeserializeObject<List<Event>>(data);

            return View(feedData);
        }
    }
}
