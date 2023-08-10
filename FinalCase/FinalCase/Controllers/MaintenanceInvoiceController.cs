using AutoMapper;
using FinalCase.DataAccess.Repository;
using FinalCase.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FinalCase.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using FinalCase.Base;
using FinalCase.Schema;
using FinalCase.DataAccess.Uow;

namespace FinalCase.Controllers;
public class MaintenanceInvoiceController : ControllerBase
{

    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public MaintenanceInvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

}
//Yeni bir daire bilgisi eklemek için POST isteği
//[HttpPost]
// public ApiResponse Post([FromBody] ApartmentRequest request)
// {


//     var entity = mapper.Map<ApartmentRequest, Apartment>(request);
//     unitOfWork..Insert(entity);
//     repository.Save();
//     return new ApiResponse();



// }

// //Yeni bir kullanıcı bilgisi eklemek için POST isteği
//[HttpPost]
// public ApiResponse Post([FromBody] UserRequest request)
// {
//     var entity = mapper.Map<UserRequest, User>(request);
//     repository.Insert(entity);
//     repository.Save();
//     return new ApiResponse();
// }

// //Bir kullanıcıya daire atamak için POST isteği
//[HttpPost]
// public IActionResult AssignApartmentToUser(int userId, int apartmentId)
// {
//     try
//     {
//         var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
//         var apartment = dbContext.Apartments.FirstOrDefault(a => a.Id == apartmentId);

//         if (user == null || apartment == null)
//             return NotFound();

//         user.ApartmentId = apartment.Id;
//         dbContext.SaveChanges();

//         return Ok("Daire kullanıcıya atandı.");
//     }
//     catch (Exception ex)
//     {
//         return BadRequest("Daire atama işlemi sırasında bir hata oluştu: " + ex.Message);
//     }
// }

