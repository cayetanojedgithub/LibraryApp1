using LibraryApp.Core.Models;
using LibraryApp.Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApp.WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;        
        }

        [HttpGet("authors")]
        [CustomAuthorization]
        public async Task<IActionResult> Get()
        {
            var authors = await _authorService.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("author/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _authorService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost("author")]
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

        [HttpPut("author/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AuthorForm author)
        {
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
