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
public class DueController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public DueController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<DueResponse>> GetAll()
    {
        var entityList = unitOfWork.DueRepository.GetAll();
        var mapped = mapper.Map<List<Due>, List<DueResponse>>(entityList);
        return new ApiResponse<List<DueResponse>>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<DueResponse> Get(int id)
    {
        var entity = unitOfWork.DueRepository.GetById(id);
        var mapped = mapper.Map<Due, DueResponse>(entity);
        return new ApiResponse<DueResponse>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] DueRequest request)
    {
        var entity = mapper.Map<DueRequest, Due>(request);

        unitOfWork.DueRepository.Insert(entity);
        unitOfWork.DueRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] DueRequest request)
    {

        var entity = mapper.Map<DueRequest, Due>(request);

        unitOfWork.DueRepository.Insert(entity);
        entity.DuesId = id;

        unitOfWork.DueRepository.Update(entity);
        unitOfWork.DueRepository.Save();
        return new ApiResponse();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        unitOfWork.DueRepository.DeleteById(id);
        unitOfWork.DueRepository.Save();
        return new ApiResponse();
    }
}

