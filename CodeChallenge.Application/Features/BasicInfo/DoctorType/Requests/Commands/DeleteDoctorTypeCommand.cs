using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands
{
    public class DeleteDoctorTypeCommand : IRequest<BaseResponse>
    {
        public DeleteDoctorTypeDto DoctorType { get; set; }
    }
}
