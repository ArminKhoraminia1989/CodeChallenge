using CodeChallenge.Dtos.Doctor;
using FluentValidation;

namespace CodeChallenge.Validators.Doctor
{
    public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorDto>
    {
        public DeleteDoctorValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
