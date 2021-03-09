using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<City, CityDTO>().ReverseMap(); //two way mapping
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Property, PropertyDTO>().ReverseMap();
            CreateMap<Property, createPropertyDTO>().ReverseMap();
            CreateMap<Property, updatePropertyDTO>().ReverseMap();


        }
    }
}
