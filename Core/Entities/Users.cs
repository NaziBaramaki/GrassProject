using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities{
    
    public class Users : IdentityUser
    {
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string ip { get; set; }
        public Boolean isDeleted { get; set; }
    
        public string Fname {get; set; }
        public string Lname { get; set; }        
        

    }
}
