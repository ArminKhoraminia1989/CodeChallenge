using AutoMapper;
using CodeChallenge.Application.Repository.BasicInfo;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;
using MediatR;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands;
using CodeChallenge.Application.Resources;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Handlers.Commands
{
    public class CreateDoctorTypeCommandHandler : IRequestHandler<CreateDoctorTypeCommand, BaseResponse>
    {
        private readonly IDoctorTypeRepository _repDoctorType;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDoctorTypeDto> _Validator;
        public CreateDoctorTypeCommandHandler(IMapper mapper,
            IDoctorTypeRepository repDoctorType,
            IValidator<CreateDoctorTypeDto> Validator)
        {
            _repDoctorType = repDoctorType;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(CreateDoctorTypeCommand request, CancellationToken cancellationToken)
        {

            request.DoctorType.DateCreated = DateTime.Now;
            var validateReault = await _Validator.ValidateAsync(request.DoctorType);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tmpDoctorType = _mapper.Map<Core.Entities.BasicInfo.DoctorType>(request.DoctorType);
                response = await _repDoctorType.CheckData(tmpDoctorType, "Create");
            }

            return response;
        }
    }
}
