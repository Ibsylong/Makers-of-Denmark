using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Makers_of_Denmark.Controllers
{
    public class FeedController : Controller
    {
        public static HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            //client.BaseAddress = new Uri("http://localhost:64195/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
            //response.EnsureSuccessStatusCode();

            //// return URI of the created resource.
            //return response.Headers.Location;

            return View();
        }
    }
}