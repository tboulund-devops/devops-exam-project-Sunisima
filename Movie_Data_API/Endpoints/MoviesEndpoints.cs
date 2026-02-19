using Microsoft.AspNetCore.Mvc;
using Movie_Data_API.Services.Interfaces;

public static class MoviesEndpoints
{
    public static void MapMoviesEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", (IMoviesService moviesService) =>
        {
            try
            {
                var movies = moviesService.GetAllMovies();
                return Results.Ok(movies);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Movies")
        .WithName("GetAllMovies")
        .WithSummary("Gets a list of all movies in the database.")
        .RequireAuthorization();


        app.MapGet("/movies/{id}", async (IMoviesService moviesService, int id) =>
        {
            try
            {
                var movie = await moviesService.GetMovieByIDAsync(id);

                return movie is null
                    ? Results.NotFound(new { Message = $"Movie with id {id} not found" })
                    : Results.Ok(movie);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Movies")
        .WithName("GetMovieByID")
        .WithSummary("Gets details for a single movie by the ID")
        .RequireAuthorization();
    }
}