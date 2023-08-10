using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Operation;

public interface IPaymentService : IGenericService<Payment, PaymentRequest, PaymentResponse>
{
}
