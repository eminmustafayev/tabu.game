using Microsoft.AspNetCore.Mvc;
using Tabu.DTOs.Languages;
using Tabu.Services.Abstracts;

namespace Tabu.Controllers
{
    [ApiController]
    [Route("/api/ [controller]")]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {
        [HttpGet]
        public async Task <IActionResult> Get()
        {

            return Ok( await _service.GetAllAsync());
        }

        [HttpPost]
        public async  Task<IActionResult> Create(LanguageCreateDto dto)
        {
            await _service.CreateAsync( dto);
            return Ok( );
        }

        [HttpPut("{code}")]
        public async Task <IActionResult> Update(string code,LanguageUpdateDto dto)
        {
            await _service.UpdateAsync(code, dto);
            return Ok( );
        }
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return Ok( );
        }

    }
}
