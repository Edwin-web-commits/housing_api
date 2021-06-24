using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User : IdentityUser
    {
       
        //public int Id { get; set; }
        public string FirstName { get; set; }
        
        public string LastName{ get; set; }
    }
}
