

using AutoMapper;
using FinalCase.Base;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Operation.Generic;
using FinalCase.Schema;

namespace FinalCase.Operation;


public class UserService : IGenericService<User, UserRequest, UserResponse>, IUSerService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UserService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public ApiResponse Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public ApiResponse<List<UserResponse>> GetAll(params string[] includes)
    {
        throw new NotImplementedException();
    }

    public ApiResponse<UserResponse> GetById(int id, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public ApiResponse Insert(UserRequest request)
    {
        throw new NotImplementedException();
    }

    public ApiResponse Update(int Id, UserRequest request)
    {
        throw new NotImplementedException();
    }
}