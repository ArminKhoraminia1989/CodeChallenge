using AutoMapper;
using CodeChallenge.Application.Features.Appointment.Requests.Commands;
using CodeChallenge.Application.Repository;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Appointment;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Handlers.Commands
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, BaseResponse>
    {
        private readonly IAppointmentRepository _repAppointment;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateAppointmentDto> _Validator;
        public UpdateAppointmentCommandHandler(IMapper mapper,
            IAppointmentRepository repAppointment,
            IValidator<UpdateAppointmentDto> Validator)
        {
            _repAppointment = repAppointment;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {

            var validateReault = await _Validator.ValidateAsync(request.Appointment);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpAppointment = _mapper.Map<CodeChallenge.Core.Entities.Appointment>(request.Appointment);
            var UpdateResponse = await _repAppointment.UpdateAsync(tmpAppointment);

            return UpdateResponse;

        }
    }
}
