using BookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        // DI: сервис внедряется через конструктор
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/count
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            int count = _bookService.GetCount();
            return Ok($"Всего книг: {count}");
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
                return NotFound($"Книга с ID {id} не найдена");
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
                return BadRequest("Название и автор обязательны");

            // Валидация года издания
            if (book.Year < 1500 || book.Year > 2026)
                return BadRequest("Год издания должен быть от 1500 до 2026");

            var addedBook = _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetById), new { id = addedBook.Id }, addedBook);
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _bookService.DeleteBook(id);
            if (!success)
                return NotFound($"Книга с ID {id} не найдена");
            return NoContent();
        }
    }
}
