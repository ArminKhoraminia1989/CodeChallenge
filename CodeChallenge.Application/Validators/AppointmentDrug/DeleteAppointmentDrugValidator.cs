using CodeChallenge.Dtos.AppointmentDrug;
using FluentValidation;

namespace CodeChallenge.Validators.AppointmentDrug
{
    public class DeleteAppointmentDrugValidator : AbstractValidator<DeleteAppointmentDrugDto>
    {
        public DeleteAppointmentDrugValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
