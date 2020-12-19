using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Makers_of_Denmark.DAL;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Makers_of_Denmark.Controllers
{
    public class EventController : Controller
    {
        private HTTPHelper _httpHelper;
        private string endpoint = "event";

        public EventController()
        {
            _httpHelper = new HTTPHelper();
        }


        // GET: Event/5
        [Route("[controller]/{id?}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            Event eventData = await _httpHelper.GetWithID<Event>(endpoint, id);
            Makerspace makerspace = await _httpHelper.GetWithID<Makerspace>("makerspace", eventData.makerSpaceId);
            eventData.makerspace = makerspace;
            return View(eventData);
        }
    }
}
