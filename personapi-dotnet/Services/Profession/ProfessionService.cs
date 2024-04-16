namespace personapi_dotnet.Services.Profession;

using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.DAO.Profession;
using personapi_dotnet.Entities.Profession;
using personapi_dotnet.Models.Dtos;
using personapi_dotnet.Models.Entities;

public class ProfessionService : IProfessionService
{
    private readonly IProfessionDao _professionDao;

    public ProfessionService(IProfessionDao professionDao)
    {
        _professionDao = professionDao;
    }

    public Task<Profession?> GetProfessionByIdAsync(int id) => _professionDao.GetProfessionByIdAsync(id);

    public Task<IEnumerable<Profession?>> GetAllProfessionsAsync() => _professionDao.GetAllProfessionsAsync();

    public Task <Profession> AddProfessionAsync(ProfessionDto professionDto) => _professionDao.AddProfessionAsync(professionDto);

    public Task <Profession> UpdateProfessionAsync(int id, ProfessionDto professionDto) => _professionDao.UpdateProfessionAsync(id, professionDto);

    public Task DeleteProfessionAsync(int id) => _professionDao.DeleteProfessionAsync(id);
}
