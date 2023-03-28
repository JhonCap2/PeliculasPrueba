using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Peliculas.Core.Entities
{
    public partial class Movies
    {
        public int IdMovie { get; set; }
        public int IdClassification { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }

        [JsonIgnore]
        public virtual Classifications? IdClassificationNavigation { get; set; }

        
    }
}
