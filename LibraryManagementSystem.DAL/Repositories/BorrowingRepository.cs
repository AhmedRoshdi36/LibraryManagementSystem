using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repositories;
public class BorrowingRepository : IBorrowingRepository
{
    private readonly LibraryDbContext _context;

    public BorrowingRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<BorrowingTransaction>> GetAllAsync()
    {
        return await _context.BorrowingTransactions
            .Include(bt => bt.Book)
            .ToListAsync();
    }

    public async Task<BorrowingTransaction?> GetByIdAsync(int id)
    {
        return await _context.BorrowingTransactions
            .Include(bt => bt.Book)
            .FirstOrDefaultAsync(bt => bt.Id == id);
    }

    public async Task<List<BorrowingTransaction>> GetByBookIdAsync(int bookId)
    {
        return await _context.BorrowingTransactions
            .Where(bt => bt.BookId == bookId)
            .ToListAsync();
    }

    public async Task<BorrowingTransaction?> GetActiveBorrowingByBookIdAsync(int bookId)
    {
        return await _context.BorrowingTransactions
            .FirstOrDefaultAsync(bt => bt.BookId == bookId && bt.ReturnedDate == null);
    }

    public async Task AddAsync(BorrowingTransaction transaction)
    {
        await _context.BorrowingTransactions.AddAsync(transaction);
    }

    public async Task UpdateAsync(BorrowingTransaction transaction)
    {
        _context.BorrowingTransactions.Update(transaction);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
