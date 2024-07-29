using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Contract.Responses;
using Movies.InfraStructure;

namespace Movies.Application.Queries.Movies.GetMovies
{
    public class GetMoviesByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, GetMovieByIdResponse>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public GetMoviesByIdQueryHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<GetMovieByIdResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _moviesDbContext.Movies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (movie is null)
            {
                throw new Exception();
            }
            return _moviesDbContext.Adapt<GetMovieByIdResponse>();
        }
    }
}
