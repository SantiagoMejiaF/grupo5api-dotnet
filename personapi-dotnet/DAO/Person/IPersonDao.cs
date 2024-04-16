namespace personapi_dotnet.DAO.Person;
using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Entities;

public interface IPersonDao
{
    Task<Person?> GetPersonByIdAsync(int id);

    Task<Person?> GetPersonByCcAsync(int cc);

    Task<IEnumerable<Person?>> GetAllPersonsAsync();

    Task AddPersonAsync(Person person);

    Task UpdatePersonAsync(Person person);

    Task DeletePersonAsync(int id);
}
