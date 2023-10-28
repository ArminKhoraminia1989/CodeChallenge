using CodeChallenge.Dtos.Appointment;
using FluentValidation;

namespace CodeChallenge.Validators.Appointment
{
    public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentDto>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(d => d.Id).Equal(0).WithMessage("شناسه کد باید خالی باشد");
            RuleFor(c => c.DurationTime).NotNull().WithMessage("نام نباید خالی باشد ")
                .GreaterThanOrEqualTo(5).LessThanOrEqualTo(30).WithMessage("مدت زمان باید بین 5 الی 30 دقیقه باشد");
            RuleFor(c => c.StartTime).NotNull().WithMessage("زمان و تاریخ شروع نباید خالی باشد ");
            RuleFor(c => c.EndTime).NotNull().WithMessage("زمان و تاریخ پایان نباید خالی باشد ");
            //RuleFor(c => c.BriefDescriptionSickness).NotEmpty().WithMessage("شرح مختصر نباید خالی باشد ");
            //RuleFor(c => c.DescriptionOfDoctor).NotEmpty().WithMessage("شرح چکاپ دکتر نباید خالی باشد ");
            RuleFor(c => c.DoctorId).NotNull().WithMessage("دکتر برای ویزیت نباید خالی باشد ");
            RuleFor(c => c.PatientId).NotNull().WithMessage("بیمار برای ویزیت نباید خالی باشد ");
        }
    }
}
