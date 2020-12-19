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
        private string endpoint = "user";

        public ProfileController()
        {
            _httpHelper = new HTTPHelper();
        }

        [Route("[controller]/{id}")]
        public async Task<IActionResult> IndexAsync(string id)
        {
            List<User> users = await _httpHelper.Get<List<User>>(endpoint);
            User user = users.Find(user => user.id == id);
            foreach (var makerspace in user.makerspaces)
            {
                makerspace.logoUrl = FakeData.MakerspaceLogos.GetValueOrDefault(makerspace.id);
            }

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
