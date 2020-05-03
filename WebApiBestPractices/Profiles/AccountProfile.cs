using AutoMapper;
using WebApiBestPractices.Entities.Dto;
using WebApiBestPractices.Entities.Model;

namespace WebApiBestPractices.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
        }
    }
}
