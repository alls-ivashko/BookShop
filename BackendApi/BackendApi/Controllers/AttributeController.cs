using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Attribute = Domain.Models.Attribute;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private IAttributeService _attributeService;
        public AttributeController(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _attributeService.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await _attributeService.GetByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Attribute attribute)
        {
            await _attributeService.Create(attribute);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Attribute attribute)
        {
            await _attributeService.Update(attribute);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            await _attributeService.Delete(name);
            return Ok();
        }
    }
}
