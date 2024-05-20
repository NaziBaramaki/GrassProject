using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class NewsDto
    {
        public string createDate { get; set; }
        public string updateDate { get; set; }
        public string IP { get; set; }
        public string Id { get; set; }
        public int userId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string langusge { get; set; }
        public int isImg { get; set; }
        public string picture { get; set; }
    }
}
