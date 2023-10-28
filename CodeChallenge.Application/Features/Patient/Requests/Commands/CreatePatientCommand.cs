using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Requests.Commands
{
    public class CreatePatientCommand : IRequest<BaseResponse>
    {
        public CreatePatientDto Patient { get; set; }
    }
}
