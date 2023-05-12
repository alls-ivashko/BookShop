using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAll());
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetByIsbn(int isbn)
        {
            return Ok(await _bookService.GetByIsbn(isbn));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            await _bookService.Create(book);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            await _bookService.Update(book);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int isbn)
        {
            await _bookService.Delete(isbn);
            return Ok();
        }
    }
}
