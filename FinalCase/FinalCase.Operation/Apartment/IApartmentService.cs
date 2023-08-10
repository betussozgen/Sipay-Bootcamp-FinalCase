using FinalCase.DataAccess.Domain;
using FinalCase.Schema;
using FinalCase.Operation.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Operation;
public interface IApartmentService : IGenericService<Apartment, ApartmentRequest, ApartmentResponse>
{
}

