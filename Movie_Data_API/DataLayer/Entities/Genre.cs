using System.ComponentModel.DataAnnotations;

namespace Movie_Data_API.DataLayer.Entities
{
    public class Genre
    {
        [Key]
        public int Genre_ID { get; set; }
        public string Genre_Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
