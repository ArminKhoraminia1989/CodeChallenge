using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Requests.Commands
{
    public class DeleteDoctorCommand : IRequest<BaseResponse>
    {
        public DeleteDoctorDto Doctor { get; set; }
    }
}
