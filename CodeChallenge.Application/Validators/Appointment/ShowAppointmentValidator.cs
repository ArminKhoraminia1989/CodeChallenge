using CodeChallenge.Dtos.Appointment;
using FluentValidation;

namespace CodeChallenge.Validators.Appointment
{
    public class ShowAppointmentValidator : AbstractValidator<ShowAppointmentDto>
    {
        public ShowAppointmentValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
