using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Commands
{
    public class UpdateAppointmentCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateAppointmentDto Appointment { get; set; }
    }
}
