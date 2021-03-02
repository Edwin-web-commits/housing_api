using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
       
        private readonly IUnitOfWork uow;

        public  readonly IMapper mapper;

        public CitiesController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {

            var cities = await uow.cityRepository.GetCitiesAsync();
            var citiesDTO = mapper.Map<IEnumerable<CityDTO>>(cities);
            

            return Ok(citiesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityDTO cityDTO)
        {
            var city = mapper.Map<City>(cityDTO);
                city.LastUpdatedBy = 1;
                city.LastUpdatedOn = DateTime.Now;
             
    

             uow.cityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDTO cityDTO)
        {
            if(id != cityDTO.Id)
            {
                return BadRequest("Update failed");
            }
            var cityFromDb = await uow.cityRepository.FindCity(id);

            if (cityFromDb == null)
            {
                return BadRequest("Update failed");
            }
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDTO, cityFromDb);
            await uow.SaveAsync();

            return StatusCode(200);
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {

            var cityFromDb = await uow.cityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;

            cityToPatch.ApplyTo(cityFromDb, ModelState); 
            await uow.SaveAsync();

            return StatusCode(200);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.cityRepository.Delete(id);
            await uow.SaveAsync();
            return Ok(id);
        }
    }
}
