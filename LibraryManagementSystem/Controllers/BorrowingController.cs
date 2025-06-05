using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class BorrowingController : Controller
{
    private readonly IBorrowingService _borrowingService;
    private readonly IBookService _bookService;

    public BorrowingController(IBorrowingService borrowingService, IBookService bookService)
    {
        _borrowingService = borrowingService;
        _bookService = bookService;
    }

    public async Task<IActionResult> Library()
    {
        var books = await _bookService.GetAllAsync();
        return View(books); // Use BookLibraryDto list
    }

    [HttpGet]
    public async Task<IActionResult> Borrow(int bookId)
    {
        var isAvailable = await _borrowingService.IsBookAvailableAsync(bookId);
        if (!isAvailable) return RedirectToAction("Library");

        var dto = new BorrowingTransactionDto
        {
            BookId = bookId,
            BorrowedDate = DateTime.Now
        };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Borrow(BorrowingTransactionDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        var result = await _borrowingService.BorrowBookAsync(dto.BookId, dto.BorrowedDate);
        if (!result)
        {
            ModelState.AddModelError("", "Book is already borrowed.");
            return View(dto);
        }

        return RedirectToAction("Library");
    }

    [HttpPost]
    public async Task<IActionResult> Return(int transactionId)
    {
        await _borrowingService.ReturnBookAsync(transactionId);
        return RedirectToAction("Library");
    }

    [HttpGet]
    public async Task<IActionResult> Filter(string? status, DateTime? borrowDate, DateTime? returnDate)
    {
        var filtered = await _borrowingService.FilterTransactionsAsync(status, borrowDate, returnDate);
        return View("LibraryFiltered", filtered); // Optional: separate view
    }
}

