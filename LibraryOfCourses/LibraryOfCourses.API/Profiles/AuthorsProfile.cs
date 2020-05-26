using AutoMapper;
using LibraryOfCourses.API.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryOfCourses.API.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<CourseLibrary.API.Entities.Author, Models.AuthorDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));
                ;
        }
    }
}
