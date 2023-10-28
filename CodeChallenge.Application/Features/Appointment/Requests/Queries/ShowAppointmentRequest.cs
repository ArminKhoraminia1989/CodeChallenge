using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Queries
{
    public class ShowAppointmentRequest : IRequest<ShowAppointmentDto>
    {
        public int Id { get; set; }
    }
}
