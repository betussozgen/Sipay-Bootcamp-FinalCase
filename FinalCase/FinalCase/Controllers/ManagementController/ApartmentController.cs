using AutoMapper;
using FinalCase.DataAccess;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
using FinalCase.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SipayApi.Base;

namespace FinalCase.Controllers.ManagementController;



[ApiController]
[Route("Final/Case/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentRepository repository;
    //private readonly IMapper mapper;
    private readonly FinalCaseDbContext dbContext;
    private readonly IMapper mapper;
    public ApartmentController(FinalCaseDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;   
    }
 

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<ApartmentResponse>> GetAll()
    {
        var entityList = repository.GetAll();
        var mapped = mapper.Map<List<Apartment>, List<ApartmentResponse>>(entityList);
        return new ApiResponse<List<ApartmentResponse>>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<ApartmentResponse> Get(int id)
    {
        var entity = repository.GetById(id);
        var mapped = mapper.Map<Apartment, ApartmentResponse>(entity);
        return new ApiResponse<ApartmentResponse>(mapped);
    }

 
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] ApartmentRequest request)
    {
        var entity = mapper.Map<ApartmentRequest, Apartment>(request);
        entity.IsOccupied = true;
        repository.Insert(entity);
        repository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] ApartmentRequest request)
    {

        var entity = mapper.Map<ApartmentRequest, Apartment>(request);
        entity.IsOccupied = true;
        repository.Insert(entity);
        entity.ApartmentNo = id;

        repository.Update(entity);
        repository.Save();
        return new ApiResponse();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        repository.DeleteById(id);
        repository.Save();
        return new ApiResponse();
    }
}

