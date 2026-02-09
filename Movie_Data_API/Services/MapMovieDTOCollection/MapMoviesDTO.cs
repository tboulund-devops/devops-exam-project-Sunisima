using Movie_Data_API.Services.DTOCollection.MoviesDTOs;

namespace Movie_Data_API.Services.MapMovieDTOCollection
{
    public static class MapMoviesDTO
    {
        /// <summary>
        /// Maps MoviesDomain to DisplayAllMoviesDTO
        /// </summary>
        /// <param name="movies">The list of MoviesDomain objects to map.</param>
        /// <returns>A list of DisplayAllMoviesDTO objects.</returns>
        public static DisplayAllMoviesDTO MapMoviesDomainToDisplayAllMoviesDTO(this Movie movies)
        {
            return new DisplayAllMoviesDTO
            {

            };
        }

        public static MovieDetailsDTO MapMoviesDomainToMovieDetailsDTO(this Movie movies)
        {
            return new MovieDetailsDTO
            {

            };
        }
    }
}
