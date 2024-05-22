using BookStorage.Data;
using BookStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStorage.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly ApiDbContext _context;

    public BooksController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Books.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [Route("AddBook")]
    public async Task<IActionResult> AddBook(Book book)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteBook")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

        if (book == null) return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch]
    [Route("UpdateBook")]
    public async Task<IActionResult> UpdateDriver(Book book)
    {
        var existBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);

        if (existBook == null) return NotFound();

        existBook.Name = book.Name;
        existBook.Author = book.Author;
        existBook.Description = book.Author;
        existBook.Page = book.Page;
        existBook.Price = book.Price;

        await _context.SaveChangesAsync();

        return NotFound();
    }
}