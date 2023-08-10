using AutoMapper;
using FinalCase.DataAccess;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
using FinalCase.DataAccess.Uow;
using FinalCase.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalCase.Base;

namespace FinalCase.Controllers;



[ApiController]
[Route("Final/Case/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<UserResponse>> GetAll()
    {
        var entityList = unitOfWork.UserRepository.GetAll();
        var mapped = mapper.Map<List<UserResponse>>(entityList);
        return new ApiResponse<List<UserResponse>>(mapped);
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]

    public ApiResponse<UserResponse> Get(int id)
    {
        var entity = unitOfWork.UserRepository.GetById(id);
        var mapped = mapper.Map<User, UserResponse>(entity);
        return new ApiResponse<UserResponse>(mapped);
    }
    //public ApiResponse<UserResponse> Get(int id)
    //{
    //    var entity = repository.GetById(id);
    //    var mapped = mapper.Map<User, UserResponse>(entity);
    //    return new ApiResponse<UserResponse>(mapped);
    //}

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] UserRequest request)
    {
        var entity = mapper.Map<UserRequest, User>(request);

        unitOfWork.UserRepository.Insert(entity);
        unitOfWork.UserRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] UserRequest request)
    {

        var entity = mapper.Map<UserRequest, User>(request);

        unitOfWork.UserRepository.Insert(entity);
        entity.UserId = id;

        unitOfWork.UserRepository.Update(entity);
        unitOfWork.UserRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        unitOfWork.UserRepository.DeleteById(id);
        unitOfWork.Complete();
        return new ApiResponse();
    }
}

