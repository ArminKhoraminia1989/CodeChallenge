using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Requests.Commands
{
    public class UpdateDoctorCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateDoctorDto Doctor { get; set; }
    }
}
