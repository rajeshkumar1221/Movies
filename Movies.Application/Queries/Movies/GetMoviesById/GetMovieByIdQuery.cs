using MediatR;
using Movies.Contract.Responses;

namespace Movies.Application.Queries.Movies.GetMoviesById
{
    public record GetMovieByIdQuery(int Id) : IRequest<GetMovieByIdResponse>;

}
