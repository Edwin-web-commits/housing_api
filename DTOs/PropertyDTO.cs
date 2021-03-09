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
    }
    public class createPropertyDTO
    {
        
        [Required]
        public int SellRent { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Hotel name is too long")]
        public string Name { get; set; }

        public string PType { get; set; }

        public int BHK { get; set; }

        public string FType { get; set; }
        [Required]
        public double Price { get; set; }

        public int BuiltArea { get; set; }

        public int CarpetArea { get; set; }

        public string Image { get; set; }

        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Property Address is too long")]
        public string Address { get; set; }

        public int CityId { get; set; }
       
        public string Description { get; set; }
        public int FloorNo { get; set; }

        public int TotalFloor { get; set; }

        public int AOP { get; set; }

        public int Bathrooms { get; set; }

        public string MainEntrance { get; set; }

        public int Gated { get; set; }
        [Required]
        public int Security { get; set; }

        public int Maintanance { get; set; }

        public string Possesion { get; set; }

        public DateTime PostedOn { get; set; }
    }

    public class updatePropertyDTO : createPropertyDTO
    { }
}
