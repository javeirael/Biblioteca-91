using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoreService _autoreService;
        public AutoresController(IAutoreService autoreService) 
        { 
            _autoreService = autoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores() 
        {
            var result = await _autoreService.GetAutores();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autoreService.CreateAutores(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAutor(int id, [FromBody] Autor request)
        {
            var result = await _autoreService.UpdateAutor(id, request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var result = await _autoreService.BorrarAutores(id);
            return Ok(result);
        }
    }
}
