using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cartService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _cartService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cart cart)
        {
            await _cartService.Create(cart);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cart cart)
        {
            await _cartService.Update(cart);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _cartService.Delete(id);
            return Ok();
        }
    }
}
