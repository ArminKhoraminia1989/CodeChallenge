using AutoMapper;
using CodeChallenge.Application.Features.DoctorScheduler.Requests.Commands;
using CodeChallenge.Application.Repository;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.DoctorScheduler;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Handlers.Commands
{
    public class UpdateDoctorSchedulerCommandHandler : IRequestHandler<UpdateDoctorSchedulerCommand, BaseResponse>
    {
        private readonly IDoctorSchedulerRepository _repDoctorScheduler;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateDoctorSchedulerDto> _Validator;
        public UpdateDoctorSchedulerCommandHandler(IMapper mapper,
            IDoctorSchedulerRepository repDoctorScheduler,
            IValidator<UpdateDoctorSchedulerDto> Validator)
        {
            _repDoctorScheduler = repDoctorScheduler;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(UpdateDoctorSchedulerCommand request, CancellationToken cancellationToken)
        {

            var validateReault = await _Validator.ValidateAsync(request.DoctorScheduler);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpDoctorScheduler = _mapper.Map<CodeChallenge.Core.Entities.DoctorScheduler>(request.DoctorScheduler);
            var UpdateResponse = await _repDoctorScheduler.UpdateAsync(tmpDoctorScheduler);

            return UpdateResponse;

        }
    }
}
