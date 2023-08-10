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
public class PaymentController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<PaymentResponse>> GetAll()
    {
        var entityList = unitOfWork.PaymentRepository.GetAll();
        var mapped = mapper.Map<List<Payment>, List<PaymentResponse>>(entityList);
        return new ApiResponse<List<PaymentResponse>>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<PaymentResponse> Get(int id)
    {
        var entity = unitOfWork.PaymentRepository.GetById(id);
        var mapped = mapper.Map<Payment, PaymentResponse>(entity);
        return new ApiResponse<PaymentResponse>(mapped);
    }


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] PaymentRequest request)
    {
        var entity = mapper.Map<PaymentRequest, Payment>(request);

        unitOfWork.PaymentRepository.Insert(entity);
        unitOfWork.PaymentRepository.Save();
        return new ApiResponse();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] PaymentRequest request)
    {

        var entity = mapper.Map<PaymentRequest, Payment>(request);

        unitOfWork.PaymentRepository.Insert(entity);
        entity.PaymentId = id;

        unitOfWork.PaymentRepository.Update(entity);
        unitOfWork.PaymentRepository.Save();
        return new ApiResponse();
    }


    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        unitOfWork.PaymentRepository.DeleteById(id);
        unitOfWork.PaymentRepository.Save();
        return new ApiResponse();
    }
}

