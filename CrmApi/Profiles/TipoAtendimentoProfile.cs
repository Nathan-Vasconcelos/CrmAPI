using AutoMapper;
using CrmApi.Data.TipoAtendimentoDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class TipoAtendimentoProfile : Profile
    {
        public TipoAtendimentoProfile()
        {
            CreateMap<CreateTipoAtendimentoDto, TipoAtendimento>();
            CreateMap<TipoAtendimento, ReadTipoAtendimentoDto>();
            CreateMap<UpdateTipoAtendimentoDto, TipoAtendimento>();
        }
    }
}
