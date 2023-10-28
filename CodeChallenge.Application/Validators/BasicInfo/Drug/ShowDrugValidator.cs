using CodeChallenge.Dtos.BasicInfo.Drug;
using FluentValidation;

namespace CodeChallenge.Validators.BasicInfo.Drug
{
    public class ShowDrugValidator : AbstractValidator<ShowDrugDto>
    {
        public ShowDrugValidator()
        {
            RuleFor(d => d.Id).NotEqual(0).WithMessage("شناسه کد نباید خالی باشد");
        }
    }
}

