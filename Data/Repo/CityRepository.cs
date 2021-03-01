﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Interfaces;
using WebAPI.Models;

namespace WebAPI.Data.Repo
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dc;

        public CityRepository(DataContext dc)
        {
            this.dc = dc;
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

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await dc.Cities.ToListAsync();
        }

      
    }
}