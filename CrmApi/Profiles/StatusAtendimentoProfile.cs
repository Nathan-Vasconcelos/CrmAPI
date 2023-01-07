using AutoMapper;
using CrmApi.Data.StatusAtendimentoDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class StatusAtendimentoProfile : Profile
    {
        public StatusAtendimentoProfile()
        {
            CreateMap<CreateStatusAtendimentoDto, StatusAtendimento>();
            CreateMap<StatusAtendimento, ReadStatusAtendimentoDto>();
            CreateMap<UpdateStatusAtendimentoDto, StatusAtendimento>();
        }
    }
}
