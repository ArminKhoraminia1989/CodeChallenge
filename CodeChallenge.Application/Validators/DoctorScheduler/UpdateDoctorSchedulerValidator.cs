using CodeChallenge.Dtos.DoctorScheduler;
using FluentValidation;

namespace CodeChallenge.Validators.DoctorScheduler
{
    public class UpdateDoctorSchedulerValidator : AbstractValidator<UpdateDoctorSchedulerDto>
    {
        public UpdateDoctorSchedulerValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
            RuleFor(d => d.DoctorId).NotNull().WithMessage("دکتر نباید خالی باشد");
            RuleFor(d => d.StartTime).NotNull().WithMessage("تاریخ شروع نباید خالی باشد");
            RuleFor(d => d.EndTime).NotNull().WithMessage("تاریخ پایان نباید خالی باشد");
            RuleFor(d => d.DoctorId).NotEqual(0).WithMessage("کد دکتر نباید خالی باشد");
        }
    }
}
