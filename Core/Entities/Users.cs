using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("users",Schema ="Base")]
    public class Users: BaseEntity
    {
        
        [Key]
        public int id { get; set; }        
        public string Fname {get; set; }
        public string Lname { get; set; }

        [MinLength(10),MaxLength(20), Required]
        public string Username { get; set; }

        [MinLength(10),MaxLength(20), Required]
        public string password { get; set; }
        [MinLength(10), MaxLength(20)]
        public string Token { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}
