using AutoMapper;
using BSynchro.DataAccess.Models;

namespace BSynchro.Dto.Mapper
{
    public class BSynchroMappingProfile : Profile
    {
        public BSynchroMappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>()
                .ForPath(dest => dest.AccountId, opt => opt.MapFrom(src => src.Account.AccountId))
                .ForPath(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.CreatedOn)).ReverseMap();
        }
    }
}