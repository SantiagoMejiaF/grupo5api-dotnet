namespace personapi_dotnet.DAO.Person;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;


public class PersonDao : IPersonDao
{
    private readonly PersonDbContext _context;

    public PersonDao(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        return await _context.Set<Person>()
                              .FirstOrDefaultAsync(p => p.Cc == id);
    }

    public async Task<Person?> GetPersonByCcAsync(int cc)
    {
        return await _context.Set<Person>()
                             .FirstOrDefaultAsync(p => p.Cc == cc);
    }

    public async Task<IEnumerable<Person?>> GetAllPersonsAsync()
    {
        return await _context.Set<Person>()
                             .ToListAsync();
    }

    public async Task AddPersonAsync(Person person)
    {
        _context.Set<Person>().Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePersonAsync(Person person)
    {
        _context.Set<Person>().Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersonAsync(int id)
    {
        var person = await _context.Set<Person>().FindAsync(id);
        if (person != null)
        {
            _context.Set<Person>().Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}

