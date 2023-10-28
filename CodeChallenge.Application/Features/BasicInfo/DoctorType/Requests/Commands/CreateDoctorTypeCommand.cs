using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands
{
    public class CreateDoctorTypeCommand : IRequest<BaseResponse>
    {
        public CreateDoctorTypeDto DoctorType { get; set; }
    }
}
