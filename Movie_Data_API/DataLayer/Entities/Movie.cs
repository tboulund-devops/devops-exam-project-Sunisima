using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Data_API.DataLayer.Entities
{
    public class Movie
    {
        [Key]
        public int Movies_ID { get; set; }
        public string Title { get; set; }
        public DateTime Release_Date { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public int User_ID { get; set; }

        public User User { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
