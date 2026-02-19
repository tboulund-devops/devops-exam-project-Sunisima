using Movie_Data_API.DataLayer.Entities;
using System.Collections.ObjectModel;

namespace Movie_Data_API.Services.DTOCollection.MoviesDTOs
{
    /// <summary>
    /// DTO for displaying details of a single movie.
    /// </summary>
    public class MovieDetailsDTO
    {
        public int Movie_ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public List<string> Genres { get; set; }
        public List<Actor> Actors { get; set; }
        public int User_ID { get; set; }
        public string UserName { get; set; }
        public ICollection<DisplayReviewDTO> Reviews { get; set; }
    }
}
