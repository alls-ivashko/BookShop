using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Interfaces;
using DataAccess.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{login}")]
        public async Task<IActionResult> GetByLogin(string login)
        {
            return Ok(await _userService.GetByLogin(login));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer user)
        {
            await _userService.Create(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string login)
        {
            await _userService.Delete(login);
            return Ok();
        }
    }
}
