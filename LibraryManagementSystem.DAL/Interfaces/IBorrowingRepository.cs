using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Interfaces
{
    public interface IBorrowingRepository
    {
        Task<List<BorrowingTransaction>> GetAllAsync();
        Task<BorrowingTransaction?> GetByIdAsync(int id);
        Task<List<BorrowingTransaction>> GetByBookIdAsync(int bookId);
        Task<BorrowingTransaction?> GetActiveBorrowingByBookIdAsync(int bookId);
        Task AddAsync(BorrowingTransaction transaction);
        Task UpdateAsync(BorrowingTransaction transaction);
        Task SaveChangesAsync();
    }


}
