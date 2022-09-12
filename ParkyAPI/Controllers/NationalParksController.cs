using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.Dtos;
using ParkyAPI.Repositories;
using System;
using System.Collections.Generic;

namespace ParkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private readonly INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParksController(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var objList = _npRepo.GetAll();
            var objListDto = new List<NationalParkDto>();
            if (objList == null)
                return BadRequest();

            foreach (var obj in objList)
            {
                objListDto.Add(_mapper.Map<NationalParkDto>(obj));
            }
            return Ok(objListDto);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var obj = _npRepo.GetById(id);
            if (obj == null)
                return BadRequest();

            var objDto = _mapper.Map<NationalParkDto>(obj);
            return Ok(objDto);
        }

        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            var objList = _npRepo.GetByName(name);
            if (objList == null)
                return BadRequest();

            var objListDto = new List<NationalParkDto>();
            foreach (var obj in objList)
            {
                objListDto.Add(_mapper.Map<NationalParkDto>(obj));
            }
            return Ok(objListDto);
        }
        [HttpPost]
        public IActionResult CreateNew([FromBody] NationalParkDtoNotId nationalParkDtoNotId)
        {
            if (nationalParkDtoNotId == null) 
                return BadRequest();

            var obj = _mapper.Map<NationalPark>(nationalParkDtoNotId);
            _npRepo.CreateNew(obj);
            _npRepo.Save();
            return Ok(obj);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var obj = _npRepo.GetById(id);
            if (obj == null)
                return NotFound();

            _npRepo.DeleteById(obj);
            _npRepo.Save();
            return Ok("Deleted");
        }

        [HttpPatch]
        public IActionResult UpdateById(int id, [FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || nationalParkDto.Id != id)     
                return BadRequest();

            var obj = _mapper.Map<NationalPark>(nationalParkDto);
            _npRepo.UpdateById(obj);
            _npRepo.Save();
            return Ok(obj);
        }
    }
}
