using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace HotelListing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly string[] Genres = new[]
        {
            "Fiction", "Non-Fiction", "Science", "Biography", "Fantasy", "Mystery", "Romance", "Thriller", "History", "Self-Help", "School/Education"
        };

        private readonly ILogger<BooksController> _logger;
        private static List<Book> books = new List<Book>();

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;

            // Populate with some initial data for demonstration
            for (int i = 1; i <= 5; i++)
            {
                books.Add(new 
                    Book
                {
                    Id = i,
                    Title = $"Book Title {i}",
                    Author = $"Author {i}",
                    Genre = Genres[Random.Shared.Next(Genres.Length)],
                    PublishedDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-i * 30))
                });
            }
        }

        // Create a GET request 
        [HttpGet(Name = "Books")]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // Create a POST request 
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            // Assign a new ID
            book.Id = books.Count + 1;

            // Add the book to the list
            books.Add(book);
            _logger.LogInformation("Book added: {Title} by {Author}", book.Title, book.Author);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        // Create a DELETE request 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            books.Remove(book);
            _logger.LogInformation("Book deleted: {Title} by {Author}", book.Title, book.Author);
            return NoContent(); // 204 No Content
        }
    }
}
