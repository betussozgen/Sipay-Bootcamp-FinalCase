using AutoMapper;
using FinalCase.Base;
using FinalCase.Business;
using FinalCase.Data.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Operation.Generic;
using FinalCase.Schema;


namespace FinalCase.Operation;

public class UserLogService : IGenericService<UserLog, UserLogRequest, UserLogResponse>, IUserLogService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UserLogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public ApiResponse<List<UserLogResponse>> GetByUserSession(string username)
    {
        var list = unitOfWork.UserLogRepository.Where(x => x.UserName == username).ToList();
        var mapped = mapper.Map<List<UserLogResponse>>(list);
        return new ApiResponse<List<UserLogResponse>>(mapped);
    }

}
