using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Data_API.DataLayer.Entities
{
    public class Review
    {
        [Key]
        public int Review_ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        [ForeignKey("User")]
        public int User_ID { get; set; }
        [ForeignKey("Movie")]
        public int Movie_ID { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
