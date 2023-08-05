using FinalCase.DataAccess;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Repository;
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
    public ApartmentController(FinalCaseDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public ApartmentController()
    {
        this.repository = repository;
        //this.mapper = mapper;
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResponse<List<Apartment>> GetAll()
    {
        var entityList = dbContext.Set<Apartment>().ToList();
        return new ApiResponse<List<Apartment>>(entityList);
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ApiResponse<Apartment> Get(int id)
    {
        var entity = dbContext.Set<Apartment>().Find(id);
        return new ApiResponse<Apartment>(entity);
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public ApiResponse Post([FromBody] Apartment request)
    {
        dbContext.Set<Apartment>().Add(request);
        dbContext.SaveChanges();
        return new ApiResponse();
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] Apartment request)
    {
        request.ApartmentNo = id;
        dbContext.Set<Apartment>().Update(request);
        dbContext.SaveChanges();
        return new ApiResponse();
    }

    // Sadece yöneticilere izin verilen bir işlem
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        var entity = dbContext.Set<Apartment>().Find(id);
        dbContext.Set<Apartment>().Remove(entity);
        dbContext.SaveChanges();
        return new ApiResponse();
    }
}

