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
    public class ExploreController : Controller
    {
        private HTTPHelper _httpHelper;

        private ExploreData exploreData;
        public ExploreController()
        {
            _httpHelper = new HTTPHelper();
            exploreData = new ExploreData();
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<Makerspace> makerspaces = await _httpHelper.Get<List<Makerspace>>("makerspace");
            List<Event> events = await _httpHelper.Get<List<Event>>("event");

            exploreData.events = events;
            exploreData.makerSpaces = makerspaces;

            foreach (var item in events)
            {
                item.makerspace = makerspaces.Find(x => x.id == item.makerSpaceId);
            }

            return View(exploreData);
        }
    }
}
