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
    public class SetEarliestAppointmentCommandHandler : IRequestHandler<SetEarliestAppointmentCommand, BaseResponse>
    {
        private readonly IAppointmentRepository _repAppointment;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAppointmentDto> _Validator;
        public SetEarliestAppointmentCommandHandler(IMapper mapper,
            IAppointmentRepository repAppointment,
            IValidator<CreateAppointmentDto> Validator)
        {
            _repAppointment = repAppointment;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(SetEarliestAppointmentCommand request, CancellationToken cancellationToken)
        {
            var TempDateStart = await _repAppointment.SetEarliest(request.Doctor, request.Patient, request.DurationonMinutes);

            BaseResponse response = new BaseResponse();

            if (!TempDateStart.Item2)
            {
                response.Message = ErrorResource.DoesNotExistTimeForAppointment;
                response.IsSuccess = false;
                return response;
            }


            CreateAppointmentDto Appointment = new CreateAppointmentDto();
            Appointment.DateCreated = DateTime.UtcNow;
            Appointment.PatientId = request.Patient;
            Appointment.DoctorId = request.Doctor;
            Appointment.StartTime = TempDateStart.Item1;
            Appointment.EndTime = TempDateStart.Item1.AddMinutes(request.DurationonMinutes);
            Appointment.DurationTime = request.DurationonMinutes;

            var validateReault = await _Validator.ValidateAsync(Appointment);
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpAppointment = _mapper.Map<CodeChallenge.Core.Entities.Appointment>(Appointment);

            return await _repAppointment.CreateAsync(tmpAppointment);

        }
    }
}
