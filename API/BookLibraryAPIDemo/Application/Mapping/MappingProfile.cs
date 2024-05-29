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
            CreateMap<Book, BookDTO>()
   .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
   .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
   .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher.PublisherName))
   .ReverseMap();

            CreateMap<CreateBookDTO, Book>();



            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<CreateAuthorDTO, Author>();
            CreateMap<UpdateAuthorDTO, Author>();


            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();



            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<CreatePublisherDTO, Publisher>();
            CreateMap<UpdatePublisherDTO, Publisher>();

        }
    }



}