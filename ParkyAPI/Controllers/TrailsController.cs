using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.ModelViews.TrailViewModel;
using ParkyAPI.Service.ServiceTrail;

namespace ParkyAPI.Controllers
{
    [Route("api/trails")]
    [ApiController]


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
            if(_ser.GetById(id) == null)
                return NotFound();
            return Ok(_ser.GetById(id));
        }
        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            if (_ser.GetByName(name) == null)
                return NotFound();
            return Ok(_ser.GetByName(name));
        }
        [HttpPost("add")]
        public IActionResult CreateNew(TrailCreateVM vm)
        {
            if(!_ser.CreateNew(vm))
                return BadRequest();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            if (!_ser.DeleteById(id))
                return BadRequest();
            return NoContent();
        }
        [HttpPatch]
        public IActionResult UpdateById(int id, TrailVM vm)
        {
            if(!_ser.UpdateById(id, vm))
                return BadRequest();
            return NoContent();
        }
    }
}
