using CodeChallenge.Dtos.AppointmentDrug;
using FluentValidation;

namespace CodeChallenge.Validators.AppointmentDrug
{
    public class ShowAppointmentDrugValidator : AbstractValidator<ShowAppointmentDrugDto>
    {
        public ShowAppointmentDrugValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
