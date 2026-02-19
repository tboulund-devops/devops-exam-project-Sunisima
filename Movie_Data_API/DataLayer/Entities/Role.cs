using System.ComponentModel.DataAnnotations;

namespace Movie_Data_API.DataLayer.Entities
{
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }
        public string Role_Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
