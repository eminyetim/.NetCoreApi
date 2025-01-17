using System.Runtime.CompilerServices;
using AutoMapper;
using BooksApi.Data.Context;
using BooksApi.Dto.WriterDto;
using BooksApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Abstract;
using WebApi.Dto.WriterDto;
using WebApi.Services.Abstract;

namespace WebApi.Services.Concrete
{
    public class WriterService : IWirterService
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateWriterDto> _validator;

        public WriterService(IAppDbContext context, IMapper mapper, IValidator<CreateWriterDto> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<CreateWriterDto> CreateWriterAsync(CreateWriterDto createWriterDto)
        {
            var validator = _validator.Validate(createWriterDto);
            if (!validator.IsValid)
            {
                // FluentValidation'ın kendi ValidationException'ını kullanabilirsiniz
                throw new ValidationException($"Doğrulama hatası: {validator.Errors}");
            }

            var writer = _mapper.Map<Writer>(createWriterDto);
            await _context.Writers.AddAsync(writer);
            await _context.SaveChangesAsync();
            return createWriterDto;
        }

        public async Task<SelectWriterDto> GetByIdWriterAsync(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
                throw new NotFiniteNumberException("Writer couldn't be find!");
            return _mapper.Map<SelectWriterDto>(writer);
        }

        public async Task<IEnumerable<SelectWriterDto>> GetAllWriterAsync()
        {
            var writers = await _context.Writers.ToListAsync();
            return _mapper.Map<IEnumerable<SelectWriterDto>>(writers);
        }
        public async Task<bool> DeleteWriterAsync(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            var WriterIsBook = await _context.Books.Where(x => x.Writers.Any<Writer>(x => x.Id == id)).FirstOrDefaultAsync();
            if (WriterIsBook != null)
                throw new NotFiniteNumberException("Writer is associated with a book");
            if (writer == null)
                throw new NotFiniteNumberException("Writer could not be find!");
            _context.Writers.Remove(writer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SelectWriterDto> UpdateWriterAsync(UpdateWriterDto updateWriterDto)
        {
            var writer = await _context.Writers.FindAsync(updateWriterDto.id);
            if (writer == null)
                 throw new NotFiniteNumberException("Writer could not be find!");
            _mapper.Map(updateWriterDto, writer);
            _context.Writers.Update(writer);
            await _context.SaveChangesAsync();
            var selectWriter = _mapper.Map<SelectWriterDto>(writer);
            return selectWriter;
        }
    }
}