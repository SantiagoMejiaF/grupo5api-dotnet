namespace personapi_dotnet.Controllers;

using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Services.Service;


[Route("api/v1/phone")]
[ApiController]
public class PhonesController : ControllerBase
{
    private readonly IPhoneService _phoneService;

    public PhonesController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Phone>>> GetAllPhones()
    {
        var phones = await _phoneService.GetAllPhonesAsync();
        return Ok(phones);
    }

    [HttpGet("{number}")]
    public async Task<ActionResult<Phone>> GetPhone(string number)
    {
        var phone = await _phoneService.GetPhoneByNumberAsync(number);
        if (phone == null)
        {
            return NotFound();
        }
        return Ok(phone);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePhone([FromBody] Phone phone)
    {
        await _phoneService.AddPhoneAsync(phone);
        return CreatedAtAction(nameof(GetPhone), new { number = phone.Number }, phone);
    }

    [HttpPut("{number}")]
    public async Task<IActionResult> UpdatePhone(string number, [FromBody] Phone phone)
    {
        if (number != phone.Number)
        {
            return BadRequest("Number mismatch");
        }

        await _phoneService.UpdatePhoneAsync(phone);
        return NoContent();
    }

    [HttpDelete("{number}")]
    public async Task<IActionResult> DeletePhone(string number)
    {
        await _phoneService.DeletePhoneAsync(number);
        return NoContent();
    }
}
