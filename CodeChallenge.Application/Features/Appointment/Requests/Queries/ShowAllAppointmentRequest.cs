using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Queries
{
    public class ShowAllAppointmentRequest : IRequest<ShowAllAppointmentDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
