using CodeChallenge.Dtos.Patient;
using FluentValidation;

namespace CodeChallenge.Validators.Patient
{
    public class ShowPatientValidator : AbstractValidator<ShowPatientDto>
    {
        public ShowPatientValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
