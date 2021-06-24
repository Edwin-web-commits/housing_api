using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{   
    [Table("Photos")]
    public class Photo
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}