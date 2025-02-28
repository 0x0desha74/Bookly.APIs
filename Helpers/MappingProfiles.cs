using AutoMapper;
using Bookly.APIs.DTOs;
using Bookly.APIs.Entities;

namespace Bookly.APIs.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookToReturnDto>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorToReturnDto>()
                .ForMember(d=>d.AuthorName,O=>O.MapFrom(s=>s.Name))
                .ForMember(d=>d.AuthorId,O=>O.MapFrom(s=>s.Id))
                .ReverseMap();
        }
    }
}
