using AutoMapper;
using FinalCase.Command.UserCommand;
using System.Diagnostics.Eventing.Reader;
using static FinalCase.Command.UserCommand.CreateUserCommand;
using static FinalCase.Command.UserCommand.GetUsersQuery;

namespace FinalCase.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateUserModel, User>();
            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UserViewModel>();
           
        }
    }
}
