using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Dtos;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Services.Profession;

namespace personapi_dotnet.Controllers;


[Route("api/v1/profession")]
[ApiController]
public class ProfessionController : ControllerBase
{
    private readonly IProfessionService _professionService;

    public ProfessionController(IProfessionService professionService)
    {
        _professionService = professionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ReadProfessionById(int id)
    {
        var profession = await _professionService.GetProfessionByIdAsync(id);
        if (profession == null)
        {
            return NotFound();
        }
        return Ok(profession);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAllProfessions()
    {
        var professions = await _professionService.GetAllProfessionsAsync();
        return Ok(professions);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfession([FromBody] ProfessionDto professionDto)
    {
        var createdProfession = await _professionService.AddProfessionAsync(professionDto);
        return Ok(createdProfession);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfession(int id, [FromBody] ProfessionDto professionDto)
    {
        var updatedProfession = await _professionService.UpdateProfessionAsync(id, professionDto);
        return Ok(updatedProfession);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfession(int id)
    {
        await _professionService.DeleteProfessionAsync(id);
        return NoContent();
    }
}
