using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makers_of_Denmark.DAL;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;

namespace Makers_of_Denmark.Controllers
{
    public class CalendarController : Controller
    {
        private HTTPHelper _httpHelper;
        private string endpoint = "event";

        public CalendarController()
        {
            _httpHelper = new HTTPHelper();
        }
        public async Task<IActionResult> IndexAsync()
        {
            List<Event> events = await _httpHelper.Get<List<Event>>(endpoint);

            foreach (var item in events)
            {
                item.makerspace = await _httpHelper.GetWithID<Makerspace>("makerspace", item.makerSpaceId);
            }
            return View(events);
        }
    }
}