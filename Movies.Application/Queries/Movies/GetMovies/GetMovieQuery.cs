using MediatR;
using Movies.Contract.Responses;

namespace Movies.Application.Queries.Movies.GetMovies
{
    public record GetMovieQuery() : IRequest<GetMovieResponse>;

}
