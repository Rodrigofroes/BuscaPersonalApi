using AutoMapper;
using BuscaPersonalApi.Dtos.InputDto;
using BuscaPersonalApi.Dtos.OutputDto;
using BuscaPersonalApi.Entities;

namespace BuscaPersonalApi.AutoMapper
{
    public class AutoMapperPofile : Profile
    {
        public AutoMapperPofile()
        {
            CreateMap<PersonalEntity, PersonalOutputDto>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Per_id))
                .ForMember(dest => dest.Nome, map => map.MapFrom(src => src.Per_nome))
                .ForMember(dest => dest.CREF, map => map.MapFrom(src => src.Per_cref))
                .ForMember(dest => dest.Telefone, map => map.MapFrom(src => src.Per_telefone))
                .ForMember(dest => dest.DataNascimento, map => map.MapFrom(src => src.Per_data_nascimento))
                .ForMember(dest => dest.Especialidade, map => map.MapFrom(src => src.Per_especialidades))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Per_email))
                .ForMember(dest => dest.Confirmado, map => map.MapFrom(src => src.Per_confirmado))
                .ForMember(dest => dest.Ativo, map => map.MapFrom(src => src.Per_ativo))
                .ForMember(dest => dest.DataCadastro, map => map.MapFrom(src => src.Per_data_cadastro))
                .ReverseMap();

            CreateMap<PersonalInputDto, PersonalEntity>()
                .ForMember(dest => dest.Per_id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Per_nome, map => map.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Per_cref, map => map.MapFrom(src => src.CREF))
                .ForMember(dest => dest.Per_cpf, map => map.MapFrom(src => src.CPF))
                .ForMember(dest => dest.Per_telefone, map => map.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Per_data_nascimento, map => map.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Per_especialidades, map => map.MapFrom(src => src.Especialidade))
                .ForMember(dest => dest.Per_email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Per_senha, map => map.MapFrom(src => src.Senha))
                .ForMember(dest => dest.Per_confirmado, map => map.MapFrom(src => false))
                .ForMember(dest => dest.Per_ativo, map => map.MapFrom(src => true))
                .ForMember(dest => dest.Per_data_cadastro, map => map.MapFrom(src => DateTime.UtcNow));
        }
    }
}
