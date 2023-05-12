using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _categoryService.GetByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            await _categoryService.Create(category);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.Update(category);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            await _categoryService.Delete(name);
            return Ok();
        }
    }
}
