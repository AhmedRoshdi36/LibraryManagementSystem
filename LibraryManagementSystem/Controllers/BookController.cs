using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // List all books
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }


        // GET: Book/Create
        public async Task<IActionResult> Create()
        {
            var authors = await _authorService.GetAllAsync();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDto dto)
        {
            if (!ModelState.IsValid)
            {
                var authors = await _authorService.GetAllAsync();
                ViewBag.Authors = new SelectList(authors, "Id", "FullName", dto.AuthorId);
                return View(dto);

            }
            await _bookService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }   

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bookDto = await _bookService.GetByIdAsync(id);
            if (bookDto == null)
                return NotFound();

            // For dropdown list of authors
            ViewBag.Authors = await _authorService.GetAllAsync();

            return View(bookDto);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookDto bookDto)
        {
            if (id != bookDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Authors = await _authorService.GetAllAsync();
                return View(bookDto);
            }

            try
            {
                await _bookService.UpdateAsync(bookDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating book: {ex.Message}");
                ViewBag.Authors = await _authorService.GetAllAsync();
                return View(bookDto);
            }
        }
        

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
