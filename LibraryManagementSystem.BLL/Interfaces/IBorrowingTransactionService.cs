using LibraryManagementSystem.BLL.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Interfaces;
public interface IBorrowingTransactionService
{
    Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate, int pageNumber, int pageSize);

    Task<BookTransactionDto?> GetTransactionByBookIdAsync(int bookId);

    Task BorrowAsync(int bookId);

    Task ReturnAsync(int transactionId);

    Task<(List<BookTransactionDto> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate);
    Task<(List<BookTransactionDto> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate ,string? sortBy);

}

