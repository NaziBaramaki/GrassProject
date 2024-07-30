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
        public long Id { get; set; }
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
    }
}
