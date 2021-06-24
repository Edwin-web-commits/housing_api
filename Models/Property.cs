using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Property
    {
        
        public int Id { get; set; }
    
        public int SellRent { get; set;}
   
        public string Name { get; set; }

        [ForeignKey(nameof(PropertyType))]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
    
        public int BHK { get; set; }

        [ForeignKey(nameof(FurnishingType))]
        public int FurnishingTypeId { get; set; }
        public FurnishingType FurnishingType { get; set; }
    
        public double Price { get; set; }
    
        public int BuiltArea { get; set; }
    
        public int CarpetArea { get; set; }
    

        public string Address { get; set; }
        public string Address2 { get; set; }
        

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
   
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

        [ForeignKey(nameof(User))]
        public string PostedBy { get; set; }
        public User User { get; set; }

        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
