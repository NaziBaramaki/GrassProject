﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

    }
}
