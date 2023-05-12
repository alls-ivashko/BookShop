using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetByCartId(int cartId)
        {
            return Ok(await _orderService.GetByCartId(cartId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDetail order)
        {
            await _orderService.Create(order);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderDetail order)
        {
            await _orderService.Update(order);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int cartId)
        {
            await _orderService.Delete(cartId);
            return Ok();
        }
    }
}
