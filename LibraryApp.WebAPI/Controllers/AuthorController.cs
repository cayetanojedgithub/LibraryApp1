using LibraryApp.Core.Models;
using LibraryApp.Core.Services.Contracts;
using LibraryApp.Infrastructure.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Get()
        {
            var authors = await _authorService.GetAllAsync();

            return Ok(authors);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _authorService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorForm authorForm)
        {
            if (authorForm == null)
            {
                return BadRequest();
            }

            if (await _authorService.SaveAsync(new Author() {
                FirstName = authorForm.FirstName,
                LastName = authorForm.LastName
            }))
            {
                return Created();
            }

            return StatusCode(500, "Internal server error.");
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorForm author)
        {
            if (id == 0)
            {
                return BadRequest($"Invalid value: {nameof(id)} {id} ");
            }

            if (author == null)
            {
                return BadRequest($"Object is null: {nameof(author)} {author} ");
            }

            if (await _authorService.SaveAsync(new Author() { 
                Id = id,
                FirstName = author.FirstName,
                LastName = author.LastName
            }))
            {
                return Ok(author);
            }

            return StatusCode(500, "Internal server error.");
        }
    }
}
