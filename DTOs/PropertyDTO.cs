using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class PropertyDTO : createPropertyDTO
    {
        public int Id { get; set; }
        public CityDTO city { get; set; }
        public FurnishingTypeDTO furnishingType { get; set; }
        public PropertyTypeDTO PropertyType { get; set; }
        public UserDTO user { get; set; }
    }
    public class createPropertyDTO
    {

        
        public int SellRent { get; set; }

        public string Name { get; set; }

        public int PropertyTypeId { get; set; }
       
        public int BHK { get; set; }

        public int FurnishingTypeId { get; set; }
        
        public double Price { get; set; }

        public int BuiltArea { get; set; }

        public int CarpetArea { get; set; }


        public string Address { get; set; }
        public string Address2 { get; set; }


       
        public int CityId { get; set; }
        

        public string Description { get; set; }
        public int FloorNo { get; set; }

        public int TotalFloor { get; set; }

        public int Bathrooms { get; set; }

        public string MainEntrance { get; set; }

        public bool Gated { get; set; }

        public int Security { get; set; }
        public bool ReadyToMove { get; set; }

        public int Maintanance { get; set; }

        public DateTime EstPossesionOn { get; set; }
        public int Age { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public DateTime PostedOn = DateTime.Now;

        
        public string PostedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }

    }

    public class updatePropertyDTO : createPropertyDTO
    { }
}
