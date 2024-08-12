using LibraryApp.Core.Models;
using LibraryApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;        
        }
        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _authorService.GetAllAsync();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            var collection = await _authorService.GetAllAsync();
            var item = collection.Find(x => x.Id == id);

            if (item == null)
            {
                throw new Exception($"Author with id:{id} not found.");
            }
            return item;
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task Post([FromBody] Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            await _authorService.SaveAsync(author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Author author)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (author == null)
            {
                throw new ArgumentException(nameof(author));

            }

            await _authorService.SaveAsync(author);
        }
    }
}
