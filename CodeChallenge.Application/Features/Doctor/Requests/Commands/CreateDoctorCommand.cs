using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Requests.Commands
{
    public class CreateDoctorCommand : IRequest<BaseResponse>
    {
        public CreateDoctorDto Doctor { get; set; }
    }
}
