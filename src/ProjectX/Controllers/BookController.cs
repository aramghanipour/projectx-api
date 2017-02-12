using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Models;
using ProjectX.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectX.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var createdBook = _bookRepository.Add(value);


            return CreatedAtRoute("GetBook", new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book value)
        {
            if (value == null)
            {
                return BadRequest();
            }


            var note = _bookRepository.GetById(id);


            if (note == null)
            {
                return NotFound();
            }


            value.Id = id;
            _bookRepository.Update(value);


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(book);


            return NoContent();
        }
    }
}
