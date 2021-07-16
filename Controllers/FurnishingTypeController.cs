using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnishingTypeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<FurnishingTypeController> logger;
        private readonly IUnitOfWork uow;

        public FurnishingTypeController(IMapper mapper, ILogger<FurnishingTypeController> logger, IUnitOfWork uow)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.uow = uow;
        }
        //GET api/propertytype/list
        [HttpGet("list")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFurnishingTypes()
        {
            var furnishingTypes = await uow.FurnishingTypeRepository.GetFurnishingTypesAsync();
            var furnishingTypesDTO = mapper.Map<IEnumerable<KeyValuePairDTO>>(furnishingTypes);

            return Ok(furnishingTypesDTO);
        }

    }
}
