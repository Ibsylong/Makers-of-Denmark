using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Makers_of_Denmark.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HttpClient _httpClient;
        private Uri BaseEndPoint { get; set; }
        private string endpoint = "user";

        public ProfileController()
        {
            BaseEndPoint = new Uri("https://makersofdenmark.azurewebsites.net");
            _httpClient = new HttpClient();
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{BaseEndPoint}/{endpoint}/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(data);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string id, User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var response = await _httpClient.PutAsync($"{BaseEndPoint}/{endpoint}/{id}", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return RedirectToAction(id, "Profile");
        }
    }
}
