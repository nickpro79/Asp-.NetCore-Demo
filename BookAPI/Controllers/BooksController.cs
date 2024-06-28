using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksrRepository _booksrRepository;
        IOperationsRepository _operationsRepository;
        public BooksController(IBooksrRepository booksrRepository,IOperationsRepository operationsRepository) {
        _booksrRepository = booksrRepository;
        _operationsRepository = operationsRepository;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            IEnumerable<Books> b = _booksrRepository.GetBooks();
            return Ok(b);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id) {
            Books b = _booksrRepository.GetBooksById(id);
            if (b != null)
            {
                return Ok(b);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBooks([FromBody]Books b)
        {
            var bookAdded = _booksrRepository.AddBook(b);
            if (bookAdded)
            {
                return CreatedAtAction(nameof(GetBookById), new { id = b.Id }, b);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooks([FromRoute]Guid id, [FromBody]Books b) { 
        Books book = _booksrRepository.UpdateBook(id, b);
            if (book != null) {
                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooks([FromRoute] Guid id) {
        var bookDeleted = _booksrRepository.DeleteBook(id);
            if (bookDeleted) {
                return Ok($"Book with Id = {id} has been deleted");
            }
            return Ok($"Book with Id = {id} has not been found");
        }

        [HttpGet("find/cost")]
        public IActionResult FindCostlyBook()
        {
            var b = _operationsRepository.FindCostliestBook();
            if(b != null) return Ok(b);
            return NotFound();
        }

        [HttpGet("find/startsWith")]
        public IActionResult FindBookThatStartsWithA()
        {
            var b = _operationsRepository.FindBooksByNameStartsWith();
            if (b != null) return Ok(b);
            return NotFound();
        }

        [HttpGet("find/BetweenMaxAndMin")]
        public IActionResult FindBetweenMaxAndMin()
        {
            var b = _operationsRepository.FindBooksByAmountRange();
            if (b != null) return Ok(b);
            return NotFound();
        }

        [HttpGet("find/CostliestAndCheapest")]
        public IActionResult FindCostliestAndCheapestBooks()
        {
            var (costliest, cheapest) = _operationsRepository.FindCostliestAndCheapestBooks();

            if (costliest == null || cheapest == null)
            {
                return NotFound();
            }
            return Ok(new { CostliestBook = costliest, CheapestBook = cheapest });
        }

        [HttpDelete]
        public IActionResult DeleteAll() { 
        var b = _booksrRepository.DeleteAllBooks();
        return Ok("All books have been deleted");
        }


    }
}
