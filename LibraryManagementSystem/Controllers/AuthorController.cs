using LibraryManagementSystem.BLL.DTos;
using LibraryManagementSystem.BLL.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementSystem.Controllers;

public class AuthorController : Controller
{
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


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _authorService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null)
            return NotFound();

        return View(author);
    }

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
            return NotFound(ex);
        }

        return RedirectToAction(nameof(Index));
    }

}
