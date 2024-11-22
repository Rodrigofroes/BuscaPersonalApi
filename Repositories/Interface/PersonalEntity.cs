using BuscaPersonalApi.Dtos.OutputDto;
using BuscaPersonalApi.Entities;

namespace BuscaPersonalApi.Repositories.Interface
{
    public interface IPersonalEntity
    {
        Task<List<PersonalOutputDto>> ListarPersonal();
        Task<PersonalOutputDto> BuscarPersonal(int id);
        Task<PersonalOutputDto> InserirPersonal(PersonalEntity personal);
        Task<PersonalOutputDto> AtualizarPersonal(PersonalEntity personal);
        Task<PersonalOutputDto> DeletarPersonal(int id);
    }
}
