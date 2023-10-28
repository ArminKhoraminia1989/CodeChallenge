using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.DoctorType
{
    public class CreateDoctorTypeValidator : AbstractValidator<CreateDoctorTypeDto>
    {
        public CreateDoctorTypeValidator()
        {
            RuleFor(d => d.Id).Equal(0).WithMessage("شناسه کد باید خالی باشد");
            //RuleFor(d => d.MinTimeVisit).Equal(5).WithMessage("حداقل زمان ویزیت باید 5 دقیقه باشد");
            //RuleFor(d => d.MaxTimeVisit).Equal(30).WithMessage("حداکثر زمان ویزیت باید 30 دقیقه باشد");
            RuleFor(d => d.Type).NotNull().WithMessage("نوع تخصص دکتر نباید خالی باشد");
        }
    }
}
