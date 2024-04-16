namespace personapi_dotnet.Services.Person;
using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.DAO.Person;
using personapi_dotnet.Models.Entities;

public class PersonService(IPersonDao personDao) : IPersonService
{
    private readonly IPersonDao _personDao = personDao;

    public Task<Person?> GetPersonByIdAsync(int id) => _personDao.GetPersonByIdAsync(id);

    public Task<Person?> GetPersonByCcAsync(int cc) => _personDao.GetPersonByCcAsync(cc);

    public Task<IEnumerable<Person?>> GetAllPersonsAsync() => _personDao.GetAllPersonsAsync();

    public Task AddPersonAsync(Person person) => _personDao.AddPersonAsync(person);

    public Task UpdatePersonAsync(Person person) => _personDao.UpdatePersonAsync(person);

    public Task DeletePersonAsync(int id) => _personDao.DeletePersonAsync(id);
}

