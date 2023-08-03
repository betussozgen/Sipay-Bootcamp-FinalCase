using FinalCase.Command.UserCommand;
using FluentValidation;

namespace FinalCase.Validator.UserValidator
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(command => command.UserTcNo)
                .NotEmpty().WithMessage("Kimlik numarasını giriniz.")
               .Length(11).WithMessage("TcNo 11 karakter olmalıdır.");
            RuleFor(user => user.Model.Name)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");
            RuleFor(user => user.Model.Surname)
                .NotEmpty().WithMessage("Kullanıcı adı boş olamaz.")
                .Length(3, 50).WithMessage("Kullanıcı adı 3 ile 50 karakter arasında olmalıdır.");
            RuleFor(user => user.Model.CarInfo)
                .NotEmpty().WithMessage("Araç bilgisi boş olamaz.")
                .Must(BeValidCarInfo).WithMessage("Geçerli bir araç bilgisi giriniz (var veya yok).");
        }

        private bool BeValidCarInfo(bool carInfo)
        {
            return carInfo == true || carInfo == false;
        }
    }
}
