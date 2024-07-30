using MediatR;
using Movies.Application.Commands.Movies.CreateMovie;
using Movies.Application.Commands.Movies.DeleteMovie;
using Movies.Application.Commands.Movies.UpdateMovie;
using Movies.Application.Queries.Movies.GetMovies;
using Movies.Application.Queries.Movies.GetMoviesById;
using Movies.Contract.Requests.Movies;

namespace Movies.Presentation.Modules
{
    public static class MoviesModule
    {
        public static void AddMoviesEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/movies/", async (IMediator mediator, CancellationToken ct) =>
            {
                var movies = await mediator.Send(new GetMovieQuery(), ct);
                return Results.Ok(movies);
            }).WithTags("Movies");

            app.MapGet("/api/movies/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
            {
                var movie = await mediator.Send(new GetMovieByIdQuery(id), ct);
            }).WithTags("Movies");

            app.MapPost("/api/movies", async (IMediator mediator, CreateMovieRequest createMovieRequest,
           CancellationToken ct) =>
            {
                var command = new CreateMovieCommand(createMovieRequest.Title, createMovieRequest.Description,
                    createMovieRequest.Category);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Movies");

            app.MapPut("/api/movies/{id}", async (IMediator mediator, int id,
            UpdateMovieRequest updateMovieRequest, CancellationToken ct) =>
             {
                 var command = new UpdateMovieCommand(id, updateMovieRequest.Title, updateMovieRequest.Description,
                     updateMovieRequest.Category);
                 var result = await mediator.Send(command, ct);
                 return Results.Ok(result);
             }).WithTags("Movies");

            app.MapDelete("/api/movies/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
            {
                var command = new DeleteMovieCommand(id);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Movies");
        }
    }
}
