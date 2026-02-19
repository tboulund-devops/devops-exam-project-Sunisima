using Movie_Data_API.DataLayer.Entities;

namespace Movie_Data_API.Services.DTOCollection.MoviesDTOs
{
    public class MovieUpdateDTO
    {
        public int Movie_ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
