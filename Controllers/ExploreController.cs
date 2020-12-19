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
    public class ExploreController : Controller
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndPoint { get; set; }

        private ExploreData exploreData;
        public ExploreController()
        {
            BaseEndPoint = new Uri("https://makersofdenmark.azurewebsites.net");
            _httpClient = new HttpClient();
            exploreData = new ExploreData();
        }
        public async Task<IActionResult> IndexAsync()
        {
            var response = await _httpClient.GetAsync(BaseEndPoint + "/MakerSpace", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            exploreData.makerSpaces = JsonConvert.DeserializeObject<List<Makerspace>>(data);

            response = await _httpClient.GetAsync(BaseEndPoint + "/event", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            data = await response.Content.ReadAsStringAsync();
            exploreData.events = JsonConvert.DeserializeObject<List<Event>>(data);

            return View(exploreData);
        }
    }
}
