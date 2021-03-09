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
   
        public string PType { get; set; }
    
        public int BHK { get; set; }
     
        public string FType { get; set; }
    
        public double Price { get; set; }
    
        public int BuiltArea { get; set; }
    
        public int CarpetArea { get; set; }
    
        public string Image { get; set; }

        public string Address { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
   
        public string Description { get; set; }
        public int FloorNo { get; set; }
    
        public int TotalFloor { get; set; }
   
        public int AOP { get; set; }
    
        public int Bathrooms { get; set; }
    
        public string MainEntrance { get; set; }
    
        public int Gated { get; set; }
   
        public int Security { get; set; }
 
        public int Maintanance { get; set; }
    
        public string Possesion { get; set; }
   
        public DateTime PostedOn { get; set; }
    }
}
