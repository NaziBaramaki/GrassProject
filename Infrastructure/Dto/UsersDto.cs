using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class UsersDto
    {

        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string IP { get; set; }        
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public string Token { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

    }
}
