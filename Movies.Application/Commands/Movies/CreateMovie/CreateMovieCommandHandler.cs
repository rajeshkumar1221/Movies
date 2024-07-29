using MediatR;
using Movies.Domain.Entities;
using Movies.InfraStructure;

namespace Movies.Application.Commands.Movies.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly MoviesDbContext _moviesDbContext;

        public CreateMovieCommandHandler(MoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                Category = request.Category,
                CreatedDate = DateTime.Now
            };
            await _moviesDbContext.AddAsync(movie, cancellationToken);

            await _moviesDbContext.SaveChangesAsync(cancellationToken);
            return movie.Id;
        }
    }
}
