using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.DoctorType
{
    public class ShowDoctorTypeValidator : AbstractValidator<ShowDoctorTypeDto>
    {
        public ShowDoctorTypeValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}
