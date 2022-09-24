using Microsoft.AspNetCore.Mvc;
using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{
    public class NationalParksController : Controller
    {
        private readonly INationalParkRepo _npRepo;
        public NationalParksController(INationalParkRepo npRepo)
        {
            _npRepo = npRepo;
        }

        public async Task<IActionResult> GetAllNationalPark()
        {
            //return Json(new { data = await _npRepo.GetAllAsync(SD.NationalParkAPIPath) });
            var nationalParks = await _npRepo.GetAllAsync(SD.NationalParkAPIPath);
            return View(nationalParks);
        }
    }
}
