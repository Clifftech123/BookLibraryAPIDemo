using AutoMapper;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Domain.Entities;

namespace BookLibraryAPIDemo.Application.Mapping
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Map from Book entity to BookDTO and back
            CreateMap<Book, BookDTO>().ReverseMap();

            // Map from Author entity to AuthorDTO and back
            CreateMap<Author, AuthorDTO>().ReverseMap();

            // Map from CreateAuthorDTO to Author
            CreateMap<CreateAuthorDTO, Author>();

            // Map from Category entity to CategoryDTO and back
            CreateMap<Category, CategoryDTO>().ReverseMap();

            // Map from Publisher entity to PublisherDTO and back
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
        }
    }



}