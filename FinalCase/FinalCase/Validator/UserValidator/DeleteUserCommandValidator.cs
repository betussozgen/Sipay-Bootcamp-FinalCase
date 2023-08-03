using FinalCase.Command.UserCommand;
using FluentValidation;

namespace FinalCase.Validator.UserValidator
{
    public class DeleteUserCommandValidator :AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.UserTcNo)
                //.NotEmpty().WithMessage("TC Kimlik Numarası boş olamaz.")
                //.Must(BeValidTC).WithMessage("Geçerli bir TC Kimlik Numarası giriniz.");

                .NotEmpty().WithMessage("Kimlik numarasını giriniz.")
                .Length(11).WithMessage("TcNo 11 karakter olmalıdır.");
        }

        /*
        private bool BeValidTC(long tc)
        {
            string tcString = tc.ToString(); // 1. TC Kimlik numarasını int türünden string türüne dönüştürüyoruz.

            if (tcString.Length != 11)   // 2. TC Kimlik numarasının uzunluğunun 11 olup olmadığını kontrol ediyoruz.
                return false;

            if (!IsAllDigits(tcString))  // 3. TC Kimlik numarasının tüm karakterlerinin sayısal olup olmadığını kontrol ediyoruz.
                return false;

            // 4. TC Kimlik numarasının ilk karakterinin sıfır olmadığını kontrol ediyoruz.
            int[] digits = tcString.Select(c => int.Parse(c.ToString())).ToArray();

            if (digits[0] == 0)
                return false;

            // 5. TC Kimlik numarasının belli kurallara uygunluğunu kontrol ediyoruz.
            int sum1 = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int sum2 = digits[1] + digits[3] + digits[5] + digits[7];

            if (((sum1 * 7 - sum2) % 10) != digits[9])
                return false;

            int sum3 = digits[0] + digits[1] + digits[2] + digits[3] + digits[4] + digits[5] + digits[6] + digits[7] + digits[8] + digits[9];
            if ((sum3 % 10) != digits[10])
                return false;

            return true;
        }

        private bool IsAllDigits(string value)
        {
            // Verilen değerinin tüm karakterlerinin sayısal olup olmadığını kontrol ediyoruz.
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        */


    }
}
