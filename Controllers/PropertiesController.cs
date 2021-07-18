using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class PropertiesController :BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<PropertiesController> logger;
        private readonly IAuthManager authManager;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IPhotoService photoService;

        public PropertiesController(IUnitOfWork uow, UserManager<User> userManager, IAuthManager authManager, ILogger<PropertiesController> logger, IMapper mapper, IPhotoService photoService )
        {
            this.uow = uow;
            this.logger = logger;
            this.mapper = mapper;
            this.authManager = authManager;
            this.userManager = userManager;
            this.photoService = photoService;
        }

        [HttpGet("type/{sellRent}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperties(int sellRent)
        {
             var properties= await uow.propertyRepository.GetPropertiesAsync(sellRent);
             var propertiesDTO = mapper.Map<IEnumerable<PropertyListDTO>>(properties);

            return Ok(propertiesDTO);
        }
       /*
        [HttpGet("{id:int}", Name = "GetProperty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProperty(int id)
        {
            var property = await uow.propertyRepository.FindProperty(op => op.Id == id, new List<string> { "City" });
            var result = mapper.Map<PropertyDTO>(property);
            return Ok(result);
        }
       */
        [HttpGet("detail/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var property = await uow.propertyRepository.GetPropertyDetailAsync(id);
            var result = mapper.Map<PropertyDetailDTO>(property);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
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

            var userId = GetUserId();
            property.PostedBy = userId;
            property.LastUpdatedBy = userId;
            uow.propertyRepository.AddProperty(property);
            await uow.SaveAsync();
            return StatusCode(201);
          //  return CreatedAtRoute("GetProperty", new { id = property.Id }, property);
        }

        //properties/add/photo/1
        [HttpPost("add/photo/{id}")]
        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProperyPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if(result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }
            return Ok(201);
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
