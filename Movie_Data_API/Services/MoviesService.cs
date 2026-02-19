using Microsoft.EntityFrameworkCore;
using Movie_Data_API.DataLayer;
using Movie_Data_API.Services.DTOCollection.MoviesDTOs;
using Movie_Data_API.Services.Interfaces;
using Movie_Data_API.Services.MapMovieDTOCollection;

namespace Movie_Data_API.Services
{
    /// <summary>
    /// A service class responsible for handling movie-related operations.
    /// </summary>
    public class MoviesService : IMoviesService
    {
        private readonly DBContext _Context;

        public MoviesService(DBContext context)
        {
            _Context = context;
        }
        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <returns> a list of DisplayAllMoviesDTO </returns>
        /// <exception cref="NotImplementedException"></exception>
        public ICollection<MovieDisplayDTO> GetAllMovies()
        {
            return _Context.Movies
                .Include(r => r.Reviews)
                .MapMoviesDomainToDMoviesDisplayDTO()
                .ToList();
        }

        /// <summary>
        /// Gets a single movie by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the movie to retrieve.</param>
        /// <returns> A MovieDetailsDTO object if found, otherwise null. </returns>
        public async Task<MovieDetailsDTO?> GetMovieByIDAsync(int id)
        {
            var movie = await _Context.Movies
                .Include(r => r.Reviews)
                    .ThenInclude(u => u.User)
                .Include(a => a.Actors)
                .Include(u => u.User)
                .Include(g => g.Genres)
                .FirstOrDefaultAsync(m => m.Movies_ID == id);

            return movie is null ? null : movie.MapMoviesDomainToMovieDetailsDTO();
        }
    }
}
