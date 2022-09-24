using GetJSON.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace GetJSON.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var webClient = new WebClient();
            var Json = webClient.DownloadString(SD.NationalParkAPIPath);
            var nationalParks = JsonConvert.DeserializeObject<IEnumerable<NationalPark>>(Json);
            return View(nationalParks);
        }
    }
}
