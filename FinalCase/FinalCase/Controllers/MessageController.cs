using AutoMapper;
using FinalCase.DataAccess;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
using FinalCase.DataAccess.Uow;
using FinalCase.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinalCase.Base;

namespace FinalCase.Controllers;

[ApiController]
[Route("Final/Case/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MessageController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetUnreadMessages")]
    public ApiResponse<List<MessageResponse>> GetAll()
    {
        var entityList = unitOfWork.MessageRepository.GetAll();
        var mapped = mapper.Map<List<Message>, List<MessageResponse>>(entityList);
        return new ApiResponse<List<MessageResponse>>(mapped);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("SendMessage")]

    public ApiResponse Post([FromBody] MessageRequest request)
    {
        var entity = mapper.Map<MessageRequest, Message>(request);

        unitOfWork.MessageRepository.Insert(entity);
        unitOfWork.MessageRepository.Save();
        return new ApiResponse();
    }

    [HttpPost("SendMessageToAdmin")]
    public ApiResponse SendMessageToAdmin([FromBody] MessageRequest request)
    {
        var message = mapper.Map<Message>(request);
        unitOfWork.MessageRepository<Message>().Insert(message);
        await unitOfWork.SaveChangesAsync();
        return new ApiResponse();
    }

    [HttpGet("GetMessages")]
    [Authorize(Roles = "Admin")]
    public ApiResponse<List<MessageResponse>> GetMessages()
    {
        var messages = await unitOfWork.MessageRepository<Message>().GetAllAsync();
        var messageResponses = mapper.Map<List<MessageResponse>>(messages);
        return new ApiResponse<List<MessageResponse>>(messageResponses);
    }
}
