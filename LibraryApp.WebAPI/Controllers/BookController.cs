﻿using LibraryApp.Core.Models;
using LibraryApp.Core.Services.Contracts;
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
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _bookService.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookForm bookForm)
        {
            if (bookForm == null)
            {
                return BadRequest();
            }

            if (await _bookService.SaveAsync(new Book()
            {
                Title = bookForm.Title,
                AuthorId = bookForm.AuthorId
            }))
            {
                return Created();
            }

            return StatusCode(500, "Internal server error.");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BookForm bookForm)
        {
            if (await _bookService.SaveAsync(new Book() { 
                Id = id,
                Title = bookForm.Title,
                AuthorId = bookForm.AuthorId
            }))
            {
                return Ok(bookForm);
            }

            return StatusCode(500, "Internal server error.");
        }
    }
}
