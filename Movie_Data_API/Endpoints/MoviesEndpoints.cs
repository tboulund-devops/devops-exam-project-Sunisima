using Microsoft.AspNetCore.Mvc;
using Movie_Data_API.Services.Interfaces;

public static class MoviesEndpoints
{
    public static void MapMoviesEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", async (IMoviesService moviesService) =>
        {
            try
            {
                var movies = await moviesService.GetAllMoviesAsync();
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


        app.MapGet("/movies/{id}", async (IMoviesService moviesService, string id) =>
        {
            try
            {
                var movie = await moviesService.GetMovieByIDAsync(id);

                return movie is null
                    ? Results.NotFound(new { Message = $"Movie withid {id} not found" })
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