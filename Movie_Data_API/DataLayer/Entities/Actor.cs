using System.ComponentModel.DataAnnotations;

namespace Movie_Data_API.DataLayer.Entities
{
    public class Actor
    {
        [Key]
        public int Actor_ID { get; set; }
        public string Actor_Name { get; set; }
        public string Actor_Lastname { get; set; }
        public DateTime Birth_Date { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
