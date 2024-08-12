using LibraryApp.Core.Models;
using LibraryApp.Core.Services.Contracts;
using LibraryApp.Infrastructure.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;   
        }
        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookService.GetAllAsync();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            var collection = await _bookService.GetAllAsync();
            var item = collection.Find(x => x.Id == id);

            if (item == null)
            {
                throw new Exception($"Book with id:{id} not found.");
            }
            return item;
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task Post([FromBody] Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            await _bookService.SaveAsync(book);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Book book)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (book == null)
            {
                throw new ArgumentException(nameof(book));

            }

            await _bookService.SaveAsync(book);
        }
    }
}
