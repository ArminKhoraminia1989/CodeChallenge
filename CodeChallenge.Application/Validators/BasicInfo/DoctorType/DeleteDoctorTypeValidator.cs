using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.DoctorType
{
    public class DeleteDoctorTypeValidator : AbstractValidator<DeleteDoctorTypeDto>
    {
        public DeleteDoctorTypeValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
