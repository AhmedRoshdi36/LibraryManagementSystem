using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;
using Microsoft.AspNetCore.Mvc;

public class BorrowingTransactionController : Controller
{

    private readonly  IBorrowingTransactionService _transactionService;
    private readonly IBookService _bookService;

    public BorrowingTransactionController(IBorrowingTransactionService transactionService, IBookService bookService)
    {
        _transactionService = transactionService;
        _bookService = bookService;
    }
    public async Task<IActionResult> Index(
    string? status, DateTime? borrowDate, DateTime? returnDate, string? sortBy, int pageNumber = 1)
    {
        int pageSize = 5;
        var (transactions, totalCount) = await _transactionService.GetPagedAsync(
            pageNumber, pageSize, status, borrowDate, returnDate, sortBy);

        ViewBag.TotalCount = totalCount;
        ViewBag.PageNumber = pageNumber;
        ViewBag.PageSize   = pageSize;
        ViewBag.SortBy     = sortBy; 

        return View(transactions);
    }

  
    [HttpGet]
    public async Task<IActionResult> Borrow(int bookId)
    {
        var book = await _bookService.GetByIdAsync(bookId);
        if (book == null)
            return NotFound();

        var latestTransaction = await _transactionService.GetTransactionByBookIdAsync(bookId);
        if (latestTransaction != null && latestTransaction.Status == "Borrowed")
        {
            TempData["Error"] = "This book is already borrowed.";
            return RedirectToAction(nameof(Index));
        }

        var dto = new BorrowBookDto
        {
            BookId = book.Id,
            BookTitle = book.BookTitle,
            BorrowedDate = DateTime.Today
        };

        return View(dto);
    }

    [HttpPost, ActionName("Borrow")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BorrowConfirmed(int bookId)
    {
        try
        {
            await _transactionService.BorrowAsync(bookId);
            TempData["Success"] = "Book borrowed successfully.";
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);

            var book = await _bookService.GetByIdAsync(bookId);
            if (book == null)
                return NotFound();

            var dto = new BorrowBookDto
            {
                BookId = book.Id,
                BookTitle = book.BookTitle,
                BorrowedDate = DateTime.Today
            };

            return View(dto);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Return(int transactionId)
    {
        try
        {
            await _transactionService.ReturnAsync(transactionId);
            TempData["Success"] = "Book returned successfully.";
            return RedirectToAction(nameof(Index));
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }

 
}
