using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<PropertiesController> logger;
        private readonly IMapper mapper;

        public PropertiesController(IUnitOfWork uow, ILogger<PropertiesController> logger, IMapper mapper )
        {
            this.uow = uow;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperties()
        {
             var properties= await uow.propertyRepository.GetPropertiesAsync();
             var propertiesDTO = mapper.Map<IEnumerable<PropertyDTO>>(properties);

            return Ok(propertiesDTO);
        }
       
        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await uow.propertyRepository.FindProperty(op => op.Id == id, new List<string> { "City" });
            var result = mapper.Map<PropertyDTO>(property);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperty(createPropertyDTO propDTO)
        {

            if (!ModelState.IsValid)
            {
                logger.LogError($"Invalid Post Attempt In {nameof(AddProperty)}");
                return BadRequest(ModelState);
            }
            var property = mapper.Map<Property>(propDTO);

            uow.propertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return CreatedAtRoute("GetProperty", new { id = property.Id }, property);
        }

       
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateProperty(int id, updatePropertyDTO propDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateProperty)}");
                return BadRequest(ModelState);
            }
            var propertyFromDb = await uow.propertyRepository.FindProperty(op => op.Id == id);

            if (propertyFromDb == null)
            {
                logger.LogError($"Invalid UPDATE attempt In {nameof(UpdateProperty)}");
                return BadRequest("Submitted data is invalid");
            }
            
            mapper.Map(propDTO, propertyFromDb);
            uow.propertyRepository.Update(propertyFromDb);
            
            await uow.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            if (id < 1)
            {
                logger.LogError($"Invalid DELETE Attempt In {nameof(DeleteProperty)}");
                return BadRequest(ModelState);
            }
            uow.propertyRepository.Delete(id);
            await uow.SaveAsync();
            return NoContent();
        }

    }
}
