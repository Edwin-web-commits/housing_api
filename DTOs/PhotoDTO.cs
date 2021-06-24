using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    [Table("Photos")]
    public class PhotoDTO
    {
        
        public string Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        
        public bool IsPrimary { get; set; }
        public int PropertyId { get; set; }
        public PropertyDTO Property { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
