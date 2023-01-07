using AutoMapper;
using CrmApi.Data.ContatoAtendimentoDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class ContatoAtendimentoProfile : Profile
    {
        public ContatoAtendimentoProfile()
        {
            CreateMap<CreateContatoAtendimentoDto, ContatoAtendimento>();
            CreateMap<ContatoAtendimento, ReadContatoAtendimentoDto>();
            CreateMap<UpdateContatoAtendimentoDto, ContatoAtendimento>();
        }
    }
}
