namespace personapi_dotnet.DAO.Phone;
using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Entities;

public interface IPhoneDao
{
    Task<IEnumerable<Phone>> GetAllPhonesAsync();

    Task<Phone?> GetPhoneByNumberAsync(string number);

    Task AddPhoneAsync(Phone phone);

    Task UpdatePhoneAsync(Phone phone);

    Task DeletePhoneAsync(string number);
}

