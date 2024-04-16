using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Services.Person;

[Route("api/v1/person")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("{cc}")]
    public async Task<IActionResult> ReadPersonByCc(int cc)
    {
        var person = await _personService.GetPersonByCcAsync(cc);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAllPersons()
    {
        var persons = await _personService.GetAllPersonsAsync();
        return Ok(persons);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        await _personService.AddPersonAsync(person);
        return CreatedAtAction(nameof(ReadPersonByCc), new { cc = person.Cc }, person);
    }

    [HttpPut("{cc}")]
    public async Task<IActionResult> UpdatePerson(int cc, [FromBody] Person person)
    {
        if (cc != person.Cc)
        {
            return BadRequest();
        }
        await _personService.UpdatePersonAsync(person);
        return NoContent();
    }

    [HttpDelete("{cc}")]
    public async Task<IActionResult> DeletePerson(int cc)
    {
        await _personService.DeletePersonAsync(cc);
        return NoContent();
    }
}

