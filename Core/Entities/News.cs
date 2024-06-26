﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    [Table("NewsTbl", Schema = "Bussiness")]
    public class News: BaseEntity
    {
      
        [Key]
        public string Id { get; set; }
        [Required]
        public int userId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string langusge { get; set; }
        public int isImg { get; set; }
        public string picture { get; set; }        

    }
}
