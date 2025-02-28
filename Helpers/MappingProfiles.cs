using AutoMapper;
using Bookly.APIs.DTOs;
using Bookly.APIs.Entities;

namespace Bookly.APIs.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
