using AutoMapper;
using BooksApi.Dto.WriterDto;
using BooksApi.Models;


namespace WebApi.Mapping
{
    public class WriterMapping : Profile
    {
        public WriterMapping()
        {
            CreateMap<SelectWriterDto,Writer >().ReverseMap();
            CreateMap<CreateWriterDto,Writer >().ReverseMap();
            CreateMap<UpdateWriterDto,Writer>().ReverseMap();
        }
    }
}