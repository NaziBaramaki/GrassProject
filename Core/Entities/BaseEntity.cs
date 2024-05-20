using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class BaseEntity
    {
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string ip { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
