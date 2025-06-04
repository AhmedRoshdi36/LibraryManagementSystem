using LibraryManagementSystem.BLL.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAsync();
        Task AddAsync(AuthorDto dto);
        Task<AuthorDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(AuthorDto dto);


    }

}
