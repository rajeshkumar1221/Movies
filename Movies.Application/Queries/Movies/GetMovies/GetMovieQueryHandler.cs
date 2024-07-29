using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contract.Responses;
using Movies.InfraStructure;

namespace Movies.Application.Queries.Movies.GetMovies
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GetMovieResponse>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public GetMovieQueryHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }
        public async Task<GetMovieResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movies = await _moviesDbContext.Movies.ToListAsync(cancellationToken);
            return movies.Adapt<GetMovieResponse>();

        }
    }
}
