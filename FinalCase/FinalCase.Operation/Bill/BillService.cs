

using AutoMapper;
using FinalCase.Base;
using FinalCase.DataAccess.Domain;
using FinalCase.DataAccess.Uow;
using FinalCase.Operation.Generic;
using FinalCase.Schema;

namespace FinalCase.Operation;

public class BillService : IGenericService<Bill, BillRequest, BillResponse>, IBillService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public BillService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public ApiResponse Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public ApiResponse<List<BillResponse>> GetAll(params string[] includes)
    {
        throw new NotImplementedException();
    }

    public ApiResponse<BillResponse> GetById(int id, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public ApiResponse Insert(BillRequest request)
    {
        throw new NotImplementedException();
    }

    public ApiResponse Update(int Id, BillRequest request)
    {
        throw new NotImplementedException();
    }
}


//public class BillService : GenericService<Bill, BillRequest, BillResponse>, IBillService
//{
//    private readonly IMapper mapper;
//    private readonly IUnitOfWork unitOfWork;

//    public BillService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
//    {
//        this.mapper = mapper;
//        this.unitOfWork = unitOfWork;
//    }



//public ApiResponse CreateForAll(BillRequest request)
//{
//    try
//    {
//        var apartments = context.Set<Apartment>().ToList();

//        foreach (Apartment apartment in apartments)
//        {
//            var entity = mapper.Map<Bill>(request);
//            entity.ApartmentId = apartment.Id;
//            unitOfWork.DynamicRepository<Bill>().Create(entity);
//            unitOfWork.DynamicRepository<Bill>().Save();
//        }

//        return new ApiResponse();
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse(ex.Message);
//    }
//}

//public ApiResponse CreateForAllByDividing(BillRequest request)
//{
//    try
//    {
//        var apartments = context.Set<Apartment>().ToList();
//        request.Amount = request.Amount / apartments.Count();

//        foreach (Apartment apartment in apartments)
//        {
//            var entity = mapper.Map<Bill>(request);
//            entity.ApartmentId = apartment.Id;
//            unitOfWork.DynamicRepository<Bill>().Create(entity);
//            unitOfWork.DynamicRepository<Bill>().Save();
//        }

//        return new ApiResponse();
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse(ex.Message);
//    }
//}

//public ApiResponse CreateById(int id, BillRequest request)
//{
//    try
//    {
//        var entity = mapper.Map<Bill>(request);
//        entity.ApartmentId = id;

//        unitOfWork.DynamicRepository<Bill>().Create(entity);
//        unitOfWork.DynamicRepository<Bill>().Save();

//        return new ApiResponse();
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse(ex.Message);
//    }
//}

//public ApiResponse<IEnumerable<BillResponse>> GetAll(params string[] includes)
//{
//    try
//    {
//        var entity = unitOfWork.DynamicRepository<Bill>().GetAllWithInclude(includes).Where(x => x.BillPaymentStatus == 0).ToList();
//        var mapped = mapper.Map<IEnumerable<BillResponse>>(entity);
//        return new ApiResponse<IEnumerable<BillResponse>>(mapped);
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse<IEnumerable<BillResponse>>(ex.Message);
//    }
//}

//public ApiResponse<IEnumerable<BillResponse>> GetByApartment(int id)
//{
//    try
//    {
//        var entity = context.Set<Apartment>().Include(x => x.Bills).FirstOrDefault(e => e.Id == id);
//        var invoicesList = entity.Bills.ToList();

//        var mapped = mapper.Map<IEnumerable<BillResponse>>(invoicesList);
//        return new ApiResponse<IEnumerable<BillResponse>>(mapped);
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse<IEnumerable<BillResponse>>(ex.Message);
//    }
//}

//public ApiResponse<IEnumerable<BillResponse>> GetByMonth(string month)
//{
//    try
//    {
//        var entityList = unitOfWork.DynamicRepository<Bill>().WhereWithInclude(x => x.Month == month, "Apartment").ToList();
//        var mapped = mapper.Map<IEnumerable<BillResponse>>(entityList);
//        return new ApiResponse<IEnumerable<BillResponse>>(mapped);
//    }
//    catch (Exception ex)
//    {
//        return new ApiResponse<IEnumerable<BillResponse>>(ex.Message);
//    }
//}



