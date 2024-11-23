using BuscaPersonalApi.Dtos.OutputDto;
using BuscaPersonalApi.Entities;

namespace BuscaPersonalApi.Repositories.Interface
{
    public interface IPersonal
    {
        Task<List<PersonalOutputDto>> ListarPersonal();
        Task<PersonalOutputDto> BuscarPersonal(int Id);
        Task<PersonalOutputDto> InserirPersonal(PersonalEntity Personal);
        Task<bool> AtualizarPersonal(PersonalEntity Personal);
        Task<bool> DeletarPersonal(int Id);
    }
}
