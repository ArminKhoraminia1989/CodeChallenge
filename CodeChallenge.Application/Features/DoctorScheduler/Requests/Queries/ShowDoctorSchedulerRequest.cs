using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Requests.Queries
{
    public class ShowDoctorSchedulerRequest : IRequest<ShowDoctorSchedulerDto>
    {
        public int Id { get; set; }
    }
}
