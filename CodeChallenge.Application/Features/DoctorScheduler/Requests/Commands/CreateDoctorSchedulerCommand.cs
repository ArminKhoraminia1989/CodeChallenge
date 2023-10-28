using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Requests.Commands
{
    public class CreateDoctorSchedulerCommand : IRequest<BaseResponse>
    {
        public CreateDoctorSchedulerDto DoctorScheduler { get; set; }
    }
}
