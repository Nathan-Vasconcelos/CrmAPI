using AutoMapper;
using CrmApi.Data.AtendimentoDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class AtendimentoProfile : Profile
    {
        public AtendimentoProfile()
        {
            CreateMap<CreateAtendimentoDto, Atendimento>();
            CreateMap<Atendimento, ReadAtendimentoDto>();
            CreateMap<UpdateAtendimentoDto, Atendimento>();
        }
    }
}
