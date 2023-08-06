using AutoMapper;
using FinalCase.DataAccess.Domain;
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

        CreateMap<UserRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<DueInvoiceRequest, DueInvoice>();
        CreateMap<DueInvoice, DueInvoiceResponse>();
    }
}
