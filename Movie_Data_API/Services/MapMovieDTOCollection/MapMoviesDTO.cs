using Movie_Data_API.DataLayer.Entities;
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
        public static IQueryable<MovieDisplayDTO> MapMoviesDomainToDMoviesDisplayDTO(this IQueryable<Movie> movie)
        {
            return movie.Select(m => new MovieDisplayDTO
            {
                Movie_ID = m.Movies_ID,
                Title = m.Title,
                ReleaseDate = m.Release_Date,
                Description = m.Description,
                Rating = m.Reviews.Count > 0 ? m.Reviews.Average(r => r.Rating) : 0
            });
        }

        public static MovieDetailsDTO MapMoviesDomainToMovieDetailsDTO(this Movie movies)
        {
            return new MovieDetailsDTO
            {
                Movie_ID = movies.Movies_ID,
                Title = movies.Title,
                ReleaseDate = movies.Release_Date,
                Description = movies.Description,
                Rating = movies.Reviews.Count > 0 ? movies.Reviews.Average(r => r.Rating) : 0,
                Genres = movies.Genres.Select(g => g.Genre_Name).ToList(),
                Actors = movies.Actors.ToList(),
                User_ID = movies.User_ID,
                UserName = movies.User.Username,
                Reviews = movies.Reviews.Select(r => new DisplayReviewDTO
                {
                    Review_ID = r.Review_ID,
                    Movie_ID = r.Movie_ID,
                    User_ID = r.User_ID,
                    UserName = r.User.Username,
                    Comment = r.Comment,
                    Rating = r.Rating
                }).ToList()
            };
        }

        public static Movie MapMovieCreateDTOToMovieDomain(this MovieCreateDTO movieCreateDTO)
        {
            return new Movie
            {
                Title = movieCreateDTO.Title,
                Description = movieCreateDTO.Description,
                Release_Date = movieCreateDTO.ReleaseDate,
                User_ID = movieCreateDTO.User_ID,
                Genres = movieCreateDTO.Genres,
                Actors = movieCreateDTO.Actors
            };
        }

        public static Movie MapMovieUpdateDTOToMovieDomain(this MovieUpdateDTO movieUpdateDTO)
        {
            return new Movie
            {
                Movies_ID = movieUpdateDTO.Movie_ID,
                Title = movieUpdateDTO.Title,
                Description = movieUpdateDTO.Description,
                Release_Date = movieUpdateDTO.ReleaseDate,
                Genres = movieUpdateDTO.Genres,
                Actors = movieUpdateDTO.Actors
            };
        }
    }
}
