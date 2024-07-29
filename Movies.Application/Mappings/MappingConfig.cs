using Mapster;
using Movies.Contract.Responses;
using Movies.Domain.Entities;

namespace Movies.Application.Mappings
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<List<Movie>, GetMovieResponse>.NewConfig()
                .Map(dest => dest.MovieDtos, src => src);

            TypeAdapterConfig<Movie, GetMovieByIdResponse>.NewConfig()
                .Map(dest => dest.movieDto, src => src);
        }

    }
}
