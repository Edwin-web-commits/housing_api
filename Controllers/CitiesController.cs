using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CitiesController> _logger;
        public  readonly IMapper mapper;

        public CitiesController(IUnitOfWork uow, ILogger<CitiesController> logger, IMapper mapper)
        {
            this.uow = uow;
            this._logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCities()
        {

            var cities = await uow.cityRepository.GetCitiesAsync();
            var citiesDTO = mapper.Map<IEnumerable<CityDTO>>(cities);
            

            return Ok(citiesDTO);
        }

        [Authorize]
        [HttpGet("{id:int}", Name = "GetCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCity(int id)
        {

            var city = await uow.cityRepository.FindCity(id);
            var result = mapper.Map<CityDTO>(city);
            return Ok(result);


        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCity(CityDTO cityDTO)
        {

            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid Post Attempt In {nameof(AddCity)}");
                return BadRequest(ModelState);
            }
            var city = mapper.Map<City>(cityDTO);
                city.LastUpdatedBy = cityDTO.Id;
                city.LastUpdatedOn = DateTime.Now;
             
    

             uow.cityRepository.AddCity(city);
            await uow.SaveAsync();
            return CreatedAtRoute("GetCity", new { id = city.Id }, city);
        }

        [Authorize]
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCity(int id, CityDTO cityDTO) 
        {
            if(   !ModelState.IsValid || id != cityDTO.Id)
            {
                _logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateCity)}");
                return BadRequest(ModelState);
            }
            var cityFromDb = await uow.cityRepository.FindCity(id);

            if (cityFromDb == null)
            {
                _logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateCity)}");
                return BadRequest("Submitted data is invalid");
            }
            cityFromDb.LastUpdatedBy = cityFromDb.Id;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDTO, cityFromDb);
            await uow.SaveAsync();

            return NoContent();
        }

        [Authorize]
        [HttpPatch("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateCityPatch)}");
                return BadRequest(ModelState);
            }

            var cityFromDb = await uow.cityRepository.FindCity(id);
            if (cityFromDb == null)
            {
                _logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateCityPatch)}");
                return BadRequest("Submitted data is invalid");
            }
            cityFromDb.LastUpdatedBy = cityFromDb.Id;
            cityFromDb.LastUpdatedOn = DateTime.Now;

            cityToPatch.ApplyTo(cityFromDb, ModelState); 
            await uow.SaveAsync();

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE Attempt In {nameof(DeleteCity)}");
                return BadRequest(ModelState);
            }
             uow.cityRepository.Delete(id);
            await uow.SaveAsync();
            return NoContent();
        }
    }
}
