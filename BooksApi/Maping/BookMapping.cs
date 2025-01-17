using AutoMapper;
using BooksApi.Dto.BookDto;
using BooksApi.Dto.GenreDto;
using BooksApi.Dto.WriterDto;
using BooksApi.Models;

namespace BooksApi.Mapping
{
    public class BookMapping : Profile
    {
        public BookMapping()
        {
            // Book -> SelectBookDto
            CreateMap<Book, SelectBookDto>()
                .ForMember(dest => dest.Genres,
                    opt => opt.MapFrom(src => src.Genres)) // Book.Genres -> SelectBookDto.Genres
                .ForMember(dest => dest.Writers,
                    opt => opt.MapFrom(src => src.Writers)); // Book.Writers -> SelectBookDto.Writers

            // Genre -> GenreReadDto
            CreateMap<Genre, SelectGenreDto>();

            // Writer -> WriterReadDto
            CreateMap<Writer, SelectWriterDto>();

            // DTO -> Entity
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
        }
    }
}