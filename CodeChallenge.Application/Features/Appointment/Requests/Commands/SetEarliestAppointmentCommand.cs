using CodeChallenge.Application.Responses;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Commands
{
    public class SetEarliestAppointmentCommand : IRequest<BaseResponse>
    {
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public int DurationonMinutes { get; set; }
    }
}
