using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Core.Entities
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; } 
        public string User { get; set; }
        public string Password { get; set; } 
    }
}
