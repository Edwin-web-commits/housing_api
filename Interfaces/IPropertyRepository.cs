﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent);
        void AddProperty(Property property);
        void Delete(int PropertyId);
        void Update(Property property);
        Task<Property> GetPropertyDetailAsync(int id);
        Task<Property> FindProperty(Expression<Func<Property, bool>> expression, List<string> includes = null);
    }
}
