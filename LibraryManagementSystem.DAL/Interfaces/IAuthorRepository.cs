using LibraryManagementSystem.DAL.Models;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddAsync(Author author);

        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
