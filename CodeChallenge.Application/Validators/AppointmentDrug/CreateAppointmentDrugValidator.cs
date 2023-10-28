using CodeChallenge.Dtos.AppointmentDrug;
using FluentValidation;

namespace CodeChallenge.Validators.AppointmentDrug
{
    public class CreateAppointmentDrugValidator : AbstractValidator<CreateAppointmentDrugDto>
    {
        public CreateAppointmentDrugValidator()
        {
            RuleFor(d => d.Id).Equal(0).WithMessage("شناسه کد باید خالی باشد");
            RuleFor(c => c.AppointmentId).NotNull().WithMessage("کد ویزیت نباید خالی باشد ");
            RuleFor(c => c.DrugId).NotNull().WithMessage("کد دارو نباید خالی باشد ");
            RuleFor(c => c.Qty).NotNull().WithMessage("مقدار دارو نباید خالی باشد ")
                .GreaterThanOrEqualTo(1).WithMessage("مقدار دارو نباید خالی باشد ");
        }
    }
}
