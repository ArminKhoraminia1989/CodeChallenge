using AutoMapper;
using CodeChallenge.Application.Features.Patient.Requests.Commands;
using CodeChallenge.Application.Repository;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Patient;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Handlers.Commands
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, BaseResponse>
    {
        private readonly IPatientRepository _repPatient;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatePatientDto> _Validator;
        public CreatePatientCommandHandler(IMapper mapper,
            IPatientRepository repPatient,
            IValidator<CreatePatientDto> Validator)
        {
            _repPatient = repPatient;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            request.Patient.DateCreated = DateTime.Now;
            var validateReault = await _Validator.ValidateAsync(request.Patient);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpPatient = _mapper.Map<CodeChallenge.Core.Entities.Patient>(request.Patient);
            response = await _repPatient.CreateAsync(tmpPatient);

            return response;

        }
    }
}
