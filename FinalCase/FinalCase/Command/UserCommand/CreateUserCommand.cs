using AutoMapper;
using FinalCase.DBOperations;
using static FinalCase.Command.UserCommand.CreateUserCommand;

namespace FinalCase.Command.UserCommand
{
    public class CreateUserCommand
    {

        public CreateUserModel Model { get; set; }


        private readonly SiteManagementDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateUserCommand(SiteManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }

        public void Handle()
        {

            var user = _dbContext.Users.SingleOrDefault(x => x.TcNo == Model.TcNo);

            if (user is not null)
            {
                throw new InvalidOperationException("Kullanıcı zaten mevcut!");
            }
            user = _mapper.Map<User>(Model);

             

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();


        }

        public class CreateUserModel
        {
            public string TcNo { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public bool CarInfo { get; set; }

        }

    }
}
