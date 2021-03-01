using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       
       
        private readonly IUnitOfWork uow;

        public CitiesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {

            var cities = await uow.cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City city)
        {

             uow.cityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
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
