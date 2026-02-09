using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Data_API.DataLayer.Entities
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        [ForeignKey("Role")]
        public int Role_ID { get; set; }

        public Role Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
