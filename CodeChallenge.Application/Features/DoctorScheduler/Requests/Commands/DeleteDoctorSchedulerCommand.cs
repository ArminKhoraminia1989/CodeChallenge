using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Requests.Commands
{
    public class DeleteDoctorSchedulerCommand : IRequest<BaseResponse>
    {
        public DeleteDoctorSchedulerDto DoctorScheduler { get; set; }
    }
}
