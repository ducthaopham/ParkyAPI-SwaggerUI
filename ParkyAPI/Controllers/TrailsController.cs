using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.ModelViews.TrailViewModel;
using ParkyAPI.Service.ServiceTrail;

namespace ParkyAPI.Controllers
{
    //[Route("api/trails")]
    //[ApiController]

    [ApiController]
    [Route("api/v{version:apiVersion}/trails")]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailService _ser;
        public TrailsController(ITrailService ser)
        {
            _ser = ser;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ser.GetAll());   
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_ser.GetById(id));
        }
        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            return Ok(_ser.GetByName(name));
        }
        [HttpPost]
        public IActionResult CreateNew(TrailCreateVM vm)
        {
            return Ok(_ser.CreateNew(vm));
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            return Ok(_ser.DeleteById(id));
        }
        [HttpPatch]
        public IActionResult UpdateById(int id, TrailVM vm)
        {
            return Ok(_ser.UpdateById(id, vm));
        }
    }
}
