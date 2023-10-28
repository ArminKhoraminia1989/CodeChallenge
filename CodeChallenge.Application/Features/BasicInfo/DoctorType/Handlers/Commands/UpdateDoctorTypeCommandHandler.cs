using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands;
using CodeChallenge.Application.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Handlers.Commands
{
    public class UpdateDoctorTypeCommandHandler : IRequestHandler<UpdateDoctorTypeCommand, BaseResponse>
    {
        private readonly IDoctorTypeRepository _repDoctorType;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateDoctorTypeDto> _Validator;
        public UpdateDoctorTypeCommandHandler(IMapper mapper,
            IDoctorTypeRepository repDoctorType,
            IValidator<UpdateDoctorTypeDto> Validator)
        {
            _repDoctorType = repDoctorType;
            _mapper = mapper;
            _Validator = Validator;
        }
        public async Task<BaseResponse> Handle(UpdateDoctorTypeCommand request, CancellationToken cancellationToken)
        {
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
                response = await _repDoctorType.CheckData(tmpDoctorType, "Update");
            }

            return response;
        }
    }
}
