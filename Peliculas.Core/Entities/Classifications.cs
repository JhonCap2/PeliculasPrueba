using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Peliculas.Core.Entities
{
    public partial class Classifications
    {
        public Classifications() 
        {
            Movies = new HashSet<Movies>();
        }
        public int IdClassification { get; set; } 
        public string Name { get; set; }

        [JsonIgnore]

        public virtual ICollection<Movies> Movies { get; set; }
    }
}
