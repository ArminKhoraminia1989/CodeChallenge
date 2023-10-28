using CodeChallenge.Dtos.DoctorScheduler;
using FluentValidation;

namespace CodeChallenge.Validators.DoctorScheduler
{
    public class DeleteDoctorSchedulerValidator : AbstractValidator<DeleteDoctorSchedulerDto>
    {
        public DeleteDoctorSchedulerValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
