namespace personapi_dotnet.Services.Service;

using personapi_dotnet.DAO.Phone;
using personapi_dotnet.Models.Entities;

public class PhoneService : IPhoneService
{
    private readonly IPhoneDao _phoneDao;

    public PhoneService(IPhoneDao phoneDao)
    {
        _phoneDao = phoneDao;
    }

    public Task<IEnumerable<Phone>> GetAllPhonesAsync() => _phoneDao.GetAllPhonesAsync();

    public Task<Phone?> GetPhoneByNumberAsync(string number) => _phoneDao.GetPhoneByNumberAsync(number);

    public Task AddPhoneAsync(Phone phone) => _phoneDao.AddPhoneAsync(phone);

    public Task UpdatePhoneAsync(Phone phone) => _phoneDao.UpdatePhoneAsync(phone);

    public Task DeletePhoneAsync(string number) => _phoneDao.DeletePhoneAsync(number);
}

