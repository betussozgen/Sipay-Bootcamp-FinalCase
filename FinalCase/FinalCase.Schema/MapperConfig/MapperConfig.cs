using AutoMapper;
using FinalCase.DataAccess.Domain;
using FinalCase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Schema;

public class MapperConfig : Profile
{
    public MapperConfig()
    {

        CreateMap<ApartmentRequest, Apartment>();
        CreateMap<Apartment, ApartmentResponse>();

        CreateMap<BillRequest, Bill>();
        CreateMap<Bill, BillResponse>();

        CreateMap<DueRequest, Due>();
        CreateMap<Due, DueResponse>();

        //CreateMap<DebtCreditRequest, DebtCredit>();
        //CreateMap<DebtCredit, DebtCreditResponse>();

        CreateMap<MessageRequest, Message>();
        CreateMap<Message, MessageResponse>();

        CreateMap<PaymentRequest, Payment>();
        CreateMap<Payment, PaymentResponse>();

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();
              //.ForMember(dest => dest.ApartmentId, opt => opt.MapFrom(src => src.Apartment.Block + " Block - No " + src.Apartment.Number)); ;

    }
}
