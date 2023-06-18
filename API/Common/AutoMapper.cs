using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace API.Common
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Transaction, TransactionDto>();
            CreateMap<TransactionDto, Transaction>();
        }
        
    }
}