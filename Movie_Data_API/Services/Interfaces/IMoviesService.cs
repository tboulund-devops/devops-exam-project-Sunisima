using Movie_Data_API.Services.DTOCollection.MoviesDTOs;

namespace Movie_Data_API.Services.Interfaces;

public interface IMoviesService
{
    Task<List<DisplayAllMoviesDTO>> GetAllMoviesAsync();
    Task<MovieDetailsDTO?> GetMovieByIDAsync(string id);
}