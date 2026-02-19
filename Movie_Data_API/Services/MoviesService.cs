using Microsoft.EntityFrameworkCore;
using Movie_Data_API.DataLayer;
using Movie_Data_API.DataLayer.Entities;
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

        /// <summary>
        /// Adds a new movie to the database using the provided MovieCreateDTO object.
        /// </summary>
        /// <param name="movieCreateDTO"></param>
        /// <returns></returns>
        public async Task AddMovieAsync(MovieCreateDTO movieCreateDTO)
        {
            Movie movie = movieCreateDTO.MapMovieCreateDTOToMovieDomain();
            _Context.Movies.Add(movie);
            await _Context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates the details of an existing movie asynchronously using the provided update data.
        /// </summary>
        /// <param name="movieUpdateDTO">An object containing the updated movie information. Cannot be null. The identifier within this object must
        /// correspond to an existing movie in the database.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        public async Task UpdateMovieAsync(MovieUpdateDTO movieUpdateDTO)
        {
            Movie movie = movieUpdateDTO.MapMovieUpdateDTOToMovieDomain();
            _Context.Movies.Update(movie);
            _Context.Entry(movie).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
