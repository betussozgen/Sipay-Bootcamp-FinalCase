using FinalCase.Base;
using FinalCase.Operation.Generic;
using FinalCase.DataAccess.Domain;
using FinalCase.Schema;

namespace FinalCase.Business;

public interface IUserLogService : IGenericService<User,UserLogRequest,UserLogResponse>
{
    ApiResponse<List<UserLogResponse>> GetByUserSession(string username);
}
