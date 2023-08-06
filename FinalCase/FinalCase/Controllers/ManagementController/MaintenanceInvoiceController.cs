using AutoMapper;
using FinalCase.DataAccess.Repository;
using FinalCase.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FinalCase.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using SipayApi.Base;
using FinalCase.Schema;

namespace FinalCase.Controllers.ManagementController
{
    public class MaintenanceInvoiceController : ControllerBase
    {
        private readonly IApartmentRepository repository;
        //private readonly IMapper mapper;
        private readonly FinalCaseDbContext dbContext;
        private readonly IMapper mapper;
        public MaintenanceInvoiceController(FinalCaseDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        // Yeni bir daire bilgisi eklemek için POST isteği
        [HttpPost]
        public ApiResponse Post([FromBody] ApartmentRequest request)
        {


            var entity = mapper.Map<ApartmentRequest, Apartment>(request);
            repository.Insert(entity);
            repository.Save();
            return new ApiResponse();



        }

        // Yeni bir kullanıcı bilgisi eklemek için POST isteği
        [HttpPost]
        public ApiResponse Post([FromBody] UserRequest request)
        {
            var entity = mapper.Map<UserRequest, User>(request);
            //repository.Insert(entity);
            repository.Save();
            return new ApiResponse();
        }

        // Bir kullanıcıya daire atamak için POST isteği
        [HttpPost]
        //public IActionResult AssignApartmentToUser(int userId, int apartmentId)
        //{
        //    try
        //    {
        //        var user = dbContext.Users.FirstOrDefault(u => u.Id == userId);
        //        var apartment = dbContext.Apartments.FirstOrDefault(a => a.Id == apartmentId);

        //        if (user == null || apartment == null)
        //            return NotFound();

        //        user.ApartmentId = apartment.Id;
        //        dbContext.SaveChanges();

        //        return Ok("Daire kullanıcıya atandı.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Daire atama işlemi sırasında bir hata oluştu: " + ex.Message);
        //    }
        //}
    }
}
