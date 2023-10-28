using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Commands
{
    public class CreateAppointmentCommand : IRequest<BaseResponse>
    {
        public CreateAppointmentDto Appointment { get; set; }
    }
}
