using AutoMapper;
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
    public class AccountController : ControllerBase
    {
       
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly IAuthManager authManager;
        ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
            this.authManager = authManager;
            
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            logger.LogInformation($"Registration Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var user = mapper.Map<User>(userDTO);
            user.UserName = userDTO.Email;
            var result = await userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

           
            return Accepted();

        }


        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Login(LoginUserDTO userDTO)
        {
            logger.LogInformation($"Login Attempt for {userDTO.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await authManager.ValidateUser(userDTO))
            {
                return Unauthorized();
            }
            return Accepted(new { Token = await authManager.CreateToken() });

        }



    }
}
