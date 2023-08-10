using AutoMapper;
using FinalCase.Base;
using FinalCase.Business.Generic;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalCase.Operation;
public class DueService : GenericService<Due, DueRequest, DueResponse>, IDueService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DueService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }



}
//    public ApiResponse CreateForAll(DueRequest request)
//    {
//        try
//        {
//            var apartments = dbContext.Set<Apartment>().ToList();

//            foreach (Apartment apartment in apartments)
//            {
//                var entity = mapper.Map<Due>(request);
//                entity.ApartmentId = apartment.Id;
//                unitOfWork.DynamicRepository<Due>().Create(entity);
//                unitOfWork.DynamicRepository<Due>().Save();
//            }

//            return new ApiResponse();
//        }
//        catch (Exception ex)
//        {
//            return new ApiResponse(ex.Message);
//        }
//    }

//    public ApiResponse CreateById(int id, DueRequest request)
//    {
//        //try
//        //{
//        //    var entity = mapper.Map<Due>(request);
//        //    entity.ApartmentId = id;

//        //    unitOfWork.DynamicRepository<Due>().Create(entity);
//        //    unitOfWork.DynamicRepository<Due>().Save();

//        //    return new ApiResponse();
//        //}
//        //catch (Exception ex)
//        //{
//        //    return new ApiResponse(ex.Message);
//        //}
//    }

//    public ApiResponse<IEnumerable<DueResponse>> GetAll(params string[] includes)
//    {
//        try
//        {
//            var entity = unitOfWork.DynamicRepository<Due>().GetAllWithInclude(includes).Where(x => x.DueStatus == 0).ToList();
//            var mapped = mapper.Map<IEnumerable<DueResponse>>(entity);
//            return new ApiResponse<IEnumerable<DueResponse>>(mapped);
//        }
//        catch (Exception ex)
//        {
//            return new ApiResponse<IEnumerable<DueResponse>>(ex.Message);
//        }
//    }

//    public ApiResponse<IEnumerable<DueResponse>> GetByApartment(int id)
//    {
//        //try
//        //{
//        //    var entity = context.Set<Apartment>().Include(x => x.Due).FirstOrDefault(e => e.Id == id);
//        //    var duesList = entity.Due.ToList();

//        //    var mapped = mapper.Map<IEnumerable<DueResponse>>(duesList);
//        //    return new ApiResponse<IEnumerable<DueResponse>>(mapped);
//        //}
//        //catch (Exception ex)
//        //{
//        //    return new ApiResponse<IEnumerable<DueResponse>>(ex.Message);
//        //}
//    }

//    public ApiResponse<IEnumerable<DueResponse>> GetByMonth(string month)
//    {
//        try
//        {
//            var entityList = unitOfWork.DynamicRepository<Due>().WhereWithInclude(x => x.Month == month, "Apartment").ToList();
//            var mapped = mapper.Map<IEnumerable<DueResponse>>(entityList);
//            return new ApiResponse<IEnumerable<DueResponse>>(mapped);
//        }
//        catch (Exception ex)
//        {
//            return new ApiResponse<IEnumerable<DueResponse>>(ex.Message);
//        }
//    }
//}


