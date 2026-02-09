namespace Movie_Data_API.Endpoints;
using Microsoft.AspNetCore.Mvc;

public static class ViewMovieSeriesEndpoints
{
    public static void MapMovieSeriesEndpoints(this WebApplication app)
    {
        app.MapGet("/")
    }
}