using AutoMapper;
using WebApiBestPractices.Entities.Dto;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Profiles
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
            CreateMap<OwnerForCreationDto, Owner>();
            CreateMap<OwnerForUpdateDto, Owner>();
        }
    }
}
