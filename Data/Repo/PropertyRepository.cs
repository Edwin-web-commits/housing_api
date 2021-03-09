using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext dc;
        private readonly DbSet<Property> _db;

        public PropertyRepository(DataContext dc)
        {
            this.dc = dc;
            _db = dc.Set<Property>();
        }

        public void AddProperty(Property property)
        {
             dc.Properties.AddAsync(property);
            
        }

        public void Delete(int PropertyId)
        {
            var property = dc.Properties.Find(PropertyId);
            dc.Properties.Remove(property);
        }

        public async Task<Property> FindProperty(Expression<Func<Property, bool>> expression, List<string> includes = null)
        {
            IQueryable<Property> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<Property>> GetPropertiesAsync()
        {
            return await dc.Properties.ToListAsync();
        }

        public void Update(Property property)
        {
                _db.Attach(property);
                dc.Entry(property).State = EntityState.Modified;
            
        }
    }
}
