using AutoMapper;
using BuscaPersonalApi.Dtos.InputDto;
using BuscaPersonalApi.Entities;
using BuscaPersonalApi.Utils;

namespace BuscaPersonalApi.Services
{
    public class PersonalService
    {
        private readonly ValidarUtils _validarUtils;
        private readonly IMapper _mapper;

        public PersonalService(ValidarUtils validarUtils, IMapper mapper)
        {
            _validarUtils = validarUtils;
            _mapper = mapper;
        }

        private bool ValidarCPF(string cpf)
        {
            if (!_validarUtils.ValidarCPF(cpf))
            {
                throw new ApplicationException("CPF inválido.");
            }
            return true;
        }

        private bool ValidarEmail(string email)
        {
            if (!_validarUtils.ValidarEmail(email))
            {
                throw new ApplicationException("Email inválido.");
            }
            return true;
        }

        private bool ValidarSenha(string senha)
        {
            if (!_validarUtils.ValidarSenha(senha))
            {
                throw new ApplicationException("Senha inválida.");
            }
            return true;
        }

        private bool ValidarTelefone(string telefone)
        {
            if (!_validarUtils.ValidarTelefone(telefone))
            {
                throw new ApplicationException("Telefone inválido.");
            }
            return true;
        }

        private bool ValidarDataNascimento(DateOnly dataNascimento)
        {
            if (!_validarUtils.ValidarDataNascimento(dataNascimento))
            {
                throw new ApplicationException("Data de nascimento inválida.");
            }
            return true;
        }

        private void ValidarParaCadastro(PersonalInputDto personal)
        {

            if (!_validarUtils.ValidarNome(personal.Nome!))
            {
                throw new ApplicationException("Nome inválido.");
            }
            if (!_validarUtils.ValidarCPF(personal.CPF!))
            {
                throw new ApplicationException("CPF inválido.");
            }

            if (!_validarUtils.ValidarCREF(personal.CREF!))
            {
                throw new ApplicationException("CREF inválido.");
            }

            if (!_validarUtils.ValidarEmail(personal.Email!))
            {
                throw new ApplicationException("Email inválido.");
            }

            if (!_validarUtils.ValidarSenha(personal.Senha!))
            {
                throw new ApplicationException("Senha inválida.");
            }

            if (!_validarUtils.ValidarTelefone(personal.Telefone!))
            {
                throw new ApplicationException("Telefone inválido.");
            }

            if (personal.DataNascimento.HasValue &&
                !_validarUtils.ValidarDataNascimento(personal.DataNascimento.Value))
            {
                throw new ApplicationException("Data de nascimento inválida.");
            }
        }

        private void ValidarParaAutualizar(PersonalInputDto personal)
        {
            if (!_validarUtils.ValidarId(personal.Id!))
            {
                throw new ApplicationException("Id inválido.");
            }
            if (!_validarUtils.ValidarNome(personal.Nome!))
            {
                throw new ApplicationException("Nome inválido.");
            }
            if (!_validarUtils.ValidarCPF(personal.CPF!))
            {
                throw new ApplicationException("CPF inválido.");
            }

            if (!_validarUtils.ValidarCREF(personal.CREF!))
            {
                throw new ApplicationException("CREF inválido.");
            }

            if (!_validarUtils.ValidarEmail(personal.Email!))
            {
                throw new ApplicationException("Email inválido.");
            }

            if (!_validarUtils.ValidarSenha(personal.Senha!))
            {
                throw new ApplicationException("Senha inválida.");
            }

            if (!_validarUtils.ValidarTelefone(personal.Telefone!))
            {
                throw new ApplicationException("Telefone inválido.");
            }

            if (personal.DataNascimento.HasValue &&
                !_validarUtils.ValidarDataNascimento(personal.DataNascimento.Value))
            {
                throw new ApplicationException("Data de nascimento inválida.");
            }
        }

        private void ValidarParaAutenticacao(PersonalInputDto personal)
        {
            if (!_validarUtils.ValidarEmail(personal.Email!))
            {
                throw new ApplicationException("Email inválido.");
            }

            if (!_validarUtils.ValidarSenha(personal.Senha!))
            {
                throw new ApplicationException("Senha inválida.");
            }
        }


        public PersonalEntity MapearParaCadastro(PersonalInputDto personal)
        { 
            ValidarParaCadastro(personal);
            var entity = _mapper.Map<PersonalEntity>(personal);
            return entity;
        }

        public PersonalEntity MapearParaAtualizacao(PersonalInputDto personal)
        {
            ValidarParaAutualizar(personal);
            return _mapper.Map<PersonalEntity>(personal);
        }

        public PersonalEntity MapearParaAutenticacao(PersonalInputDto personal)
        {
            ValidarParaAutenticacao(personal);
            return _mapper.Map<PersonalEntity>(personal);
        }

        public bool ValidarId(int id)
        {
            if (!_validarUtils.ValidarId(id))
            {
                return false;
            }
            return true;
        }
    }
}
