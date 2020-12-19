using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Makers_of_Denmark.DAL;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Makers_of_Denmark.Controllers
{
    public class FeedController : Controller
    {
        private HTTPHelper _httpHelper;
        private string endpoint = "makerspace";

        private FeedData feedData;
        public FeedController() 
        {
            _httpHelper = new HTTPHelper();
            feedData = new FeedData();
        }
        public async Task<IActionResult> IndexAsync()
        {

            List<Makerspace> makerspaces = await _httpHelper.Get<List<Makerspace>>(endpoint);
            List<Event> events = await _httpHelper.Get<List<Event>>("event");

            feedData.makerSpaces = makerspaces;
            feedData.events = events;

            return View(feedData);
        }
    }
}
