using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Requests.Queries
{
    public class ShowAllDoctorSchedulerRequest : IRequest<ShowAllDoctorSchedulerDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
