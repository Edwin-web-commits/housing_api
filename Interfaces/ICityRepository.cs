using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data.Interfaces
{
   public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void AddCity(City city);
        void Delete(int CityId);
        void Update(City city);
        Task<City> FindCity(Expression<Func<City, bool>> expression, List<string> includes = null);
       
    }
}
