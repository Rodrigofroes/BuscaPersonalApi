using BuscaPersonalApi.Dtos.InputDto;
using BuscaPersonalApi.Repositories.Interface;
using BuscaPersonalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuscaPersonalApi.Controllers
{
    [ApiController]
    [Route("api/personal")]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonal _personal;
        private readonly PersonalService _personalService;
        public PersonalController(IPersonal personal, PersonalService pservice)
        {
            _personal = personal;
            _personalService = pservice;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPersonal()
        {
            try
            {
                var personais = await _personal.ListarPersonal();
                if (!personais.Any())
                {
                    return BadRequest(new
                    {
                        Mensagem = "Nenhum personal cadastrado"
                    });
                }
                return Ok(personais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar/{Id}")]
        public async Task<IActionResult> BuscarPersonal(int Id)
        {
            try
            {
                if (!_personalService.ValidarId(Id))
                {
                    return BadRequest(new
                    {
                        Mensagem = "Id inválido"
                    });
                }
                var personal = await _personal.BuscarPersonal(Id);
                if (personal == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Personal não encontrado"
                    });
                }
                return Ok(personal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> InserirPersonal([FromBody] PersonalInputDto personal)
        {
            try
            {
               var mpersonal = _personalService.MapearParaCadastro(personal);
               var personalCadastrado = await _personal.InserirPersonal(mpersonal);
               if(personalCadastrado == null)
               {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao cadastrar personal"
                    });
               }

               return Ok(new
               {
                   Mensagem = "Personal cadastrado com sucesso",
               });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarPersonal([FromBody] PersonalInputDto personal)
        {
            try
            {
                var mpersonal = _personalService.MapearParaAtualizacao(personal);
                var personalAtualizado = await _personal.AtualizarPersonal(mpersonal);
                if (personalAtualizado == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao atualizar personal"
                    });
                }
                return Ok(new
                {
                    Mensagem = "Personal atualizado com sucesso",
                });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("deletar/{Id}")]
        public async Task<IActionResult> DeletarPersonal(int Id)
        {
            try
            {
                if (!_personalService.ValidarId(Id))
                {
                    return BadRequest(new
                    {
                        Mensagem = "Id inválido"
                    });
                }
                var personalDeletado = await _personal.DeletarPersonal(Id);
                if (personalDeletado == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Erro ao deletar personal"
                    });
                }
                return Ok(new
                {
                    Mensagem = "Personal deletado com sucesso",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new 
                {
                    message = ex.Message
                });

            }
        }
    }
}
