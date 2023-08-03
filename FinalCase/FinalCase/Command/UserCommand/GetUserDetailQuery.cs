using AutoMapper;
using FinalCase.DBOperations;
using static FinalCase.Command.UserCommand.CreateUserCommand;

namespace FinalCase.Command.UserCommand
{
    public class GetUserDetailQuery
    {
        private readonly SiteManagementDbContext _dbContext;

        private readonly IMapper _mapper;

        public string UserTcNo { get; set; }   

        public GetUserDetailQuery(SiteManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserDetailViewModel Handle()
        {
            var user = _dbContext.Users.Where(user => user.TcNo == UserTcNo).SingleOrDefault();
            if (user is null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }
            UserDetailViewModel vm = _mapper.Map<UserDetailViewModel>(user);
            //UserDetailViewModel vm = new UserDetailViewModel();
            //vm.Name = user.Name;
            //vm.Surname = user.Surname;
            //vm.Email = user.Email;
            //vm.PhoneNumber = user.PhoneNumber;
            //vm.CarInfo = user.CarInfo;


            return vm;
        }
    }


    public class UserDetailViewModel
    {
       
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool CarInfo { get; set; }
    }

 }

