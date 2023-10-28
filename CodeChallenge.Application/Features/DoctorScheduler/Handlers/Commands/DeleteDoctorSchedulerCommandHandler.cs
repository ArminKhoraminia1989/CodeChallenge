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
    public class DeleteDoctorSchedulerCommandHandler : IRequestHandler<DeleteDoctorSchedulerCommand, BaseResponse>
    {
        private readonly IDoctorSchedulerRepository _repDoctorScheduler;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteDoctorSchedulerDto> _Validator;
        public DeleteDoctorSchedulerCommandHandler(IMapper mapper,
            IDoctorSchedulerRepository repDoctorScheduler,
            IValidator<DeleteDoctorSchedulerDto> Validator)
        {
            _repDoctorScheduler = repDoctorScheduler;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(DeleteDoctorSchedulerCommand request, CancellationToken cancellationToken)
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

            var DeleteResponse = await _repDoctorScheduler.DeleteAsync(request.DoctorScheduler.Id);

            return DeleteResponse;

        }
    }
}
