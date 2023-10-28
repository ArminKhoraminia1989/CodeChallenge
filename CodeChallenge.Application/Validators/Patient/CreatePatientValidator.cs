using CodeChallenge.Dtos.Patient;
using FluentValidation;

namespace CodeChallenge.Validators.Patient
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientDto>
    {
        public CreatePatientValidator()
        {
            RuleFor(d => d.Id).Equal(0).WithMessage("شناسه کد باید خالی باشد");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("نام نباید خالی باشد ")
                .MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد");
            RuleFor(c => c.LastName).NotEmpty().WithMessage("نام خانوادگی نباید خالی باشد ")
                .MaximumLength(50).WithMessage("نام خانوادگی نمی تواند بیشتر از 50 کاراکتر باشد");
            RuleFor(d => d.Age).GreaterThanOrEqualTo(1).WithMessage("سن باید از 0 بزرگتر باشد");
            RuleFor(b => b.Gender).NotNull().WithMessage("جنسیت انتخاب نشده است");
            RuleFor(b => b.NationalCode).NotEmpty().WithMessage("کد ملی نباید خالی باشد ")
                 .MaximumLength(10).MinimumLength(10).WithMessage("کد ملی باید 10 کاراکتر باشد");
            RuleFor(b => b.EmailAddress).NotEmpty().WithMessage("آدرس ایمیل نباید خالی باشد")
                .EmailAddress().WithMessage("آدرس ایمیل صحیح نیست");
            RuleFor(b => b.PhoneNumber).NotEmpty().WithMessage("شماره تلفن نباید خالی باشد");
        }
    }
}
