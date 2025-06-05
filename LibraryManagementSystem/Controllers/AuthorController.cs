using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;
using LibraryManagementSystem.DAL;
using LibraryManagementSystem.DAL.Interfaces;
using LibraryManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers;

public class AuthorController : Controller
{
    //private readonly LibraryDbContext libraryDb;
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task<IActionResult> Index()
    {
        var authors = await _authorService.GetAllAsync();
        return View(authors);
    }

    //public async Task<IActionResult> Details(int id)
    //{
    //    //var author = await _authorService.GetAuthorByIdAsync(id);
    //    //if (author == null) return NotFound();
    //    return View(author);
    //}

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(AuthorDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        await _authorService.AddAsync(dto);
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Delete(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null)
            return NotFound();

        return View(author);
    }


    // POST: Handle delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _authorService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


    // GET: Author/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null)
            return NotFound();

        return View(author);
    }

    // POST: Author/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AuthorDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(dto);

        try
        {
            await _authorService.UpdateAsync(dto);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., author not found)
            return NotFound(ex);
        }

        return RedirectToAction(nameof(Index));
    }

}
