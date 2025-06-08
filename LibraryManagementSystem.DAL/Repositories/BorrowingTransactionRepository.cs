using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem.DAL.Repositories;


public class BorrowingTransactionRepository : IBorrowingTransactionRepository
{
    private readonly LibraryDbContext _context;

    public BorrowingTransactionRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BorrowingTransaction>> GetAllWithBooksAsync(int pageNumber, int pageSize)
    {
        return await _context.BorrowingTransactions
            .Include(t => t.Book)
            .OrderByDescending(t => t.BorrowedDate) 
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<BorrowingTransaction?> GetLatestTransactionForBookAsync(int bookId)
    {
        return await _context.BorrowingTransactions
            .Where(t => t.BookId == bookId)
            .OrderByDescending(t => t.BorrowedDate)
            .Include(t => t.Book)
            .FirstOrDefaultAsync();
    }

    public async Task<BorrowingTransaction?> GetByIdAsync(int id)
    {
        return await _context.BorrowingTransactions
            .Include(t => t.Book)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(BorrowingTransaction transaction)
    {
        _context.BorrowingTransactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task ReturnBookAsync(BorrowingTransaction transaction)
    {
        transaction.ReturnedDate = DateTime.Now;
        _context.BorrowingTransactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task<(List<BorrowingTransaction> Transactions, int TotalCount)> GetPagedAsync(
     int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate, string? sortBy)
    {
        var query = _context.BorrowingTransactions.Include(t => t.Book).AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = status == "borrowed"
                ? query.Where(x => !x.ReturnedDate.HasValue)
                : query.Where(x => x.ReturnedDate.HasValue);
        }

        if (borrowDate.HasValue)
            query = query.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date);

        if (returnDate.HasValue)
            query = query.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date);

        var totalCount = await query.CountAsync();

        switch (sortBy)
        {
            case "returnDateDesc":
                query = query.OrderByDescending(x => x.ReturnedDate ?? DateTime.MinValue);
                break;
            case "borrowDateDesc":
            default:
                query = query.OrderByDescending(x => x.BorrowedDate);
                break;
        }

        var transactions = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (transactions, totalCount);
    }
    public async Task<(List<BorrowingTransaction> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var query = _context.BorrowingTransactions.Include(t => t.Book).AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = status == "borrowed"
                ? query.Where(x => !x.ReturnedDate.HasValue)
                : query.Where(x => x.ReturnedDate.HasValue);
        }

        if (borrowDate.HasValue)
            query = query.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date);

        if (returnDate.HasValue)
            query = query.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date);

        var totalCount = await query.CountAsync();

        var transactions = await query
            .OrderByDescending(x => x.BorrowedDate)  
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (transactions, totalCount);
    }

}
