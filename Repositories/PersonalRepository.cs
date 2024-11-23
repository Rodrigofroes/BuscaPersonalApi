using AutoMapper;
using BuscaPersonalApi.Data;
using BuscaPersonalApi.Dtos.OutputDto;
using BuscaPersonalApi.Entities;
using BuscaPersonalApi.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BuscaPersonalApi.Repositories
{
    public class PersonalRepository : IPersonal
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public PersonalRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<PersonalOutputDto>> ListarPersonal() 
        {
            try 
            {
                var personais = await _context.Personal.ToListAsync();
                return _mapper.Map<List<PersonalOutputDto>>(personais);
            } catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PersonalOutputDto> BuscarPersonal(int Id)
        {
            try
            {
                var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Per_id == Id);
                return _mapper.Map<PersonalOutputDto>(personal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PersonalOutputDto> InserirPersonal(PersonalEntity Personal)
        {
            try
            {
                var validacao = await ValidacaoPersonal(Personal);
                var personalEntity = _mapper.Map<PersonalEntity>(Personal);
                await _context.Personal.AddAsync(personalEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<PersonalOutputDto>(personalEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AtualizarPersonal(PersonalEntity Personal)
        {
            try
            {
                var validacao = await ValidacaoPersonal(Personal);
                if (!validacao)
                {
                    throw new Exception("Personal já cadastrado");
                }
                var personalEntity = _mapper.Map<PersonalEntity>(Personal);
                _context.Personal.Update(personalEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarPersonal(int Id)
        {
            try
            {
                 var personal = await _context.Personal.FirstOrDefaultAsync(x => x.Per_id == Id);
                if (personal == null)
                {
                    throw new Exception("Personal não encontrado");
                }
                _context.Personal.Remove(personal!);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> ValidacaoPersonal(PersonalEntity personal)
        {
            var buscar = await _context.Personal
                .Where(x => (x.Per_nome == personal.Per_nome ||
                             x.Per_cpf == personal.Per_cpf ||
                             x.Per_cref == personal.Per_cref ||
                             x.Per_email == personal.Per_email)
                            && x.Per_id != personal.Per_id) 
                .FirstOrDefaultAsync();

            if (buscar != null)
            {
                return false;
            }

            return true;
        }
    }
}
