using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proforientation.Models
{
    public class UsersToProf
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProfId { get; set; }
    }
}