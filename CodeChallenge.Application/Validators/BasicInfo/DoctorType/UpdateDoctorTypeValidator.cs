using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.DoctorType
{
    public class UpdateDoctorTypeValidator : AbstractValidator<UpdateDoctorTypeDto>
    {
        public UpdateDoctorTypeValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
            //RuleFor(d => d.MinTimeVisit).Equal(5).WithMessage("حداقل زمان ویزیت باید 5 دقیقه باشد");
            //RuleFor(d => d.MaxTimeVisit).Equal(30).WithMessage("حداکثر زمان ویزیت باید 30 دقیقه باشد");
            RuleFor(d => d.Type).NotNull().WithMessage("نوع دکتر نباید خالی باشد");
        }
    }
}
