using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Makers_of_Denmark.DAL;
using Makers_of_Denmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace Makers_of_Denmark.Controllers
{
    public class ProfileController : Controller
    {
        private HTTPHelper _httpHelper;
        private Uri BaseEndPoint { get; set; }
        private string endpoint = "user";

        public ProfileController()
        {
            _httpHelper = new HTTPHelper();
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            User user = await _httpHelper.GetWithID<User>(endpoint, id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string id, User user)
        {
            await _httpHelper.PostWithID(endpoint, id, user);
            return RedirectToAction(id, "Profile");
        }
    }
}
