using System.Text.Json.Serialization;

namespace Peliculas.Core.DTOs
{
    public class MoviesDto
    {  
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public int IdClassification { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public virtual ClassificationsDto? IdClassificationNavigation { get; set; }
    }
}
