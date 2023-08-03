using FinalCase.Command.UserCommand;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FinalCase.Validator.UserValidator
{
    public class GetUserDetailQueryValidator : AbstractValidator<GetUserDetailQuery>
    {

        public GetUserDetailQueryValidator() 
        {
            RuleFor(query => query.UserTcNo)
                .NotEmpty().WithMessage("Kimlik numarasını giriniz.")
                .Length(11).WithMessage("TcNo 11 karakter olmalıdır.");
        }


    }
}
