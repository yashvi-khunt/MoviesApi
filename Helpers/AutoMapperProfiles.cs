using AutoMapper;
using MoviesApi.DTOs;
using MoviesApi.Entities;

namespace MoviesApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();

            CreateMap<GenreCreationDTO, Genre>();

            CreateMap<Person, PersonDTO>().ReverseMap();

            CreateMap<PersonCreationDTO,  Person>()
                .ForMember(x => x.Picture, options => options.Ignore());

            CreateMap<Person, PersonPatchDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>().ReverseMap();

            CreateMap<MovieCreationDTO, Movie>()
                .ForMember(x => x.Poster, options => options.Ignore());

            CreateMap<Movie, MoviePatchDTO>().ReverseMap();
        }
    }
}
