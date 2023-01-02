using AutoMapper;
using CrmApi.Data.ClienteDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
