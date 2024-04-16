namespace personapi_dotnet.Services.Service;

using personapi_dotnet.Models.Entities;

public interface IPhoneService
{
    Task<IEnumerable<Phone>> GetAllPhonesAsync();

    Task<Phone?> GetPhoneByNumberAsync(string number);

    Task AddPhoneAsync(Phone phone);

    Task UpdatePhoneAsync(Phone phone);

    Task DeletePhoneAsync(string number);
}
