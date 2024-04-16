namespace personapi_dotnet.Services.Profession;

using System.Collections.Generic;
using System.Threading.Tasks;
using personapi_dotnet.Models.Dtos;
using personapi_dotnet.Models.Entities;

public interface IProfessionService
{
    Task<Profession?> GetProfessionByIdAsync(int id);

    Task<IEnumerable<Profession?>> GetAllProfessionsAsync();

    Task<Profession> AddProfessionAsync(ProfessionDto professionDto);

    Task <Profession> UpdateProfessionAsync(int id, ProfessionDto professionDto);

    Task DeleteProfessionAsync(int id);
}
