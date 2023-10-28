using CodeChallenge.Dtos.Doctor;
using FluentValidation;

namespace CodeChallenge.Validators.Doctor
{
    public class ShowDoctorValidator : AbstractValidator<ShowDoctorDto>
    {
        public ShowDoctorValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
