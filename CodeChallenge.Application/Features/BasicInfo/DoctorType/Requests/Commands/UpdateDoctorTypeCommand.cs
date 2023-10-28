using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands
{
    public class UpdateDoctorTypeCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateDoctorTypeDto DoctorType { get; set; }
    }
}
