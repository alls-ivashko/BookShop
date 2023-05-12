using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPropertyController : ControllerBase
    {
        private IBookPropertyService _bookPropertyService;
        public BookPropertyController(IBookPropertyService bookPropertyService)
        {
            _bookPropertyService = bookPropertyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookPropertyService.GetAll());
        }

        [HttpGet("{isbn}/{attribute}")]
        public async Task<IActionResult> GetById(int isbn, string attribute)
        {
            return Ok(await _bookPropertyService.GetById(isbn, attribute));
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookProperty bookProperty)
        {
            await _bookPropertyService.Create(bookProperty);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookProperty bookProperty)
        {
            await _bookPropertyService.Update(bookProperty);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int isbn, string attribute)
        {
            await _bookPropertyService.Delete(isbn, attribute);
            return Ok();
        }
    }
}
