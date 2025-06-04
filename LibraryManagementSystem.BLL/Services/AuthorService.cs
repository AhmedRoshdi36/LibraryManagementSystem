using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<AuthorDto>> GetAllAsync()
    {
        var authors = await _repository.GetAllAsync();
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            FullName = a.FullName,
            Email = a.Email,
            Bio = a.Bio,
            Website = a.Website,

        }).ToList();
    }
    public async Task AddAsync(AuthorDto dto)
    {
        var author = new Author
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Bio =dto.Bio,
            Website=dto.Website
        };
        await _repository.AddAsync(author);
    }
    public async Task<AuthorDto> GetByIdAsync(int id)
    {
        var author = await _repository.GetByIdAsync(id);
        if (author == null)
            return null;

        return new AuthorDto
        {
            Id = author.Id,
            FullName = author.FullName,
            Email = author.Email,
            Bio = author.Bio,
            Website = author.Website
        };
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _repository.GetByIdAsync(id);
        if (author != null)
        {
            await _repository.DeleteAsync(author.Id);
        }
    }

    public async Task UpdateAsync(AuthorDto dto)
    {
        var author = await _repository.GetByIdAsync(dto.Id);
        if (author == null)
            throw new Exception("Author not found");

        author.FullName = dto.FullName;
        author.Email = dto.Email;
        author.Bio = dto.Bio;
        author.Website = dto.Website;

        await _repository.UpdateAsync(author);
    }


}