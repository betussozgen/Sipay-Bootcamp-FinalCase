using AutoMapper;
using FinalCase.Business.Generic;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Operation;
public class PaymentService : GenericService<Payment, PaymentRequest, PaymentResponse>, IPaymentService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public PaymentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

}

