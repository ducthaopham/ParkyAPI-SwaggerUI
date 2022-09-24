using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.ModelViews.NationalParkViewModel;
using ParkyAPI.Repositories;
using ParkyAPI.Service.ServiceNationalPark;
using System;
using System.Collections.Generic;

namespace ParkyAPI.Controllers
{
    [Route("api/nationalparks")]
    [ApiController]

    public class NationalParksController : ControllerBase
    {
        private readonly INationalParkService _ser;
        public NationalParksController(INationalParkService ser)
        {
            _ser =ser;
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
        public IActionResult CreateNew(NationalParkCreateVM vm)
        {
            if (!_ser.CreateNew(vm)) 
                return BadRequest();
            return Ok();
        }
        [HttpPatch("update")]
        public IActionResult UpdateById(int id, NationalParkVM vm)
        {
            if (!_ser.UpdateById(id,vm))
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("delete")]
        public IActionResult DeleteById(int id)
        {
            if(!_ser.DeleteById(id))
                return BadRequest();
            return NoContent();
        }
    }
}
