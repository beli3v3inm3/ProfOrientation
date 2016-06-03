using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proforientation.Models
{
    public class SubProfession
    {
        public int Id { get; set; }
        public int ProfId { get; set; }
        public string SubName { get; set; }
        public string SubDescription { get; set; }
        public int Cost { get; set; }
        public string ImgUrl { get; set; }
    }
}