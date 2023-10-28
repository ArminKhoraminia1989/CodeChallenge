using CodeChallenge.Dtos.Patient;
using FluentValidation;

namespace CodeChallenge.Validators.Patient
{
    public class DeletePatientValidator : AbstractValidator<DeletePatientDto>
    {
        public DeletePatientValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
