using Movie_Data_API.Services.DTOCollection.MoviesDTOs;

namespace Movie_Data_API.Services.Interfaces;

public interface IMoviesService
{
    ICollection<MovieDisplayDTO> GetAllMovies();
    Task<MovieDetailsDTO?> GetMovieByIDAsync(int id);
    Task AddMovieAsync(MovieCreateDTO movieCreateDTO);
    Task UpdateMovieAsync(MovieUpdateDTO movieUpdateDTO);
}