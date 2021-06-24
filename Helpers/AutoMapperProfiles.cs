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

           // CreateMap<PropertyType, PropertyTypeDTO>().ReverseMap(); //two way mapping
            CreateMap<PropertyType, KeyValuePairDTO>().ReverseMap(); //two way mapping
            CreateMap<FurnishingType, FurnishingTypeDTO>().ReverseMap();
            //.......
            //In the first case, We only want to map the Name property in the City model with the city field in the PropertyListDTO model.
            //The source(Property) and destination(PropertyListDTO) have different types or names in their fields.
            // For those fields or names where their types are different from source and destination,we can...
            //create a custom mapping for individual fields using ForMember method.
            //......
            CreateMap<Property, PropertyListDTO>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City.Country))
                .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name));

            CreateMap<Property, PropertyDetailDTO>()
                .ForMember(d => d.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(d => d.Country, opt => opt.MapFrom(src => src.City.Country))
                .ForMember(d => d.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name))
                .ForMember(d => d.FurnishingType, opt => opt.MapFrom(src => src.FurnishingType.Name));
        }
    }
}
