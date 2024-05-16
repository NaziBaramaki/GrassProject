using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("RequestTbl",Schema ="Bussiness" )]
    public class Requests
    {
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string IP { get; set; }

        [Key]
        public string Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }
        public string requestNumber { get; set; }

        [ForeignKey("GrassTbl")]
        public int grassId { get; set; }
    }
}
