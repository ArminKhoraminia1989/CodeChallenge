using CodeChallenge.Dtos.BasicInfo.Drug;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.Drug
{
    public class UpdateDrugValidator : AbstractValidator<UpdateDrugDto>
    {
        public UpdateDrugValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
            RuleFor(d => d.DateCreated).NotEmpty().WithMessage("تاریخ کد نباید خالی باشد");
            RuleFor(d => d.Description).NotEmpty().WithMessage("شرح نباید خالی باشد ")
                .MaximumLength(250).WithMessage("شرح مورد نظر نمیتواند بیشتر از 250 کاراکتر باشد");
            RuleFor(d => d.Price).GreaterThanOrEqualTo(1).WithMessage("قیمت باید از 0 بزرگتر باشد");
        }
    }
}
