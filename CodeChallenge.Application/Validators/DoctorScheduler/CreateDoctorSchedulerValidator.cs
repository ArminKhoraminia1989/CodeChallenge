using CodeChallenge.Dtos.DoctorScheduler;
using FluentValidation;

namespace CodeChallenge.Validators.DoctorScheduler
{
    public class CreateDoctorSchedulerValidator : AbstractValidator<CreateDoctorSchedulerDto>
    {
        public CreateDoctorSchedulerValidator()
        {
            RuleFor(d => d.Id).Equal(0).WithMessage("شناسه کد باید خالی باشد");
            RuleFor(d => d.DoctorId).NotNull().WithMessage("دکتر نباید خالی باشد");
            RuleFor(d => d.StartTime).NotNull().WithMessage("تاریخ شروع نباید خالی باشد");
            RuleFor(d => d.EndTime).NotNull().WithMessage("تاریخ پایان نباید خالی باشد");
            RuleFor(d => d.DoctorId).NotEqual(0).WithMessage("کد دکتر نباید خالی باشد");
        }
    }
}
