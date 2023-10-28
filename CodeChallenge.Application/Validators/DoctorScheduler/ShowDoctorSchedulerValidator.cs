using CodeChallenge.Dtos.DoctorScheduler;
using FluentValidation;

namespace CodeChallenge.Validators.DoctorScheduler
{
    public class ShowDoctorSchedulerValidator : AbstractValidator<ShowDoctorSchedulerDto>
    {
        public ShowDoctorSchedulerValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
