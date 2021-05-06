using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Makers_of_Denmark.Models;
using Newtonsoft.Json;
using System.Collections;
using Makers_of_Denmark.DAL;

namespace Makers_of_Denmark.Controllers
{
    public class MakerspaceController : Controller
    {
        private HTTPHelper _httpHelper;
        private string endpoint = "makerspace";
        public MakerspaceController()
        {
            _httpHelper = new HTTPHelper();
        }

        // GET: Makerspace/5
        [Route("[controller]/{id?}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            Makerspace makerspace = await _httpHelper.GetWithID<Makerspace>(endpoint, id);
            return View(makerspace);
        }
    }
}
