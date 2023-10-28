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
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, BaseResponse>
    {
        private readonly IPatientRepository _repPatient;
        private readonly IMapper _mapper;
        private readonly IValidator<DeletePatientDto> _Validator;
        public DeletePatientCommandHandler(IMapper mapper,
            IPatientRepository repPatient,
            IValidator<DeletePatientDto> Validator)
        {
            _repPatient = repPatient;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {

            var validateReault = await _Validator.ValidateAsync(request.Patient);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            response = await _repPatient.DeleteAsync(request.Patient.Id);

            return response;

        }
    }
}
