using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Requests.Commands
{
    public class UpdateDoctorSchedulerCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateDoctorSchedulerDto DoctorScheduler { get; set; }
    }
}
