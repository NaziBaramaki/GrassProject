using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("NewsTbl", Schema = "Bussiness")]
    public class News: BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string userId { get; set; }
        public string farsiTitle { get; set; }
        public string farsiDescription { get; set; }
        public string farsiSubTitle { get; set; } 
        public string englishTitle { get; set; }
        public string englishDescription { get; set; }
        public string englishSubTitle { get; set; }
        public int isNews { get; set; }
        public int isProduct { get; set; }
        public int isProject { get; set; }
        public int isImg { get; set; }
        public string imgAddress { get; set; }

        //public  Users Users { get; set; }
    }
}
