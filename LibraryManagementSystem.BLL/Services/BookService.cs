using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();  // returns List of boooks
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                BookTitle = b.Title ?? "",
                Genre = b.Genre,
                Description = b.Description,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.FullName ?? "Unknown"
            }).ToList();
        }


        public async Task<BookDto?> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                BookTitle = book.Title ?? "",
                Genre = book.Genre,
                Description = book.Description,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.FullName ?? ""
            };
        }


        public async Task UpdateAsync(BookDto dto)
        {
            var book = await _repository.GetByIdAsync(dto.Id);
            if (book == null) throw new Exception("Book not found");

            book.Title = dto.BookTitle;
            book.Genre = dto.Genre;
            book.Description = dto.Description;
            book.AuthorId = dto.AuthorId;

            await _repository.UpdateAsync(book);
        }

        public async Task UpdateAsync(int id, BookDto dto)
        {
            var existingBook = await _repository.GetByIdAsync(id);
            if (existingBook == null)
                throw new KeyNotFoundException("Book not found");

            existingBook.Title = dto.BookTitle;
            existingBook.Genre = dto.Genre;
            existingBook.Description = dto.Description;
            existingBook.AuthorId = dto.AuthorId;

            await _repository.UpdateAsync(existingBook);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public Task AddAsync(BookDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
