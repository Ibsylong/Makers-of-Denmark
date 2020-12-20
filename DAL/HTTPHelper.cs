using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Makers_of_Denmark.DAL
{
    public class HTTPHelper
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Uri baseEndPoint =
            new Uri("https://makersofdenmark.azurewebsites.net");


        public async Task<T> Get<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(
                $"{baseEndPoint}/{endpoint}",
                HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(data);

            return result;
        }

        public async Task<T> GetWithID<T>(string endpoint, string id)
        {
            var response = await _httpClient.GetAsync(
                $"{baseEndPoint}/{endpoint}/{id}",
                HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(data);

            return result;
        }

        public async Task<Task> PostWithID(string endpoint, string id, object objectData)
        {
            string json = JsonConvert.SerializeObject(objectData);
            var response = await _httpClient.PutAsync(
                $"{baseEndPoint}/{endpoint}/{id}",
                new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return Task.CompletedTask;
        }
    }
}
