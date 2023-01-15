using AutoMapper;
using CrmApi.Data.ContratoDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class ContratoProfile : Profile
    {
        public ContratoProfile()
        {
            CreateMap<CreateContratoDto, Contrato>();
            CreateMap<Contrato, ReadContratoDto>();
            CreateMap<UpdateContratoDto, Contrato>();
        }
    }
}
