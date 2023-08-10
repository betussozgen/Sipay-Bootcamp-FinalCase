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
public class ApartmentController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ApartmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<ApartmentResponse>> GetAll()
    {
        var entityList = unitOfWork.ApartmentRepository.GetAll();
        var mapped = mapper.Map<List<Apartment>, List<ApartmentResponse>>(entityList);
        return new ApiResponse<List<ApartmentResponse>>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<ApartmentResponse> Get(int id)
    {
        var entity = unitOfWork.ApartmentRepository.GetById(id);
        var mapped = mapper.Map<Apartment, ApartmentResponse>(entity);
        return new ApiResponse<ApartmentResponse>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] ApartmentRequest request)
    {
        var entity = mapper.Map<ApartmentRequest, Apartment>(request);

        unitOfWork.ApartmentRepository.Insert(entity);
        unitOfWork.ApartmentRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
    {

        var entity = mapper.Map<ApartmentRequest, Apartment>(request);

        unitOfWork.ApartmentRepository.Insert(entity);
        entity.ApartmentNumber = id;

        unitOfWork.ApartmentRepository.Update(entity);
        unitOfWork.ApartmentRepository.Save();
        return new ApiResponse();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        unitOfWork.ApartmentRepository.DeleteById(id);
        unitOfWork.ApartmentRepository.Save();
        return new ApiResponse();
    }
}

