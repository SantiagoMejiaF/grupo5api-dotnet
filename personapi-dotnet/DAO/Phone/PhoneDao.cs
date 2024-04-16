namespace personapi_dotnet.DAO.Phone;

using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PhoneDao : IPhoneDao
{
    private readonly PersonDbContext _context;

    public PhoneDao(PersonDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Phone>> GetAllPhonesAsync()
    {
        return await _context.Phones.ToListAsync();
    }

    public async Task<Phone?> GetPhoneByNumberAsync(string number)
    {
        return await _context.Phones.FirstOrDefaultAsync(p => p.Number == number);
    }

    public async Task AddPhoneAsync(Phone phone)
    {
        _context.Phones.Add(phone);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePhoneAsync(Phone phone)
    {
        _context.Phones.Update(phone);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePhoneAsync(string number)
    {
        var phone = await GetPhoneByNumberAsync(number);
        if (phone != null)
        {
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
        }
    }
}
