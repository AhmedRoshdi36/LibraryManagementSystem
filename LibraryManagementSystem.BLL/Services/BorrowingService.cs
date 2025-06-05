using AutoMapper;
using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using LibraryManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Services;
public class BorrowingService : IBorrowingService
{
    private readonly IBorrowingRepository _transactionRepo;
    private readonly IMapper _mapper;

    public BorrowingService(IBorrowingRepository transactionRepo, IMapper mapper)
    {
        _transactionRepo = transactionRepo;
        _mapper = mapper;
    }

    public async Task<List<BorrowingTransactionDto>> GetAllTransactionsAsync()
    {
        var transactions = await _transactionRepo.GetAllAsync();
        return _mapper.Map<List<BorrowingTransactionDto>>(transactions);
    }

    public async Task<BorrowingTransactionDto?> GetTransactionByIdAsync(int id)
    {
        var transaction = await _transactionRepo.GetByIdAsync(id);
        return _mapper.Map<BorrowingTransactionDto>(transaction);
    }

    public async Task<bool> IsBookAvailableAsync(int bookId)
    {
        var active = await _transactionRepo.GetActiveBorrowingByBookIdAsync(bookId);
        return active == null;
    }

    public async Task<bool> BorrowBookAsync(int bookId, DateTime borrowedDate)
    {
        var available = await IsBookAvailableAsync(bookId);
        if (!available) return false;

        var transaction = new BorrowingTransaction
        {
            BookId = bookId,
            BorrowedDate = borrowedDate
        };

        await _transactionRepo.AddAsync(transaction);
        await _transactionRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ReturnBookAsync(int transactionId)
    {
        var transaction = await _transactionRepo.GetByIdAsync(transactionId);
        if (transaction == null || transaction.ReturnedDate != null) return false;

        transaction.ReturnedDate = DateTime.Now;

        await _transactionRepo.UpdateAsync(transaction);
        await _transactionRepo.SaveChangesAsync();
        return true;
    }

    public async Task<List<BorrowingTransactionDto>> FilterTransactionsAsync(
        string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var all = await _transactionRepo.GetAllAsync();

        if (!string.IsNullOrEmpty(status))
        {
            all = all.Where(t =>
                status == "Available" && t.ReturnedDate != null ||
                status == "Borrowed" && t.ReturnedDate == null).ToList();
        }

        if (borrowDate.HasValue)
            all = all.Where(t => t.BorrowedDate.Date == borrowDate.Value.Date).ToList();

        if (returnDate.HasValue)
            all = all.Where(t => t.ReturnedDate?.Date == returnDate.Value.Date).ToList();

        return _mapper.Map<List<BorrowingTransactionDto>>(all);
    }
}

