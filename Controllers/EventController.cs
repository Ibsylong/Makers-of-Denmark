using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Makers_of_Denmark.Controllers
{
    public class EventController : Controller
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndPoint { get; set; }
        private string endpoint = "event";

        public EventController()
        {
            BaseEndPoint = new Uri("https://makersofdenmark.azurewebsites.net");
            _httpClient = new HttpClient();
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseEndPoint}/{endpoint}/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var eventData = await response.Content.ReadAsStringAsync();
            Event myEvent = JsonConvert.DeserializeObject<Event>(eventData);
            
            var makerspaceResponse = await _httpClient.GetAsync($"{BaseEndPoint}/makerspace/{myEvent.makerSpaceId}", HttpCompletionOption.ResponseHeadersRead);
            makerspaceResponse.EnsureSuccessStatusCode();
            var makerspaceData = await makerspaceResponse.Content.ReadAsStringAsync();
            Makerspace makerspace = JsonConvert.DeserializeObject<Makerspace>(makerspaceData);
            myEvent.makerspace = makerspace;

            return View(myEvent);
        }
    }
}
