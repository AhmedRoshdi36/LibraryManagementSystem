using LibraryManagementSystem.BLL.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto?> GetByIdAsync(int id);
        Task AddAsync(BookDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
    }
}
