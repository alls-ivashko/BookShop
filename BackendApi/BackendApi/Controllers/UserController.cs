using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using BackendApi.Contracts;
using Mapster;

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
            var request = await _userService.GetByLogin(login);
            var response = new GetUserResponse()
            {
                Login = request.Login,
                Password = request.Password,
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                ZipCode = request.ZipCode,
                Region = request.Region,
                City = request.City,
                Street = request.Street,
                House = request.House,
                Flat = request.Flat,
                Age = request.Age,
                Gender = request.Gender,
                Deleted = request.Deleted,
            };
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "login" : "A4Tech Bloody B188",
        /// "password" : "!Pa$$word123@",
        /// "firstname" : "Иван",
        /// "lastname" : "Иванов",
        /// "middlename" : "Иванович",
        /// "phonenumber" : "+79876542323",
        /// "zipcode" : "455000",
        /// "region" : "Moscow",
        /// "city" : "Moscow",
        /// "street" : "lenina",
        /// "house" : "23",
        /// "flat" : "12",
        /// "age" : "18",
        /// "gender" : "true",
        /// "deleted" : "false"
        /// }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<Customer>();
            
            await _userService.Create(userDto);
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
