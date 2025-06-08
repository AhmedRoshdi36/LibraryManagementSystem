using AutoMapper;
using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;

namespace LibraryManagementSystem.BLL.Services;

public class BorrowingTransactionService : IBorrowingTransactionService
{
    private readonly IBorrowingTransactionRepository _repo;

    public BorrowingTransactionService(IBorrowingTransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<BookTransactionDto>> GetAllAsync(string? status, DateTime? borrowDate, DateTime? returnDate, int pageNumber, int pageSize)
    {
        var data = await _repo.GetAllWithBooksAsync(pageNumber, pageSize);

        if (!string.IsNullOrWhiteSpace(status))
        {
            data = status == "borrowed"
                ? data.Where(x => !x.IsReturned).ToList()
                : data.Where(x => x.IsReturned).ToList();
        }

        if (borrowDate.HasValue)
            data = data.Where(x => x.BorrowedDate.Date == borrowDate.Value.Date).ToList();

        if (returnDate.HasValue)
            data = data.Where(x => x.ReturnedDate.HasValue && x.ReturnedDate.Value.Date == returnDate.Value.Date).ToList();

        return data.Select(x => new BookTransactionDto
        {
            Id = x.Id,
            BookId = x.BookId,
            BookTitle = x.Book?.Title ?? string.Empty,
            BorrowedDate = x.BorrowedDate,
            ReturnedDate = x.ReturnedDate
        }).ToList();
    }

    public async Task<BookTransactionDto?> GetTransactionByBookIdAsync(int bookId)
    {
        var latest = await _repo.GetLatestTransactionForBookAsync(bookId);
        if (latest == null) return null;

        return new BookTransactionDto
        {
            Id = latest.Id,
            BookId = latest.BookId,
            BookTitle = latest.Book?.Title ?? string.Empty, 
            BorrowedDate = latest.BorrowedDate,
            ReturnedDate = latest.ReturnedDate
        };
    }

    public async Task BorrowAsync(int bookId)
    {
        var latest = await _repo.GetLatestTransactionForBookAsync(bookId);

        if (latest != null && !latest.IsReturned)
            throw new InvalidOperationException(" already borrowed.");

        var tx = new BorrowingTransaction
        {
            BookId = bookId,
            BorrowedDate = DateTime.Now,
            Status = "Borrowed"
        };

        await _repo.AddAsync(tx);
    }

    public async Task ReturnAsync(int transactionId)
    {
        var tx = await _repo.GetByIdAsync(transactionId);
        if (tx == null || tx.IsReturned)
            throw new InvalidOperationException("Invalid return operation.");

        tx.Status = "Available";
        await _repo.ReturnBookAsync(tx);
    }
    public async Task<(List<BookTransactionDto> Transactions, int TotalCount)> GetPagedAsync(
    int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate, string? sortBy)
    {
        var (transactions, totalCount) = await _repo.GetPagedAsync(pageNumber, pageSize, status, borrowDate, returnDate, sortBy);

        var dtos = transactions.Select(x => new BookTransactionDto
        {
            Id = x.Id,
            BookId = x.BookId,
            BookTitle = x.Book?.Title ?? string.Empty,
            BorrowedDate = x.BorrowedDate,
            ReturnedDate = x.ReturnedDate
        }).ToList();

        return (dtos, totalCount);
    }

    public async Task<(List<BookTransactionDto> Transactions, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var (transactions, totalCount) = await _repo.GetPagedAsync(pageNumber, pageSize, status, borrowDate, returnDate);

        var dtos = transactions.Select(x => new BookTransactionDto
        {
            Id = x.Id,
            BookId = x.BookId,
            BookTitle = x.Book?.Title ?? string.Empty,
            BorrowedDate = x.BorrowedDate,
            ReturnedDate = x.ReturnedDate
        }).ToList();

        return (dtos, totalCount);
    }

}
