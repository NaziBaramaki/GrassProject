using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("GrassTbl", Schema = "Bussiness")]
    public class GrassType
    {
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string IP { get; set; }
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }
}
