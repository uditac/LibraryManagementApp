using LibraryManagement.Models;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManagement.Controllers;

[Route("api/book")]
[ApiController]
public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Creates a book entry to the backend with json string input, checkout Database/Books.json for reference")] 
    public async Task<ActionResult<List<Book>>> CreateBook(string bookJsonString)
    {
        return _bookService.ReadBooks(bookJsonString);
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooksByFilter(string filterExpression)
    {
        return _bookService.FindBooks(filterExpression);
    }

    [HttpGet("{isbn}")]
    public async Task<ActionResult<string>> Create(string isbn)
    {
        return _bookService.GetBookLocation(isbn);
    }
}
