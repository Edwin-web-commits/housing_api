using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class LoginUserDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }


    public class UserDTO : LoginUserDTO
    {    
            public string FirstName { get; set; }
            public string LastName { get; set; }

            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
            public DateTime LastUpdatedOn { get; set; }
            public string LastUpdatedBy { get; set; }

        //  public ICollection<string> Roles { get; set; }

    }
}
