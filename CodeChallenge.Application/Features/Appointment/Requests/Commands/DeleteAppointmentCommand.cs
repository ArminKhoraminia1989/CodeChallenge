using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Commands
{
    public class DeleteAppointmentCommand : IRequest<BaseResponse>
    {
        public DeleteAppointmentDto Appointment { get; set; }
    }
}
