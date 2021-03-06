﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Data.Repo;
using WebAPI.Interfaces;

namespace WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }
        public ICityRepository cityRepository => new CityRepository(dc);

        public IPropertyRepository propertyRepository => new PropertyRepository(dc);

        public IPropertyTypeRepository PropertyTypeRepository =>  new PropertyTypeRepository(dc);

        public IFurnishingTypeRepository FurnishingTypeRepository => new FurnishingTypeRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0; 
        }
    }
}
