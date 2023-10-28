using AutoMapper;
using CodeChallenge.Application.Features.Doctor.Requests.Commands;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using CodeChallenge.Core.Entities.Enums;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;
using CodeChallenge.Application.Resources;

namespace CodeChallenge.Application.Features.Doctor.Handlers.Commands
{
    public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, BaseResponse>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Doctor> _repDoctor;
        private readonly IGenericRepository<CodeChallenge.Core.Entities.BasicInfo.DoctorType> _repType;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDoctorDto> _Validator;
        public CreateDoctorCommandHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.Doctor> repDoctor,
            IGenericRepository<CodeChallenge.Core.Entities.BasicInfo.DoctorType> repType,
            IValidator<CreateDoctorDto> Validator)
        {
            _repDoctor = repDoctor;
            _repType = repType;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {

            BaseResponse response = new BaseResponse();

            // چک کردن نوع دکتر
            if (!Utilities.Utilities.CheckTypeDoctor(request.Doctor.TypeDoctorId))
            {
                response.Message = ErrorResource.TypeDoctorCheck;
                response.IsSuccess = false;
                return response;
            }

            if (!Utilities.Utilities.CheckGender(request.Doctor.Gender))
            {
                response.Message = ErrorResource.GenderCheck;
                response.IsSuccess = false;
                return response;
            }

            // بدست آوردن id نوع دکتر
            Expression<Func<CodeChallenge.Core.Entities.BasicInfo.DoctorType, bool>> Filter = (x =>
            (x.Type == (EnumDoctorType)request.Doctor.TypeDoctorId ));
            var TypeId = await _repType.FindIdByFilter(Filter);
            if (TypeId == null)
            {
                response.Message = ErrorResource.TypeDoctorCheck;
                response.IsSuccess = false;
                return response;
            }
            else
            {
                request.Doctor.TypeDoctorId = TypeId.Id;
            }

            request.Doctor.DateCreated = DateTime.Now;
            var validateReault = await _Validator.ValidateAsync(request.Doctor);

            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {

                var tmpDoctor = _mapper.Map<CodeChallenge.Core.Entities.Doctor>(request.Doctor);

                // چک کردن تکراری بودن کد ملی
                Expression<Func<CodeChallenge.Core.Entities.Doctor, bool>> NationalCodeFilter = x => 
                x.NationalCode == request.Doctor.NationalCode;
                if (await _repDoctor.ExistFilter(NationalCodeFilter))
                {
                    response.Message = ErrorResource.NationalCodeEarlyExist;
                    response.IsSuccess = false;
                    return response;
                }

                // چک کردن تکراری بودن ایمیل
                Expression<Func<CodeChallenge.Core.Entities.Doctor, bool>> EmailFilter = x =>
                x.EmailAddress == request.Doctor.EmailAddress;
                if (await _repDoctor.ExistFilter(EmailFilter))
                {
                    response.Message = ErrorResource.EmailEarlyExist;
                    response.IsSuccess = false;
                    return response;
                }

                Expression<Func<CodeChallenge.Core.Entities.Doctor, bool>> queryFilter = (x =>
                (x.FirstName == tmpDoctor.FirstName && x.LastName == tmpDoctor.LastName) ||
                x.NationalCode == tmpDoctor.NationalCode || x.EmailAddress == tmpDoctor.EmailAddress);
                var create = await _repDoctor.CreateAsync(tmpDoctor, queryFilter);

                if (create.Id != 0)
                {
                    response.Id = tmpDoctor.Id;
                    response.Message = ErrorResource.CreateSuccess;
                    response.IsSuccess = true;
                    response.CodeStatus = 200;
                }
                else
                {
                    response.Message = ErrorResource.CreateNotSuccess;
                    response.IsSuccess = false;
                }
            }

            return response;
        }
    }
}
