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
public class BillController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public BillController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<BillResponse>> GetAll()
    {
        var entityList = unitOfWork.BillRepository.GetAll();
        var mapped = mapper.Map<List<Bill>, List<BillResponse>>(entityList);
        return new ApiResponse<List<BillResponse>>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<BillResponse> Get(int id)
    {
        var entity = unitOfWork.BillRepository.GetById(id);
        var mapped = mapper.Map<Bill, BillResponse>(entity);
        return new ApiResponse<BillResponse>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] BillRequest request)
    {
        var entity = mapper.Map<BillRequest, Bill>(request);

        unitOfWork.BillRepository.Insert(entity);
        unitOfWork.BillRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] BillRequest request)
    {

        var entity = mapper.Map<BillRequest, Bill>(request);

        unitOfWork.BillRepository.Insert(entity);
        entity.BillId = id;

        unitOfWork.BillRepository.Update(entity);
        unitOfWork.BillRepository.Save();
        return new ApiResponse();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        unitOfWork.BillRepository.DeleteById(id);
        unitOfWork.BillRepository.Save();
        return new ApiResponse();
    }
}

