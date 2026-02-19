namespace Movie_Data_API.Services.DTOCollection.MoviesDTOs
{
    /// <summary>
    /// DTO for displaying all movies in the database. 
    /// This DTO is used to transfer data from the MoviesDomain to the client when requesting all movies.
    /// </summary>
    public class MovieDisplayDTO
    {
        public int Movie_ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
    }
}
