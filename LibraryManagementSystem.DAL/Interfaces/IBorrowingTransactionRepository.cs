using LibraryManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Interfaces;

public interface IBorrowingTransactionRepository
{
    Task<List<BorrowingTransaction>> GetAllWithBooksAsync(int pageNumber, int pageSize);

    Task<BorrowingTransaction?> GetLatestTransactionForBookAsync(int bookId);

    Task<BorrowingTransaction?> GetByIdAsync(int id);

    Task AddAsync(BorrowingTransaction transaction);

    Task ReturnBookAsync(BorrowingTransaction transaction);

    Task<(List<BorrowingTransaction> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate);
    Task<(List<BorrowingTransaction> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate, string? sortBy);


}
