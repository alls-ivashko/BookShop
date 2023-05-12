using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cartItemService.GetAll());
        }

        [HttpGet("{cartId}/{isbn}")]
        public async Task<IActionResult> GetById(int cartId, int isbn)
        {
            return Ok(await _cartItemService.GetById(cartId, isbn));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CartItem cartItem)
        {
            await _cartItemService.Create(cartItem);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CartItem cartItem)
        {
            await _cartItemService.Update(cartItem);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int cartId, int isbn)
        {
            await _cartItemService.Delete(cartId, isbn);
            return Ok();
        }
    }
}
