using Movie_Data_API.Services.DTOCollection.MoviesDTOs;
using Movie_Data_API.Services.Interfaces;

namespace Movie_Data_API.Services
{
    /// <summary>
    /// A service class responsible for handling movie-related operations.
    /// </summary>
    public class MoviesService : IMoviesService
    {

        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <returns> a list of DisplayAllMoviesDTO </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<DisplayAllMoviesDTO>> GetAllMoviesAsync()
        {
            List<Movie> movies = await _moviesCollection.Find(_ => true).ToListAsync();
            return movies.ConvertAll(movie => movie.MapMoviesDomainToDisplayAllMoviesDTO());
        }

        /// <summary>
        /// Gets a single movie by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns> A MovieDetailsDTO object if found, otherwise null. </returns>
        public async Task<MovieDetailsDTO?> GetMovieByIDAsync(string id)
        {
            var movie = await _moviesCollection.
                Find(movie => movie.Id == id).FirstOrDefaultAsync();

            return movie is null ? null : movie.MapMoviesDomainToMovieDetailsDTO();
        }
    }
}
