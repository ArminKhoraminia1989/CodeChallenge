using CodeChallenge.Application.Responses;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Requests.Commands
{
    public class SetAppointmentCommand : IRequest<BaseResponse>
    {
        public int Doctor { get; set; }
        public int Patient { get; set; }
        public int DurationonMinutes { get; set; }
        public DateTime StartDateTime { get; set; }
    }
}
