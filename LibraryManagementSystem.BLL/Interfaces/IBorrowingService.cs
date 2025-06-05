using LibraryManagementSystem.BLL.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Interfaces;
public interface IBorrowingService
{
    Task<List<BorrowingTransactionDto>> GetAllTransactionsAsync();
    Task<BorrowingTransactionDto?> GetTransactionByIdAsync(int id);
    Task<bool> IsBookAvailableAsync(int bookId);
    Task<bool> BorrowBookAsync(int bookId, DateTime borrowedDate);
    Task<bool> ReturnBookAsync(int transactionId);
    Task<List<BorrowingTransactionDto>> FilterTransactionsAsync(
        string? status, DateTime? borrowDate, DateTime? returnDate
    );
}
