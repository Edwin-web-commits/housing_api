using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;
        private readonly DbSet<City> _db;

        public CityRepository(DataContext dc)
        {
            this.dc = dc;
            _db = dc.Set<City>();
        }

        

        public void AddCity(City city)
        {
            dc.Cities.AddAsync(city);
        }

        public void Delete(int CityId)
        {
            var city = dc.Cities.Find(CityId);
            dc.Cities.Remove(city);
        }

        public async Task<City> FindCity(Expression<Func<City, bool>> expression, List<string> includes = null)
        {
            IQueryable<City> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }

        public void Update(City city)
        {
            _db.Attach(city);
            dc.Entry(city).State = EntityState.Modified;
        }
    }
}
