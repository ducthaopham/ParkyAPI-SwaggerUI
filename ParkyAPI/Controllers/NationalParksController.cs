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
    [Route("api/[controller]")]
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_ser.GetById(id));
        }
        [HttpGet("name={name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(_ser.GetByName(name));
        }
        [HttpPost]
        public IActionResult CreateNew(NationalParkCreateVM vm)
        {
            return Ok(_ser.CreateNew(vm));
        }
        [HttpPatch]
        public IActionResult UpdateById(int id, NationalParkVM vm)
        {
            return Ok(_ser.UpdateById(id,vm));
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            return Ok(_ser.DeleteById(id));
        }
    }
}
