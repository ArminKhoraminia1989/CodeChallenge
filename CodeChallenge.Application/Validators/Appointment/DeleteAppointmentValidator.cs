using CodeChallenge.Dtos.Appointment;
using FluentValidation;

namespace CodeChallenge.Validators.Appointment
{
    public class DeleteAppointmentValidator : AbstractValidator<DeleteAppointmentDto>
    {
        public DeleteAppointmentValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
