using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAttributeController : ControllerBase
    {
        private ICategoryAttributeService _categoryAttributeService;
        public CategoryAttributeController(ICategoryAttributeService categoryAttributeService)
        {
            _categoryAttributeService = categoryAttributeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryAttributeService.GetAll());
        }

        [HttpGet("{category}/{attribute}")]
        public async Task<IActionResult> GetByNames(string category, string attribute)
        {
            return Ok(await _categoryAttributeService.GetByNames(category, attribute));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAttribute categoryAttribute)
        {
            await _categoryAttributeService.Create(categoryAttribute);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryAttribute categoryAttribute)
        {
            await _categoryAttributeService.Update(categoryAttribute);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string category, string attribute)
        {
            await _categoryAttributeService.Delete(category, attribute);
            return Ok();
        }
    }
}
