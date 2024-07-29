using Movies.Contract.Dtos;

namespace Movies.Contract.Responses
{
    public record GetMovieResponse(List<MovieDto> MovieDtos);

}
