namespace personapi_dotnet.DAO.Profession;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Entities.Profession;
using personapi_dotnet.Models.Dtos;
using personapi_dotnet.Models.Entities;

public class ProfessionDao : IProfessionDao
{
    private readonly PersonDbContext _context;

    public ProfessionDao(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<Profession?> GetProfessionByIdAsync(int id)
    {
        return await _context.Set<Profession>().FindAsync(id);
    }

    public async Task<IEnumerable<Profession?>> GetAllProfessionsAsync()
    {
        return await _context.Set<Profession>().ToListAsync();
    }

    public async Task<Profession> AddProfessionAsync(ProfessionDto professionDto)
    {
        var profession = new Profession
        {
            Name = professionDto.Name,
            Description = professionDto.Description
        };

        _context.Professions.Add(profession);
        await _context.SaveChangesAsync();

        return profession;
    }

    public async Task<Profession> UpdateProfessionAsync(int id, ProfessionDto professionDto)
    {
        var profession = await _context.Professions.FindAsync(id);

        if (profession == null)
        {
            throw new KeyNotFoundException("No profession found with ID " + id);
        }

        profession.Name = professionDto.Name;
        profession.Description = professionDto.Description;

        await _context.SaveChangesAsync();

        return profession;
    }

    public async Task DeleteProfessionAsync(int id)
    {
        var profession = await _context.Set<Profession>().FindAsync(id);
        if (profession != null)
        {
            _context.Set<Profession>().Remove(profession);
            await _context.SaveChangesAsync();
        }
    }
}
