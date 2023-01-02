using AutoMapper;
using CrmApi.Data.ParecerDto;
using CrmApi.Models;

namespace CrmApi.Profiles
{
    public class ParecerProfile : Profile
    {
        public ParecerProfile()
        {
            CreateMap<CreateParecerDto, Parecer>();
            CreateMap<Parecer, ReadParecerDto>();
            CreateMap<UpdateParecerDto, Parecer>();
        }
    }
}
