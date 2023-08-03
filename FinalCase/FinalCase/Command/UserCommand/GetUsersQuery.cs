using AutoMapper;
using FinalCase.DBOperations;
using static FinalCase.Command.UserCommand.GetUsersQuery;

namespace FinalCase.Command.UserCommand
{
    public class GetUsersQuery
    {

        private readonly SiteManagementDbContext _dbContext;

        private readonly IMapper _mapper;
        public GetUsersQuery(SiteManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public List<UserViewModel> Handle()
        {
            var userList = _dbContext.Users.OrderBy(x => x.Name).ToList<User>();
            List<UserViewModel> vm = _mapper.Map<List<UserViewModel>>(userList);
            
            return vm;

        }

        public class UserViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public bool CarInfo { get; set; }
        }
    }
}
